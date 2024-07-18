using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsnumber;
    [SerializeField] GameObject dotparent;
    [SerializeField] GameObject dotprefab;
    [SerializeField] float dotspacing;
    // Start is called before the first frame update

    Transform[] dotList;
    Vector2 pos;
    float timestamp;   
    void Start()
    {
        hide();
        preparedots();
    }

    public void updatedots(Vector3 Ballpos,Vector2 forceapplied)
    {
        timestamp = dotspacing;
        for(int i = 0; i < dotsnumber; i++) {
            pos.x = (Ballpos.x + forceapplied.x * timestamp);
            pos.y = (Ballpos.y + forceapplied.y * timestamp)-(Physics2D.gravity.magnitude*timestamp*timestamp)/2f;
            dotList[i].position = pos;
            timestamp += dotspacing;
        }
    }
    public void preparedots()
    {
        dotList = new Transform[dotsnumber];
        for (int i = 0; i < dotsnumber; i++)
        {
            dotList[i] = Instantiate(dotprefab,null).transform;
            dotList[i].parent = dotparent.transform;
            
        }
    }
    public void show()
    {
        dotparent.SetActive(true);
    }
    public void hide()
    {
        dotparent.SetActive(false);
    }
}
