using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    #region Character parametrs
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    #endregion

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Vector3 playerDirection;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void Move(CallbackContext inputValue)
    {
        Vector2 value = inputValue.ReadValue<Vector2>();
        playerDirection = new Vector3(value.x, 0, value.y);
    }

    public void Jump()
    {
        if (controller.isGrounded)
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }

    private void Update()
    {
        if (controller.isGrounded && playerVelocity.y < 0)
            playerVelocity.y = 0f;
        controller.Move(playerDirection * Time.deltaTime * playerSpeed);
        if (playerDirection != Vector3.zero)
            gameObject.transform.forward = playerDirection;

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
