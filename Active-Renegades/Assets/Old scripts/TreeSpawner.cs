using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public float tree = 0;
    public float radius = 5;
    Vector3 origin;

    public GameObject treePrefab;

    // Start is called before the first frame update
    void Start()
    {
        TreeStart();
    }

    // Update is called once per frame
    void Update()
    {
        TreeSpawnCount();
    }

    public void TreeSpawnCount()
    {
        if (tree >= 10)
        {
            Spawn();
            tree -= 10f;
        }
    }
    void MoreTree()
    {
        tree += 1;
    }
    void TreeStart()
    {
        tree = 9f;
        InvokeRepeating("MoreTree", 1, 1);
    }

    void Spawn()
    {
        GameObject trees = GameObject.Instantiate<GameObject>(treePrefab);
        trees.transform.parent = this.transform;
        origin = trees.transform.position;
        origin.x += Random.Range(-radius, radius);
        origin.y += Random.Range(-radius, radius);
        trees.transform.position = origin;
        
        trees.transform.rotation = this.transform.rotation;

        //if (Vector3.Distance(origin, trees.transform.position < radius))
        //{

        //}
    }
}
