using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour,ActionBase {

	[SerializeField] private bool isInitiallyHidden = true;
    void Awake()
    {
        gameObject.SetActive(!isInitiallyHidden);
    }

    public  void Action(){
		gameObject.SetActive(true);
	}
}
