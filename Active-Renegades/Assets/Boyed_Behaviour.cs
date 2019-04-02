using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boyed_Behaviour : MonoBehaviour {


	
	public float  mass = 1 , maxSpeed = 5 , slowingDistance = 5 ;
    public Vector3 volocity, accelaration, target, force;

    private void Start()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("Ground").transform);
        ariveTarget.transform.position = Vector3.zero; 

    }
    // seek Behavour 
    Vector3 Seek(Vector3 x){
        // look at the target location
        Vector3 desired = x - transform.position;
        //normalize the vector to max it easyer to work with
        desired.Normalize(); 
        // using the normalized vector scale it for faster movement
        desired *= maxSpeed; 
        // return the required voloisity for the seek behavious
        return desired - volocity;  
    } 

    Vector3 Arrive(Vector3 x){
        // find 
        Vector3 toTarget = x - transform.position;
        // check the distance form the target object 
        float dist = toTarget.magnitude; 
        // slow down the speed relative to distance;
        float rampSpeed = (dist/slowingDistance) * maxSpeed;
        //limit the maxamum possable speed  
        float clamped = Mathf.Min(rampSpeed, maxSpeed);
        // modifie speed by the distance form the object 
        Vector3 desirded = clamped * (toTarget /dist);
        // return movement vector
        return desirded - volocity; 
    }

    public GameObject ariveTarget; 
    void Update () {
       
        
            
                force = Arrive(ariveTarget.transform.position);
                force.y =0; 
        
                // work out the amount I can accelarate by 
                accelaration = force/mass;
                // work out movement baced on accelartation and make frame rate indpented
                volocity += accelaration *Time.deltaTime;
                // move the object along the liner line
                transform.position += volocity * Time.deltaTime; 

                if(volocity.magnitude > float.Epsilon){
                    // rotate to look at the direction of movement
                    transform.forward = volocity; 
            } 
        }


	}

