using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnalysisAnswer : MonoBehaviour
{
   public int SelectedNumber;
   private int _rewardNumber = 2;

   public Button _Button;
   public TabletGoal _TabletGoal;

   public void SendFeedback()
   {
      if (SelectedNumber == _rewardNumber)
      {
         GameEvents.CheckAnswer.Invoke(true," Tebrikler! Su saf bir maddedir ve donma olayı boyunca sıcaklığı donma noktasında sabit kalır!");
         _Button.interactable = false;
         _TabletGoal.isAnswered = true;
         GameEvents.GoalUpdate.Invoke();
         return;
      }
      GameEvents.CheckAnswer.Invoke(false,"Lütfen seçimini tekrar değerlendir.");
   }

   public void ChangeIndex(int index)
   {
      SelectedNumber = index;
   }
}
