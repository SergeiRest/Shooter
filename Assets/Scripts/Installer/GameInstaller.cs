using Input.InputListener;
using Main.Enemy;
using Main.Overlap;
using UnityEngine;
using VContainer;
using Weapon;
using Weapon.Bullets;

namespace Installer
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private WeaponStorage weaponStorage;
        [SerializeField] private EnemyContext[] _enemyContexts;
        public override void Install(IContainerBuilder builder)
        {
            // INPUT
            builder.Register<MouseTouchListener>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<OverlapService>(Lifetime.Singleton).AsImplementedInterfaces();
            
            // WEAPON
            builder.RegisterInstance<WeaponStorage>(weaponStorage).AsImplementedInterfaces();
            builder.Register<WeaponFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BulletFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<EnemyFactory>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(_enemyContexts);
        }
    }
}