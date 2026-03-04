using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDependOnGoal : MonoBehaviour
{
    [SerializeField] Goal dependGoal;
    [SerializeField] CookerGoal cookerGoal;
    [SerializeField] GameObject[] RevealOnStartSuccess;
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TryClick);
    }

    private void TryClick()
    {
        if (dependGoal.isComplete())
        { 
            foreach (GameObject go in RevealOnStartSuccess)
            {
                go.SetActive(true);
            }
            cookerGoal.startCooking();
        }
    }


}
