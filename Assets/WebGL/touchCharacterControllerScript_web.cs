using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchCharacterControllerScript_web : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float cameraSensitivity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveInputDeadZone;

    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;

    private int leftFingerId, rightFingerId;
    private float halfScreenWidth;

    private Vector2 lookInput;
    private float cameraPitch;

    private Vector2 moveTouchStartPosition;
    private Vector2 moveInput;
    private Vector3 moveDirection = Vector3.zero;

    public GameObject jumpButton;
    private Button interactButton;

    private bool jumpButtonClicked = false;

    void Start()
    {
        leftFingerId = -1;
        rightFingerId = -1;

        halfScreenWidth = Screen.width / 2;

        moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);

        interactButton = jumpButton.GetComponent<Button>();
        interactButton.onClick.AddListener(OnJumpButtonPressed);
    }

    void Update()
    {
        GetTouchInput();

        if (rightFingerId != -1)
        {
            LookAround();
        }

        if (leftFingerId != -1)
        {
            Move();
        }

        ApplyGravity();
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void GetTouchInput()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    if (t.position.x < halfScreenWidth && leftFingerId == -1)
                    {
                        leftFingerId = t.fingerId;
                        moveTouchStartPosition = t.position;
                    }
                    else if (t.position.x > halfScreenWidth && rightFingerId == -1)
                    {
                        rightFingerId = t.fingerId;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (t.fingerId == leftFingerId) leftFingerId = -1;
                    else if (t.fingerId == rightFingerId) rightFingerId = -1;
                    break;

                case TouchPhase.Moved:
                    if (t.fingerId == rightFingerId)
                    {
                        lookInput = t.deltaPosition * cameraSensitivity * Time.deltaTime;
                    }
                    else if (t.fingerId == leftFingerId)
                    {
                        moveInput = t.position - moveTouchStartPosition;
                    }
                    break;

                case TouchPhase.Stationary:
                    if (t.fingerId == rightFingerId) lookInput = Vector2.zero;
                    break;
            }
        }
    }

    void LookAround()
    {
        cameraPitch = Mathf.Clamp(cameraPitch + lookInput.y, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
        transform.Rotate(transform.up, -lookInput.x);
    }

    void Move()
    {
        if (moveInput.sqrMagnitude <= moveInputDeadZone) return;

        Vector2 movementDirection = moveInput.normalized * moveSpeed * Time.deltaTime;
        characterController.Move(transform.right * movementDirection.x + transform.forward * movementDirection.y);
    }

    void ApplyGravity()
    {
        if (characterController.isGrounded)
        {
            moveDirection.y = 0;

            if (jumpButtonClicked)
            {
                moveDirection.y = jumpSpeed;
                jumpButtonClicked = false;
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
    }

    void OnJumpButtonPressed()
    {
        jumpButtonClicked = true;
    }
}