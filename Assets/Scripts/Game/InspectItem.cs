using System.Collections;
using System.Collections.Generic;
using OyuncakHazinesiNerede.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

public class InspectItem : DraggableImage
{
    public GameObject InspectContent;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
    }


    public override void OnEndDrag(PointerEventData eventData)
    {
        // Re-enable raycasting on the image after dragging
        canvasGroup.blocksRaycasts = true;

        // Check if the image was dropped on top of another object
        GameObject droppedObject = eventData.pointerCurrentRaycast.gameObject;
        if (droppedObject != null && droppedObject.TryGetComponent<Inspector>(out Inspector _inspector))
        {
            _inspector.InspectItem(this);
            ResetPosition();
        }

        if (droppedObject != null && droppedObject.TryGetComponent<ItemContainer>(out ItemContainer _container))
        {
            if (_container.m_ItemType == type || _container.m_ItemType == ItemType.Hepsi)
            {
                _container.addItem(this);
                GameEvents.ChapterTwoCheckAnswer.Invoke(type, true, _container.m_ItemType);
                FindObjectOfType<GameManager>().RefreshGoals();
            }
            else
            {
                ResetPosition();
                GameEvents.ChapterTwoCheckAnswer.Invoke(type, false, _container.m_ItemType);
            }
        }
        else
        {
            // Reset the position of the image to its original position
            ResetPosition();
        }

        isDragging = false;
    }
}
