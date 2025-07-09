using System;
using TMPro;
using UnityEngine;

public class PlayerVrata : MonoBehaviour
{
    [SerializeField] private TMP_Text vrataText;
    
    void OnDrawGizmosSelected()
    {
        float radius = 1f;
        float distance = 1f;
        Vector3 origin = transform.position;
        Vector3 direction = transform.right;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(origin, radius);
        Gizmos.DrawWireSphere(origin + direction * distance, radius);
        Gizmos.DrawLine(origin + direction * radius, origin + direction * (distance - radius));
    }
    
    private void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 1, transform.right, out hit, 1f))
        {
            if (hit.collider.TryGetComponent(out Vrata vrata) && Input.GetKeyDown(KeyCode.E))
            {
                vrata.TriggerDoor();
            }
        }
    }

    public void EnableText(string text)
    {
        vrataText.gameObject.SetActive(true);
        vrataText.text = text;
    }

    public void DisableText()
    {
        vrataText.gameObject.SetActive(false);
    }
}
