using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private int scoreAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.SetScore(scoreAmount);
        }
        
        Destroy(gameObject);
    }
}
