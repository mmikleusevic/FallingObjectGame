using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene Instance { get; private set; }

    public int SceneToLoadIndex {  get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void LoadLoadingScene(int sceneToLoadIndex)
    {
        SceneToLoadIndex = sceneToLoadIndex;
        SceneManager.LoadScene(1);
    }
}