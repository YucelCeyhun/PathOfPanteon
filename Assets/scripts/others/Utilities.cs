using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
//You don't have to obey the oop rules in this script :)
public enum Layer
{
    Walkable = 9,
    Enemy = 10,
    Item = 11,
    Unidentified = -1
}

public enum AttackType
{
    Normal = 0,
    Fire = 1,
    Lightning = 2,
    Cold = 3,
    Poison = 4
}

public enum EnemyType
{
    Normal = 0,
    Rare = 1,
    Elit = 2,
    Unique = 3
}

public enum TagList
{
    Player = 0,
    Enemy = 1
}

[System.Serializable]
public struct Source
{
    public int life;
    public int mana;
    public float lifeReg;
    public float manaReg;
}

[System.Serializable]
public struct EnemyInfo
{
    public string name;
    public EnemyType enemyType;
}

[System.Serializable]
public struct Stats
{
    public int intelligence;
    public int dexterity;
    public int strength;
    public int vitality;
}

[System.Serializable]
public sealed class Defensive
{

    public int armor;
    public byte dodge;


    [System.Serializable]
    public struct Resists
    {
        public int fireResist;
        public int lightningResist;
        public int coldResist;
        public int poisonResist;
    }

    public Resists res;
}

[System.Serializable]
public struct Offensive
{
    public int normalAttack;
    public float attackSpeed;
    public float attackRange;
    public float castSpeed;
    public float criticalChance;
    public float criticalDmg;
    public float moveSpeed;

    
}

/*for enemies */
[System.Serializable]
public class SpellCaster 
{
    public string spellName;
    public float cooldown;
    public float timer;
    [SerializeField] SpellTrigger mainTrigger;
    [SerializeField] SpellTrigger othersTrigger;

    public void SpellCast(bool state)
    {
        othersTrigger.DoThat();
        if (timer >= cooldown && state)
        {
            mainTrigger.DoThat();
            timer = 0;   
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}

[System.Serializable]
public class SpellTrigger : UnityEvent
{
    public void DoThat()
    {
        Invoke();
    }
}







