using UnityEngine;

public class ClickSounds : MonoBehaviour
{
    public AudioSource clickSound;
    private bool canPlaySound = false;

    void Start()
    {
        Invoke(nameof(EnableSound), 0.1f);
    }

    void EnableSound()
    {
        canPlaySound = true;
    }

    public void PlayClickSound()
    {
        if (!canPlaySound) return;

        Debug.Log("Audio Played from: " + gameObject.name);
        clickSound.Play();
    }
}