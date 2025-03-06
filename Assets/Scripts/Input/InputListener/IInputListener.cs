using UnityEngine;

namespace Input.InputListener
{
    public interface IInputListener
    {
        public Vector2 GetAxis();
        public Vector2 GetAxisRaw();
    }
}