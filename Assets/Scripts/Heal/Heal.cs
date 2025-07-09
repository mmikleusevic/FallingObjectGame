using System;
using System.Collections;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private bool isHealing;
    private IEnumerator coroutine;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (isHealing) return;
            if (!other.TryGetComponent(out PlayerTest playerTest));
                
            coroutine = HealPlayer(playerTest);
            StartCoroutine(coroutine);
        }
        else
        {
            if (coroutine == null) return;
            StopCoroutine(coroutine);
            isHealing = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isHealing = false;
        StopCoroutine(coroutine);
    }

    private IEnumerator HealPlayer(PlayerTest playerTest)
    {
        isHealing = true;
        
        yield return new WaitForSeconds(1f);
        playerTest.Heal();
        
        isHealing = false;
    }
}
