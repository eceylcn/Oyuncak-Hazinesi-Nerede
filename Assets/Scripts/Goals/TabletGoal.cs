using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletGoal :Goal
{
    public bool isAnswered;
    public override bool isComplete()
    {
        return isAnswered;
    }

    public void SetIsAnswered()
    {
        isAnswered = true;
    }
     public void SetIsAnsweredWIthNotify()
        {
            isAnswered = true;
            GameEvents.GoalUpdate.Invoke();
        }
}
