using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private int scoreAmount;
    [SerializeField] private AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.SetScore(scoreAmount);
            AudioManager.Instance.PlaySound(audioClip);
        }
        
        Destroy(gameObject);
    }
}
