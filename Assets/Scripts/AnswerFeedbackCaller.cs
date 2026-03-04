using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerFeedbackCaller : MonoBehaviour
{
    [SerializeField] private string _correctText;
    [SerializeField] private string _wrongText;

    public void Correct()
    {
        GameEvents.CheckAnswer.Invoke(true,_correctText);
    }

    public void Wrong()
    {
        GameEvents.CheckAnswer.Invoke(false,_wrongText);
    }
}
