using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_1 : MonoBehaviour
{
    private S sscript;
    private L lscript;
    private I iscript;
    private N nscript;
    private G gscript;
    public GameObject spawnObject;
    public GameObject spawnObject1;
    public bool T=false;
    private bool ball_collide = false;
    private bool button_pressed=false;
    private string String;
    private string String1=""+"S"+"L"+"I"+"N"+"G";
    private char checker='\0';
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        S[] sscripts = FindObjectsOfType<S>();
        L[] lscripts = FindObjectsOfType<L>();
        I[] iscripts = FindObjectsOfType<I>();
        N[] nscripts = FindObjectsOfType<N>();
        G[] gscripts = FindObjectsOfType<G>();

        if (sscripts.Length > 0)
            sscript = sscripts[0];
        if (lscripts.Length > 0)
            lscript = lscripts[0];
        if (iscripts.Length > 0)
            iscript = iscripts[0];
        if (nscripts.Length > 0)
            nscript = nscripts[0];
        if (gscripts.Length > 0)
            gscript = gscripts[0];
        String = "";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "circle")
        {if(button_pressed)
            ball_collide = true;
            checker = '\0';
            Debug.Log(ball_collide);
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(sscript.S_pressed || checker == 'S')
        {

            checker = 'S';
            
            if (ball_collide)
            {
                audioManager.Playsfx(audioManager.Ball_destroy);
                Debug.Log("1");
                String += "S";
                Debug.Log(String);
                ball_collide = false;
                checker = '\0';
                button_pressed = false;
                sscript.SetPressedfalse();
            }
        }
        if (lscript.L_pressed || checker == 'L')
        {
            checker = 'L';
            
            if (ball_collide)
            {
                audioManager.Playsfx(audioManager.Ball_destroy);
                Debug.Log("2");
                String = String + "L";
                Debug.Log(String);
                ball_collide = false;
                checker = '\0';
                lscript.SetPressedfalse();
                button_pressed = false;
            }

        }
        if (iscript.I_pressed || checker == 'I')
        {
            checker = 'I';
            
            if (ball_collide)
            {
                audioManager.Playsfx(audioManager.Ball_destroy);
                Debug.Log("3");
                String += "I";
                Debug.Log(String);
                ball_collide = false;
                checker = '\0';
                iscript.SetPressedfalse();
                button_pressed = false;

            }
        }
        if (nscript.N_pressed || checker == 'N')
        {
            checker = 'N';
            
            if (ball_collide)
            {
                audioManager.Playsfx(audioManager.Ball_destroy);
                Debug.Log("4");
                String += "N";
                Debug.Log(String);
                ball_collide = false;
                checker = '\0';
                nscript.SetPressedfalse();
                button_pressed = false;

            }
        }
        if (gscript.G_pressed || checker == 'G')
        {
            checker = 'G';
            
            if (ball_collide)
            {
                audioManager.Playsfx(audioManager.Ball_destroy);
                Debug.Log("5");
                String += "G";
                Debug.Log(String);
                ball_collide = false;
                checker = '\0';
                gscript.SetPressedfalse();
                button_pressed = false;

            }
        }
        if(String.Equals(String1,System.StringComparison.OrdinalIgnoreCase)==true||T){
            audioManager.Playsfx(audioManager.collider_off);
            Destroy(gameObject);
            spawnObject.SetActive(true);
            spawnObject1.SetActive(true);
        }
        if(sscript.S_pressed||lscript.L_pressed || iscript.I_pressed || nscript.N_pressed || gscript.G_pressed)
        {
            button_pressed = true;
        }
        
    }
    
}
