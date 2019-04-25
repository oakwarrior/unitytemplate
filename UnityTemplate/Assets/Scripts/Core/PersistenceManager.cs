using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Vector3Serializable
{
    Vector3Serializable(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public float x;
    public float y;
    public float z;

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }

    public static Vector3Serializable ToVector3Serializable(Vector3 vec)
    {
        return new Vector3Serializable(vec.x, vec.y, vec.z);
    }
}

[System.Serializable]
public class SaveData
{
    public System.DateTime LastPlayedTime = System.DateTime.Now;
    public string Version = "0.1.1";
    public List<PrefabSaveData> SavedPrefabObjects = new List<PrefabSaveData>();

    public void InitData()
    {
        Version = Application.version;
        LastPlayedTime = System.DateTime.Now;
    }

    public void ApplyData()
    {

    }
}

[System.Serializable]
public class PrefabSaveData
{
    string PrefabPath;
    public Vector3Serializable Position;

    public PrefabSaveData(PrefabObject prefabObject)
    {
        PrefabPath = AssetDatabase.GetAssetPath(prefabObject.GetSourcePrefab());
        Position = Vector3Serializable.ToVector3Serializable(prefabObject.GetLocation());
    }

    public virtual PrefabObject GetTemplate()
    {
        PrefabObject template = (PrefabObject)AssetDatabase.LoadAssetAtPath(PrefabPath, typeof(PrefabObject));
        return template;
    }
}

public interface PrefabObject
{
    GameObject GetSourcePrefab();
    Vector3 GetLocation();
}

public class PersistenceManager : ManagerBase
{
    public static PersistenceManager instance;

    private void Awake()
    {
        instance = this;
    }

    SaveData LocalCopyOfData = null;

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create(Application.persistentDataPath + "\\save.binary");
        SaveData data = new SaveData();
        data.InitData();
        LocalCopyOfData = data;

        formatter.Serialize(saveFile, data);

        saveFile.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "\\save.binary"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream saveFile = File.Open(Application.persistentDataPath + "\\save.binary", FileMode.Open);

            LocalCopyOfData = (SaveData)formatter.Deserialize(saveFile);

            LocalCopyOfData.ApplyData();

            saveFile.Close();
        }
        else
        {
            Debug.Log("No save yet, creating dummy save");
            Save();
        }
    }

    public override void InitManager()
    {
        base.InitManager();

        Load();
    }
}
