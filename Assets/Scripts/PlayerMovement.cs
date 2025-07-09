using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private int lives;
    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private GameObject gameOverPanel;

    private int score;
    private int increaseLivesCounter = 0;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        scoreText.text = $"Score: {score.ToString()}";
        livesText.text = $"Lives: {lives}";
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
        
        if (lives == 0)
        {
            gameOverPanel.SetActive(true);
        }
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
}