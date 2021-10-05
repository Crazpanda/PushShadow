using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button mainSetting, endButton;
    public Slider mainSlider;
    public AudioSource backgroundSound;
    public GameObject mainPanel;
    public ProgressMgrPanel progressMgrPanel;
    public Sprite SettingOn, SettingOff;
    private bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        mainPanel.GetComponent<RectTransform>().localScale = new Vector2(0, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame() {
        print("quit game notify");
        Application.Quit();
    }

    public void StartGame() {
        print("start game notify");
        // 加载场景
        SceneManager.LoadScene("VideoScene");
    }

    public void MainVolume() {
        backgroundSound.volume = mainSlider.value;
    }

    public void OpenSetting() {
        print("open or close setting");
        // isOpen: true 关闭设置 false 打开设置
        if (isOpen)
        {
            mainPanel.GetComponent<RectTransform>().localScale = new Vector2(0, 0f);
            mainSetting.GetComponent<Image> ().sprite = SettingOff;
        } else {
            mainPanel.GetComponent<RectTransform>().localScale = new Vector2(1, 1f);
            mainSetting.GetComponent<Image> ().sprite = SettingOn;  
        }
        
        isOpen = !isOpen;
    }
    
    public void LoadProgress()
    {

        Debug.Log("LoadProgress");
        progressMgrPanel.OpenProgressMgrPanel(FileOperationType.Load);
    }
}
