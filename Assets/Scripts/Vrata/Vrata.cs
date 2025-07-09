using System;
using UnityEngine;

public class Vrata : MonoBehaviour
{
    private bool isOpen;
    
    public void TriggerDoor()
    {
        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerVrata playerVrata))
        {
            if (isOpen)
            {
                playerVrata.EnableText("Press E to close door");
            }
            else
            {
                playerVrata.EnableText("Press E to open door");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerVrata playerVrata))
        {
            playerVrata.DisableText();
        }
    }

    private void Open()
    {
        isOpen = true;
        transform.Rotate(new Vector3(0, 90, 0), Space.Self);
    }

    private void Close()
    {
        isOpen = false;
        transform.rotation = Quaternion.identity;
    }
}
