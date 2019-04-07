using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour {

    public void triggerMenuBehavior(int i)
    {
        switch (i)
        {
            default:
            case (1):
                SceneManager.LoadScene(1);
                break;
            case (0):
                Application.Quit();
                break;
        }
    }

}
