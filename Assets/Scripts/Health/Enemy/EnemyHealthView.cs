using UnityEngine;
using UnityEngine.UI;

namespace Health.Enemy
{
    public class EnemyHealthView : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;

        public void Fill(float amount)
        {
            _healthImage.fillAmount = amount;
        }
    }
}