using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.ParticleSystem;

public class ParticleController : MonoBehaviour
{

    public Player_update_script player;
    public Sprite_change_script sprite;
    public ParticleSystem strength;
    public ParticleSystem heal;
    public ParticleSystem wind;
    public ParticleSystem speed;
    public SpriteRenderer Playercolor;

    int counterR = 1;
    int counterB = 1;
    int counterG = 1;
    int counterY = 1;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Playercolor.color == sprite.squareColor[1] && counterR == 1)
        {
            audioManager.PlaySFX(audioManager.powerActivation);
            Instantiate(strength, transform.position, Quaternion.identity);
            counterR = 0;
            counterB = 1;
            counterY = 1;
            counterG = 1;
        }
        else if (Playercolor.color == sprite.squareColor[0] && counterB == 1)
        {
            audioManager.PlaySFX(audioManager.powerActivation);
            audioManager.PlaySFX(audioManager.wind);
            Instantiate(wind, transform.position, Quaternion.identity);
            counterB = 0;
            counterR = 1;
            counterY = 1;
            counterG = 1;
        }
        else if (Playercolor.color == sprite.squareColor[2] && counterG == 1)
        {
            audioManager.PlaySFX(audioManager.powerActivation);
            Instantiate(heal, transform.position, Quaternion.identity);
            counterG = 0;
            counterB = 1;
            counterY = 1;
            counterR = 1;
        }
        else if (Playercolor.color == sprite.squareColor[3] && counterY == 1)
        {
            audioManager.PlaySFX(audioManager.powerActivation);
            Instantiate(speed, transform.position, Quaternion.identity);
            counterY = 0;
            counterB = 1;
            counterR = 1;
            counterG = 1;
        }
        else if (Playercolor.color == sprite.squareColor[4])
        {
            counterY = 1;
            counterB = 1;
            counterR = 1;
            counterG = 1;
        }
    }
}
