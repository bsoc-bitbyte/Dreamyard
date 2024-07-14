using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    public SoundDisabler audioManager;

    public void HandlePlayerDeath()
    {
        if (audioManager != null)
        {
            audioManager.OnPlayerDeath();
        }
    }
}
