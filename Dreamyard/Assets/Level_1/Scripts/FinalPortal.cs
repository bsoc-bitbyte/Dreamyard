using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPortal : MonoBehaviour
{
    GameObject player;
    Animation anim;
    Rigidbody2D rb;
    public player_movement movement;
    public HealthController health;
    public coinManager cm;
    public GameOverScript gameOverScript;
    float startTime;
    public int damage;
    public int death;
    public int timeTaken;
    public int coins;

    AudioManager audioManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animation>();
        rb = player.GetComponent<Rigidbody2D>();
        startTime = Time.time;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                StartCoroutine(portalIn());
            }
        }
    }

    IEnumerator portalIn()
    {
        movement.enabled = false;
        anim.Play("portalAnim");
        audioManager.PlaySFX(audioManager.portal);
        StartCoroutine(MoveInPortal());
        yield return new WaitForSeconds(0.5f);
        GameOver();
    }

    IEnumerator MoveInPortal()
    {
        float timer = 0;
        while (timer < 0.5f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
    }

    public void GameOver()
    {
        damage = health.damageTaken;
        death = health.deaths;
        timeTaken = (int)(Time.time - startTime);
        coins = cm.coinCount;
        gameOverScript.Setup(coins, death, damage, timeTaken);
    }
}
