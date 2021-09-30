using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    public ProgressMgrPanel progressMgrPanel;
    public Slider mainSlider;
    public AudioSource backgroundSound;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void LoadProgress()
    {
        progressMgrPanel.OpenProgressMgrPanel(FileOperationType.Load);
    }

    public void MainVolume()
    {
        backgroundSound.volume = mainSlider.value;
    }

    public void SaveProgress()
    {
        progressMgrPanel.OpenProgressMgrPanel(FileOperationType.Save);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void BackToMenu()
    {
        // º”‘ÿ≥°æ∞
        SceneManager.LoadScene("VideoScene");
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
