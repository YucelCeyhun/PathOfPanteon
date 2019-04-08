using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "PlayerSpell",menuName ="JayHooN/PlayerSpell",order=6)]
public class SpellCreate : ScriptableObject {

    public int ID;
    public string spellName;
    public Sprite icon;
    public int level;
    public float cooldown;
    public AttackType attackType;
    public int coreDmg;
    public int dmgPercent;
    public int manaCost;
    public List<GameObject> mainEffect;
    public List<GameObject> tailEffect;
	public List<AudioClip> audioClip;
    public PlayerSpellCaster playerSpellCaster;
}
