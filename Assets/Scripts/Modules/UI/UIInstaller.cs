using UnityEngine;
using VContainer;

namespace Modules.UI
{
    [CreateAssetMenu(fileName = nameof(UIInstaller), menuName = "Settings/Installer/" + nameof(UIInstaller))]
    public class UIInstaller : ScriptableObjectsInstaller
    {
        [SerializeField] private UIView[] _prefabs;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<UIContainer>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(_prefabs);
        }
    }
}