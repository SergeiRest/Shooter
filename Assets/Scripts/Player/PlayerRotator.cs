using Input;
using UnityEngine;

namespace Player
{
    public class PlayerRotator
    {
        private Transform _transform;
        private IInputRotator _inputRotator;
        
        public PlayerRotator(Transform body, IInputRotator rotator)
        {
            _transform = body;
            _inputRotator = rotator;
        }

        public void FixedTick()
        {
            Vector3 axis = _inputRotator.GetAxis();
            if(axis == Vector3.zero)
                return;

            var angle = _transform.localEulerAngles + new Vector3(-axis.y, axis.x);
            float clampedX = Mathf.Clamp(WrapAngle(angle.x), -25, 25);
            Quaternion quaternion = Quaternion.Euler(new Vector3(clampedX, angle.y, 0));

            _transform.localRotation = quaternion;
        }
        
        private float WrapAngle(float angle)
        {
            if (angle > 180f)
                angle -= 360f;
            else if (angle < -180f)
                angle += 360f;
            return angle;
        }
    }
}