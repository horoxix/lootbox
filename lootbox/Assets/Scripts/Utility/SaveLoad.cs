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
            Luck = User.user.luck,
            Dexterity = User.user.dexterity,
            Strength = User.user.strength,
            Intelligence = User.user.intelligence,
            RareChange = User.user.RareChange,
            EquippedHelm = User.user.equippedHelm,
            EquippedArmor = User.user.equippedArmor,
            EquippedAccessory1 = User.user.equippedAccessory1,
            EquippedAccessory2 = User.user.equippedAccessory2,
            EquippedBelt = User.user.equippedBelt,
            EquippedBoots = User.user.equippedBoots,
            EquippedGloves = User.user.equippedGloves,
            EquippedLeftHand = User.user.equippedLeftHand,
            EquippedPants = User.user.equippedPants,
            EquippedRightHand = User.user.equippedRightHand
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
            User.user.luck = data.Luck;
            User.user.dexterity = data.Dexterity;
            User.user.strength = data.Strength;
            User.user.intelligence = data.Intelligence;
            User.user.RareChange = data.RareChange;
            User.user.equippedHelm = data.EquippedHelm;
            User.user.equippedArmor = data.EquippedArmor;
            User.user.equippedAccessory1 = data.EquippedAccessory1;
            User.user.equippedAccessory2 = data.EquippedAccessory2;
            User.user.equippedBelt = data.EquippedBelt;
            User.user.equippedBoots = data.EquippedBoots;
            User.user.equippedGloves = data.EquippedGloves;
            User.user.equippedLeftHand = data.EquippedLeftHand;
            User.user.equippedPants = data.EquippedPants;
            User.user.equippedRightHand = data.EquippedRightHand;
        }
        throw new IOException();
    }
}
