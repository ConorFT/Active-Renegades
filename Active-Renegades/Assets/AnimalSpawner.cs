using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public float animal = 0;
    public float radius = 5;
    Vector3 origin;

    public GameObject animalPrefab;


    // Start is called before the first frame update
    void Start()
    {
        AnimalStart();
    }

    // Update is called once per frame
    void Update()
    {
        AnimalSpawnCount();
    }

    public void AnimalSpawnCount()
    {
        if (animal >= 15)
        {
            Spawn();
            animal -= 15f;
        }
    }
    void MoreAnimal()
    {
        animal += 1;
    }
    void AnimalStart()
    {
        animal = 14f;
        InvokeRepeating("MoreAnimal", 1, 1);
    }

    void Spawn()
    {
        GameObject animal = GameObject.Instantiate<GameObject>(animalPrefab);
        animal.transform.parent = this.transform;
        origin = animal.transform.position;
        origin.x += Random.Range(-radius, radius);
        origin.y += Random.Range(-radius, radius);
        animal.transform.position = origin;
        animal.transform.rotation = this.transform.rotation;
    }
}
