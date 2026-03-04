using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverItem : DraggableImage
{
    public float hoverTime = 2f;
    [SerializeField] HoverArea hoverArea;

    [Space(10)]
    [SerializeField] GameObject[] revealOnHover;
    [SerializeField] GameObject[] hideOnHover;


    public override void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        // Re-enable raycasting on the image after dragging
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        GameObject hoveringObject = eventData.pointerCurrentRaycast.gameObject;

        if (hoveringObject != null && hoveringObject.TryGetComponent<HoverArea>(out HoverArea area))
        {
            if (area == hoverArea)
            {
                hoverTime -= Time.deltaTime;
                if (hoverTime <= 0)
                {
                    GameEvents.GoalUpdate?.Invoke();
                    foreach (GameObject go in revealOnHover) 
                    {
                        go.SetActive(true);
                    }
                    foreach (GameObject go in hideOnHover)
                    {
                        go.SetActive(false);
                    }
                }
            }
        }
    }
}
