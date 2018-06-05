using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    private int frame = 20;
    private int it = 0;
	// Use this for initialization
	void Start () {
        StartCoroutine(enumerator());
    }
	
	// Update is called once per frame
	void Update () {
		if (it < frame)
        {
            Debug.Log(it);
            it++;
        }
	}

    IEnumerator enumerator()
    {
        for (int i = 0; i < frame; i++)
        {
            Debug.Log("e" + i);
            yield return null;
        }
    }
}
