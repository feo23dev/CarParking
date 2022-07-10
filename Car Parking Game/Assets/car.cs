using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public bool move;
    public Transform parent;
    public GameObject[] trails;
    
    //


    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(move == true)
        {
            transform.Translate(transform.forward * 15f * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("parking"))
        {
            move=false;
            transform.SetParent(parent);
            trails[0].SetActive(false);
            trails[1].SetActive(false);
            
        }
        if(other.gameObject.CompareTag("middle"))
        {
            Destroy(gameObject); // later with obj pool,false
        }
        
    }
}
