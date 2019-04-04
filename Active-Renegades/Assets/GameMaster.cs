using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMaster : MonoBehaviour
{
    public GameObject[] trees, animals;
    public static GameObject GM;
     
    
    void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("Trees");
        animals = GameObject.FindGameObjectsWithTag("Animals");
        maxAnimals = animals.Length;
        maxTrees = trees.Length;
        treesPercent = maxTrees;
        animalsPercent = maxAnimals;
        GameMaster.GM = gameObject;
        InvokeRepeating("Ticks", 2f, 2f);
    }
     
    public float maxAnimals, maxTrees;
    [Range(0,100)]
    public float treesPercent = 100f, animalsPercent = 100f; 
    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < maxTrees; i++)
        {
            if(i < treesPercent)
            {
                trees[i].SetActive(true);
            }
            else
            {
                trees[i].SetActive(false);
            }

        }
        for (int i = 0; i < animals.Length; i++)
        {
            if (i < animalsPercent)
            {
                animals[i].SetActive(true);
            }
            else
            {
                animals[i].SetActive(false);
            }

        }
        
    }

    void Ticks()
    {

        if(treesPercent < maxTrees)
        {
            treesPercent += 0.5f;

        }
        if (animalsPercent < maxAnimals && treesPercent > 3f)
        {
            animalsPercent += 0.25f;

        }
    }



}
