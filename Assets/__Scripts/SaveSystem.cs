using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
   public static void SavePlayer(PlayerMovement player){
      
       BinaryFormatter formatter = new BinaryFormatter();
       string path = Application.persistentDataPath + "/player.game";
       FileStream stream = new FileStream(path, FileMode.Create);
  
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();  
   }

    public static PlayerData LoadPLayer(){
        string path = Application.persistentDataPath + "/player.game";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open); 

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }else{
            Debug.LogError("Save file not found in "+ path);
            return null;
        }
    }

}
