using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] LoadConditions;
    public string NextSceneName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool isLoad = true;
        foreach (var c in LoadConditions)
        {
            if (c.activeSelf == true)
            {
                isLoad = false;
            }
        }

        if (isLoad)
        {
            SceneManager.LoadScene(NextSceneName);
        }
    }
}
