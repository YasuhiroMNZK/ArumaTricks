using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContactTrigger : TriggerBase {
    [SerializeField] protected UnityEvent exitAction = null;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        action.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player") && exitAction != null) return;
        exitAction.Invoke();
    }
}
