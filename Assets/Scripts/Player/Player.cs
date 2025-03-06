using System;
using Health;
using Input;
using Input.InputListener;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Weapon;

namespace Player
{
    public class Player : IFixedTickable, IStartable, IDisposable
    {
        private readonly IObjectResolver _objectResolver;
        private readonly PlayerComponent _component;
        
        private PlayerRotator _playerRotator;
        private PlayerMover _playerMover;
        private PlayerWeaponController _weaponController;
        private PlayerHealthController _healthController;
        
        public Player(
            IInputRotator inputRotator,
            IInputListener inputListener,
            IGroundChecker groundChecker,
            IObjectResolver resolver,
            PlayerComponent component)
        {
            _component = component;
            _playerRotator = new PlayerRotator(_component.Main, inputRotator);
            _playerMover = new PlayerMover(inputListener, groundChecker, _component.Main);
            _objectResolver = resolver;

        }

        public void FixedTick()
        {
            _playerRotator.FixedTick();
            _playerMover.FixedTick();
        }

        public void Start()
        {
            _healthController = new PlayerHealthController();
            _weaponController = new PlayerWeaponController(_component.WeaponRoot);
            
            _objectResolver.Inject(_weaponController);
            _objectResolver.Inject(_healthController);

            _weaponController.SetWeapon("DebugWeapon");
        }

        public void Dispose()
        {
            _healthController?.Dispose();
        }
    }
}