using UnityEngine;

namespace Modules.UI
{
    public abstract class UIView : MonoBehaviour, IUIView
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}