using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Transform playTrans;
    public Transform exitTrans;
    public Transform Pointer;

    private bool MenuState = true; //true = play, false = exit

    private SoundManager sm;

    private void Start()
    {
        sm = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!MenuState)
            {
                Pointer.position = playTrans.position;
                MenuState = !MenuState;
                sm.PlayMoveMenu();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (MenuState)
            {
                Pointer.position = exitTrans.position;
                MenuState = !MenuState;
                sm.PlayMoveMenu();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (MenuState)
            {
                Debug.Log("Enter game");
                sm.PlaySelectMenu();
            }
            else
            {
                Debug.Log("Exit");
                Application.Quit();
                sm.PlaySelectMenu();
            }
        }
    }

}
