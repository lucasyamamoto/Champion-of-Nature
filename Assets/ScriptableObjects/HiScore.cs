using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "HiScore", menuName = "ScriptableObjects/HiScore")]
public class HiScore : ScriptableObject
{
    [SerializeField] private double hiscore;
    
    string GetPath()
    {
#if UNITY_WEBGL
        return Path.Combine("/idbfs", Application.productName);
#else
        return Application.persistentDataPath;
#endif
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(hiscore);
        string path = GetPath();
        Directory.CreateDirectory(path);
        string fileName = "hiScoreSave";
        string filePath = Path.Combine(path, fileName);
        using (StreamWriter streamWriter = File.CreateText(filePath))
        {
            streamWriter.Write(json);
        }
    }

    public void Load()
    {
        string path = GetPath();
        string fileName = "hiScoreSave";
        string filePath = Path.Combine(path, fileName);

        if (File.Exists(filePath))
        {
            try
            {
                using (StreamReader streamReader = File.OpenText(filePath))
                {
                    string json = streamReader.ReadToEnd();
                    if (json.Length > 0)
                    {
                        hiscore = JsonUtility.FromJson<double>(json);
                    }
                }
            }
            catch
            {
                hiscore = 0.0;
            }
        }
        else
        {
            hiscore = 0.0;
        }
    }

    public void UpdateScore(double newScore)
    {
        if (newScore > hiscore)
        {
            hiscore = newScore;
            Save();
        }
    }

    void Awake()
    {
        Load();
    }
}
