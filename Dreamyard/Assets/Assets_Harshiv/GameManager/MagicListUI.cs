using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MagicListUI : MonoBehaviour
{
    [SerializeField] private GameObject magicListPanel;


    private bool isMoveListActive;

    void Start()
    {
        // Initialize the move list text
        magicListPanel.SetActive(false);


        // Check if we are in Scene 1 and show the move list if so
        if (SceneManager.GetActiveScene().buildIndex == 4)
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
        magicListPanel.SetActive(true);
        isMoveListActive = true;
    }

    void HideMoveList()
    {
        magicListPanel.SetActive(false);
        isMoveListActive = false;
    }
}
