using UnityEngine;
using System;
using System.IO;
// this class is to handle the data from a given path 
public class SaveDataHandler 
{
    private string dataPath;
    private string FileName;
    public SaveDataHandler(string Path, string Name)
    {
        dataPath = Path;
        FileName = Name;
    }

    public GameData  load()
    {
        string fullPath = Path.Combine(dataPath, FileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {

                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.Log("erro loading");
            }
        }

        return loadedData;
    }

    public void save(GameData data)
    {
        string fullPath = Path.Combine(dataPath, FileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore = JsonUtility.ToJson(data, true);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("error trying to get the path: " + fullPath);
        }
    }
}
