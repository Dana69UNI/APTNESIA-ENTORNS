using UnityEngine;
using System;
using System.Collections;
using FMOD.Studio;
using FMODUnity;

public class CarlosAI2 : MonoBehaviour
{
    private Transform character;         // Referencia al jugador
    public float moveSpeed = 2f;        // Velocidad de movimiento
    public float hideDistance = 1f;     // Distancia mínima para detenerse
    public float retreatSpeed = 3f;     // Velocidad al alejarse
    public float retreatDistance = 5f; // Distancia a la que se aleja cuando observado
    public float hidingSpotRadius = 10f; // Radio para buscar escondites
    public LayerMask hidingSpotLayer;   // Capa de los escondites
    private Rigidbody rb;

    private bool isBeingWatched = false;
    private bool isNormalSoundPlaying = false;
    private bool isAgitatedSoundPlaying = false;
    private Transform currentHidingSpot;

    public GameObject key;               // Referencia a la llave
    private Transform apple;             // Referencia a la manzana
    private bool hasApple = false;       // Indica si Carlos tiene la manzana

    [SerializeField] private EventInstance respiracionSFX;
    [SerializeField] private EventInstance respiracionAgitadaSFX;

    private void Start()
    {
        respiracionSFX = AudioManager.Instance.CreateEventInstanceCarlos(FMODEvents.instance.Respira);
        respiracionAgitadaSFX = AudioManager.Instance.CreateEventInstanceCarlos(FMODEvents.instance.RespiraAgit);
        rb = GetComponent<Rigidbody>();
        character = GameObject.Find("Character").transform;

        if (key != null) key.SetActive(false); // Asegúrate de que la llave esté desactivada al inicio
    }

    void Update()
    {
        HandleInverseGravity();
        UpdateSound();

        if (hasApple)
        {
            // Si ya tiene la manzana, se queda quieto
            return;
        }

        if (apple == null)
        {
            // Buscar la manzana en el rango utilizando el tag "Apple"
            FindApple();
        }

        if (apple != null)
        {
            MoveTowardsApple(); // Moverse hacia la manzana
        }
        else
        {
            // Comportamiento normal de Carlos
            if (isBeingWatched)
            {
                HideOrRetreat(); // Carlos busca esconderse o se aleja
            }
            else
            {
                MoveTowardsCharacter(); // Carlos se mueve hacia el jugador
            }
        }
    }

    private void HandleInverseGravity()
    {
        rb.AddForce(new Vector3(0, 9.81f, 0), ForceMode.Impulse);
    }

    // Método para mover a Carlos hacia el jugador
    private void MoveTowardsCharacter()
    {
        Vector3 direction = (character.position - transform.position).normalized;

        if (Vector3.Distance(character.position, transform.position) > hideDistance)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    // Método para buscar la manzana
    private void FindApple()
    {
        Collider[] itemsInRange = Physics.OverlapSphere(transform.position, hidingSpotRadius);

        foreach (Collider item in itemsInRange)
        {
            if (item.CompareTag("Apple"))
            {
                apple = item.transform;
                break;
            }
        }
    }

    // Método para moverse hacia la manzana
    private void MoveTowardsApple()
    {
        Vector3 direction = (apple.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Si Carlos alcanza la manzana
        if (Vector3.Distance(transform.position, apple.position) < 1f)
        {
            PickUpApple();
        }
    }

    // Método para recoger la manzana
    private void PickUpApple()
    {
        hasApple = true;

        if (apple != null)
        {
            Destroy(apple.gameObject); // Elimina la manzana
        }

        if (key != null)
        {
            key.SetActive(true); // Activa la llave
        }

        Debug.Log("Carlos ha recogido la manzana y ha activado la llave.");
    }

    // Método para buscar esconderse o alejarse
    private void HideOrRetreat()
    {
        if (currentHidingSpot == null)
        {
            Collider[] hidingSpots = Physics.OverlapSphere(transform.position, hidingSpotRadius, hidingSpotLayer);

            if (hidingSpots.Length > 0)
            {
                Transform closestSpot = null;
                float closestDistance = Mathf.Infinity;

                foreach (Collider spot in hidingSpots)
                {
                    float distance = Vector3.Distance(transform.position, spot.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestSpot = spot.transform;
                    }
                }

                currentHidingSpot = closestSpot;
            }
        }

        if (currentHidingSpot != null)
        {
            Vector3 direction = (currentHidingSpot.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, currentHidingSpot.position) < hideDistance)
            {
                currentHidingSpot = null;
            }
        }
        else
        {
            RetreatFromPlayer();
        }
    }

    // Método para alejarse del jugador
    private void RetreatFromPlayer()
    {
        Vector3 direction = (transform.position - character.position).normalized;

        if (Vector3.Distance(character.position, transform.position) < retreatDistance)
        {
            transform.position += direction * retreatSpeed * Time.deltaTime;
        }
    }

    public void SetBeingWatched(bool watched)
    {
        isBeingWatched = watched;
    }

    private void UpdateSound()
    {
        PLAYBACK_STATE playbackStateNormal;
        PLAYBACK_STATE playbackStateAgitada;

        // Obtener los estados de reproducción de ambos sonidos
        respiracionSFX.getPlaybackState(out playbackStateNormal);
        respiracionAgitadaSFX.getPlaybackState(out playbackStateAgitada);

        //Debug.Log("Playback State Normal: " + playbackStateNormal);
        //Debug.Log("Playback State Agitada: " + playbackStateAgitada);

        // Si está siendo observado, reproducir respiración agitada
        if (isBeingWatched)
        {
            // Si el sonido agitado no está en reproducción, iniciar reproducción
            if (playbackStateAgitada == PLAYBACK_STATE.STOPPED && !isAgitatedSoundPlaying)
            {
                //Debug.Log("Starting agitated breathing...");
                respiracionAgitadaSFX.start();
                isAgitatedSoundPlaying = true;  // Marca que la respiración agitada está en reproducción
            }

            // Detener la respiración normal si está sonando
            if (playbackStateNormal != PLAYBACK_STATE.STOPPED && isNormalSoundPlaying)
            {
                StopNormalBreathing();
            }
        }
        else
        {
            // Si no está siendo observado, reproducir respiración normal
            if (playbackStateNormal == PLAYBACK_STATE.STOPPED && !isNormalSoundPlaying)
            {
                //Debug.Log("Starting normal breathing...");
                respiracionSFX.start();
                isNormalSoundPlaying = true;  // Marca que la respiración normal está en reproducción
            }

            // Detener la respiración agitada si está sonando
            if (playbackStateAgitada != PLAYBACK_STATE.STOPPED && isAgitatedSoundPlaying)
            {
                StopAgitatedBreathing();
            }
        }
    }

    private void StopNormalBreathing()
    {
        if (respiracionSFX.isValid() && isNormalSoundPlaying)
        {
            //Debug.Log("Stopping normal breathing...");
            respiracionSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            isNormalSoundPlaying = false;  // Marca que la respiración normal se detuvo
        }
    }

    private void StopAgitatedBreathing()
    {
        if (respiracionAgitadaSFX.isValid() && isAgitatedSoundPlaying)
        {
            //    Debug.Log("Stopping agitated breathing...");
            respiracionAgitadaSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            isAgitatedSoundPlaying = false;  // Marca que la respiración agitada se detuvo
        }
    }
}
