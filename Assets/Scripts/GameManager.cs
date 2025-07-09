using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private FallingObject[] collectibles;
    [SerializeField] private float[] spawnRange;
    

    private void Awake()
    {
        Instance = this;
    }
    
    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);

        int randomIndex = RandomIndex(collectibles.Length);
        
        float min = spawnRange[0];
        float max = spawnRange[1];
        float randomPositionX = RandomPosition(min, max);
        
        Instantiate(collectibles[randomIndex], new Vector3(randomPositionX, 18f, 8), Quaternion.identity);
        
        yield return StartGame();
    }

    private int RandomIndex(int length)
    {
        return Random.Range(0, length);
    }

    private float RandomPosition(float min, float max)
    {
        return Random.Range(min, max);
    }

    public void Quit()
    {
        Application.Quit();
    }
}