using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ModifiedTestCode : MonoBehaviour
{
    public GameObject plane;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public short playerCount;
    public short enemyCount;

    private void Start()
    {
        SpawnCode.SpawnPlane(plane, 10);
        for (int i = 0; i < playerCount; i++)
        {
            SpawnCode.SpawnMixed(playerPrefab, 10);
        }
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnCode.SpawnMixed(enemyPrefab, 10);
        }
    }
    public void ChangeTint()
    {
        EditorPrefs.SetString("Playmode tint", "Playmode tint;1;0;0;1");
    }
}
