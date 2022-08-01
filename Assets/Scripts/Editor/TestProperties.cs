using UnityEngine;
using UnityEditor;

public class TestProperties : MonoBehaviour
{
    public GameObject plane;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public short playerCount;
    public short enemyCount;
    public void ChangeTint()
    {
        EditorPrefs.SetString("Playmode tint", "Playmode tint;1;0;0;1");
    }
}

