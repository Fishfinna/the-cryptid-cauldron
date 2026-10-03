using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //get the input for player
    //apply movement ot sprite
    //transform.position holds the location of the game object
    // we will create the speed ourselves, we will get time with Time.deltaTime
    public float speed;
    public Animator animator;


    // rigid body controller
    public Rigidbody2D rb;

    private void Update()
    {
        //this update to get the user input for triggering motion
        //we are going to use the Input.GetAxisRaw() to get a number between -1 and 1


        //get the values
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");



        //create the movement vector
        Vector3 direction = new Vector3(horizontal, vertical);

        AnimateMovement(direction);

        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);

            }
            else
            {
                animator.SetBool("isMoving", false);
            }

        }
    }
}


