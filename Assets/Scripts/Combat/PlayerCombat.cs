using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : CharacterCombat
{
    public Slider hpBar;

    public override void StartTurn()
    {
        BattleManager battleManager = FindObjectOfType<BattleManager>();
        battleManager.ShowActionUI(this); // Hiển thị menu hành động
    }

    public void Defend()
    {
        isDefending = true;
        speed += 10; // Tăng tốc độ để lượt kế đến đến sớm hơn

        Debug.Log(characterName + " đã phòng thủ! Tốc độ mới: " + speed);

        BattleManager battleManager = FindObjectOfType<BattleManager>();
        battleManager.SortTurnOrder(); // Cập nhật thứ tự lượt đi ngay lập tức
        battleManager.EndTurn(); // Kết thúc lượt
    }
    protected override void TakeDamage(int damage)
    {
        if (isDefending)
        {
            damage /= 2;
            isDefending = false;
        }

        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }

        UpdateHPBar(); // Cập nhật thanh HP sau khi bị tấn công
    }
    public void AttackEnemy(EnemyCombat target)
    {
        if (target != null)
        {
            Attack(target);
        }
        battleManager.EndTurn();
    }
    public void UpdateHPBar()
    {
        if (hpBar != null)
        {
            hpBar.value = (float)health / maxHP; // Cập nhật giá trị HP bar
        }
    }
}