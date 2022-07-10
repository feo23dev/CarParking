using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("---CAR'S PROPERTIES---")]
    public GameObject[] cars;
    
    public GameObject[] carcanvas;
    public Sprite carSprite;
    public int howmanyCars;
    int activeCarIndex;
    [Header("---Platform Properties---")]
    public GameObject platform_1;
    public GameObject platform_2;
    public float[] turnSpeed;
    public GameObject stopTransform;
    // Start is called before the first frame update
    void Start()
    {
        for( int i=0; i < howmanyCars; i++)
        {
            carcanvas[i].SetActive(true);
        }
    
        cars[activeCarIndex].SetActive(true);
        
        
    }
    public void bringNewCar()
    {
        stopTransform.SetActive(true);
        if(activeCarIndex < howmanyCars)
        {
            cars[activeCarIndex].SetActive(true); 
        }

        carcanvas[activeCarIndex-1].GetComponent<Image>().sprite = carSprite;




    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            cars[activeCarIndex].GetComponent<car>().move = true;
            activeCarIndex++;
        }
        platform_1.transform.Rotate(new Vector3(0,0,turnSpeed[0]),Space.Self);
    }

    
}
