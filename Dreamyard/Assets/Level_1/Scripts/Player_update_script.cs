using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Player_update_script : MonoBehaviour
{
    public coinManager cm;
    public SpriteRenderer playerColor;
    public Sprite_change_script color;
    public player_movement movement;
    public Color defaultColor;
    public float boostTimer;
    public float boostTimerB;
    public float boostTimerR;
    public float boostTimerY;
    public float boostTimerG;
    public bool isInEffect;

    public HealthController healthController;

    [SerializeField]private ParticleSystem powerUp;
    private int counter = 0;

    AudioManager audioManager;

    public FinalPortal FinalPortal;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        boostTimer = 0;
        playerColor = GetComponent<SpriteRenderer>();
        defaultColor = color.squareColor[4];
    }

    private void Update()
    {
        if(transform.position.y<-15)
        {
            FinalPortal.GameOver();
            transform.position = new Vector2(-20, -2);
        }
        if (playerColor.color == color.squareColor[0])
        {
            boostTimerB += 1 * Time.deltaTime;
            boostTimerR = 0;
            boostTimerG = 0;
            boostTimerY = 0;
            isInEffect = true;
        }
        else if (playerColor.color == color.squareColor[1])
        {
            boostTimerR += 1 * Time.deltaTime;
            boostTimerB = 0;
            boostTimerG = 0;
            boostTimerY = 0;
            isInEffect = true;
        }
        else if (playerColor.color == color.squareColor[2])
        {
            boostTimerG += 1 * Time.deltaTime;
            boostTimerB = 0;
            boostTimerR = 0;
            boostTimerY = 0;
            isInEffect = true;
        }
        else if (playerColor.color == color.squareColor[3])
        {
            boostTimerY += 1 * Time.deltaTime;
            boostTimerB = 0;
            boostTimerG = 0;
            boostTimerR = 0;
            isInEffect = true;
        }
        boostTimer = boostTimerR + boostTimerB + boostTimerG + boostTimerY;
        if (boostTimer > 10)
        {
            isInEffect = false;
            boostTimer = 0;
            boostTimerG = 0;
            boostTimerB = 0;
            boostTimerR = 0;
            boostTimerY = 0;
            playerColor.color = defaultColor;
            movement.newSpeed = 0;
        }
        if (playerColor.color == color.squareColor[3]) movement.moveSpeed = 12;
        else movement.moveSpeed = 6;
        if (playerColor.color == color.squareColor[2]) healthController.currenthealth += 2 * Time.deltaTime;
        if(counter==0 && boostTimer > 0)
        {
            powerUp.Play();
            Debug.Log("powerUp");
            counter = 1;
        }
        else if ( boostTimer == 0)
        {
            powerUp.Stop();
            counter = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin") && !cm.isCollected)
        {
            cm.isCollected = true;
            Destroy(collision.gameObject);
            audioManager.PlaySFX(audioManager.coinCollection);
            cm.coinCount++;
        }
    }
}
