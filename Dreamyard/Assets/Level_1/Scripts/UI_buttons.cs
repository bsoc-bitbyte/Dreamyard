using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_buttons : MonoBehaviour
{
    public pauseScript pauseScript;
    public HelpMenu hm;

    public void pauseButton()
    {
        pauseScript.setUp();
    }
    public void helpButton()
    {
        hm.helpMenu();
    }
}
