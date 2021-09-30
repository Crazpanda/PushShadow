using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class MessageBoxPanel : MonoBehaviour
{
    public Button button1;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show(string message)
    {
        text.text = message;
        gameObject.SetActive(true);
    }

    public void ClickButton1()
    {
        //StopAllCoroutines();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
