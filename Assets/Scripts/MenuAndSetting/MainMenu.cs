using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button mainSetting, endButton;
    public Slider slider, mainSlider;
    public AudioSource backgroundSound;
    public GameObject panel, mainPanel;
    public ProgressMgrPanel progressMgrPanel;
    public Sprite myFirstSprite;
    private bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        panel.GetComponent<RectTransform>().localScale = new Vector2(0, 0f);
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

    public void Volume() {
        backgroundSound.volume = slider.value;
    }

    public void MainVolume() {
        backgroundSound.volume = mainSlider.value;
    }

    public void OpenSetting() {
        panel.GetComponent<RectTransform>().localScale = new Vector2(1, 1f);
    }

    public void CloseSetting() {
        panel.GetComponent<RectTransform>().localScale = new Vector2(0, 0f);
    }

    public void LoadProgress()
    {
        progressMgrPanel.OpenProgressMgrPanel(FileOperationType.Load);
    }

    public void SaveProgress()
    {
        progressMgrPanel.OpenProgressMgrPanel(FileOperationType.Save);
    }

    public void BackToMenu()
    {
        // 加载场景
        SceneManager.LoadScene("beginScene");
    }

    public void SettingVolume()
    {
        // isOpen: true 关闭音量设置 false 打开音量设置
        if (isOpen)
        { 
            mainPanel.GetComponent<RectTransform>().localScale = new Vector2(0, 0f);
            endButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -133f);
            mainSetting.GetComponent<Image> ().sprite = myFirstSprite;
        } else {
            mainPanel.GetComponent<RectTransform>().localScale = new Vector2(1, 1f);
            endButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -152f);
            mainSetting.GetComponent<Image> ().sprite = Resources.Load <Sprite>("右上角-设置-on 128-64");;  
        }

        isOpen = !isOpen;
    }

}
