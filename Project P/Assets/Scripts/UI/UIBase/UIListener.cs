/****************************************************
    文件：AudioSvc.cs
	作者：Project P Group
    邮箱: 389371356@qq.com
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIListener : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler {
    public Action<object> onClick;
    public Action<PointerEventData> onClickDown;
    public Action<PointerEventData> onClickUp;
    public Action<PointerEventData> onDrag;

    public object args;

    public void OnPointerClick(PointerEventData eventData) {
        if (onClick != null) {
            onClick(args);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (onClickDown != null) {
            onClickDown(eventData);
        }
    }
    public void OnPointerUp(PointerEventData eventData) {
        if (onClickUp != null) {
            onClickUp(eventData);
        }
    }
    public void OnDrag(PointerEventData eventData) {
        if (onDrag != null) {
            onDrag(eventData);
        }
    }

}