using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteStatFactory : StatFactory {

    public override Stat GetStat(Stat.StatType statType, Item item)
    {
        switch (statType)
        {
            case Stat.StatType.LUCK:
                return new Luck("Luck", Stat.StatType.LUCK, Stat.Rarity.EPIC, Stat.AffectedStat.RARITY, GenerateStatValue(GetItemRarity(item)));
            case Stat.StatType.STRENGTH:
                return new Strength("Strength", Stat.StatType.STRENGTH, Stat.Rarity.COMMON, Stat.AffectedStat.LOOT_AMOUNT, GenerateStatValue(GetItemRarity(item)));
            case Stat.StatType.DEXTERITY:
                return new Dexterity("Dexterity", Stat.StatType.DEXTERITY, Stat.Rarity.RARE, Stat.AffectedStat.ACCUMULATION, GenerateStatValue(GetItemRarity(item)));
            case Stat.StatType.INTELLIGENCE:
                return new Intelligence("Intelligence", Stat.StatType.INTELLIGENCE, Stat.Rarity.COMMON, Stat.AffectedStat.THEME, GenerateStatValue(GetItemRarity(item)));
        }
        throw new System.NotImplementedException();
    }
}
