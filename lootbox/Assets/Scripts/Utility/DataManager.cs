using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour{
    private string path;
    public static DataManager dataManager;

    private void Awake()
    {
        if (dataManager == null)
        {
            DontDestroyOnLoad(gameObject);
            dataManager = this;
        }
        else if (dataManager != this)
        {
            Destroy(gameObject);
        }
        path = Application.persistentDataPath + "/savedData.dat";
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        PlayerData data = new PlayerData
        {
            Experience = User.user.Experience,
            Level = User.user.Level,
            InventorySlots = User.user.InventorySlots,
            EquipmentSlots = User.user.EquipmentSlots,
            LootBoxes = User.user.LootBoxes,
            Currency = User.user.Currency,
            Inventory = User.user.inventory,
            Luck = User.user.luck.StatValue,
            Dexterity = User.user.dexterity.StatValue,
            Strength = User.user.strength.StatValue,
            Intelligence = User.user.intelligence.StatValue,
            RareChange = User.user.RareChange,
            EquippedHelm = JsonUtility.ToJson(User.user.equippedHelm),
            EquippedArmor = JsonUtility.ToJson(User.user.equippedArmor),
            EquippedAccessory1 = JsonUtility.ToJson(User.user.equippedAccessory1),
            EquippedAccessory2 = JsonUtility.ToJson(User.user.equippedAccessory2),
            EquippedBelt = JsonUtility.ToJson(User.user.equippedBelt),
            EquippedBoots = JsonUtility.ToJson(User.user.equippedBoots),
            EquippedGloves = JsonUtility.ToJson(User.user.equippedGloves),
            EquippedLeftHand = JsonUtility.ToJson(User.user.equippedLeftHand),
            EquippedPants = JsonUtility.ToJson(User.user.equippedPants),
            EquippedRightHand = JsonUtility.ToJson(User.user.equippedRightHand)
        };
        Debug.Log(JsonUtility.ToJson(User.user.equippedArmor));
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            User.user.Experience = data.Experience;
            User.user.Level = data.Level;
            User.user.InventorySlots = data.InventorySlots;
            User.user.EquipmentSlots = data.EquipmentSlots;
            User.user.LootBoxes = data.LootBoxes;
            User.user.Currency = data.Currency;
            User.user.inventory = data.Inventory;
            User.user.luck.StatValue = data.Luck;
            User.user.dexterity.StatValue = data.Dexterity;
            User.user.strength.StatValue = data.Strength;
            User.user.intelligence.StatValue = data.Intelligence;
            User.user.RareChange = data.RareChange;
            User.user.equippedHelm = JsonUtility.FromJson<ItemObject>(data.EquippedHelm);
            User.user.equippedArmor = JsonUtility.FromJson<ItemObject>(data.EquippedArmor);
            User.user.equippedAccessory1 = JsonUtility.FromJson<ItemObject>(data.EquippedAccessory1);
            User.user.equippedAccessory2 = JsonUtility.FromJson<ItemObject>(data.EquippedAccessory2);
            User.user.equippedBelt = JsonUtility.FromJson<ItemObject>(data.EquippedBelt);
            User.user.equippedBoots = JsonUtility.FromJson<ItemObject>(data.EquippedBoots);
            User.user.equippedGloves = JsonUtility.FromJson<ItemObject>(data.EquippedGloves);
            User.user.equippedLeftHand = JsonUtility.FromJson<ItemObject>(data.EquippedLeftHand);
            User.user.equippedPants = JsonUtility.FromJson<ItemObject>(data.EquippedPants);
            User.user.equippedRightHand = JsonUtility.FromJson<ItemObject>(data.EquippedRightHand);
        }
        throw new IOException();
    }

    public void LoadInventory()
    {
        if (File.Exists(path))
        {
            Debug.Log("Exists");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            User.user.InventorySlots = data.InventorySlots;
            User.user.EquipmentSlots = data.EquipmentSlots;
            User.user.inventory = data.Inventory;
            User.user.luck.StatValue = data.Luck;
            User.user.dexterity.StatValue = data.Dexterity;
            User.user.strength.StatValue = data.Strength;
            User.user.intelligence.StatValue = data.Intelligence;
            User.user.RareChange = data.RareChange;
            User.user.equippedHelm = JsonUtility.FromJson<ItemObject>(data.EquippedHelm);
            User.user.equippedArmor = JsonUtility.FromJson<ItemObject>(data.EquippedArmor);
            User.user.equippedAccessory1 = JsonUtility.FromJson<ItemObject>(data.EquippedAccessory1);
            User.user.equippedAccessory2 = JsonUtility.FromJson<ItemObject>(data.EquippedAccessory2);
            User.user.equippedBelt = JsonUtility.FromJson<ItemObject>(data.EquippedBelt);
            User.user.equippedBoots = JsonUtility.FromJson<ItemObject>(data.EquippedBoots);
            User.user.equippedGloves = JsonUtility.FromJson<ItemObject>(data.EquippedGloves);
            User.user.equippedLeftHand = JsonUtility.FromJson<ItemObject>(data.EquippedLeftHand);
            User.user.equippedPants = JsonUtility.FromJson<ItemObject>(data.EquippedPants);
            User.user.equippedRightHand = JsonUtility.FromJson<ItemObject>(data.EquippedRightHand);
        }
        throw new IOException();
    }
}
