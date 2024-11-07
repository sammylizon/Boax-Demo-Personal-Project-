using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float circleRadius = 1f;  // Radius of the circle
    public int segments = 36;        // Number of segments in the circle

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Convert mouse position to world point
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Abs(Camera.main.transform.position.z);
            Vector3 center = Camera.main.ScreenToWorldPoint(mousePosition);
            center.z = 0;  // Keep it on the 2D plane

            // Draw a circle at the clicked position
            DrawCircle(center, circleRadius, segments);
            Debug.Log("Circle drawn at: " + center);
        }
    }

    void DrawCircle(Vector3 center, float radius, int segments)
    {
        float angleStep = 360f / segments;
        Vector3 previousPoint = center + new Vector3(radius, 0, 0);  // Start point on the circle's edge

        for (int i = 1; i <= segments; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;  // Convert angle to radians
            Vector3 nextPoint = center + new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);

            // Draw line between the previous point and the next point
            Debug.DrawLine(previousPoint, nextPoint, Color.green, 3f);

            previousPoint = nextPoint;  // Update the previous point
        }
    }
}
