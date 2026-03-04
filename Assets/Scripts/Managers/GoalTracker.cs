using System.Collections;
using System.Collections.Generic;
using OyuncakHazinesiNerede.Managers;
using UnityEngine;

public class GoalTracker : MonoBehaviour
{
    [SerializeField] private Goal[] _currentGoals;
    private bool _autoPass;
    public void UpdateCurrentGoals(Page page)
    {
        _currentGoals = page.GetGoals();
        _autoPass = page.AutomaticPass;
    }

    public bool IsPageComplete()
    {
        for (int i = 0; i < _currentGoals.Length; i++)
        {
            Goal goal = _currentGoals[i];
            if (goal.isComplete() == false) return false;
        }

        if (_autoPass)
        {
            FindObjectOfType<GameManager>().AdvanceChapterPage();
            return false;
        }
        return true;
    }


    public void SoftCheckGoals()
    { 
        foreach (Goal goal in _currentGoals) 
        {
            if ((goal is DropdownGoal)) 
            {
                DropdownGoal dropdown_goal = goal as DropdownGoal;
                if (!dropdown_goal.validateAnswer() && dropdown_goal._dropdownAsset.gameObject.activeInHierarchy)
                { 
                    GameEvents.SoftCheckWrong?.Invoke();
                }
            }
        }
        
        GameEvents.GoalUpdate?.Invoke();
    }

}

