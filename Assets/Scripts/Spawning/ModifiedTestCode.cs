using UnityEngine;
using UnityEditor;

public class ModifiedTestCode : MonoBehaviour
{
    //GameObjects to spawn
    public GameObject plane;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    //Amount of units to spawn, will adjust spawning area based on amount of units
    public short playerCount;
    public short enemyCount;

    private void Start()
    {
        //Spawn the plane according to the SpawnPlane function from the SpawnCode script
        SpawnCode.SpawnPlane(plane, 10);
        //Use the SpawnMixed function of the SpawnCode script to spawn units based on the amount and spread set by playerCount
        for (int i = 0; i < playerCount; i++)
        {
            SpawnCode.SpawnMixed(playerPrefab, playerCount * 0.5f);
        }
        //Use the SpawnMixed function of the SpawnCode script to spawn units based on the amount and spread set by enemyCount
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnCode.SpawnMixed(enemyPrefab, enemyCount * 0.5f);
        }
    }
    //Create function to change the colour of playmode tint. Currently set to change to Red
    public void ChangeTint()
    {
        EditorPrefs.SetString("Playmode tint", "Playmode tint;1;0;0;1");
    }
}
