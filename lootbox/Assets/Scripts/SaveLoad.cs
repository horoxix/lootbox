using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad {

    public static void Save(User user)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedData.gd");
        bf.Serialize(file, user);
        file.Close();
    }

    public static User Load(User user)
    {
        if (File.Exists(Application.persistentDataPath + "/savedData.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedData.gd", FileMode.Open);
            user = (User)bf.Deserialize(file);
            file.Close();
            return user;
        }
        throw new IOException();
    }
}
