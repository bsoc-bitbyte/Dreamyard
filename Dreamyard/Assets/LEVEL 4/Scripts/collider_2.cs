using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_bridge : MonoBehaviour
{
    private B bscript;
    private R rscript;
    private I i1script;
    private D dscript;
    private G gscript;
    private E escript;
    public GameObject spawnObject;
    public GameObject spawnObject1;
    public bool T=false;
    private bool ball_collide = false;
    private bool button_pressed = false;
    private string String;
    private string String1 = "" + "B" + "R" + "I" + "D" + "G" + "E";
    private char checker = '\0';
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        B[] bscripts = FindObjectsOfType<B>();
        R[] rscripts = FindObjectsOfType<R>();
        I[] i1scripts = FindObjectsOfType<I>();
        D[] dscripts = FindObjectsOfType<D>();
        G[] gscripts = FindObjectsOfType<G>();
        E[] escripts = FindObjectsOfType<E>();

        if (bscripts.Length > 0)
            bscript = bscripts[0];
        if (rscripts.Length > 0)
            rscript = rscripts[0];
        if (i1scripts.Length > 0)
            i1script = i1scripts[0];
        if (dscripts.Length > 0)
            dscript = dscripts[0];
        if(gscripts.Length > 0)
            gscript=gscripts[0];
        if (escripts.Length > 0)
            escript = escripts[0];

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
        if (bscript.B_pressed || checker == 'B')
        {
            checker = 'B';

            if (ball_collide)
            {
                audioManager.Playsfx(audioManager.Ball_destroy);
                Debug.Log("1");
                String += "B";
                Debug.Log(String);
                ball_collide = false;
                checker = '\0';
                bscript.SetPressedfalse();
                button_pressed = false;
            }
        }
        if (rscript.R_pressed || checker == 'R')
        {
            checker = 'R';

            if (ball_collide)
            {
                audioManager.Playsfx(audioManager.Ball_destroy);
                Debug.Log("2");
                String += "R";
                Debug.Log(String);
                ball_collide = false;
                checker = '\0';
                rscript.SetPressedfalse();
                button_pressed = false;
            }
        }
        if (i1script.I_pressed || checker == 'I')
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
                i1script.SetPressedfalse();
                button_pressed = false;
            }
        }
        if (dscript.D_pressed || checker == 'D')
        {
            checker = 'D';

            if (ball_collide)
            {
                audioManager.Playsfx(audioManager.Ball_destroy);
                Debug.Log("4");
                String += "D";
                Debug.Log(String);
                ball_collide = false;
                checker = '\0';
                dscript.SetPressedfalse();
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


        if (escript.E_pressed || checker == 'E')
        {
            checker = 'E';

            if (ball_collide)
            {
                audioManager.Playsfx(audioManager.Ball_destroy);
                Debug.Log("6");
                String += "E";
                Debug.Log(String);
                ball_collide = false;
                checker = '\0';
                escript.SetPressedfalse();
                button_pressed = false;
            }
        }
        if (String.Equals(String1, System.StringComparison.OrdinalIgnoreCase) == true||T)
        {
            audioManager.Playsfx(audioManager.Bridge);
            Destroy(gameObject);
            spawnObject1.SetActive(false);
            spawnObject.transform.rotation= Quaternion.identity;
        }
        if (bscript.B_pressed || rscript.R_pressed || i1script.I_pressed || dscript.D_pressed || gscript.G_pressed||escript.E_pressed)
        {
            button_pressed = true;
        }
    }
}