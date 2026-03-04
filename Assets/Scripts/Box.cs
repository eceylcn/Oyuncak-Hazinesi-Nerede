using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public List<int> correctAnswers;
    public List<Button> correctAnswerButtons;
    public List<Button> AllButtons;
    public Sprite correctAnswerAfter;
    public string _wrongAnswer;
    public string _afterDialogue;
    public TabletGoal Goal;
    public int correctAnswer;

    public TMP_Text Text;
    public void GiveAnswer(int index)
    {
        if (correctAnswers.Contains(index))
        {
            GameEvents.CheckAnswer.Invoke(true,index == 0 ? "Doğru! Kırağılaşma olayı ısı kaybı ile gerçekleşir! " : "Doğru! Kırağılaşma, gaz hâlindeki maddenin doğrudan katı hâle geçmesiyle oluşur. Yani bu olay sadece gazlarda gerçekleşebilir!");
            correctAnswerButtons[index].image.sprite = correctAnswerAfter;
            correctAnswerButtons[index].enabled = false;
            correctAnswer++;

            if (correctAnswer >= 2)
            {
                Goal.isAnswered = true;
                GameEvents.GoalUpdate?.Invoke();
                Text.text = _afterDialogue;
                foreach (var button in AllButtons)
                {
                    button.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            GameEvents.CheckAnswer.Invoke(false,_wrongAnswer);
        }
    }
    
}
