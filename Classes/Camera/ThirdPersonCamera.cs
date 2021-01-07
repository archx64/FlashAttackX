using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private readonly float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private Transform cameraRig;
    private Transform target;
    private Transform cameraParent;


    private void Awake()
    {
        cameraRig = GameObject.FindWithTag("CameraRig").transform;
        target = GameObject.FindWithTag("CameraLookTarget").transform;
        cameraParent = GameObject.FindWithTag("CameraParent").transform;
    }


    private void FixedUpdate()
    {
        cameraParent.LookAt(target);
        cameraParent.position = Vector3.SmoothDamp(cameraParent.position, cameraRig.position, ref velocity, smoothTime);
    }
}
