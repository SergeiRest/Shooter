using UnityEngine;
using VContainer.Unity;

namespace VContainer
{
    public class ScriptableObjectsInstaller : ScriptableObject, IInstaller
    {
        public virtual void Install(IContainerBuilder builder)
        {
            throw new System.NotImplementedException();
        }
    }
}