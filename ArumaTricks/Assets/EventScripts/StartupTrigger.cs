using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupTrigger : TriggerBase
{
    // Start is called before the first frame update
    void Start()
    {
        action.Invoke();
    }

}
