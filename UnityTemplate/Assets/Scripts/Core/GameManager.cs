using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ManagerBase
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public List<ManagerBase> ManagerTemplates = new List<ManagerBase>();


    // Start is called before the first frame update
    void Start()
    {
        InitManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void InitManager()
    {
        base.InitManager();

        for (int i = 0; i < ManagerTemplates.Count; ++i)
        {
            ManagerBase newManager = Instantiate(ManagerTemplates[i]);
            newManager.InitManager();
        }
    }
}
