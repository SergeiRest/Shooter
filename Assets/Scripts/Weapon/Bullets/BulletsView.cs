using System.Collections;
using System.Collections.Generic;
using Modules.UI;
using TMPro;
using UnityEngine;

public class BulletsView : UIView
{
   [SerializeField] private TextMeshProUGUI _bulletCount;
   [SerializeField] private TextMeshProUGUI _maxBulletsCount;
   
   public void SetAmount(int value)
   {
      _bulletCount.text = value.ToString();
   }

   public void SetMaxBullets(int value)
   {
      _maxBulletsCount.text = value.ToString();
   }
}
