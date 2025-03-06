using System;
using UnityEngine;

namespace Weapon.Bullets
{
    public class BaseBullet : Bullet
    {
        private void FixedUpdate()
        {
            transform.position += transform.forward * 5 * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy();
        }
    }
}