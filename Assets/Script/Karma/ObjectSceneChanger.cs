using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSceneChanger : MonoBehaviour
{
    KarmaManager karmaManager;
    int karma;
    int currentSceneIndex;

    private void Awake()
    {
        karmaManager = GameObject.Find("KarmaManager").GetComponent<KarmaManager>();
        karma = karmaManager.GetKarma();
        Scene currentScene = SceneManager.GetActiveScene();
        int currentSceneIndex = currentScene.buildIndex;
        Debug.Log(currentSceneIndex);

    }
    private void OnTriggerEnter(Collider other)
    {

        if (karma <= 0)
        {
            // Cargar escena de un número superior si no es 3
            int nextSceneIndex = currentSceneIndex + 1;
            Debug.Log("Laseguent");
            Debug.Log(nextSceneIndex);
            if (nextSceneIndex < 3)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                SceneManager.LoadScene(currentSceneIndex);
            }
        }
        else
        {
            // Cargar escena de un número inferior si no es -1
            int previousSceneIndex = currentSceneIndex - 1;
            Debug.Log("Laseguent");
            Debug.Log(previousSceneIndex);
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
