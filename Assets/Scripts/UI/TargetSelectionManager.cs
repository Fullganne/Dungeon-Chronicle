//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.TextCore.Text;

//public class TargetSelectionManager : MonoBehaviour
//{
//    public static TargetSelectionManager Instance;

//    private List<Character> availableTargets = new List<Character>(); // Danh sách mục tiêu hợp lệ
//    private SkillSO selectedSkill; // Kỹ năng hiện tại
//    private Character selectedTarget; // Mục tiêu được chọn

//    void Awake()
//    {
//        Instance = this;
//    }

//    public void StartTargetSelection(SkillSO skill)
//    {
//        selectedSkill = skill; // Lưu kỹ năng được chọn
//        availableTargets = GetAvailableTargets(); // Lấy danh sách mục tiêu hợp lệ

//        if (selectedSkill.isAOE)
//        {
//            // Nếu là kỹ năng diện rộng, tự động chọn tất cả mục tiêu
//            ExecuteSkill(availableTargets);
//        }
//        else
//        {
//            // Nếu là kỹ năng đơn, yêu cầu chọn mục tiêu
//            ShowTargetSelectionUI();
//        }
//    }

//    void ShowTargetSelectionUI()
//    {
//        // Hiển thị UI chọn mục tiêu (có thể highlight kẻ địch)
//        Debug.Log("Chọn mục tiêu để dùng " + selectedSkill.skillName);
//    }

//    public void SelectTarget(Character target)
//    {
//        selectedTarget = target;
//        ExecuteSkill(new List<Character> { selectedTarget });
//    }

//    void ExecuteSkill(List<Character> targets)
//    {
//        // Gửi thông tin kỹ năng và mục tiêu đến BattleSystem để thực thi
//        BattleManager.Instance.PerformSkill(selectedSkill, targets);
//    }

//    List<Character> GetAvailableTargets()
//    {
//        // Giả lập lấy danh sách kẻ địch (có thể cập nhật theo trạng thái trận đấu)
//        return BattleManager.Instance.GetEnemyCharacters();
//    }
//}
