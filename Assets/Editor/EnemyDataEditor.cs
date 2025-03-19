using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyData))]
public class EnemyDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EnemyData enemy = (EnemyData)target;

        GUILayout.Label("Enemy Info", EditorStyles.boldLabel);

        enemy.characterName = EditorGUILayout.TextField("Name", enemy.characterName);
        enemy.characterSprite = (Sprite)EditorGUILayout.ObjectField("Sprite", enemy.characterSprite, typeof(Sprite), false);
        enemy.maxHP = EditorGUILayout.IntField("Max HP", enemy.maxHP);
        enemy.maxMP = EditorGUILayout.IntField("Max MP", enemy.maxMP);
        enemy.attack = EditorGUILayout.IntField("Attack", enemy.attack);
        enemy.defense = EditorGUILayout.IntField("Defense", enemy.defense);
        enemy.speed = EditorGUILayout.IntField("Speed", enemy.speed);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Enemy Settings", EditorStyles.boldLabel);
        enemy.expDrop = EditorGUILayout.IntField("EXP Drop", enemy.expDrop);
        enemy.goldDrop = EditorGUILayout.IntField("Gold Drop", enemy.goldDrop);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(enemy);
        }
    }
}