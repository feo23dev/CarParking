using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject car;
    [Header("Platform Properties")]
    public GameObject platform_1;
    public GameObject platform_2;
    
    public float[] turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            car.GetComponent<car>().move = true;
        }
        platform_1.transform.Rotate(new Vector3(0,0,turnSpeed[0]),Space.Self);
    }
}
