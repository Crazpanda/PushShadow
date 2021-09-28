using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileHandle : MonoBehaviour, IDragHandler, IEndDragHandler
{
    RectTransform trans;
    Vector2 beginPos;
    Vector2 moved = new Vector2(0, 0);

    public Vector2 HandleMovedDirection
    {
        get { return moved; }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        trans.anchoredPosition += eventData.delta;

        moved = trans.anchoredPosition - beginPos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        trans.anchoredPosition = beginPos;

        moved = trans.anchoredPosition - beginPos;
    }


    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<RectTransform>();
        beginPos = trans.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
