//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class UIManager : MonoBehaviour
//{
//    public static UIManager Instance;
//    public GameObject actionMenu; // Menu chọn hành động
//    public Button attackButton;
//    public Button skillButton;

//    private CharacterCombat currentCharacter;

//    void Awake()
//    {
//        Instance = this;
//        actionMenu.SetActive(false);
//    }

//    public void ShowActionMenu(CharacterCombat character)
//    {
//        currentCharacter = character;
//        actionMenu.SetActive(true);
//    }

//    public void OnAttackPressed()
//    {
//        actionMenu.SetActive(false);
//        TargetSelectionManager.Instance.StartTargetSelection(currentCharacter, SkillDatabase.Instance.defaultAttack);
//    }

//    public void OnSkillPressed()
//    {
//        actionMenu.SetActive(false);
//        SkillSelectionManager.Instance.ShowSkillMenu(currentCharacter);
//    }
//}
