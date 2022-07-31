using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testingcode : MonoBehaviour
{
    public GameObject plane;
    public GameObject sideOne;
    public GameObject sideTwo;

    private void Start()
    {
        SpawnCode.SpawnPlane(plane, 10);
        for (int i = 0; i < 100; i++)
        {
            SpawnCode.SpawnMixed(sideOne, 10);
        }
        for (int i = 0; i < 100; i++)
        {
            SpawnCode.SpawnMixed(sideTwo, 10);
        }
    }
}
