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
            RareChange = User.user.RareChange,
            EquippedHelm = User.user.EquippedHelm,
            EquippedArmor = User.user.EquippedArmor,
            EquippedAccessory1 = User.user.EquippedAccessory1,
            EquippedAccessory2 = User.user.EquippedAccessory2,
            EquippedBelt = User.user.EquippedBelt,
            EquippedBoots = User.user.EquippedBoots,
            EquippedGloves = User.user.EquippedGloves,
            EquippedLeftHand = User.user.EquippedLeftHand,
            EquippedPants = User.user.EquippedPants,
            EquippedRightHand = User.user.EquippedRightHand
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
            User.user.EquippedHelm = data.EquippedHelm;
            User.user.EquippedArmor = data.EquippedArmor;
            User.user.EquippedAccessory1 = data.EquippedAccessory1;
            User.user.EquippedAccessory2 = data.EquippedAccessory2;
            User.user.EquippedBelt = data.EquippedBelt;
            User.user.EquippedBoots = data.EquippedBoots;
            User.user.EquippedGloves = data.EquippedGloves;
            User.user.EquippedLeftHand = data.EquippedLeftHand;
            User.user.EquippedPants = data.EquippedPants;
            User.user.EquippedRightHand = data.EquippedRightHand;
        }
        throw new IOException();
    }
}
