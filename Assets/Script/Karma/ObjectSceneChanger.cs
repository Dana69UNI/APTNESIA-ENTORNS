using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            int karma = KarmaManager.Instance.GetKarma();

            if (karma <= -10)
            {
                SceneManager.LoadScene(1); // Escena distópica
            }
            else if (karma >= 10)
            {
                SceneManager.LoadScene(0); // Escena utópica
            }
            else
            {
                SceneManager.LoadScene(0); // Escena normal
            }
    }
}
