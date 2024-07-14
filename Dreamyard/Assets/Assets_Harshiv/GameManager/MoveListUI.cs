using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveListUI : MonoBehaviour
{
    [SerializeField] private GameObject moveListPanel;


    private bool isMoveListActive;

    void Start()
    {
        // Initialize the move list text
        moveListPanel.SetActive(false);


        // Check if we are in Scene 1 and show the move list if so
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ShowMoveList();
        }
        else
        {
            HideMoveList();
        }
    }

    void Update()
    {
        if (isMoveListActive && Input.GetKeyDown(KeyCode.Return))
        {
            HideMoveList();
        }
    }

    void ShowMoveList()
    {
        moveListPanel.SetActive(true);
        isMoveListActive = true;
    }

    void HideMoveList()
    {
        moveListPanel.SetActive(false);
        isMoveListActive = false;
    }
}
