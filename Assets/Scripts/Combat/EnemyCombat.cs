using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : CharacterCombat
{
    public override void StartTurn()
    {
        Debug.Log($"{characterName} (Enemy) đang suy nghĩ...");
        StartCoroutine(EnemyAction());
    }

    IEnumerator EnemyAction()
    {
        yield return new WaitForSeconds(1f);

        CharacterCombat target = FindLowestHPTarget();
        if (target == null)
        {
            battleManager.EndTurn();
            yield break;
        }

        if (skills.Count > 0 && mana >= skills[0].manaCost)
        {
            UseSkill(skills[0], target); // Sử dụng skill đầu tiên trong danh sách
        }
        else
        {
            Attack(target);
        }

        yield return new WaitForSeconds(0.5f);
        battleManager.EndTurn();
    }
    CharacterCombat FindRandomTarget()
    {
        CharacterCombat[] combatants = FindObjectsOfType<CharacterCombat>();
        foreach (var combatant in combatants)
        {
            if (combatant != this) return combatant;
        }
        return null;
    }
    private CharacterCombat FindLowestHPTarget()
    {
        List<CharacterCombat> players = battleManager.GetPlayerCharacters();
        if (players.Count == 0) return null;

        CharacterCombat lowestHPCharacter = players[0];
        foreach (CharacterCombat player in players)
        {
            if (player.health > 0 && player.health < lowestHPCharacter.health)
            {
                lowestHPCharacter = player;
            }
        }

        return lowestHPCharacter;
    }
}
