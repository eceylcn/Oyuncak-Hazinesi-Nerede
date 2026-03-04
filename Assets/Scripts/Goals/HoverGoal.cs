using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverGoal : Goal
{
    [SerializeField] HoverItem item;

    public override bool isComplete()
    {
        return item.hoverTime <= 0;
    }
}
