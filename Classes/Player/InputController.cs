using UnityEngine;

public class InputController : MonoBehaviour
{
    private float movementVertical;
    private float movementHorizontal;

    private float cameraVertical;
    private float cameraHorizontal;

    private FloatingJoystick movementJoyStick;
    private FloatingJoystick cameraJoyStick;

    private void Awake()
    {
        movementJoyStick = GameObject.FindWithTag("MovementInput").GetComponent<FloatingJoystick>();
        cameraJoyStick = GameObject.FindWithTag("CameraInput").GetComponent<FloatingJoystick>();
    }

    private void QuitCheck()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        movementVertical = movementJoyStick.Vertical;
        movementHorizontal = movementJoyStick.Horizontal;
        cameraHorizontal = cameraJoyStick.Horizontal;
        cameraVertical += cameraJoyStick.Vertical * 0.5f;
        cameraVertical = Mathf.Clamp(cameraVertical, -10, 10);

        QuitCheck();
    }

    public float MovementVertical()
    {
        return movementVertical;
    }

    public float MovementHorizontal()
    {
        return movementHorizontal;
    }

    public float CameraVertical()
    {
        return cameraVertical;
    }

    public float CameraHorizontal()
    {
        return cameraHorizontal;
    }
}
