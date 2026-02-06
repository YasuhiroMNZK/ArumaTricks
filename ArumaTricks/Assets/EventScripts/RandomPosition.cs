using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour,ActionBase
{
    [SerializeField] float xmin, xmax;
    [SerializeField] float ymin, ymax;
    [SerializeField] float zmin, zmax;

    public  void Action()
    {
        transform.localPosition =
            new Vector3(
                Random.Range(xmin, xmax),
                Random.Range(ymin, ymax),
                Random.Range(zmin, zmax)
            );
    }
}
