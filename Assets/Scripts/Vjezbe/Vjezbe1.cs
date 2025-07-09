using System;
using UnityEngine;

public class Vjezbe1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"On CollisionEnter");
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log($"On CollisionExit");
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log($"On CollisionStay");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"On TriggerEnter");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"On TriggerExit");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"On TriggerStay");
    }
}
