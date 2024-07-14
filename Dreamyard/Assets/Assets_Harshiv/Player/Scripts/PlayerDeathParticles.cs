using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathParticles : MonoBehaviour
{
    public string playerTag = "Player"; // Tag of the player GameObject
    public GameObject deathParticles; // Drag your Particle System GameObject here in the Inspector

    public int targetSceneIndex = 5;

    private GameObject player; // Reference to the player GameObject
    private ParticleSystem particlesSystem; // Reference to the Particle System component

    void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex != targetSceneIndex)
        {
            // Disable the script if not in the target scene
            this.enabled = false;
            return;
        }
        // Find the player GameObject using its tag
        player = GameObject.FindWithTag(playerTag);

        // Get the Particle System component attached to this GameObject
        particlesSystem = deathParticles.GetComponent<ParticleSystem>();

        // Disable the particle system initially
        deathParticles.SetActive(false);

        // Check if player and particleSystem are not null
        if (player != null && particlesSystem != null)
        {
            // Set the position of the Particle System to match the player's position
            particlesSystem.transform.position = player.transform.position;
        }
        else
        {
            Debug.LogWarning("Player or Particle System not found!");
        }
    }

    // Method called by animation event when player dies
    public void StartDeathParticles()
    {
        // Check if the current scene is the target scene
        if (SceneManager.GetActiveScene().buildIndex == targetSceneIndex)
        {
            if (deathParticles != null)
            {
                // Set the position of the particle system to match the player's position
                particlesSystem.transform.position = player.transform.position;

                // Activate the particle system
                deathParticles.SetActive(true);
            }

            // Add other death-related effects or actions here
        }
    }
}
