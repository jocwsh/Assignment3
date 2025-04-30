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
    private float roundcountdown;
    public bool roundactive = false;

    public GameObject btnNextRound;

    private float thresholdscore;
    //private float exponent;

    private TextMeshPro timertext;

    private float[] thresholdcuttoff;

    private float playscore;

    void Start()
    {
        roundcountdown = roundtime;
        timertext = GetComponent<TextMeshPro>();

        //threshold is currently an array but can be a formula later
        thresholdcuttoff = new float [6] {500, 800, 1200, 1800, 2500, 3500};

        
    }

    void Update()
    {

        playscore = GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().score;

        if (roundactive == false)
        {
            roundactive = btnNextRound.GetComponent<buttonmanager>().buttonpressed;
            roundcountdown = roundtime;
            timertext.text = "0.000";

            if (btnNextRound.GetComponent<buttonmanager>().buttonpressed == true)
            {
                roundactive = true;
                btnNextRound.GetComponent<buttonmanager>().buttonpressed = false;

                /* This is me trying to figure out the threshold, it doesnt work
                exponent = (roundnumber + 10) / 10;
                Debug.Log (exponent);
                thresholdscore = math.pow (40, exponent);

                Debug.Log (thresholdscore);
                */

                //sets button bool back to false 

                
                
                btnNextRound.GetComponent<buttonmanager>().makefalse();
            }
        }

        if (roundactive == true)
        {
            //makes button uninteractable
            btnNextRound.GetComponent<Button>().interactable = false;
            
            //moves off screen
            btnNextRound.GetComponent<RectTransform>().localPosition = new Vector2(0, 500);

            thresholdscore = thresholdcuttoff[roundnumber];

            playround();
        }
    }


    void playround()
    {
        roundcountdown -= Time.deltaTime;
        //maybe cut off some decimals at the end here
        timertext.text = roundcountdown.ToString("0.000");

        //logic for round in here



        //this is for checking threshold
        
        if (roundcountdown < 0)
        {
            if (playscore >= thresholdscore)
            {
                roundactive = false;
                roundnumber += 1;

                Debug.Log (thresholdscore);

                Debug.Log (playscore);

                Debug.Log("you win");
            

                //makes button interactable
                btnNextRound.GetComponent<Button>().interactable = true;

                //moves back on screen
                btnNextRound.GetComponent<RectTransform>().localPosition = new Vector2 (0, 0);
            }

            else
            {
                //put lose menu here
                Debug.Log (thresholdscore);
                roundactive = false;
                Debug.Log (playscore);
                Debug.Log ("you lose");
            }
            

        }

    }
       
}
