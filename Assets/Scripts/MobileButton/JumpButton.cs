using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public Sprite JumpOnIcon;
    public Sprite JumpOffIcon;
    public Sprite HighlightIcon;

    Image image;
    bool isClick = false;

    bool isManual = false;
    public bool IsClick
    {
        get { return isClick; }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        isClick = true;

        if (!isManual)
            image.sprite = JumpOnIcon;
        else
            image.sprite = HighlightIcon;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        image.sprite = JumpOffIcon;

        if(isManual)
            isManual = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = JumpOffIcon;

        SetManualButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        isClick = false;
    }

    public void SetManualButton()
    {
        isManual = true;
        image.sprite = HighlightIcon;
    }
}
