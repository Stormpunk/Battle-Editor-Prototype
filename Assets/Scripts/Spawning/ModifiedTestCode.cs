using UnityEngine;
using UnityEditor;

public class ModifiedTestCode : MonoBehaviour
{
    //GameObjects to spawn
    public GameObject plane;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    GameObject[] gameObjects;
    public bool isCreated = false;
    //Amount of units to spawn, will adjust spawning area based on amount of units
    public short playerCount;
    public short enemyCount;

    private void Start()
    {
        
    }
    //Create function to change the colour of playmode tint. Currently set to change to Red
    public void ChangeTint()
    {
        EditorPrefs.SetString("Playmode tint", "Playmode tint;1;0;0;1");
    }

    public void CreateAll()
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
        isCreated = true;
    }
    public void DestroyAll()
    {
        //creates a variable that stores all game objects found with the tag "Test Object"
        gameObjects = GameObject.FindGameObjectsWithTag("Test Object");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            //destroys all game objects stored in that variable
            DestroyImmediate(gameObjects[i]);
        }
        Debug.Log("Destroying All");
        isCreated = false;
    }
    public void ResetValues()
    {
        playerCount = 10;
        enemyCount = 10;
    }
}
