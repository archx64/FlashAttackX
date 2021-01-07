using UnityEngine;

public class MoveController
{
    private float gravity;
    public void Move(Vector3 direction, CharacterController characterController)
    {
        if(characterController.isGrounded)
        {
            gravity = 0;
        }
        else
        {
            gravity += 10 * Time.deltaTime;
        }
        // character.Translate(direction * Time.deltaTime, Space.Self);
        characterController.Move((direction * Time.deltaTime) + (-Vector3.up * gravity));


    }

    public void CameraControl(Transform player, float sensitivityX, float x)
    {
        player.Rotate(Vector3.up * x * sensitivityX);
    }
}
