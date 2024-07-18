using UnityEngine;

public class SoundDisabler : MonoBehaviour
{
    public GameObject uiCanvas; // Reference to the UI Canvas

    // This method should be called when the player dies
    public void OnPlayerDeath()
    {
        // Find all AudioSources in the scene
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // Disable audio clips for non-UI audio sources
        foreach (AudioSource audioSource in allAudioSources)
        {
            // Check if the audio source is not a UI audio source
            if (!IsUIAudioSource(audioSource))
            {
                audioSource.Stop(); // Stop the audio source
                audioSource.clip = null; // Disable audio clip
            }
        }

        // Additional logic for handling player death, such as showing UI, etc.
        // For example, you might want to show a game over screen or reset the level.
    }

    // Helper method to check if an AudioSource is part of the UI Canvas
    private bool IsUIAudioSource(AudioSource audioSource)
    {
        // Check if the audio source is a child of the UI Canvas
        return audioSource.transform.IsChildOf(uiCanvas.transform);
    }
}
