using Modules.UI;
using TMPro;
using UnityEngine;

namespace Health
{
    public class PlayerHealthView : UIView
    {
        [SerializeField] private TextMeshProUGUI _heathAmount;

        public void SetAmount(int amount)
        {
            _heathAmount.text = amount.ToString();
        }
    }
}