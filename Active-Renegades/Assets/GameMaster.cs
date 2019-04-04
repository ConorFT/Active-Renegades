using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class GameMaster : MonoBehaviour
{
    public GameObject[] trees, animals;
    public static GameObject GM;
    public string levelToload;
   
     
    
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

        if(treesPercent < 5 || animalsPercent < 1){

            doomCount += Time.deltaTime; 
        } 
        if(doomCount > 5 && canEnd){
            doomCount = 0; 
            endGame.enabled = true; 
        } 
    }
    public Canvas endGame;
    public bool canEnd = false; 
    
    public float doomCount = 0; 
    void Ticks()
    {

        if(treesPercent < maxTrees)
        {
            treesPercent += 0.75f;

        }
        if (animalsPercent < maxAnimals && treesPercent > 2f)
        {
            animalsPercent += 1f;

        }
    }

    public void ReloadLevel(){

        SceneManager.LoadScene(levelToload);

    }

   



}
