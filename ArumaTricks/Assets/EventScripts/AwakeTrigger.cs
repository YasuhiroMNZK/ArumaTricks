using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeTrigger : TriggerBase
{
    // Start is called before the first frame update
    void Awake()
    {
        action.Invoke();
    }

}
