using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject gun;

    private Transform gunTransform;
    private Transform rightHand;
    private Transform laserStart;
    private Transform laserEnd;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        gun = GameObject.FindWithTag("Gun");
        gunTransform = GameObject.FindWithTag("Gun").transform;
        rightHand = GameObject.FindWithTag("RightHand").transform;
        laserStart = gunTransform.transform.Find("laser");
        laserEnd = gunTransform.transform.Find("laserEnd");
    }


    private void Start()
    {
        lineRenderer = gun.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
        lineRenderer.startColor = new Color(255, 0, 0);
        lineRenderer.endColor = new Color(255, 0, 0);
        gunTransform.SetParent(rightHand);
        gunTransform.localPosition = new Vector3(-0.01f, 0.073f, 0.023f);
        gunTransform.localEulerAngles = new Vector3(-78.785f, 102.376f, -6.213f);
    }


    private void FixedUpdate()
    {
        Laser(laserStart, laserEnd);
    }


    private void Laser(Transform origin, Transform end)
    {
        if (Physics.Linecast(origin.position, end.position, out RaycastHit hit))
        {
            // sDebug.DrawRay(origin.position, origin.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            // Debug.Log("Did Hit");

            lineRenderer.SetPosition(0, origin.position);
            lineRenderer.SetPosition(1, hit.point);
        }

        else
        {
            // Debug.DrawRay(origin.position, origin.forward * 100, Color.red);
            // Debug.Log("Did not Hit");

            lineRenderer.SetPosition(0, origin.position);
            lineRenderer.SetPosition(1, end.position);
        }


    }
}
