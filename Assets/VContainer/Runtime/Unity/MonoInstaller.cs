using UnityEngine;
using VContainer.Unity;

namespace VContainer
{
    public class MonoInstaller : MonoBehaviour, IInstaller
    {
        public virtual void Install(IContainerBuilder builder)
        {
            throw new System.NotImplementedException();
        }
    }
}