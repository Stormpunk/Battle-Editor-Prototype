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
        SpawnCode.SpawnPlane(plane, 4);
        for (int i = 0; i < 10; i++)
        {
            SpawnCode.SpawnMixed(sideOne, 4);
        }
    }
}
