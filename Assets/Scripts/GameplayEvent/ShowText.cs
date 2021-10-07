using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : GameplayEvent
{
    public string TextString;
    // Start is called before the first frame update
    public GameObject UIObject;

    public override void OnEventTriggered()
    {
        UIObject.SetActive(true);
        Text text = UIObject.GetComponentInChildren<Text>();
        text.text = TextString;
    }
}
