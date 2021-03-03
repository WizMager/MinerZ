using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float gravity = 0.1f;

    private Vector3 move = Vector3.zero;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            move = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            
        }

        if (Input.GetKeyUp(KeyCode.Space) && characterController.isGrounded)
        {
            move.y = jumpForce;
        }

        if (!characterController.isGrounded)
        {
            move.y -= gravity;
        }
    }

    private void FixedUpdate()
    {
        move = move * moveSpeed * Time.deltaTime;
        characterController.Move(move);
    }
}
