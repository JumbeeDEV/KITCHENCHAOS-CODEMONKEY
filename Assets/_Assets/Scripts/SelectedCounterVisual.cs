using System;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
     [SerializeField] private ClearCounter clearCounter;
     [SerializeField] private GameObject selectedCounterVisual;

     private void Start()
     {
          Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
     }

     private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
     {
          if (e.eventSelectedCounter == clearCounter)
          {
               ShowSelectedCounterVisual();
          }
          else
          {
               HideSelectedCounterVisual();
          }

     }

     private void ShowSelectedCounterVisual()
     {
          selectedCounterVisual.SetActive(true);
     }

     private void HideSelectedCounterVisual()
     {
          selectedCounterVisual.SetActive(false);
     }
     
}