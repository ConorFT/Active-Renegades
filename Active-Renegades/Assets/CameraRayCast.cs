using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
public GameObject MainHub;
    public GameObject House;
    public GameObject LumberMill;
    public GameObject Mine;
    public GameObject Barn;
    public Camera cam;


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
    }
    GameObject selectedHuman; 
    void SwitchControlers(string x, GameObject y, Vector3 hitPos){

        switch (x){
            case "Human":
                y.GetComponent<HumanBehaviour>().active = true; 
                selectedHuman = y; 
                break; 
             
                

        case "Ground":
                if(selectedHuman != null){
                    selectedHuman.GetComponent<Boyed_Behaviour>().ariveTarget.transform.position = hitPos; 
                    selectedHuman.GetComponent<HumanBehaviour>().active = false; 
                    selectedHuman = null;
                }
                

                break; 

            default:
                 break; 

        }



    } 


}
