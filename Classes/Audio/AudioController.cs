using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip[] footSteps = null;

    private AudioSource footStepSource;
    private InputController inputController;
    private Vector2 value;

    private bool canPlay;

    private void Awake()
    {
        inputController = GameManager.Instance.InputController;
    }

    private void Start()
    {
        canPlay = true;
        footStepSource = GameObject.FindWithTag("FootSteps").GetComponent<AudioSource>();
    }

    private void Update()
    {
        PlaySounds();
    }

    private void PlaySounds()
    {
        value = new Vector2(inputController.MovementHorizontal(), inputController.MovementVertical());
        if (value.magnitude > 0.7f)
        {
            PlayFootSteps(1.5f - value.magnitude, value.magnitude);
        }
    }

    public void PlayFootSteps(float delay, float volume)
    {
        Debug.Log("Playing");
        if (!canPlay)
        {
            return;
        }

        GameManager.Instance.Timer.Add(() =>
        {
            canPlay = true;
        }, delay);
        canPlay = false;

        AudioClip footStep = footSteps[Random.Range(0, footSteps.Length)];
        footStepSource.PlayOneShot(footStep, volume);
    }
}
