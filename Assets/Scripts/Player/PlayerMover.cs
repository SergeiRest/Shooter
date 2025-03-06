using Input;
using Input.InputListener;
using UnityEngine;

namespace Player
{
    public class PlayerMover
    {
        private readonly IInputListener _inputListener;
        private readonly IGroundChecker _groundChecker;
        private readonly Transform _transform;
        private float _speed = 10;
        private float _gravity = 5f;
        
        public PlayerMover(
            IInputListener inputListener,
            IGroundChecker groundChecker,
            Transform transform)
        {
            _inputListener = inputListener;
            _transform = transform;
            _groundChecker = groundChecker;
        }

        public void FixedTick()
        {
            Vector3 axis = _inputListener.GetAxisRaw();
            

            var position = _transform.position;
            position += _transform.forward * axis.y * _speed * Time.fixedDeltaTime;
            position += _transform.right * axis.x * _speed * Time.fixedDeltaTime;
            if(!_groundChecker.IsOnGround(_transform))
                position += -_transform.up * _gravity * Time.fixedDeltaTime;
            
            _transform.position = position;
        }
    }
}