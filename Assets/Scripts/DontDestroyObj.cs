using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObj : MonoBehaviour
{
    public static bool m_isCreated = false;
    AudioSource m_audio;
    DataHandler m_data;

    //check if the file is created to avoid duplicates
    private void Awake()
    {
       // MoveToMainScene();
    }
    private void Start()
    {
        if (!m_isCreated)
        {     
            m_audio = GetComponent<AudioSource>();
            DontDestroyOnLoad(this.gameObject);
            m_data = GetComponentInChildren<DataHandler>();
            m_data.m_onStatusChanged += StopMusic;
            m_isCreated = true;
        }

        else
        {
            Destroy(this.gameObject);
        }

    }

    //void MoveToMainScene()
    //{
    //    Scene sceneDestination = SceneManager.GetSceneByName("Main");
    //    SceneManager.MoveGameObjectToScene(gameObject, sceneDestination);
    //    SceneManager.SetActiveScene(sceneDestination);
    //}

    void StopMusic()
    {
        m_audio.Stop();
    }

}
