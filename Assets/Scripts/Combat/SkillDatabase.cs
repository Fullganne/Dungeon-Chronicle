using System.Collections.Generic;
using UnityEngine;

public class SkillDatabase : MonoBehaviour
{
    public static SkillDatabase Instance;
    public SkillSO defaultAttack;
    public List<SkillSO> skillList = new List<SkillSO>();

    void Awake()
    {
        Instance = this;
    }
}