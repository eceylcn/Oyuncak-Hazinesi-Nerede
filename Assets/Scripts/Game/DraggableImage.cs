using System;
using OyuncakHazinesiNerede.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemType
{
    Katı, Sıvı, Gaz, IsıAlan,IsıVeren, Hepsi
}

[RequireComponent(typeof(CanvasGroup))]
public class DraggableImage : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public ItemType type;
    protected RectTransform rectTransform;
    protected CanvasGroup canvasGroup;
    protected Vector2 originalPosition;
    public bool isMoveable = true;
    public bool isDragging = false;
    public bool isDestroyable = true;
    public bool isFirstChap = true;
    public bool isValid = false;

    public Sprite AfterValidSprite;
   
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (transform.parent.TryGetComponent<ItemContainer>(out ItemContainer container))
        {
            container.removeItem(this);
            isMoveable = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Disable raycasting on the image while dragging
        canvasGroup.blocksRaycasts = false;
        isDragging = true;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        // Re-enable raycasting on the image after dragging
        canvasGroup.blocksRaycasts = true;

        // Check if the image was dropped on top of another object
        GameObject droppedObject = eventData.pointerCurrentRaycast.gameObject;
        if (droppedObject != null && droppedObject.TryGetComponent<ItemContainer>(out ItemContainer _container))
        {
            if (_container.TargetImage != null)
            {
                if ( _container.TargetImage == this)
                {
                    _container.addItem(this);
                    FindObjectOfType<GameManager>().RefreshGoals();
                    if(_container.CorrectAnswer != String.Empty) GameEvents.CheckAnswer.Invoke(true,_container.CorrectAnswer);
                    ResetPosition();
                }
                else
                {
                    ResetPosition();
                    GameEvents.ChapterTwoCheckAnswer.Invoke(type, false, _container.m_ItemType);
                    if(_container.WrongAnswer != String.Empty) GameEvents.CheckAnswer.Invoke(false,_container.WrongAnswer);
                }
                ResetPosition();
                
                if (isValid && AfterValidSprite != null)
                {
                    var image = GetComponent<Image>();
                    image.sprite = AfterValidSprite;
                    image.SetNativeSize();
            
                }
                isDragging = false; 
                return;
            }
            
            if (_container.m_ItemType == type || _container.m_ItemType == ItemType.Hepsi)
            {
                _container.addItem(this);
                GameEvents.ChapterTwoCheckAnswer.Invoke(type, true, _container.m_ItemType);
                if(_container.CorrectAnswer != String.Empty) GameEvents.CheckAnswer.Invoke(true,_container.CorrectAnswer);
                FindObjectOfType<GameManager>().RefreshGoals();
            }
            else
            {
                ResetPosition();
                GameEvents.ChapterTwoCheckAnswer.Invoke(type, false, _container.m_ItemType);
                if(_container.WrongAnswer != String.Empty) GameEvents.CheckAnswer.Invoke(false,_container.WrongAnswer);
            }
            
        }
        else
        {
            // Reset the position of the image to its original position
            ResetPosition();
        }

        if (isValid && AfterValidSprite != null)
        {
            var image =GetComponent<Image>();
            image.sprite = AfterValidSprite;
            image.SetNativeSize();
            
        }
        isDragging = false; 
    }

    public void ResetPosition()
    {
        rectTransform.anchoredPosition = originalPosition;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        // Move the image according to the mouse position
        if (isMoveable)
        {
            rectTransform.anchoredPosition += eventData.delta / GetCanvasScale();
        }
    }

    private float GetCanvasScale()
    {
        // Calculate the scale factor of the canvas
        Canvas canvas = GetComponentInParent<Canvas>();
        return canvas.scaleFactor;
    }
}
