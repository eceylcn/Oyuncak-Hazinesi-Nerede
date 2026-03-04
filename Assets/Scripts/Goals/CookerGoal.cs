using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookerGoal : Goal
{
    [SerializeField] float _cookTime;
    [SerializeField] float cookDegree = 1538f;
    private bool didCook = false;
    private bool startedCooking = false;
    private TransformingItem transformComponent;
    [SerializeField] float currentDegree = 0f;
    [SerializeField] TMP_Text sayac;
    [SerializeField] private Image sayacIcon;
    [SerializeField] bool useSayac = true;
    [SerializeField] GameObject[] revealOnCook;
    [SerializeField] GameObject[] revealOnStartCook;
    [SerializeField] GameObject[] hideOnCook;

    public override bool isComplete()
    {
        return didCook;
    }
    private void Awake()
    {
        transformComponent = GetComponent<TransformingItem>();
    }
    public void startCooking()
    {
        if (!transformComponent.isTransformed) { return; }
        if (startedCooking) { return; }

        foreach (GameObject go in revealOnStartCook)
        {
            go.SetActive(true);
        }

        startedCooking = true;
        StartCoroutine(incrementForT(_cookTime, .05f));
        if (sayacIcon != null) sayacIcon.gameObject.SetActive(true);
    }

    IEnumerator incrementForT(float time, float timeIntervals)
    {
        float totalDuration = time;
        float stepDuration = timeIntervals;
        float steps = totalDuration / stepDuration;
        float waitDuration = 0.05f;
        float waitSteps = totalDuration / waitDuration;

        float fillStep = 1f / waitSteps;

        if (!(cookDegree < currentDegree))
        {
            float degreeIncrement = (cookDegree - currentDegree) / waitSteps;

            if (sayacIcon != null) sayacIcon.fillAmount = 0;

            while (currentDegree < cookDegree)
            {
                yield return new WaitForSeconds(waitDuration);
                currentDegree += degreeIncrement;
                if (currentDegree > cookDegree) currentDegree = cookDegree;

                if (useSayac) sayac.text = $"{currentDegree:F1}°C";
                if (sayacIcon != null) sayacIcon.fillAmount += fillStep;
            }
        }
        else
        {
            float degreeIncrement = (cookDegree - currentDegree) / waitSteps;

            if (sayacIcon != null) sayacIcon.fillAmount = 0;

            while (currentDegree > cookDegree)
            {
                yield return new WaitForSeconds(waitDuration);
                currentDegree += degreeIncrement;
                if (currentDegree < cookDegree) currentDegree = cookDegree;

                if (useSayac) sayac.text = $"{currentDegree:F1}°C";
                if (sayacIcon != null) sayacIcon.fillAmount += fillStep;
            }
        }

        if (sayacIcon != null) sayacIcon.fillAmount = 1f; // Ensure it's exactly 1
        if (sayacIcon != null) sayacIcon.gameObject.SetActive(false);
        
        didCook = true;
        GameEvents.GoalUpdate?.Invoke();

        foreach (GameObject go in revealOnCook) { go.SetActive(true); }    
        foreach (GameObject go in hideOnCook) { go.SetActive(false); }
    }
}
