using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    [SerializeField] Player_update_script player;
    public int[] keysCollected = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<4; i++)
        {
            keysCollected[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("key1") && player.playerColor.color == player.color.squareColor[1])
        {
            Destroy(collision.gameObject);
            keysCollected[0]++;
            Debug.Log("Key1 Collected");
        }
        if (collision.CompareTag("key2") && player.playerColor.color == player.color.squareColor[0])
        {
            Destroy(collision.gameObject);
            keysCollected[1]++;
            Debug.Log("Key2 collected");
        }
        if (collision.CompareTag("key3") && player.playerColor.color == player.color.squareColor[2])
        {
            Destroy(collision.gameObject);
            keysCollected[2]++;
            Debug.Log("Key3 collected");
        }
        if (collision.CompareTag("key4") && player.playerColor.color == player.color.squareColor[3])
        {
            Destroy(collision.gameObject);
            keysCollected[3]++;
            Debug.Log("Key4 collected");
        }
    }
}
