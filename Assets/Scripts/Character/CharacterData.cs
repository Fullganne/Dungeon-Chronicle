using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "RPG/Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
    public int maxHP;
    public int maxMP;
    public int attack;
    public int defense;
    public int speed;
    public List<SkillData> skills;
}