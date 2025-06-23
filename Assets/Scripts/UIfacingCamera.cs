using UnityEngine;

public class UIfacingCamera : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void LateUpdate()
    {
        // Get direction to camera, but flatten Y to avoid tilting
        Vector3 directionToCamera = mainCamera.transform.position - transform.position;
        directionToCamera.y = 0f;  // Ignore vertical tilt

        if (directionToCamera != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(-directionToCamera);
            transform.rotation = lookRotation;
        }
    }
}