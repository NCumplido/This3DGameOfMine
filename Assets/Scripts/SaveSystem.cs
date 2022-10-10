using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string saveFilePathName = Application.persistentDataPath + "/player.ttdgom" ; //Extract/refactor

        FileStream fileStream = new FileStream(saveFilePathName, FileMode.Create);//FUTURE: update the filestream implementation to use "Using" 

        PlayerData playerData = new PlayerData(player);

        formatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string saveFilePathName = Application.persistentDataPath + "/player.ttdgom"; //Extract/refactor

        if (File.Exists(saveFilePathName))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fileStream = new FileStream(saveFilePathName, FileMode.Open);//FUTURE: update the filestream implementation to use "Using" 
            
            PlayerData playerData = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close ();
            return playerData;
        }
        else
        {
            Debug.LogError("Save file not found in " + saveFilePathName);
            return null;
        }
    }
}
