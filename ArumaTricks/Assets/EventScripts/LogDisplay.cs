using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public sealed class LogDisplay : MonoBehaviour, ActionBase
{
    public void Action()
    {
        Debug.Log(transform.name + " action!");
    }
}
