using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager2 : MonoBehaviour
{
    public static SoundManager2 instance { get; private set; }
    private List<AudioSource> sources; // List to hold multiple AudioSources
    public Transform playerTransform;
    public float defaultMaxDistance = 10f; // Default max distance for volume calculation
    public float defaultMinVolume = 0.1f; // Default min volume
    public float defaultMaxVolume = 1.0f; // Default max volume

    private void Awake()
    {
        instance = this;
        sources = new List<AudioSource>();
        
    }

    private float CalculateVolume(Transform soundSource, float distance, float maxDistance, float minVolume, float maxVolume)
    {
        float volume = Mathf.Clamp(1 - (distance / maxDistance), minVolume, maxVolume);
        return volume;
    }

    public void UpdateVolumeBasedOnDistance(float maxDistance, float minVolume = 0.1f, float maxVolume = 1.0f)
{
    foreach (AudioSource source in sources)
    {
        float distance = Vector3.Distance(source.transform.position, playerTransform.position);
        float targetVolume = CalculateVolume(source.transform, distance, maxDistance, minVolume, maxVolume);
        source.volume = Mathf.Lerp(source.volume, targetVolume, Time.deltaTime * 5f);  // Smooth transition
    }
}


    public void AddSoundSource(AudioSource newSource)
    {
        if (!sources.Contains(newSource))
        {
            sources.Add(newSource);
        }
    }

    public void PlayLoopingSound(AudioClip clip, AudioSource targetSource, float maxDistance, float minVolume = 0.1f, float maxVolume = 1.0f)
    {
        targetSource.clip = clip;
        targetSource.loop = true;
        targetSource.Play();
        AddSoundSource(targetSource);
        UpdateVolumeBasedOnDistance(maxDistance, minVolume, maxVolume); // Update volume initially
    }
}
