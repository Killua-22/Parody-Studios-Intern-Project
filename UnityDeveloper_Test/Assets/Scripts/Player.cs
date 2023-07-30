using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform orientation;
    Animator _animator;
    [SerializeField]
    private float speed = 3.5f;
    [SerializeField]
    private float gravity = 9.81f;

    public float rotationSpeed = 10f;
    Vector3 moveDirection;
    float horizontalInput;
    float verticalInput;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    
    public void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(moveDirection == Vector3.zero)
        {
            _animator.SetBool("isRunning", false);
        }
        else
        {
            _animator.SetBool("isRunning", true);
        }

        rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
    }
}
