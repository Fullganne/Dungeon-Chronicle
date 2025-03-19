using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterData))]
public class CharacterDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CharacterData character = (CharacterData)target;

        GUILayout.Label("Character Info", EditorStyles.boldLabel);

        character.characterName = EditorGUILayout.TextField("Name", character.characterName);
        character.characterSprite = (Sprite)EditorGUILayout.ObjectField("Sprite", character.characterSprite, typeof(Sprite), false);
        character.maxHP = EditorGUILayout.IntField("Max HP", character.maxHP);
        character.maxMP = EditorGUILayout.IntField("Max MP", character.maxMP);
        character.attack = EditorGUILayout.IntField("Attack", character.attack);
        character.defense = EditorGUILayout.IntField("Defense", character.defense);
        character.speed = EditorGUILayout.IntField("Speed", character.speed);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Skills", EditorStyles.boldLabel);
        if (character.skills == null)
            character.skills = new System.Collections.Generic.List<SkillData>();

        for (int i = 0; i < character.skills.Count; i++)
        {
            character.skills[i] = (SkillData)EditorGUILayout.ObjectField("Skill " + (i + 1), character.skills[i], typeof(SkillData), false);
        }

        if (GUILayout.Button("Add Skill"))
        {
            character.skills.Add(null);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(character);
        }
    }
}
