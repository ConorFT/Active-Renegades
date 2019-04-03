using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterCode : MonoBehaviour
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
            Debug.Log("Working");
            Vector3 point = hit.point; 
            GameObject x = Instantiate(House, point, hit.collider.transform.rotation);
            x.transform.SetParent(hit.transform);


        }


    }
}
