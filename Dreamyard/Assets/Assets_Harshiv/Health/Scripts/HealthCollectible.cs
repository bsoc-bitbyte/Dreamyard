using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue = 1f;
    [SerializeField] private AudioClip healthClip;
    [SerializeField] private float volume;
    private bool collected = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collected)
        {
            SoundManager.instance.PlaySound(healthClip, volume);
            collected = true;
            collision.GetComponent<Health>().AddHealth(healthValue);
            GetComponent<BoxCollider2D>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
