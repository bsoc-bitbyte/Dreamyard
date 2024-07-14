using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton class:GameManager
    public static GameManager instance;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    

    Camera Cam;
    GameObject Ball;
    public Trajectory Trajectory;
    public float pushforce = 4f;
    bool isDraggin = false;
    Vector2 startpoint;
    Vector2 endpoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    public float changedPOV=12f;
    Camerascript scrip;
    public Vector3 followspeed = Vector3.zero;
    AudioManager audioManager;
    
    
        
    

    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("circle");
        Cam = Camera.main;
        Ball.GetComponent<Ball>().DeActivaterb();
        Camerascript scrip = Camera.main.GetComponent<Camerascript>();
    }

    // Update is called once per frame
    void Update()
    {
        Ball = GameObject.FindGameObjectWithTag("circle");
        if (Ball != null)
        {
            
            if (Ball.GetComponent<Ball>().Sling == true)

            {
                
                Vector3 newpos = Cam.transform.position;
                newpos.x = 30f;
                Cam.transform.position = Vector3.SmoothDamp(Cam.transform.position,newpos,ref followspeed ,0.3f );
                if (Input.GetMouseButtonDown(0))
                {
                    isDraggin = true;
                    onStartDrag();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    isDraggin = false;
                    onEndDrag();
                }
                if (isDraggin)
                {
                    OnDrag();

                }
            }
        }
    }
    void onStartDrag()
    {
        Cam.orthographicSize = changedPOV;
        Ball.GetComponent<Ball>().DeActivaterb();
        startpoint= Cam.ScreenToWorldPoint(Input.mousePosition);
        Trajectory.show();
    }
    void OnDrag()
    {
        
        endpoint = Cam.ScreenToWorldPoint(Input.mousePosition);
        distance=Vector2.Distance(endpoint, startpoint);
        direction=(startpoint - endpoint).normalized;
        force=direction*distance*pushforce;
        Debug.DrawLine(startpoint,endpoint);
        Trajectory.updatedots(Ball.GetComponent<Ball>().pos, force);
        
    }

    void onEndDrag()
    {
        Cam.orthographicSize = 9.44f;
        Ball.GetComponent<Ball>().Activaterb();
        Ball.GetComponent<Ball>().Push(force);
        audioManager.Playsfx(audioManager.slingshot);
        Trajectory.hide();
    }
    
}
