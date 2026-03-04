using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HıddenGoal : Goal
{
    public bool isAnswered;

    private void OnEnable()
    {
        SetIsAnsweredWIthNotify();
    }

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
