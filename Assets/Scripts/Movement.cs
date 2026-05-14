using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float gravity = 20f;     // Better gravity value

    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector3 movementVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // === Left / Right Movement (A & D) ===
        movementVelocity.x = moveInput.x * moveSpeed;
        
        // Keep forward movement at 0 (no automatic forward)
        movementVelocity.z = 0f;

        // Apply gravity
        if (characterController.isGrounded)
        {
            movementVelocity.y = -2f;           // Small negative value when grounded
        }
        else
        {
            movementVelocity.y -= gravity * Time.deltaTime;
        }

        // Move the character
        characterController.Move(movementVelocity * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}