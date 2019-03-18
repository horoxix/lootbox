
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemObjectDatabase", menuName = "ItemObjectDatabase", order = 0)]
public class ItemObjectDatabase : ScriptableObject {
    public List<ItemScriptableObject> ItemList;
}
