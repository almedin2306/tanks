using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackgroundMusicController : MonoBehaviour
{
    private static BackgroundMusicController instance = null;
    public string targetSceneName;  // Assign the name of the scene where the music should play in the inspector

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusicIfInTargetScene();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicIfInTargetScene();
    }

    void PlayMusicIfInTargetScene()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == targetSceneName)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else
        {
            if (audio.isPlaying)
            {
                audio.Stop();
            }
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
