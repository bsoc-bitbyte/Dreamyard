using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameController gameController;
    public Transform respwanPoint;
    SpriteRenderer spriteRenderer;
    Collider2D coll;

    AudioManager audioManager;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.checkPoint);
            spriteRenderer.color = Color.black;
            gameController.UpdateCheckPoint(respwanPoint.position);
            coll.enabled = false;
        }
    }
}
