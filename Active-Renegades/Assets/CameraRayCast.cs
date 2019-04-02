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
    GameObject GM;
    public Text animalT, treeT;
    float storedResorcesTree = 0, storedAnimalsResorces = 0; 
    private void Start()
    {
        
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

        animalT.text = "Animal :" + storedAnimalsResorces.ToString();
        treeT.text = "Wood: " + storedResorcesTree.ToString(); 
    }
    GameObject selectedHuman; 
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
                GameObject z =Instantiate(House, hitPos, y.transform.rotation);
                z.transform.SetParent(y.transform);

                break;

            default:
                 break; 

        }



    } 


}
