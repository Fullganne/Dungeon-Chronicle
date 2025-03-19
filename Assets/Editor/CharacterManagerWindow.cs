using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class CharacterManagerWindow : EditorWindow
{
    private List<CharacterData> characters;
    private Vector2 scrollPos;

    [MenuItem("RPG Editor/Character Manager")]
    public static void ShowWindow()
    {
        GetWindow<CharacterManagerWindow>("Character Manager");
    }

    private void OnEnable()
    {
        LoadCharacters();
    }

    void LoadCharacters()
    {
        characters = new List<CharacterData>();
        string[] guids = AssetDatabase.FindAssets("t:CharacterData");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            CharacterData character = AssetDatabase.LoadAssetAtPath<CharacterData>(path);
            characters.Add(character);
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Character List", EditorStyles.boldLabel);
        if (GUILayout.Button("Refresh List"))
        {
            LoadCharacters();
        }

        scrollPos = GUILayout.BeginScrollView(scrollPos);
        foreach (var character in characters)
        {
            GUILayout.BeginHorizontal();
            if (character.characterSprite)
            {
                GUILayout.Label(character.characterSprite.texture, GUILayout.Width(50), GUILayout.Height(50));
            }
            GUILayout.Label(character.characterName);
            if (GUILayout.Button("Edit"))
            {
                Selection.activeObject = character;
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndScrollView();
    }
}
