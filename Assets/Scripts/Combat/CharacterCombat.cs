using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public string characterName;
    public int maxHP = 100;
    public int maxMP = 50;
    public int health;
    public int mana;
    public int attackPower = 10;
    public int speed = 5;
    public bool isAlive = true;
    public bool isDefending = false;

    public List<SkillData> skills; // Danh sách kỹ năng của nhân vật

    public BattleManager battleManager;

    void Start()
    {
        health = maxHP;
        mana = maxMP;
        battleManager = FindObjectOfType<BattleManager>();
    }

    public virtual void StartTurn()
    {
        Debug.Log($"{characterName} đến lượt! Chờ người chơi chọn hành động...");
        battleManager.ShowActionUI((PlayerCombat)this);
    }   

    public void Attack(CharacterCombat target)
    {
        Debug.Log($"{characterName} tấn công {target.characterName}");
        target.TakeDamage(attackPower);
        battleManager.EndTurn();
    }

    public void UseSkill(SkillData skill, CharacterCombat target)
    {
        if (mana < skill.manaCost)
        {
            Debug.Log("Không đủ MP!");
            return;
        }

        mana -= skill.manaCost;
        skill.ApplyEffect(this, target);
        battleManager.EndTurn();
    }

    protected virtual void TakeDamage(int damage)
    {
        if (isDefending)
        {
            damage /= 2; // Giảm 50% sát thương
            isDefending = false; // Hủy trạng thái phòng thủ sau khi nhận sát thương
        }

        health -= damage;
        Debug.Log($"{characterName} nhận {damage} sát thương! Máu còn: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        Debug.Log($"{characterName} đã bị đánh bại!");
        Destroy(gameObject);
    }
}
