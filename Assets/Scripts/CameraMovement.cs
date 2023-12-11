using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;
    private Vector3 PlayerMouseInput;
    private float xRot;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private CharacterController Controller;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;

    void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }
    private void MovePlayer()
    {
        Vector3 forwardDirection = Vector3.Scale(PlayerCamera.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveDirection = forwardDirection * PlayerMovementInput.z + PlayerCamera.right * PlayerMovementInput.x;

        Controller.Move(moveDirection * Speed * Time.deltaTime);
        Controller.Move(Velocity * Speed * Time.deltaTime);

        Velocity.y = 0f;
    }

    private void MovePlayerCamera()
    {
        if (Input.GetMouseButton(1))
        {
            xRot -= PlayerMouseInput.y * Sensitivity;
            xRot = Mathf.Clamp(xRot, -90f, 90f);

            transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
            PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, transform.rotation.eulerAngles.y, 0f);
        }
    }

}