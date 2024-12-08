using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            int karma = KarmaManager.Instance.GetKarma();

            if (karma <= -10)
            {
                SceneManager.LoadScene(1); // Escena dist�pica
            }
            else if (karma >= 10)
            {
                SceneManager.LoadScene(0); // Escena ut�pica
            }
            else
            {
                SceneManager.LoadScene(0); // Escena normal
            }
    }
}
