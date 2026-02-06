using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : TriggerBase
{
    [SerializeField] private float remainTime;
    [SerializeField] bool continuous;

    void OnEnable()
    {
        StartCoroutine(TimeWait());
    }

    private IEnumerator TimeWait()
    {
        do
        {
            yield return new WaitForSeconds(remainTime);
            action.Invoke();
        } while (continuous);
    }
}
