using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameFlag : MonoBehaviour
{

    static bool[] Flags = new bool[8];
    [SerializeField] UnityEvent[] events;

    [SerializeField] bool[] gameFlags;

    private void Start()
    {
        gameFlags = new bool[Flags.Length];
        for (int i = 0; i < Flags.Length; i++)
        {
            gameFlags[i] = Flags[i];

        }
    }


    public void SetFlag(int flagnumber)
    {
        Flags[flagnumber] = true;
        gameFlags[flagnumber] = Flags[flagnumber];
    }
    public void UnsetFlag(int flagnumber)
    {
        Flags[flagnumber] = false;
        gameFlags[flagnumber] = Flags[flagnumber];
    }
    public void ToggleFlag(int flagnumber)
    {
        Flags[flagnumber] = !Flags[flagnumber];
        gameFlags[flagnumber] = Flags[flagnumber];
    }

    public void RelayAction(int flagnumber)
    {
        if (Flags[flagnumber])
        {
            events[flagnumber].Invoke();
        }
    }
}
