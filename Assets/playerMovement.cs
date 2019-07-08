﻿using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private bool isMoving = false;
    private int xSpeed = 0;
    private int ySpeed = 0;
    private float targetX = 0;
    private float targetY = 0;
    public int moveSpeed = 10;
    private float tileLength = 1;

    // Update is called once per frame
    void Update()
    {
        // Only accept player input after we stop moving
        if (!isMoving) {
            if (Input.GetKey("w") && !Input.GetKey("s")) {
                // Move up
                targetY = transform.position.y + tileLength;
                targetX = transform.position.x;
                ySpeed = moveSpeed;
            } else if (Input.GetKey("s") && !Input.GetKey("w")) {
                // Move down
                targetY = transform.position.y - tileLength;
                targetX = transform.position.x;
                ySpeed = -1 * moveSpeed;
            } else {
                ySpeed = 0;
            }
            
            if (Input.GetKey("a") && !Input.GetKey("d")) {
                // Move left
                targetX = transform.position.x - tileLength;
                targetY = transform.position.y;
                xSpeed = -1 * moveSpeed;
            } else if (Input.GetKey("d") && !Input.GetKey("a")) {
                // Move right
                targetX = transform.position.x + tileLength;
                targetY = transform.position.y;
                xSpeed = moveSpeed;
            } else {
                xSpeed = 0;
            }

            if (xSpeed != 0 || ySpeed != 0) {
                isMoving = true;
                Debug.Log("Starting to move. Setting targetX to " + targetX + " and targetY to " + targetY);
            }
        }

        // Stop and snap to target position if we are about to move past it
        if (isMoving) {
            // Update position with expected coordinates based on velocity
            transform.position = new Vector3(transform.position.x + xSpeed * Time.deltaTime, transform.position.y + ySpeed * Time.deltaTime, transform.position.z);

            // Check if we've gone too far and are ready to stop
            if ((xSpeed > 0 && transform.position.x > targetX) || (xSpeed < 0 && transform.position.x < targetX) || (ySpeed > 0 && transform.position.y > targetY) || (ySpeed < 0 && transform.position.y < targetY))
            {
                Debug.Log("Attempting to stop at target");
                transform.position = new Vector3(targetX, targetY, transform.position.z);
                isMoving = false;
                xSpeed = 0;
                ySpeed = 0;
            }
        }
    }
}
