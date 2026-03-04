using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TransformGoal : Goal
{
    [SerializeField] TransformingItem TransformingItem;
    public override bool isComplete()
    {
        return TransformingItem.isTransformed;
    }
}
