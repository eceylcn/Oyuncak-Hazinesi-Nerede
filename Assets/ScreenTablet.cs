using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTablet : MonoBehaviour
{
   public List<GameObject> tabletScreens;

   private void OnEnable()
   {
      GameEvents.PageAdvanced += CloseAllScreenTablets;
   }

   private void OnDisable()
   {
      GameEvents.PageAdvanced -= CloseAllScreenTablets;
   }

   public void CloseAllScreenTablets()
   {
      foreach (var tabletScreen in tabletScreens)
      {
         tabletScreen.SetActive(false);
      }
      gameObject.SetActive(false);
   }
}
