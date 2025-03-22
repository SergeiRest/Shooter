using UnityEngine;

namespace Main
{
    public static class Utilits
    {
        public static void DrawSphere(Vector3 center, float radius, Color color, int segments = 15)
        {
            DrawCircle(center, radius, color, segments, Vector3.up);
            DrawCircle(center, radius, color, segments, Vector3.right);
            DrawCircle(center, radius, color, segments, Vector3.forward);
        }

        private static void DrawCircle(Vector3 center, float radius, Color color, int segments, Vector3 axis)
        {
            for (int i = 0; i <= segments; i++)
            {
                float angle1 = i * Mathf.PI * 2f / segments;
                float angle2 = (i + 1) * Mathf.PI * 2f / segments;

                Vector3 point1 = center + Quaternion.AngleAxis(angle1 * Mathf.Rad2Deg, axis) * (Vector3.forward * radius);
                Vector3 point2 = center + Quaternion.AngleAxis(angle2 * Mathf.Rad2Deg, axis) * (Vector3.forward * radius);

                Debug.DrawLine(point1, point2, color, 100);
            }
        }
    }
}