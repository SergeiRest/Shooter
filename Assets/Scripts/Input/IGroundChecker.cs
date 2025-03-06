using UnityEngine;

namespace Input
{
    public interface IGroundChecker
    {
        public bool IsOnGround(Transform transform);
    }
}