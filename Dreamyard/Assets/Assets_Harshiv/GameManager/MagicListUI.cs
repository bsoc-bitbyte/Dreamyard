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


        
        if (SceneManager.GetActiveScene().name == "lvl5_Scene4")
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
