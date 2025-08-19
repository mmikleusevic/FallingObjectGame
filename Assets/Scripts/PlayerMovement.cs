using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private int livesMax;
    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;

    private int score;
    private int increaseLivesCounter = 0;
    private int lives;
    private bool isPaused;
    private IEnumerator coroutine;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        
        PlayGame();
    }

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = Vector3.zero;
        
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.right);
        }
    }

    private void Update()
    {
        float positionX = transform.position.x;
        if (transform.position.x > 11)
        {
            positionX = 11;
        }
        else if (transform.position.x < -11)
        {
            positionX = -11;
        }

        transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
        
        if (Input.GetKey(KeyCode.A))
        {
            if (Mathf.Approximately(transform.rotation.eulerAngles.y, 0)) return;
            
            Rotate(0, new Vector3(0, 180, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Mathf.Approximately(transform.rotation.eulerAngles.y, 180f)) return;
            
            Rotate(180, new Vector3(0, -180, 0));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    
    private void Pause()
    {
        if (isPaused)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        isPaused = !isPaused;
    }
    
    public void SetScore(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = $"Score: {score.ToString()}";

        if (scoreAmount > 0)
        {
            CanIncreaseLives();
        }
        else
        {
            ReduceLives();
        }
    }

    private void ReduceLives()
    {
        increaseLivesCounter -= 10;
        lives = Math.Max(lives - 1, 0);
        livesText.text = $"Lives: {lives}";

        if (lives != 0) return;
        
        StopAllCoroutines();
        gameOverPanel.SetActive(true);
    }

    private void CanIncreaseLives()
    {
        increaseLivesCounter++;
        
        if (increaseLivesCounter < 20 || lives == 3) return;
        
        increaseLivesCounter = 0;
        
        lives = Math.Min(lives + 1, 3);
        livesText.text = $"Lives: {lives}";
    }
    
    private void Move(Vector3 direction)
    {
        playerRigidbody.linearVelocity = direction * speed;
    }

    private void Rotate(float rotationY, Vector3 target)
    {
        if (Mathf.Approximately(transform.rotation.eulerAngles.y, rotationY)) return;
            
        transform.Rotate(target, Space.Self);
    }

    public void PlayGame()
    {
        DestroyAllSpawnedObjects();
        
        Time.timeScale = 1;
        score = 0;
        lives = livesMax;
        increaseLivesCounter = 0;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        
        scoreText.text = $"Score: {score.ToString()}";
        livesText.text = $"Lives: {lives}";
        
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        coroutine = GameManager.Instance.StartGame();
        StartCoroutine(coroutine);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        if (coroutine != null) StopCoroutine(coroutine);
        pausePanel.SetActive(false);
    }

    private void DestroyAllSpawnedObjects()
    {
        FallingObject[] fallingObjects =  FindObjectsByType<FallingObject>(FindObjectsSortMode.None);
        foreach (FallingObject fallingObject in fallingObjects)
        {
            Destroy(fallingObject.gameObject);
        }
    }
    
    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        GameManager.Instance.Quit();
        #endif
    }
}