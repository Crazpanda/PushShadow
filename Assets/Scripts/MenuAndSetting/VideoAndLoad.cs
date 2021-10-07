using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoAndLoad : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.playOnAwake = false;
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //print("frame count: "+videoPlayer.frame+", frame allCount: "+videoPlayer.frameCount);
        if (videoPlayer.frame+10 >= (long) videoPlayer.frameCount) {
            SceneManager.LoadScene("teach_Scene");
        }
    }
}
