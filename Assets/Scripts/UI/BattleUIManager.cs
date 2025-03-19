using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    private BattleManager battleManager;

    public GameObject actionPanel;
    public Button attackButton, skillButton, itemButton, defendButton, runButton;
    public Text statusText;

    public GameObject enemySelectionPanel;
    public Transform enemyButtonContainer;
    public GameObject enemyButtonPrefab;

    public GameObject playerSelectionPanel;
    public Transform playerButtonContainer;
    public GameObject playerButtonPrefab;

    private PlayerCombat currentPlayer;
    private ActionType selectedAction;
    private SkillData selectedSkill;
    private ItemData selectedItem;

    public enum ActionType
    {
        None,
        Attack,
        Defend,
        Skill,
        Item,
        Run
    }

    void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();
        actionPanel.SetActive(false);
        enemySelectionPanel.SetActive(false);
        playerSelectionPanel.SetActive(false);

        attackButton.onClick.AddListener(() => SelectAction(ActionType.Attack));
        defendButton.onClick.AddListener(() => SelectAction(ActionType.Defend));
        skillButton.onClick.AddListener(() => SelectAction(ActionType.Skill));
        itemButton.onClick.AddListener(() => SelectAction(ActionType.Item));
        runButton.onClick.AddListener(() => SelectAction(ActionType.Run));
    }

    public void ShowActionMenu(PlayerCombat player)
    {
        currentPlayer = player;
        selectedAction = ActionType.None;
        actionPanel.SetActive(true);
    }

    public void HideActions()
    {
        actionPanel.SetActive(false);
        enemySelectionPanel.SetActive(false);
        playerSelectionPanel.SetActive(false);
    }

    public void SelectAction(ActionType action)
    {
        selectedAction = action;
        actionPanel.SetActive(false);

        switch (selectedAction)
        {
            case ActionType.Attack:
                ShowEnemySelection();
                break;
            case ActionType.Defend:
                currentPlayer.Defend();
                battleManager.EndTurn();
                break;
            case ActionType.Skill:
                ShowSkillSelection();
                break;
            case ActionType.Item:
                ShowItemSelection();
                break;
        }
    }

    public void ShowEnemySelection(bool includePlayers = false)
    {
        enemySelectionPanel.SetActive(true);
        PopulateTargetList(enemyButtonContainer, enemyButtonPrefab, battleManager.GetAllEnemies(), SelectEnemy);

        if (includePlayers)
        {
            PopulateTargetList(enemyButtonContainer, enemyButtonPrefab, battleManager.GetPlayerCharacters(), SelectPlayer);
        }
    }

    public void ShowPlayerSelection()
    {
        playerSelectionPanel.SetActive(true);
        PopulateTargetList(playerButtonContainer, playerButtonPrefab, battleManager.GetPlayerCharacters(), SelectPlayer);
    }

    private void PopulateTargetList<T>(Transform container, GameObject buttonPrefab, List<T> targets, System.Action<T> onSelect)
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        foreach (var target in targets)
        {
            GameObject newButton = Instantiate(buttonPrefab, container);
            newButton.GetComponentInChildren<Text>().text = target.ToString();
            newButton.GetComponent<Button>().onClick.AddListener(() => onSelect(target));
        }
    }

    void SelectEnemy(EnemyCombat enemy)
    {
        enemySelectionPanel.SetActive(false);
        PerformAction(enemy);
    }

    void SelectPlayer(CharacterCombat player)
    {
        playerSelectionPanel.SetActive(false);
        PerformAction(player);
    }

    void PerformAction(CharacterCombat target)
    {
        switch (selectedAction)
        {
            case ActionType.Attack:
                currentPlayer.AttackEnemy(target as EnemyCombat);
                break;
            case ActionType.Skill:
                currentPlayer.UseSkill(selectedSkill, target);
                break;
            case ActionType.Item:
                //currentPlayer.UseItem(selectedItem, target);
                break;
        }
        battleManager.EndTurn();
    }

    private void ShowSkillSelection()
    {
        Debug.Log("Hiển thị danh sách kỹ năng");
        // Kiểm tra loại kỹ năng để chọn Enemy hoặc Player
    }

    private void ShowItemSelection()
    {
        Debug.Log("Hiển thị danh sách vật phẩm");
        // Kiểm tra loại vật phẩm để chọn Enemy hoặc Player
    }
}
