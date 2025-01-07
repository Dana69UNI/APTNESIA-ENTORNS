using UnityEngine;

public class CarlosAI : MonoBehaviour
{
    public Transform character;         // Referencia al jugador
    public float moveSpeed = 2f;        // Velocidad de movimiento
    public float hideDistance = 1f;     // Distancia m�nima para detenerse
    public float retreatSpeed = 3f;     // Velocidad al alejarse
    public float retreatDistance = 5f;  // Distancia a la que se aleja cuando observado
    public float hidingSpotRadius = 10f; // Radio para buscar escondites
    public LayerMask hidingSpotLayer;   // Capa de los escondites

    private bool isBeingWatched = false;
    private Transform currentHidingSpot;

    private void Start()
    {
        // Buscar autom�ticamente al jugador si no est� asignado
        if (character == null)
        {
            FindPlayer();
        }
    }

    private void Update()
    {
        // Revalidar la referencia al jugador si se pierde
        if (character == null)
        {
            FindPlayer();
        }

        if (isBeingWatched)
        {
            HideOrRetreat(); // Carlos busca esconderse o se aleja
        }
        else
        {
            MoveTowardsCharacter(); // Carlos se mueve hacia el jugador
        }
    }

    // M�todo para mover a Carlos hacia el jugador
    private void MoveTowardsCharacter()
    {
        if (character == null) return;

        Vector3 direction = (character.position - transform.position).normalized;

        if (Vector3.Distance(character.position, transform.position) > hideDistance)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    // M�todo para buscar esconderse o alejarse
    private void HideOrRetreat()
    {
        if (character == null) return;

        // Si no tiene un escondite actual, busca uno cercano
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

    // M�todo para alejar a Carlos cuando no hay escondites
    private void RetreatFromPlayer()
    {
        if (character == null) return;

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

    // M�todo para buscar al jugador autom�ticamente
    private void FindPlayer()
    {
        GameObject playerObject = GameObject.Find("Character");
        if (playerObject != null)
        {
            character = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("No se encontr� un objeto llamado 'Character'. Aseg�rate de que el jugador est� en la escena.");
        }
    }
}
