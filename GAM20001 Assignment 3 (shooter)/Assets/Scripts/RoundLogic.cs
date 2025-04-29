using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class RoundLogic : MonoBehaviour
{
    private int roundnumber = 1;
    public float roundtime;
    private float roundcountdown;
    public bool roundactive = false;

    public GameObject btnNextRound;

    private float thresholdscore;

    private float exponent;

    void Start()
    {
        roundcountdown = roundtime;
    }

    void Update()
    {

        if (roundactive == false)
        {
            roundactive = btnNextRound.GetComponent<buttonmanager>().buttonpressed;
            roundcountdown = roundtime;

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

            playround();
        }
    }


    void playround()
    {
        roundcountdown -= Time.deltaTime;


        //logic for round in here


        //this is for checking threshold
        //if (roundcountdown < 0 && score >= thresholdscore)
        if (roundcountdown < 0)
        {
            roundactive = false;
            roundnumber += 1;

            Debug.Log(roundnumber);

            //makes button interactable
            btnNextRound.GetComponent<Button>().interactable = true;

            //moves back on screen
            btnNextRound.GetComponent<RectTransform>().localPosition = new Vector2 (0, 0);

        }
    }
       
}
