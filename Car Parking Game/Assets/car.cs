using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public bool move;
    public Transform parent;
    public GameObject[] trails;
    public GameManager _gameManager;
    public bool stopPoint;
    
    
    //


    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(!stopPoint)
        {
            transform.Translate(transform.forward * 4f * Time.deltaTime);
        }
        if(move)
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
            _gameManager.bringNewCar();

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            
        }
        else if(other.gameObject.CompareTag("stopper"))
        {
            stopPoint = true;
            _gameManager.stopTransform.SetActive(false);
            
        }
        else if(other.gameObject.CompareTag("middle"))
        {
            Destroy(gameObject); // canvas + setActiveFalse
        }

        else if(other.gameObject.CompareTag("car"))
        {
            Destroy(gameObject); // canvas + setActiveFalse
        }
        
    }
}
