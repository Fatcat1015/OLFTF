using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LootData", menuName = "ScriptableObjects/Loot", order = 2)]

public class SlotData : ScriptableObject
{
    public int num_of_Slots;
    public List<GameObject> LootSlots = new List<GameObject>();
    public List<int> Loot_num = new List<int>();
}
