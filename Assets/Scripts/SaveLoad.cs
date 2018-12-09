using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private string path = "/Save.dat";
    BinaryFormatter bf = new BinaryFormatter();

    internal void Save(Vector2 scr)
    {
        SaveData data = new SaveData();
        data.Scores.x = scr.x;
        data.Scores.y = scr.y;

        FileStream file;
        if (!File.Exists(Application.persistentDataPath + path))
        {
            file = File.Create(Application.persistentDataPath + path);
        }
        else
        {
            file = File.Open(Application.persistentDataPath + path, FileMode.Open);
        }
        bf.Serialize(file, data);
        file.Close();
    }

    internal void Load()
    {
        if (File.Exists(Application.persistentDataPath + path))
        {
            FileStream file = File.Open(Application.persistentDataPath + path, FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            MainMenu.highScore = (int)data.Scores.x;
            MainMenu.totalScore = (int)data.Scores.y;
        }
    }
    
}
[Serializable]
class SaveData : ISerializable
{
    internal Vector2 Scores;

    public SaveData()
    {

    }

    public SaveData(SerializationInfo info, StreamingContext context)
    {
        Scores = (Vector2)info.GetValue("Scores", typeof(Vector2));
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Scores", Scores);
    }
}
