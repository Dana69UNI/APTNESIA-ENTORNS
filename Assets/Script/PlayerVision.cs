using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    public float maxViewDistance = 10f; // Distancia máxima para detectar
    public LayerMask enemyLayer;       // Capa para detectar solo enemigos

    void Update()
    {
        CheckVision();
    }

    private void CheckVision()
    {
        Ray ray = new Ray(transform.position, transform.forward); // Rayo desde la cámara hacia adelante
        RaycastHit hit;

        // Verifica si el rayo golpea algo en la capa de enemigos
        if (Physics.Raycast(ray, out hit, maxViewDistance, enemyLayer))
        {
            // Si golpea a Carlos, lo marca como observado
            CarlosAI carlos = hit.collider.GetComponent<CarlosAI>();
            if (carlos != null)
            {
                carlos.SetBeingWatched(true);
                return;
            }
        }

        // Si no golpea a Carlos, asegúrate de notificarle que ya no está siendo observado
        CarlosAI[] allEnemies = FindObjectsOfType<CarlosAI>();
        foreach (var enemy in allEnemies)
        {
            enemy.SetBeingWatched(false);
        }
    }
}

