using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Float")]
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float _runningSpeed;
    
    private float MouseInput;
    private Vector3 input;
    
    private Rigidbody rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        getInput();
        CharacterAnim();
        CharacterRotation();
    }
    
    //to control the character rotation with mouse button
    private void CharacterRotation()
    {
        if (Input.GetMouseButton(1))
        {
            MouseInput = Input.GetAxis("Mouse X");
            //use vector3.up because we want to rotate y axis
            transform.Rotate(Vector3.up * MouseInput * sensitivity);
            Cursor.lockState = CursorLockMode.Locked;
        }else if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    //character animation
    private void CharacterAnim()
    {
        if (input != Vector3.zero)
        {
            _runningSpeed = 1f;
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _runningSpeed = 1.5f;
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    
    //inputs of character controller
    private void getInput()
    {
        input.z = Input.GetAxis("Vertical");
        input.x = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.TransformDirection(input) * speed * _runningSpeed * Time.fixedDeltaTime);
    }
}
