using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehaviour : MonoBehaviour
{
    public bool active = false;
    public float recorses = 0;
    Renderer[] col;
    public string huntTarget;



    void Gathering()
    {

        GameObject[] targetResorce = GameObject.FindGameObjectsWithTag(huntTarget);
        int rnd = Random.Range(0, targetResorce.Length);
        transform.position = targetResorce[rnd].transform.position;
    }
}
