using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    public static KarmaManager Instance; // Singleton para acceso global (sinceramente aun no tengo muy claro que es) necesito invertigar mas, solo se que con esto funciona

    private int karmaPoints = 0;

    private void Awake()
    {
        // Configurar el Singleton (sinceramente aun no tengo muy claro que es) necesito invertigar mas, solo se que con esto funciona
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para agregar karma positivo
    public void AddKarma(int points)
    {
        karmaPoints += points;
        Debug.Log($"Karma aumentado: {karmaPoints}");
    }

    // Método para quitar karma negativo
    public void RemoveKarma(int points)
    {
        karmaPoints -= points;
        Debug.Log($"Karma disminuido: {karmaPoints}");
    }

    // Método para obtener el karma actual
    public int GetKarma()
    {
        return karmaPoints;
    }
}
