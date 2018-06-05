using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

    public Text text;
    private int frame = 10;
    private bool isOpen;

	// Use this for initialization
	void Start () {
        isOpen = true;
        Button button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(ButtonOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ButtonOnClick()
    {
        // 收起
        if (isOpen)
        {
            StartCoroutine(Close());
        }
        // 展开
        else
        {
            StartCoroutine(Open());
        }
    }

    private IEnumerator Close()
    {
        float height = 120;
        for (int i = 0; i < frame; i++)
        {
            height -= 120f / frame;
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, height);
            if (i == frame - 1)
                isOpen = false;
            yield return null;
        }
    }

    private IEnumerator Open()
    {
        float height = 0; 
        for (int i = 0; i < frame; i++)
        {
            height += 120f / frame;
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, height);
            if (i == frame - 1)
                isOpen = true;
            yield return null;
        }
    }
}
