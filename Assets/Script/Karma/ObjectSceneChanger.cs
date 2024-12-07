using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSceneChanger : MonoBehaviour
{
    public string casa1SceneName = "casa1";
    public string casa2SceneName = "casa2";
    public string casa3SceneName = "casa3";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Detecta si el jugador toca el objeto
        {
            int karma = KarmaManager.Instance.GetKarma();

            if (karma <= -10)
            {
                SceneManager.LoadScene(casa3SceneName); // Escena distópica
            }
            else if (karma >= 10)
            {
                SceneManager.LoadScene(casa2SceneName); // Escena utópica
            }
            else
            {
                SceneManager.LoadScene(casa1SceneName); // Escena normal
            }
        }
    }
}
