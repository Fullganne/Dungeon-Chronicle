using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<CharacterCombat> turnOrder = new List<CharacterCombat>();
    public List<EnemyCombat> enemyList = new List<EnemyCombat>();
    public List<PlayerCombat> playerList = new List<PlayerCombat>();
    private int currentTurnIndex = 0;

    public BattleUIManager battleUIManager; // UI hành động

    void Start()
    {
        SetupBattle();
    }

    void SetupBattle()
    {
        enemyList = FindObjectsOfType<EnemyCombat>().ToList();
        playerList = FindObjectsOfType<PlayerCombat>().ToList();

        turnOrder = new List<CharacterCombat>();
        turnOrder.AddRange(playerList);
        turnOrder.AddRange(enemyList);
        
        SortTurnOrder();

        StartCoroutine(NextTurn());
    }

    IEnumerator NextTurn()
    {
        while (true)
        {
            if (turnOrder.Count == 0) yield break;

            CharacterCombat currentCharacter = turnOrder[currentTurnIndex];

            if (currentCharacter.health > 0)
            {
                currentCharacter.StartTurn();
                yield break;
            }

            currentTurnIndex = (currentTurnIndex + 1) % turnOrder.Count;
        }
    }
    public List<CharacterCombat> GetPlayerCharacters()
    {
        List<CharacterCombat> players = new List<CharacterCombat>();
        foreach (CharacterCombat character in turnOrder)
        {
            if (character is PlayerCombat && character.health > 0)
            {
                players.Add(character);
            }
        }
        return players;
    }
    public List<EnemyCombat> GetAllEnemies()
    {
        return enemyList.Where(enemy => enemy.isAlive).ToList();
    }

    public void EndTurn()
    {
        currentTurnIndex = (currentTurnIndex + 1) % turnOrder.Count;
        StartCoroutine(NextTurn());
    }

    public void ShowActionUI(PlayerCombat player)
    {
        battleUIManager.ShowActionMenu(player);
        // Code để hiển thị UI cho nhân vật lựa chọn hành động
    }
    public void StartPlayerTurn(PlayerCombat player)
    {
        battleUIManager.ShowEnemySelection();
    }
    public void SortTurnOrder()
    {
        turnOrder = turnOrder.OrderByDescending(c => c.speed).ToList();
    }
}
