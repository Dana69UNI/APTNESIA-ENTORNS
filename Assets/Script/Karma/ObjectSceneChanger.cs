using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int karma = KarmaManager.Instance.GetKarma();
        Scene currentScene = SceneManager.GetActiveScene();

        int currentSceneIndex = currentScene.buildIndex;

        if (karma < -10)
        {
            // Cargar escena de un número superior si no es 3
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex < 3)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                SceneManager.LoadScene(currentSceneIndex);
            }
        }
        else if (karma > 10)
        {
            // Cargar escena de un número inferior si no es -1
            int previousSceneIndex = currentSceneIndex - 1;
            if (previousSceneIndex > -1)
            {
                SceneManager.LoadScene(previousSceneIndex);
            }
            else
            {
                SceneManager.LoadScene(currentSceneIndex);
            }
        }
    }
}
