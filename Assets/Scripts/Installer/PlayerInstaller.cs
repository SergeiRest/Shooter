using Input;
using Input.InputListener;
using Player;
using UnityEngine;
using VContainer;

namespace Installer
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerComponent _playerComponent;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<MouseRotator>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<KeyBoardListener>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GroundChecker>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<Player.Player>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(_playerComponent);
        }
    }
}