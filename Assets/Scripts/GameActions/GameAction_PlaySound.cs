using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class GameAction_PlaySound : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the audio source component
        audioSource = GetComponent<AudioSource> ();   
        audioSource.clip = sound;
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

}
