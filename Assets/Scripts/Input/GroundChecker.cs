using UnityEngine;

namespace Input
{
    public class GroundChecker : IGroundChecker
    {
        public bool IsOnGround(Transform transform)
        {
            Physics.SphereCast(transform.position, 0.5f, -Vector3.up, out var info, LayerMask.NameToLayer("Ground"));
            if (info.distance < 0.7f && info.distance != 0)
                return true;
            
            return false;
        }
    }
}