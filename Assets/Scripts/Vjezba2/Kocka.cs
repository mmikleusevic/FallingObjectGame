using System;
using UnityEngine;

public class Kocka : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SphereCollider sfera))
        {
            Debug.Log("Sfera je usla u kocku");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SphereCollider sfera))
        {
            Debug.Log("Sfera je u kocki");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SphereCollider sfera))
        {
            Debug.Log("Sfera je izasla iz kocke");
        }
    }
}
