using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndListener : MonoBehaviour
{
    // Start is called before the first frame update
    public AimLocation[] Aims;

    public string NextSceneName;
    public GameObject EndCanvas;
    void Start()
    {
        EndCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Aims.Length <= 1) return;

        bool isEnd = true;

        foreach(var aim in Aims)
        {
            if(aim.IsTouched == false)
            {
                isEnd = false;
                break;
            }
        }

        if(isEnd)
        {
            //EndCanvas.SetActive(true);

            SceneManager.LoadScene(NextSceneName);
        }
    }

    public void NextScene()
    {
        if (EndCanvas != null)
            SceneManager.LoadScene(NextSceneName);
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
