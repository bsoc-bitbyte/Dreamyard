using TMPro;
using UnityEngine;

public class FruitCollision : MonoBehaviour
{   
    public int CountTillNow;
    Animator animator;

    public Vector3 LastFruitCollected;
    public TextMeshProUGUI CoinCountDisplay;
    public GateOpen gateOpen;

    // Start is called before the first frame update
    void Start()
    {
        CountTillNow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CoinCountDisplay.text = ":" + CountTillNow.ToString()+"/"+ gateOpen.FruitsToBeCollected;
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.CompareTag("Fruit")){
            animator = collider.gameObject.GetComponent<Animator>();
            LastFruitCollected = collider.gameObject.GetComponent<Transform>().position;

            animator.SetTrigger("Pop");

            Destroy(collider.gameObject, 0.3f);
        
            CountTillNow ++;
            Debug.Log(CountTillNow);
        }
    }
}
