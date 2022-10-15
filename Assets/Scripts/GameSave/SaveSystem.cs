using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SavePlayer(Player player)
    {
        Debug.Log("SavePlayer called with player: " + player.playerCurrentHealth + " " + player.coinCount + " " + player.level);
        BinaryFormatter formatter = new BinaryFormatter();
        string saveFilePathName = Application.persistentDataPath + "/player.ttdgom" ; //Extract/refactor
        FileStream fileStream = new FileStream(saveFilePathName, FileMode.Create);//FUTURE: update the filestream implementation to use "Using" 

        PlayerData playerData = new PlayerData(player);

        formatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public static int LoadPlayer()
    {
        string saveFilePathName = Application.persistentDataPath + "/player.ttdgom"; //Extract/refactor
        if (File.Exists(saveFilePathName))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(saveFilePathName, FileMode.Open);//FUTURE: update the filestream implementation to use "Using" 
            
            PlayerData playerData = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close ();

            Debug.Log("LoadPlayer called with player: " + playerData.playerCurrentHealth + " " + playerData.coinCount + " " + playerData.level);

            CurrentPlayerState.SetPlayerStateFromPlayerData(playerData);

            return playerData.level;
        }
        else
        {
            Debug.Log("Error: Save file not found in " + saveFilePathName);
            return 0; //If player data doesn't exist, return the menu scene build index
        }
    }

    public static void SetPlayerState(Player player)
    {
        CurrentPlayerState.player = player;
    }
}
