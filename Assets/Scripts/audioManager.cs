using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class audioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public static audioManager instance;

    public AudioClip background;
    public AudioClip jump;
    public AudioClip slide;
    public AudioClip charHit;
    public AudioClip busStart;
    public AudioClip busIdle;
    public AudioClip scream;
    public AudioClip buttonPress;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

}
