using System;
using UnityEngine;
using VContainer.Unity;

namespace Input
{
    public class MouseRotator : IInputRotator
    {
        private float _senserive = 100;
        private int _ticks = 0;

        public Vector3 GetAxis()
        {
            _ticks++;
            if (_ticks == 2)
                return Vector3.zero;
            
            float x = UnityEngine.Input.GetAxis("Mouse X") * _senserive * Time.fixedDeltaTime;
            float y = UnityEngine.Input.GetAxis("Mouse Y") * _senserive * Time.fixedDeltaTime;

            return new Vector3(x, y, 0);

        }
    }
}