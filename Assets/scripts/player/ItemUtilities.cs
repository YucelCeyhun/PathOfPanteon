using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//{4;2;5;1;50}{0,0;0,0;0,0;0,0}{0,0;0,0;0,0;0,0}{0,0;0,0;0,0;0,0}

public enum ItemType
{
    normal = 1,
    rare = 2,
    elit = 3,
    legendary = 4
}

public enum ItemGroup
{
    helmet = 1,
    weaponOne = 2,
    weaponTwo = 3,
    shield = 4,
    gloves = 5,
    boots = 6,
    belt = 7,
    rings = 8,
    amulet = 9
}



public struct OffenviveAttr
{
    public int extraDmg;
    public int extraFireDmg;
    public int extraColdDmg;
    public int extraLightningDmg;
    public int extraPoisonDmg;
    public int extraHolyDmg;
    public int addPercentDmg;
    public int addPercentFireDmg;
    public int addPercentColdDmg;
    public int addPercentLightningDmg;
    public int addPercentPoisonDmg;
    public int addPercentHolyDmg;
    public int addPercentAttackSpeed;
    public int addPercentCastSpeed;
}

public enum OffensiveAttributes
{
    extraDmg = 1,
    extraFireDmg = 2,
    extraColdDmg = 3,
    extraLightningDmg = 4,
    extraPoisonDmg = 5,
    extraHolyDmg = 6,
    addPercentDmg = 7,
    addPercentFireDmg = 8,
    addPercentColdDmg = 9,
    addPercentLightningDmg = 10,
    addPercentPoisonDmg = 11,
    addPercentHolyDmg = 12,
    addPercentAttackSpeed = 13,
    addPercentCastSpeed = 14
}

public enum DefensiveAttributes
{
    addDefans = 1,
    addFireResist = 2,
    addColdResist = 3,
    addLightningResist = 4,
    addPoisonResist = 5,
    addAllResist = 6
}

public enum FunctionalAttributes
{
    addPercentMoveSpeed = 1,
    addStr = 2,
    addInt = 3,
    addDex = 4,
    addVitality = 5

}

public struct RareMagic
{
    
}

public class Weapon {
    public int dmg;
    public Dictionary<string, int> dict = new Dictionary<string, int>();
    

    void CreateDict()
    {
        dict.Add("extraDmg", 15);
    }
}
