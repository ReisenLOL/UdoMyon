using System;
using UnityEngine;

public class DirectionsTest : MonoBehaviour
{
    public Transform[] allDirections;
    public Camera cam;
    public Vector3 directionToMove;
    private void Update()
    {
        Vector3 mouseWorldPos =  cam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,cam.nearClipPlane));
        float distanceToTarget = Vector3.Distance(mouseWorldPos, transform.position);
        Vector3 directionToTarget = (mouseWorldPos - transform.position).normalized;
        directionToMove = directionToTarget;
        float currentHighestScore = float.NegativeInfinity;
        Vector3 strafeDirection = new Vector3(directionToTarget.y, -directionToTarget.x);
        Vector3 directionToStrafe = strafeDirection;
        foreach (Transform direction in allDirections)
        {
            Vector3 directionToPoint = (direction.position - transform.position).normalized;
            float forwardScore = Vector3.Dot(directionToPoint, directionToTarget);
            float strafeScore = Vector3.Dot(directionToPoint, strafeDirection);
            float finalScore = (forwardScore * 0.7f) + (strafeScore * 0.3f);
            Debug.Log($"Forward: {forwardScore} Strafe: {strafeScore} Final: {finalScore}");
            if (finalScore > currentHighestScore)
            {
                Debug.Log($"{finalScore} is higher than current score: {currentHighestScore}");
                currentHighestScore = finalScore;
                directionToMove = directionToPoint;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, directionToMove, Color.green);
    }
}
