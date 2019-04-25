using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : ManagerBase
{
    public static InputManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }


    void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("You pressed SPACE! CONGRATS!");
        }

        foreach (char c in Input.inputString)
        {
            Debug.Log("You pressed: " + c);
            //string text = TextManager.instance.CurrentInputText;

            //if (c == '\b') // has backspace/delete been pressed?
            //{
            //    TextManager.instance.CurrentInputText = text = text.Substring(0, text.Length - 1);
            //}
            //else if ((c == '\n') || (c == '\r')) // enter/return
            //{
            //    string inputText = TextManager.instance.CurrentInputText;
            //    TextManager.instance.CurrentInputText = "";
            //    TheMessage.instance.CheckInput(inputText);
            //}
            //else
            //{
            //    TextManager.instance.CurrentInputText = text + c;
            //}
        }
    }
}
