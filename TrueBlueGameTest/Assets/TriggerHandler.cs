using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : MonoBehaviour
{

    public UnityEvent onEnter;
    public UnityEvent onExit;
    
    private void OneTriggerEnter(Collider other)
    {
        onEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {

        onExit.Invoke();

    }
}
