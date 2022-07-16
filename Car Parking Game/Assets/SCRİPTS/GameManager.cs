using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Header("---LEVEL---")]
    public int DiamondNumber;

    public int remainingCar;
    

    [Header("----CANVAS -------")]
    public TextMeshProUGUI[] texts;
    public GameObject[] panels;
    
    // Start is called before the first frame update
    void Start()
    {
        remainingCar = howmanyCars ;

        for( int i=0; i < howmanyCars; i++)
        {
            carcanvas[i].SetActive(true);
        }
    
        cars[activeCarIndex].SetActive(true);
        checkDefaultSettings();
        
    }
    public void bringNewCar()
    {
        stopTransform.SetActive(true);
        remainingCar--;
        if(activeCarIndex < howmanyCars)
        {
            cars[activeCarIndex].SetActive(true); 
        }
        else
        {
            Win();
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
        if(Input.GetKeyDown(KeyCode.H))
        {
            panels[0].SetActive(false);

        }
        platform_1.transform.Rotate(new Vector3(0,0,turnSpeed[0]),Space.Self);
    }

    public void Lost()
    {
        PlayerPrefs.SetInt("Elmas", PlayerPrefs.GetInt("Elmas")+ DiamondNumber);
        texts[6].text = PlayerPrefs.GetInt("Elmas").ToString();
        texts[7].text= SceneManager.GetActiveScene().name;
        texts[8].text = (howmanyCars - remainingCar).ToString();
        texts[9].text = DiamondNumber.ToString();

        panels[1].SetActive(true);

    }

    void Win()
    {
        PlayerPrefs.SetInt("Elmas", PlayerPrefs.GetInt("Elmas")+ DiamondNumber);
        texts[2].text = PlayerPrefs.GetInt("Elmas").ToString();
        texts[3].text= SceneManager.GetActiveScene().name;
        texts[4].text = (howmanyCars - remainingCar).ToString();
        texts[5].text = DiamondNumber.ToString();
        panels[2].SetActive(true);

    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level",SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



    //BELLEK YÖNETİMİ

    void checkDefaultSettings()
    {
        if(!PlayerPrefs.HasKey("Elmas"))
        {
            PlayerPrefs.SetInt("Elmas",0);
            PlayerPrefs.SetInt("Level",0);
        }
        
        texts[0].text = PlayerPrefs.GetInt("Elmas").ToString();
        texts[1].text= SceneManager.GetActiveScene().name;
    }

    
}
