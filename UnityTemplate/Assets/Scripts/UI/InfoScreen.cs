using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScreen : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void InitInfoScreen()
    {
        gameObject.SetActive(false);
    }


    public virtual bool ToggleScreen()
    {
        if (IsScreenOpen())
        {
            HideScreen();
        }
        else
        {
            ShowScreen();
        }
        return gameObject.activeSelf;
    }


    public virtual void ShowScreen()
    {
        UIManager.instance.HideAllInfoScreens();

        gameObject.SetActive(true);

        PopulateScreen();
    }

    public virtual void HideScreen()
    {
        gameObject.SetActive(false);

        ClearScreen();
    }

    public bool IsScreenOpen()
    {
        return gameObject.activeSelf;
    }

    public virtual void PopulateScreen()
    {

    }

    public virtual void ClearScreen()
    {

    }

    public virtual void RefreshScreen()
    {
        ClearScreen();
        PopulateScreen();
    }
}
