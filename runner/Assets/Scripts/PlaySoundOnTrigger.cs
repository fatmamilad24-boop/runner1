using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            Destroy(gameObject, 0.1f); // remove object after sound
        }
    }
}
