using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHeldTrigger : TriggerBase
{
    [SerializeField] private string keyname;

    // 離したときに実行するイベント
    [SerializeField] private UnityEvent releaseAction;

    // Update is called once per frame
    void Update()
    {
        // 押した瞬間
        if (Input.GetButton(keyname))
        {
            if (action != null)
            {
                action.Invoke();
            }
        }

        // 離した瞬間
        if (Input.GetButtonUp(keyname))
        {
            if (releaseAction != null)
            {
                releaseAction.Invoke();
            }
        }
    }
}
