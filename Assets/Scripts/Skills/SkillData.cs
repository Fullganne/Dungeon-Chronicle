using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "RPG/Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public string description;
    public int damage;
    public int manaCost;
    public Sprite icon; // Ảnh hiển thị kỹ năng

    public void ApplyEffect(CharacterCombat user, CharacterCombat target)
    {
        target.TakeDamage(damage);
        Debug.Log($"{user.characterName} sử dụng {skillName} lên {target.characterName}, gây {damage} sát thương!");
    }
}
