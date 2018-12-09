using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoad {

    const string fileExtension = ".dat";
    static string dataPath = Path.Combine(Application.persistentDataPath, "SaveData" + fileExtension);

    internal static void Save(int a, int b)
    {
        BinaryFormatter bf = new BinaryFormatter();
        SaveData data = new SaveData
        {
            highScore = a,
            totalScore = b

        };
        using (FileStream fileStream = File.Open(dataPath, FileMode.OpenOrCreate))
        {
            bf.Serialize(fileStream, data);
            fileStream.Close();
        }
        MainMenu.highScore = data.highScore;
        MainMenu.totalScore = data.totalScore;
    }

    internal static void Load()
    {
        if (File.Exists(dataPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            SaveData data;
            using (FileStream fileStream = File.Open(dataPath, FileMode.Open))
            {
                data = (SaveData)bf.Deserialize(fileStream);
                fileStream.Close();
            }
            MainMenu.highScore = data.highScore;
            MainMenu.totalScore = data.totalScore;
        }
    }

}

[Serializable]
public class SaveData
{
    public int totalScore;
    public int highScore;
}
