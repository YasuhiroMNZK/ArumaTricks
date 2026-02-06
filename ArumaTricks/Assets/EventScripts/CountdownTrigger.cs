using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTrigger : TriggerBase ,ActionBase
{
    [SerializeField] int count;
    [SerializeField] bool continuous;
    int originalcount;
    private void Start()
    {
        originalcount = count;
    }

    public void Action()
    {
        count -= 1;
        if(count == 0)
        {
            action.Invoke();
            if(continuous)
            {
                count = originalcount;
            }
        }
    }
}
