using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;


public class RoundLogic : MonoBehaviour
{
    private int roundnumber = 0;
    public float roundtime;
    public float roundcountdown;
    public bool roundactive = false;

    public GameObject hardbutton;
    public GameObject easybutton;

    private float thresholdscore;

    private float[] thresholdcuttoff;

    private float playscore;

    void Start()
    {
        roundcountdown = roundtime;

        //threshold is currently an array but can be a formula later
        thresholdcuttoff = new float [6] {500, 800, 1200, 1800, 2500, 3500};
        thresholdscore = thresholdcuttoff[0];
    }

    void Update()
    {
        if (roundactive == false)
        {
            roundcountdown = roundtime;
        }


        if(roundactive == true)
        {
            playround();
        }

    }

    public void buttonclicked()
    {
        roundnumber += 1;
        roundactive= true;
        thresholdscore = thresholdcuttoff[roundnumber];


  

    }


    void playround()
    {

        roundcountdown -= Time.deltaTime;

        //logic for round in here



        //this is for checking threshold
        
        if (roundcountdown < 0)
        {
            playscore = GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().score;

            if (playscore >= thresholdscore)
            {
                //win sequence
                roundactive = false;
                

                Debug.Log (thresholdscore);
                Debug.Log("you win");
        
            }

            else
            {
                roundactive = false;
                //do gameover = true instead of ^^

                Debug.Log (thresholdscore);
                Debug.Log ("you lose");
            }
            
        }

    }
       
}
