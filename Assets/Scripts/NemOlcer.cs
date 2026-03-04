using System;
using System.Collections;
using System.Collections.Generic;
using OyuncakHazinesiNerede.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class NemOlcer : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    protected RectTransform rectTransform;
    protected CanvasGroup canvasGroup;
    protected Vector2 originalPosition;
    public bool isValid = false;

    public GameObject afterUI;
    public Image afterUIImage;
    public Sprite AfterValidSprite;
    public List<string> _fanuslar;
    public GameObject NewDialogue;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Disable raycasting on the image while dragging
        canvasGroup.blocksRaycasts = false;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        // Re-enable raycasting on the image after dragging
        canvasGroup.blocksRaycasts = true;

       
        // Check if the image was dropped on top of another object
        GameObject droppedObject = eventData.pointerCurrentRaycast.gameObject;
        if (droppedObject != null && droppedObject.TryGetComponent<ItemContainer>(out ItemContainer _container))
        {
            if(_fanuslar.Contains(_container.gameObject.name) == false )_fanuslar.Add(_container.gameObject.name);
            ResetPosition();
            afterUI.SetActive(true);
            afterUIImage.sprite = _container.GetComponent<Image>().sprite;
        }
        else
        {
            ResetPosition();
        }

        if (isValid && AfterValidSprite != null)
        {
            var image =GetComponent<Image>();
            image.sprite = AfterValidSprite;
            image.SetNativeSize();
        }

        if (_fanuslar.Count >= 3)
        {
            NewDialogue.SetActive(true);
        }
    }
    
    public void ResetPosition()
    {
        rectTransform.anchoredPosition = originalPosition;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetCanvasScale();
    }

    private float GetCanvasScale()
    {
        // Calculate the scale factor of the canvas
        Canvas canvas = GetComponentInParent<Canvas>();
        return canvas.scaleFactor;
    }
}
