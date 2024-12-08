using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    public static KarmaManager Instance; // Singleton para acceso global

    private int karmaPoints = 0;

    private void Awake()
    {
        // Configurar el Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // M�todo para agregar karma positivo
    public void AddKarma(int points)
    {
        karmaPoints += points;
        Debug.Log($"Karma aumentado: {karmaPoints}");
    }

    // M�todo para quitar karma negativo
    public void RemoveKarma(int points)
    {
        karmaPoints -= points;
        Debug.Log($"Karma disminuido: {karmaPoints}");
    }

    // M�todo para obtener el karma actual
    public int GetKarma()
    {
        return karmaPoints;
    }
}
