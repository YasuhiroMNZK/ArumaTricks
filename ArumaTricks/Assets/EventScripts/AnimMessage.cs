using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMessage : MonoBehaviour, ActionBase
{
    [SerializeField] Animator targetObject;
    [SerializeField] string message;
    public void Action()
    {
        targetObject.SetTrigger(message);
    }
}
