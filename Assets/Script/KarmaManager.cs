using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    public int karmaPoints = 0; // Puntos de karma iniciales

    // Método para agregar karma positivo
    public void AddKarma(int amount)
    {
        karmaPoints += amount;
        Debug.Log("Puntos de karma: " + karmaPoints);
    }

    // Método para reducir karma (si implementas acciones negativas en el futuro)
    public void SubtractKarma(int amount)
    {
        karmaPoints -= amount;
        Debug.Log("Puntos de karma: " + karmaPoints);
    }
}