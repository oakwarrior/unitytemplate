using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : ManagerBase
{
    public static UIManager instance;

    public List<InfoScreen> InfoScreenTemplates = new List<InfoScreen>();

    public List<GameObject> OtherScreens = new List<GameObject>();

    List<InfoScreen> InfoScreens = new List<InfoScreen>();

    private void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void HideAllInfoScreens()
    {
        for (int i = 0; i < InfoScreens.Count; ++i)
        {
            InfoScreens[i].HideScreen();
        }
    }

    public bool IsAnyInfoScreenOpen()
    {
        for (int i = 0; i < InfoScreens.Count; ++i)
        {
            if (InfoScreens[i].IsScreenOpen())
            {
                return true;
            }
        }

        return false;
    }

    public override void InitManager()
    {
        base.InitManager();

        for (int i = 0; i < InfoScreenTemplates.Count; ++i)
        {
            InfoScreens.Add(Instantiate(InfoScreenTemplates[i]));
            InfoScreens[i].InitInfoScreen();
        }

        for (int i = 0; i < OtherScreens.Count; ++i)
        {
            Instantiate(OtherScreens[i]);
        }
    }
}
