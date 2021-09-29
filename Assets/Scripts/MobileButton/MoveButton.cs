using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Sprite DragOnIcon;
    public Sprite DragOffIcon;

    public Image BackImage;
    public Image DynamicImage;
    public Image LineImage;
    public uint MoveRadius;

    Image ButtonImage;

    RectTransform dynamicTrans;
    RectTransform lineTrans;
    Vector2 beginPos;
    Vector2 moved = new Vector2(0, 0);
    public Vector2 HandleMovedDirection
    {
        get { return moved; }
    }

    void Start()
    {
        BackImage.enabled = false;
        LineImage.enabled = false;

        ButtonImage = GetComponent<Image>();
        ButtonImage.sprite = DragOffIcon;

        dynamicTrans = DynamicImage.GetComponent<RectTransform>();
        beginPos = dynamicTrans.anchoredPosition;

        lineTrans = LineImage.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        
        BackImage.enabled = true;
        LineImage.enabled = true;

        ButtonImage.sprite = DragOnIcon;

        dynamicTrans.anchoredPosition += eventData.delta;
        float dis = Vector2.Distance(dynamicTrans.anchoredPosition, beginPos) / MoveRadius;
        if (dis >= 1.0f)
        {
            dynamicTrans.anchoredPosition = moved.normalized * MoveRadius;
        }
        
        moved = dynamicTrans.anchoredPosition - beginPos;

        float lineDegress = -Mathf.Rad2Deg * Mathf.Atan2(moved.x,moved.y);

        lineTrans.eulerAngles = new Vector3(0,0, lineDegress);
        lineTrans.localScale = new Vector3(1, dis, 1);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        dynamicTrans.anchoredPosition = beginPos;
        moved = dynamicTrans.anchoredPosition - beginPos;
        
        BackImage.enabled = false;
        LineImage.enabled = false;
        ButtonImage.sprite = DragOffIcon;
    }
}
