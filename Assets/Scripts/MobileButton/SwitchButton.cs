using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour,IPointerClickHandler,IPointerUpHandler
{
    public Sprite LightenModeIcon;
    public Sprite ShadowModeIcon;
    public Sprite TeachLightenModeIcon;
    public Sprite TeachlShadowModeIcon;

    Image image;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {

        if (!ShadowModeManager.Instance) return;

        ShadowMode mode = ShadowModeManager.Instance.CurrentShadowMode;
        if (mode == ShadowMode.Interactive)
        {
            ShadowModeManager.Instance.ChangeShadowMode(ShadowMode.Normal);
        }
        else
        {
            ShadowModeManager.Instance.ChangeShadowMode(ShadowMode.Interactive);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = LightenModeIcon;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ShadowModeManager.Instance) return;

        ShadowMode mode = ShadowModeManager.Instance.CurrentShadowMode;
        if (mode == ShadowMode.Interactive)
        {
            image.sprite = ShadowModeIcon;
        }
        else
        {
            image.sprite = LightenModeIcon;
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
    }
}
