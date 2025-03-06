using UnityEngine;

namespace Input.InputListener
{
    public class KeyBoardListener : IInputListener
    {
        public Vector2 GetAxis()
            => new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));

            public Vector2 GetAxisRaw() 
            => new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
    }
}