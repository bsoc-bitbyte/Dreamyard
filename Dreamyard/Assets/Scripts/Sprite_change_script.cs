using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Sprite_change_script : MonoBehaviour
{
    public SpriteRenderer player;
    public Color[] squareColor;
    string groundTag;

    void Awake()
    {
        player = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // Initialize anything if needed
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        groundTag = collision.gameObject.tag;
        ChangeSprite();
    }

    void ChangeSprite()
    {
        switch (groundTag)
        {
            case "blueTile":
                player.color = squareColor[0];
                break;
            case "redTile":
                player.color = squareColor[1];
                break;
            case "greenTile":
                player.color = squareColor[2];
                break;
            case "yellowTile":
                player.color = squareColor[3];
                break;
            default:
                break;
        }
    }
}
