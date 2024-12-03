using System.Collections;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;  // Para acceder a FMOD

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;  // Instancia única (Singleton)

    [Header("FMOD Event References")]


    public Transform playerTrans;
    private Vector3 playerPos;
    private FMOD.Studio.EventInstance musicInstance;  // Instancia para la música
    private FMOD.Studio.EventInstance sfxInstance;    // Instancia para SFX

    void Awake()
    {
        // Singleton: asegura que haya solo una instancia de AudioManager
        if (Instance == null)
        {
            Instance = this;
             // No destruir el AudioManager al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {


    }
  

    public void PlaySFX(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(playerTrans));
        return eventInstance;
    }
}