using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour
{
    [SerializeField] float cameraShakeDuration = .25f;
    [SerializeField] float cameraShakeMagnitude = 0.01f;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shell;

    private AudioSource audioSource;

    private Transform muzzle;
    private Transform shellRelease;

    private void Awake()
    {
        audioSource = GameObject.FindWithTag("Gun").GetComponent<AudioSource>();

        muzzle = GameObject.FindWithTag("Muzzle").transform;
        shellRelease = GameObject.FindWithTag("ShellRelease").transform;
    }

    public void Shoot()
    {
        StartCoroutine(ShakeCamera(cameraShakeDuration, cameraShakeMagnitude, Camera.main.transform));
    }

    private IEnumerator ShakeCamera(float duration, float magnitude, Transform camera)
    {
        Vector3 originalPosition = camera.localPosition;
        float elapsed = 0;
        audioSource.PlayOneShot(audioSource.clip);
        Instantiate(bullet, muzzle.position, muzzle.rotation);
        Instantiate(shell, shellRelease.position, shellRelease.rotation);
        while (elapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            camera.localPosition = new Vector3(x, y, originalPosition.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        camera.localPosition = originalPosition;
    }
}
