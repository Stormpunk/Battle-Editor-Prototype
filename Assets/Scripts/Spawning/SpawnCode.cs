using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCode
{
    //spawns plane and changes plane size to meet needs
    static public void SpawnPlane(GameObject plane, float size)
    {
        Transform go = MonoBehaviour.Instantiate(plane, Vector3.zero, Quaternion.identity).transform;
        go.transform.localScale = Vector3.one * size;
    }
    //takes spawn location and spawns soldiers on that side
    static public void SpawnOrdered(GameObject prefab, float size, Transform spawn)
    {
        //TODO: this shit
    }
    //for a chaotic battlefield, size changes spawnzone size
    static public void SpawnMixed(GameObject prefab, float size)
    {
        //area size scales with number of enemies, in theory
        Vector3 area = Vector3.zero;
        area.y = (prefab.GetComponent<Renderer>().bounds.size.y) / 2;//this should make the object barely touch the ground, don't use collider.bounds.size as object has not yet spawned in
        
        do//run once, keep running if it overlaps an object
        {
            area.x = Random.Range(-size, size);
            area.z = Random.Range(-size, size);
        } while (Physics.OverlapSphere(area, 0.5f).Length != 0);
        
        MonoBehaviour.Instantiate(prefab, area, Quaternion.identity);//can use empty gameobject as parent, can come in handy
    }
}
