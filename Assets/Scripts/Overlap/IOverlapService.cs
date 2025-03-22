using UnityEngine;
using VContainer.Unity;

namespace Main.Overlap
{
    public interface IOverlapService
    {
        public void OverlapSphere(Vector3 position, float radius, int layerMask);
    }

    public class OverlapService : IOverlapService, IStartable
    {
        public OverlapService()
        {
        }
        
        public void OverlapSphere(Vector3 position, float radius, int layerMask = default)
        {
            Collider[] results = new Collider[100];
            var size = Physics.OverlapSphereNonAlloc(position, radius, results, layerMask);
            Utilits.DrawSphere(position, radius, Color.blue, 25);

            Debug.Log(size);
            foreach (var result in results)
            {
                if(result == null)
                    continue;
                
                Debug.Log(result.gameObject.name);
            }
        }

        public void Start()
        {
            
        }
    }
}