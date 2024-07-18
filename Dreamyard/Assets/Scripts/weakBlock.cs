using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakBlock : MonoBehaviour
{
    public SpriteRenderer playerColor;
    public Sprite_change_script color;

    public ParticleSystem particle;

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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("weakBlock") && playerColor.color == color.squareColor[1])
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.takeDamage);
            Destroy(collision.gameObject);
        }
    }
}
