using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltInteraction : MonoBehaviour
{

    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform otherCrosshair;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float maxDistance = 100.0f;
    [SerializeField] private GameObject player;

    void Update()
    {
        Vector3 target = mainCamera.position + mainCamera.forward * 2;
        this.transform.position = target;
        transform.LookAt(mainCamera.position);

        otherCrosshair.position = target;
        otherCrosshair.LookAt(mainCamera.position);
        otherCrosshair.Rotate(0, 0, 45);
        transform.Rotate(0, 0, -mainCamera.rotation.eulerAngles.z * 2);

        float angle = Vector3.Angle(mainCamera.forward, otherCrosshair.forward);

        // If the angle is within a certain threshold, perform the jump
        if (angle > 10.0f) // Adjust the threshold as needed
        {
            // Perform a raycast to find the target position
            Ray ray = new Ray(mainCamera.position, mainCamera.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance, interactableLayer))
            {
                Debug.Log("Jump");
                // Get the target position from the raycast hit
                Vector3 jumpTarget = hit.point;

                // Jump to the target position
                player.transform.position = jumpTarget;

                // Rotate the player to look at the camera
                transform.LookAt(mainCamera.position);

                // Apply additional rotation based on the camera's tilt
                transform.Rotate(0, 0, -mainCamera.rotation.eulerAngles.z * 2);
            }
        }
    }
}
