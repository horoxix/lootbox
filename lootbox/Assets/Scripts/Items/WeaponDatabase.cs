
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "ItemDatabase", order = 0)]
public class ItemDatabase : ScriptableObject {
    public List<Item> WeaponList;
}
