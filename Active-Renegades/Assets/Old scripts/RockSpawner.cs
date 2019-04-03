using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public float rock = 0;
    public float radius = 5;
    Vector3 origin;

    public GameObject rockPrefab;


    // Start is called before the first frame update
    void Start()
    {
        RockStart();
    }

    // Update is called once per frame
    void Update()
    {
        RockSpawnCount();
    }

    public void RockSpawnCount()
    {
        if (rock >= 20)
        {
            Spawn();
            rock -= 20f;
        }
    }
    void MoreRock()
    {
        rock += 1;
    }
    void RockStart()
    {
        rock = 19f;
        InvokeRepeating("MoreRock", 1, 1);
    }

    void Spawn()
    {
        GameObject rock = GameObject.Instantiate<GameObject>(rockPrefab);
        rock.transform.parent = this.transform;
        origin = rock.transform.position;
        origin.x += Random.Range(-radius, radius);
        origin.y += Random.Range(-radius, radius);
        rock.transform.position = origin;
        rock.transform.rotation = this.transform.rotation;
    }
}
