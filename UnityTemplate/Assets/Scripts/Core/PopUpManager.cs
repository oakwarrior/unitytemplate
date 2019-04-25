using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : ManagerBase
{

    public static PopUpManager instance;

    void Awake()
    {
        instance = this;
    }

    List<PopUp> PopUps = new List<PopUp>();
    public PopUp PopUpTemplate;


    public PopUp MakePopUp()
    {
        PopUp newPopUp = Instantiate(PopUpTemplate);
        PopUps.Add(newPopUp);
        return newPopUp;
    }

    public void ClosePopUp(PopUp popUp)
    {
        if (popUp != null)
        {
            PopUps.Remove(popUp);
            GameObject.Destroy(popUp.gameObject);
        }
    }
}
