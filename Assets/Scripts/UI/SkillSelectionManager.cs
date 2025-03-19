//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections.Generic;

//public class SkillSelectionManager : MonoBehaviour
//{
//    public static SkillSelectionManager Instance;
//    public GameObject skillMenu; // UI menu chọn kỹ năng
//    public Transform skillButtonContainer;
//    public Button skillButtonPrefab;

//    private CharacterCombat currentCharacter;

//    void Awake()
//    {
//        Instance = this;
//        skillMenu.SetActive(false);
//    }

//    public void ShowSkillMenu(CharacterCombat character)
//    {
//        currentCharacter = character;
//        skillMenu.SetActive(true);

//        foreach (Transform child in skillButtonContainer)
//        {
//            Destroy(child.gameObject);
//        }

//        foreach (SkillSO skill in SkillDatabase.Instance.skillList)
//        {
//            Button btn = Instantiate(skillButtonPrefab, skillButtonContainer);
//            btn.GetComponentInChildren<Text>().text = skill.skillName;
//            btn.onClick.AddListener(() => OnSkillSelected(skill));
//        }
//    }

//    void OnSkillSelected(SkillSO selectedSkill)
//    {
//        skillMenu.SetActive(false);
//        TargetSelectionManager.Instance.StartTargetSelection(currentCharacter, selectedSkill);
//    }
//}
