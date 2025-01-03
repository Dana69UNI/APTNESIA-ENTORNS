using UnityEngine;
using System;
using System.Collections;
using FMOD.Studio;
using FMODUnity;




public class CarlosAI : MonoBehaviour
{
    private Transform character;         // Referencia al jugador
    public float moveSpeed = 2f;        // Velocidad de movimiento
    public float hideDistance = 1f;     // Distancia m�nima para detenerse
    public float retreatSpeed = 3f;     // Velocidad al alejarse
    public float retreatDistance = 5f; // Distancia a la que se aleja cuando observado
    public float hidingSpotRadius = 10f; // Radio para buscar escondites
    public LayerMask hidingSpotLayer;   // Capa de los escondites
    private Rigidbody rb;

    private bool isBeingWatched = false;
    private bool isNormalSoundPlaying = false;  
    private bool isAgitatedSoundPlaying = false;  
    private Transform currentHidingSpot;

   
    [SerializeField] private EventInstance respiracionSFX;
    [SerializeField] private EventInstance respiracionAgitadaSFX;

    private void Start()
    {
        respiracionSFX = AudioManager.Instance.CreateEventInstanceCarlos(FMODEvents.instance.Respira);
        respiracionAgitadaSFX = AudioManager.Instance.CreateEventInstanceCarlos(FMODEvents.instance.RespiraAgit);
        rb = GetComponent<Rigidbody>();
        character = GameObject.Find("Character").transform;
    }

    void Update()
    {
        SearchApple();
        HandleInverseGravity();
        UpdateSound();
        if (isBeingWatched)
        {
            HideOrRetreat(); // Carlos busca esconderse o se aleja
        }
        else
        {
            MoveTowardsCharacter(); // Carlos se mueve hacia el jugador
        }
    }

    private void HandleInverseGravity()
    {
        rb.AddForce(new Vector3(0,9.81f,0), ForceMode.Impulse);
    }

    // M�todo para mover a Carlos hacia el jugador
    private void MoveTowardsCharacter()
    {
        Vector3 direction = (character.position - transform.position).normalized;

        

        if (Vector3.Distance(character.position, transform.position) > hideDistance)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

    }

    // M�todo para buscar esconderse o alejarse
    private void HideOrRetreat()
    {
        // Si no tiene un escondite actual, busca uno cercano
        if (currentHidingSpot == null)
        {
            Collider[] hidingSpots = Physics.OverlapSphere(transform.position, hidingSpotRadius, hidingSpotLayer); //Physics.OverlapSphere es lo que utilizamos para detectar escondites cercanos a Carlos

            if (hidingSpots.Length > 0)
            {
                // Encuentra el escondite m�s cercano
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
        
        // Moverse hacia el escondite si existe
        if (currentHidingSpot != null)
        {
            Vector3 direction = (currentHidingSpot.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
           
            // Si ya est� cerca del escondite, detenerse
            if (Vector3.Distance(transform.position, currentHidingSpot.position) < hideDistance)
            {
                currentHidingSpot = null; // Reinicia el escondite para la pr�xima vez
            }
        }
        else
        {
            // Si no encuentra escondite, se aleja del jugador
            RetreatFromPlayer();
        }
    }

    // M�todo para alejar a Carlos cuando no hay escondites
    private void RetreatFromPlayer()
    {
        Vector3 direction = (transform.position - character.position).normalized;

        if (Vector3.Distance(character.position, transform.position) < retreatDistance)
        {
            transform.position += direction * retreatSpeed * Time.deltaTime;
        }
    }

    // M�todo para notificar si Carlos est� siendo observado
    public void SetBeingWatched(bool watched)
    {
        isBeingWatched = watched;
    }



    private void UpdateSound()
    {
        PLAYBACK_STATE playbackStateNormal;
        PLAYBACK_STATE playbackStateAgitada;

        // Obtener los estados de reproducci�n de ambos sonidos
        respiracionSFX.getPlaybackState(out playbackStateNormal);
        respiracionAgitadaSFX.getPlaybackState(out playbackStateAgitada);

        //Debug.Log("Playback State Normal: " + playbackStateNormal);
        //Debug.Log("Playback State Agitada: " + playbackStateAgitada);

        // Si est� siendo observado, reproducir respiraci�n agitada
        if (isBeingWatched)
        {
            // Si el sonido agitado no est� en reproducci�n, iniciar reproducci�n
            if (playbackStateAgitada == PLAYBACK_STATE.STOPPED && !isAgitatedSoundPlaying)
            {
                //Debug.Log("Starting agitated breathing...");
                respiracionAgitadaSFX.start();
                isAgitatedSoundPlaying = true;  // Marca que la respiraci�n agitada est� en reproducci�n
            }

            // Detener la respiraci�n normal si est� sonando
            if (playbackStateNormal != PLAYBACK_STATE.STOPPED && isNormalSoundPlaying)
            {
                StopNormalBreathing();
            }
        }
        else
        {
            // Si no est� siendo observado, reproducir respiraci�n normal
            if (playbackStateNormal == PLAYBACK_STATE.STOPPED && !isNormalSoundPlaying)
            {
                //Debug.Log("Starting normal breathing...");
                respiracionSFX.start();
                isNormalSoundPlaying = true;  // Marca que la respiraci�n normal est� en reproducci�n
            }

            // Detener la respiraci�n agitada si est� sonando
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
            isNormalSoundPlaying = false;  // Marca que la respiraci�n normal se detuvo
        }
    }

    private void StopAgitatedBreathing()
    {
        if (respiracionAgitadaSFX.isValid() && isAgitatedSoundPlaying)
        {
        //    Debug.Log("Stopping agitated breathing...");
            respiracionAgitadaSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            isAgitatedSoundPlaying = false;  // Marca que la respiraci�n agitada se detuvo
        }
    }

    private void SearchApple()
    {

    }
}

