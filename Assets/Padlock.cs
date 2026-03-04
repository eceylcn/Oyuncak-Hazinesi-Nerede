using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Padlock : MonoBehaviour
{
    [SerializeField] List<Button> ButtonCombination = new List<Button>();

    [SerializeField] List<Button> PressedButtons = new List<Button>();

    [SerializeField] GameObject[] RevealIfSolved;

    [SerializeField] GameObject[] buttonPressReveals;

    [SerializeField] private string _correctText;
    [SerializeField] private string _wrongText;
    
    public void PressButton(Button button)
    { 
        PressedButtons.Add(button);
        if (PressedButtons.Count <= buttonPressReveals.Length)
        {
            buttonPressReveals[PressedButtons.Count-1].SetActive(true);
        }
    }

    public bool CheckPassword()
    {
        if (ButtonCombination.Count != PressedButtons.Count) return false;

        for (int i = 0; i < ButtonCombination.Count; i++) 
        {
            if (ButtonCombination[i] != PressedButtons[i]) { return false; }
        }
        if(_correctText !=  String.Empty) GameEvents.CheckAnswer.Invoke(true,_correctText);
        return true;
    }

    public void AdvanceIfTrue()
    {
        if (CheckPassword())
        {
            foreach (GameObject gj in RevealIfSolved)
            {
                gj.SetActive(true);
            }
            transform.parent.gameObject.SetActive(false);
        }
        else
        { 
            if(_wrongText != String.Empty) GameEvents.CheckAnswer.Invoke(false,_wrongText);
            PressedButtons.Clear();
            foreach (GameObject gj in buttonPressReveals) { gj.SetActive(false); }
        }
    }
}
