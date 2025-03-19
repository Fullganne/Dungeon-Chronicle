using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "RPG/Skill")]
public class SkillSO : ScriptableObject
{
    public string skillName;
    public int power;
    public int manaCost;
    public bool isAOE;
}
