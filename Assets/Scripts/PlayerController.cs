using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _comprigidbody3D;
    public float speedX;
    public float JumpingPower;
    public int maxJumps = 2;
    private int jumpsRemaining;
    public float raycastDistance = 1f;
    public JK jk;
    public float _xMovement;
    public float _zMovement;
    public bool _jump;
    public LayerMask collisionMask;

   


    private void Awake()
    {
        _comprigidbody3D = GetComponent<Rigidbody>();
        jumpsRemaining = maxJumps;


    }

    void FixedUpdate()
    {
        Move();

        if (_jump && jumpsRemaining > 0)
        {
            Jump();
        }

        CheckGrounded();
    }

    void Move()
    {
        _comprigidbody3D.velocity = new Vector3(_xMovement * speedX, _comprigidbody3D.velocity.y, _zMovement * speedX);
    }

    void Jump()
    {
        _comprigidbody3D.velocity = new Vector3(_comprigidbody3D.velocity.x, JumpingPower, _comprigidbody3D.velocity.z);
        jumpsRemaining = jumpsRemaining - 1;
        _jump = false;
    }

    void CheckGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, collisionMask))
        {
            jumpsRemaining = maxJumps;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * raycastDistance);
    }

    public void OnMovementX(InputAction.CallbackContext context)
    {
        _xMovement = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _jump = context.performed;
    }

    public void OnMovementZ(InputAction.CallbackContext context)
    {
        _zMovement = context.ReadValue<float>();
    }

    public void OnPreviousCharacter(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jk.SwitchToPreviousCharacter();
        }
    }

    public void OnNextCharacter(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jk.SwitchToNextCharacter();
        }
    }


}
