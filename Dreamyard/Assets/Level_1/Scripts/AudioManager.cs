using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip death;
    public AudioClip takeDamage;
    public AudioClip checkPoint;
    public AudioClip powerActivation;
    public AudioClip portal;
    public AudioClip jump;
    public AudioClip wind;
    public AudioClip coinCollection;
    public AudioClip GameOver;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
