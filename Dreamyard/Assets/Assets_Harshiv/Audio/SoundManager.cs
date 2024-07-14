using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource soundSource;
    private AudioSource attackSoundSource; // Separate source for attack sounds
    private Dictionary<AudioClip, AudioSource> playingSounds = new Dictionary<AudioClip, AudioSource>();

    private void Awake()
    {
        instance = this;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        soundSource = audioSources[0];
        attackSoundSource = audioSources.Length > 1 ? audioSources[1] : gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound, float volume = 1.0f)
    {
        soundSource.PlayOneShot(_sound, volume);
    }

    public void PlayAttackSound(AudioClip _sound, float volume = 1.0f)
    {
        attackSoundSource.clip = _sound;
        attackSoundSource.volume = volume;
        attackSoundSource.Play();
        playingSounds[_sound] = attackSoundSource;
    }

    public void StopSound(AudioClip _sound)
    {
        if (playingSounds.ContainsKey(_sound))
        {
            playingSounds[_sound].Stop();
            playingSounds.Remove(_sound);
        }
    }

    public void StopAllSounds()
    {
        soundSource.Stop();
        attackSoundSource.Stop();
        playingSounds.Clear();
    }
}
