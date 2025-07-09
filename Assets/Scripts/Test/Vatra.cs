using System;
using System.Collections;
using UnityEngine;

public class Vatra : MonoBehaviour
{
    private bool entered;
    private IEnumerator coroutine;
    
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (entered) yield break;
        if (!other.gameObject.TryGetComponent(out PlayerTest playerTest)) yield break;

        coroutine = Damage(playerTest);
        
        StartCoroutine(coroutine);
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(coroutine);
        entered = false;
    }

    private IEnumerator Damage(PlayerTest playerTest)
    {
        while (true)
        {
            entered = true;
            
            yield return new WaitForSeconds(1f);
                
            playerTest.Damage();
            entered = false;
        }
    }
}
