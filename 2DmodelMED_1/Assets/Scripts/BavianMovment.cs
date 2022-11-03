using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BavianMovment : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D bavianBody;
    private Animator bavianAnimator;

    [SerializeField] private int speed = 5;

    private void Awake()
    {
        bavianBody = GetComponent<Rigidbody2D>();
        bavianAnimator = GetComponent<Animator>();
    }
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            bavianAnimator.SetFloat("x", movement.x);
            bavianAnimator.SetFloat("y", movement.y);

            bavianAnimator.SetBool("IsWalking", true);
        }
        else
        {
            bavianAnimator.SetBool("IsWalking", false);
        }

        
       

    }
    
    private void FixedUpdate()
    {
        bavianBody.velocity = movement * speed;
    }
}
