using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene3TriggerEvent : MonoBehaviour
{
    public string NextSceneName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(NextSceneName);
        }
    }
}
