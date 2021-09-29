using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour,IPointerClickHandler,IPointerUpHandler
{
    public Sprite LightenModeIcon;
    public Sprite ShadowModeIcon;
    public Sprite ManualLightenModeIcon;
    public Sprite ManualShadowModeIcon;

    Image image;

    bool isManualLight = false;
    bool isManulaShadow = false;

    bool isClick = false;
    public bool IsClick
    {
        get { return isClick; }
    }

    //true : LightenMode , false : ShadowMode
    bool state = true;
    bool LightState
    {
        get { return state; }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        isClick = true;

        //if (state)
        //{
        //    if (isManulaShadow)
        //    {
        //        image.sprite = ManualShadowModeIcon;
        //        isManulaShadow = false;
        //    }
        //    else
        //        image.sprite = ShadowModeIcon;
        //    state = false;
        //}
        //else if (!state)
        //{
        //    if (isManualLight)
        //    {
        //        image.sprite = ManualLightenModeIcon;
        //        isManualLight = false;
        //    }
        //    else
        //        image.sprite = LightenModeIcon;

        //    state = true;
        //}

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
        state = true;

        //SetManualButton();
    }

    // Update is called once per frame
    void Update()
    {
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

    void LateUpdate()
    {
        isClick = false;
    }

    public void SetManualButton()
    {
        isManualLight = true;
        isManulaShadow = true;

        if (state)
            image.sprite = ManualLightenModeIcon;
        else
            image.sprite = ManualShadowModeIcon;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
    }
}
