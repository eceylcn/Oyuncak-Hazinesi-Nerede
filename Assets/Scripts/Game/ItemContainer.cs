using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    private List<DraggableImage> m_Items = new List<DraggableImage>();
    public ItemType m_ItemType;
    public Goal assignedGoal;
    public DraggableImage TargetImage;
    [SerializeField] bool checkInactive = false;

    [SerializeField] bool deActivateItem = true;
    [SerializeField] bool freeItem = false;
    [SerializeField] private Sprite _afterFullSprite;
    public string CorrectAnswer;
    public string WrongAnswer;
    public bool areItemsValid()
    {
        if (!gameObject.activeInHierarchy) { return false; }

        if (freeItem)
        {
            if (TargetImage == null)
            {
                foreach (DraggableImage _item in FindObjectsByType<DraggableImage>(FindObjectsInactive.Exclude, FindObjectsSortMode.InstanceID))
                {
                    if (_item.isValid == false) return false;
                }
            }
            else
            {
                return TargetImage.isValid;
            }
            
            foreach (var item in m_Items)
            {
                if (item.isValid == false) return false;
            }

            return true;
        }
       
        if (TargetImage != null)
        {
            return TargetImage.isValid;
        }
        
        if (!checkInactive)
        {
            foreach (DraggableImage _item in FindObjectsByType<DraggableImage>(FindObjectsInactive.Exclude, FindObjectsSortMode.InstanceID))
            {
                if (_item.type == m_ItemType) { return false; }
            }
        }

        else
        {
            foreach (DraggableImage _item in FindObjectsByType<DraggableImage>(FindObjectsInactive.Exclude, FindObjectsSortMode.InstanceID))
            {
                if (_item.isMoveable == true) { return false; }
            }
        }

        foreach (DraggableImage item in m_Items)
        {
            if (item.type == m_ItemType)
                continue;

            else return false;
        }

        Debug.Log(m_Items.Count);
        return true;
    }

    public void addItem(DraggableImage Item)
    {
        if(m_Items.Contains(Item)) return;
        
        Item.isValid = true;
        m_Items.Add(Item);
        if (!Item.isFirstChap)
        {
            Item.isMoveable = false;
        }


        if (deActivateItem) Item.gameObject.SetActive(false);
        else
        {
            if (freeItem == false)
            {
                Item.transform.SetParent(transform);
            }
            else
            {
                Item.ResetPosition();
            }
        }

        if (_afterFullSprite != null)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = _afterFullSprite;
        }
    }
    public void removeItem(DraggableImage Item)
    {
        m_Items.Remove(Item);
    }


    public void checkItemsInside()
    {
        Debug.Log("Checking items inside");
        GameEvents.showContainerState?.Invoke(this, areItemsValid());
        GameEvents.GoalUpdate?.Invoke();
    }

    public void DumpItems()
    {
        m_Items = new List<DraggableImage>();
        GameEvents.GoalUpdate?.Invoke();
    }
    public List<DraggableImage> GetItems()
    {
        return m_Items;
    }




}
