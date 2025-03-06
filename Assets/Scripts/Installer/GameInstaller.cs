using Input.InputListener;
using UnityEngine;
using VContainer;
using Weapon;
using Weapon.Bullets;

namespace Installer
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private WeaponStorage weaponStorage;
        public override void Install(IContainerBuilder builder)
        {
            // INPUT
            builder.Register<MouseTouchListener>(Lifetime.Singleton).AsImplementedInterfaces();
            
            // WEAPON
            builder.RegisterInstance<WeaponStorage>(weaponStorage).AsImplementedInterfaces();
            builder.Register<WeaponFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BulletFactory>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}