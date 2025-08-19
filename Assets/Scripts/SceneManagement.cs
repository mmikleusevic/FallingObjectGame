using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI progressText;
    
    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        progressBar.fillAmount = 0;
        progressText.text = "0%";
        
        yield return null;
        
        int sceneToLoad = LoadingScene.Instance.SceneToLoadIndex;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            progressText.text = (asyncOperation.progress * 100f) + "%";
            progressBar.fillAmount = progress;
            yield return null;
        }

        progressBar.fillAmount = 1;
        progressText.text = "100%";
    }
}
