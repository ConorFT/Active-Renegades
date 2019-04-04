using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour
{
public GameObject MainHub;
    public GameObject House;
    public GameObject LumberMill;
    public GameObject Mine;
    public GameObject Barn;
    public Camera cam;
    public float storedAnimal;
    public float storedTree;
    GameObject GM;
    public Text animalT, treeT, populationT;
    public Text houseT, branT, millT;
    int population = 0;
    float storedResorcesTree = 0, storedAnimalsResorces = 0; 
    private void Start()
    {
        InvokeRepeating("CheckFood", 2f, 2f);
    }
    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) && Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Working");
            //Vector3 point = hit.point; 
            //GameObject x = Instantiate(House, point, hit.collider.transform.rotation);
            //x.transform.SetParent(hit.transform);
            SwitchControlers(hit.collider.tag, hit.collider.gameObject, hit.point); 
        }

        animalT.text = storedAnimalsResorces.ToString();
        treeT.text =  storedResorcesTree.ToString();
        populationT.text = population.ToString();
        houseT.text = buildingCost[0].ToString(); 
        branT.text = buildingCost[1].ToString();
        millT.text = buildingCost[2].ToString();
    }
    GameObject selectedHuman;
    bool[] activeHouse = new bool[3];
    public GameObject[] buildings;
    public int[] buildingCost = {100, 100 , 100 }; 
    void SwitchControlers(string x, GameObject y, Vector3 hitPos){

        switch (x){
            case "Trees":
                Debug.Log("Trees");
                GameMaster.GM.GetComponent<GameMaster>().treesPercent -= 0.5f;
                storedResorcesTree += 5;
                break;

            case "Animals":
                Debug.Log("Animals");
                GameMaster.GM.GetComponent<GameMaster>().animalsPercent -= 1f;
                storedAnimalsResorces += 10;
                break;

            case "Ground":

                for (int i = 0; i < activeHouse.Length; i++) {

                    if (activeHouse[i]) {

                        if(buildingCost[i] <= storedResorcesTree){
                            GameObject z = Instantiate(buildings[i], hitPos, y.transform.rotation);
                            z.transform.SetParent(y.transform);
                            MatsMod(i);
                        }
                        activeHouse[i] = false; 
                        break;
                    }

                }
                break;

            default:
                 break; 

        }



    }
     
    void MatsMod(int x){

        

                storedResorcesTree -= buildingCost[x];
                buildingCost[x] =  Mathf.RoundToInt(buildingCost[x] * 1.1f); 

        switch (x){
            //house

            case 0:
                population += 2; 
                break;
            case 1:
                InvokeRepeating("BarnAdded", 2f, 2f);
                break;
            case 2:
                InvokeRepeating("MillAdded", 2f, 2f);
                break; 


        }




    }
    void BarnAdded()
    {
        if(population > 0 && GameMaster.GM.GetComponent<GameMaster>().treesPercent > 5 && GameMaster.GM.GetComponent<GameMaster>().animalsPercent > 0)
        {

            GameMaster.GM.GetComponent<GameMaster>().animalsPercent -= 0.5f;
            storedAnimalsResorces += storedAnimal;
        }

    }
    void MillAdded(){

        if(population > 0 && GameMaster.GM.GetComponent<GameMaster>().animalsPercent > 5) {

            GameMaster.GM.GetComponent<GameMaster>().treesPercent -= 1f;
            storedResorcesTree += storedTree; 
        }

    } 

    void CheckFood(){

        int x = population; 
        for(int i =0; i < x; i ++){

            if(storedAnimalsResorces <= population - 1 && population > 0){
                population--; 
            }else{
                storedAnimalsResorces -= 2; 

            }

        } 



    }
    public void ActiveHouseToBuild(int x)
    {

        for(int i = 0; i < buildings.Length; i ++){

            if (i != x) {
                activeHouse[i] = false;

            } else {

                activeHouse[i] = true; 
            }

            } 

    }

}
