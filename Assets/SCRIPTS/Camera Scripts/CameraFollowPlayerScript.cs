using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerScript : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float smoothSpeed = 5.0f;  // Smoothing factor for camera movement
    public Vector3 offset;  // Offset distance between the player and the camera

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the target position for the camera
            Vector3 desiredPosition = player.position + offset;

            // Use Lerp to smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, smoothedPosition.z);
        }
    }
}
