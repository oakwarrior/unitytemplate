using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : ManagerBase
{
    public static AssetManager instance;

    private void Awake()
    {
        instance = this;
    }
}
