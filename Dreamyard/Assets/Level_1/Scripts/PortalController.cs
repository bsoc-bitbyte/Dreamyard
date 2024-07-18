using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public Transform destination;
    GameObject player;
    Animation anim;
    Rigidbody2D rb;
    public player_movement movement;

    AudioManager audioManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animation>();
        rb = player.GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 0.75f)
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
        player.transform.position = destination.position;
        rb.velocity = Vector2.zero;
        anim.Play("portalout");
        yield return new WaitForSeconds(0.5f);
        movement.enabled = true;
    }

    IEnumerator MoveInPortal()
    {
        float timer = 0;
        while (timer < 0.5f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 3*Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
    }
}
