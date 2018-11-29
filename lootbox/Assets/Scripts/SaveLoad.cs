using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad {

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedData.dat");
        PlayerData data = new PlayerData
        {
            Experience = User.user.Experience,
            Level = User.user.Level,
            InventorySlots = User.user.InventorySlots,
            EquipmentSlots = User.user.EquipmentSlots,
            LootBoxes = User.user.LootBoxes,
            Currency = User.user.Currency,
            Inventory = User.user.inventory,
            Luck = User.user.Luck,
            Dexterity = User.user.Dexterity,
            Strength = User.user.Strength,
            Intelligence = User.user.Intelligence,
            RareChange = User.user.RareChange
        };

        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedData.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            User.user.Experience = data.Experience;
            User.user.Level = data.Level;
            User.user.InventorySlots = data.InventorySlots;
            User.user.EquipmentSlots = data.EquipmentSlots;
            User.user.LootBoxes = data.LootBoxes;
            User.user.Currency = data.Currency;
            User.user.inventory = data.Inventory;
            User.user.Luck = data.Luck;
            User.user.Dexterity = data.Dexterity;
            User.user.Strength = data.Strength;
            User.user.Intelligence = data.Intelligence;
            User.user.RareChange = data.RareChange;
        }
        throw new IOException();
    }
}
