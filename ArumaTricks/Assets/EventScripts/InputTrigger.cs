using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTrigger : TriggerBase
{
    [SerializeField] private string keyname;

    // Update is called once per frame
    void Update()
    {
        // 暂停中は入力を無効化
        if (Pause.IsPausedStatic)
        {
            return;
        }

        if (Input.GetButtonDown(keyname))
        {
            action.Invoke();
        }
    }
}
