using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using Quaternion = UnityEngine.Quaternion;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // Speed at which the player moves
    private Rigidbody2D rb;

    

    [SerializeField] bool isWalking = false;

    [SerializeField] Animator animator;

    public Vector3 mousePosition;
    public Vector3 playerPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckIfMoving();
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);

        // Apply the movement to the rigidbody
        rb.velocity = movement;

        // Flip the player sprite if moving left
        FlipSpriteToGoWhereMouseIs();
        
        
    }

    void CheckIfMoving()
    {
        if(rb.velocity.magnitude > 0.01f)
        {
            isWalking = true;
            animator.SetBool("Walking", isWalking);
        }
        else 
        {
            isWalking = false;
            animator.SetBool("Walking", isWalking);
        }
    }


  


    void RightYRotationControl()
    {
        Quaternion newRotation = Quaternion.Euler(0, 180, 0);

        // Set the object's rotation to the new rotation
        transform.rotation = newRotation;
    }
    void LeftYRotationControl()
    {
        Quaternion newRotation = Quaternion.Euler(0, 0, 0);

        // Set the object's rotation to the new rotation
        transform.rotation = newRotation;
    }


    void FlipSpriteToGoWhereMouseIs()
    {
        // Get the mouse position in screen coordinates
        Vector3 screenMousePosition = Input.mousePosition;

        // Convert the screen position to world position
        mousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
        playerPosition = transform.position;

        if(mousePosition.x < playerPosition.x)
        {
            
            LeftYRotationControl();
        }
        else if (mousePosition.x > playerPosition.x)
        {
           
            RightYRotationControl();
        }
        
    }
}

