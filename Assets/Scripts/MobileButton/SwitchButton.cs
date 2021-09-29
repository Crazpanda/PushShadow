using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour,IPointerClickHandler
{
    public Sprite LightenModeIcon;
    public Sprite ShadowModeIcon;

    Image image;

    //true : LightenMode , false : ShadowMode
    bool state = true;
    bool LightState
    {
        get { return state; }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {

        if (state)
        {
            image.sprite = ShadowModeIcon;
            state = false;
        }
        else if (!state)
        {
            image.sprite = LightenModeIcon;
            state = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = LightenModeIcon;
        state = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
