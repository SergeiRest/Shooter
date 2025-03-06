using System.Linq;
using Input.InputListener;
using Modules.UI;
using UniRx;
using UnityEngine;
using VContainer;
using Weapon.Data;

namespace Weapon
{
    public class PlayerWeaponController : WeaponController
    {
        [Inject] private IWeaponFactory _weaponFactory;
        [Inject] private IWeaponStorage _weaponStorage;
        [Inject] private IObjectResolver _objectResolver;
        [Inject] private ITouchListener _touchListener;
        [Inject] private IUIContainer _uiContainer;

        private Transform _weaponTransform;
        private BaseWeapon _selected;
        private CompositeDisposable _compositeDisposable;

        public PlayerWeaponController(Transform weaponTransform)
        {
            _weaponTransform = weaponTransform;
        }
        
        public override void SetWeapon(string name)
        {
            _compositeDisposable?.Dispose();
            _compositeDisposable = new CompositeDisposable();
            IWeaponData weaponData = _weaponStorage.Weapons.First(x => x.WeaponId == name);
            WeaponContext context = _weaponFactory.GetWeapon(name);
            Transform contextTransform = context.transform;
            contextTransform.SetParent(_weaponTransform);
            contextTransform.localScale = Vector3.one;
            contextTransform.localPosition = Vector3.zero;

            _selected = new BaseWeapon(weaponData.MaxBullets, weaponData.BulletId, context);
            _objectResolver.Inject(_selected);

            _touchListener.LeftMouseButton.Subscribe(_ =>
            {
                _selected.Shot();
            }).AddTo(_compositeDisposable);
            
            BulletsView view = _uiContainer.GetUI<BulletsView>();
            view.SetMaxBullets(weaponData.MaxBullets);

            _selected.BulletsCount.Subscribe(view.SetAmount).AddTo(_compositeDisposable);

        }
    }
}