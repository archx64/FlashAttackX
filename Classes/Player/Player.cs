using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly MoveController moveController = new MoveController();
    
    [SerializeField] float speed;
    [SerializeField] MouseControl mouseControl;

    private Vector2 mouseInput;

    private InputController inputController;

    private Animator animator;
    private readonly AnimationController animationController = new AnimationController();

    private Transform leftElbow;
    private Transform rightElbow;

    private CharacterController characterController;

    private void Awake()
    {
        inputController = GameManager.Instance.InputController;
 
        animator = GameObject.Find("Jeniffer").GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        
    }



    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(inputController.MovementHorizontal() * speed, 0, inputController.MovementVertical() * speed);
        mouseInput.x = Mathf.Lerp(mouseInput.x, inputController.CameraHorizontal(), mouseControl.damping.x);
        moveController.Move(transform.TransformDirection(direction), characterController);
        moveController.CameraControl(transform, mouseControl.sensitivity.x, mouseInput.x);
        animationController.ControlAnimator(animator, inputController.MovementVertical(), inputController.MovementHorizontal(), inputController.CameraVertical());
    }
}


[System.Serializable]
public class MouseControl
{
    public Vector2 damping;
    public Vector2 sensitivity;
}

