using UnityEngine;

public class AnimationController
{
    public void ControlAnimator(Animator animator, float forward = 0f, float strafe = 0f, float aim = 0f)
    {
        animator.SetFloat("Forward", forward, 0.2f, 2 * Time.deltaTime);
        animator.SetFloat("Strafe", strafe, 0.2f, 2 * Time.deltaTime);
        animator.SetFloat("Aim", aim, 0.2f, 2 * Time.deltaTime);
    }
}
