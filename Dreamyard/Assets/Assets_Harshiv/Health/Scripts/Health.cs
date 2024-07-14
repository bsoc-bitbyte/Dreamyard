using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [Header("Sound")]
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private float volume;

    private Rigidbody2D rb;

    private UIManager uiManager;

    private EndGameManager endGameManager;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        uiManager = FindObjectOfType<UIManager>();
        endGameManager = FindObjectOfType<EndGameManager>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, 10000);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            SoundManager.instance.PlaySound(hurtSound, volume);
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Die");
                SoundManager.instance.PlaySound(deathSound, volume);

                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

                if (gameObject.CompareTag("Player"))
                {
                    rb.velocity = Vector3.zero;
                    StartCoroutine(StartGameOverAfterDelay(2f));
                }

                if (gameObject.CompareTag("Hero"))
                {
                    StartCoroutine(StartGameOverAfterDelay(2f));
                }

                dead = true;
            }

        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, 10);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);

    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    private IEnumerator StartGameOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnDeath();
    }

    public void OnDeath()
    {
        // Check current scene index
        

        if (SceneManager.GetActiveScene().name == "lvl5_Scene5")
        {
            // Scene 5 logic: Call DreamOver for player death, GameOver for hero death
            if (gameObject.CompareTag("Player"))
            {
                StartCoroutine(StartDreamOverAfterDelay(10f));
            }
            else if (gameObject.CompareTag("Hero"))
            {
                endGameManager.GameOver();
            }
        }
        else
        {
            // Default behavior: Always call GameOver for player death
            uiManager.GameOver();
        }
    }

    private IEnumerator StartDreamOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnDeath2();
    }

    public void OnDeath2()
    {
        endGameManager.DreamOver();
    }

}
