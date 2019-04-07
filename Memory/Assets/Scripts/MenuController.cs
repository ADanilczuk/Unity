using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void triggerMenuBehavior(int i)
    {
        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene ("ActualGame");
                break;
            case (1):
                Application.Quit();
                break;
        }
    }
}
