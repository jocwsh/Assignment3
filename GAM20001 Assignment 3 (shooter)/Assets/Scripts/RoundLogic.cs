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
    public bool gameover = false;

    public float thresholdscore;

    private float[] thresholdcuttoff;

    private float playscore;

    public AudioSource audioSource;
    public AudioClip winsound;
    public AudioClip losesound;

    void Start()
    {
        roundcountdown = roundtime;

        //threshold is currently an array but can be a formula later
        //i think the first one can be cut out if too easy
        thresholdcuttoff = new float[] { 400, 500, 700, 900, 1200, 1500, 1900, 2400, 3000, 3700, 4500, 5700 };
        thresholdscore = thresholdcuttoff[0];

        //GameObject.Find("thresholdscore").GetComponent<updatethresh>().newthresh();
    }

    void Update()
    {
        if (roundactive == false)
        {
            roundcountdown = roundtime;
        }


        if (roundactive == true)
        {
            playround();
        }

    }

    public void buttonclicked()
    {
        roundnumber += 1;
        thresholdscore = thresholdcuttoff[roundnumber];
        roundactive = true;


        GameObject.Find("thresholdscore").GetComponent<updatethresh>().newthresh();
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
                GameObject.Find("RandomiseCanvas").GetComponent<ButtonRandomiser>().AssignButtons();


                Debug.Log(thresholdscore);
                Debug.Log("you win");

                audioSource.clip = winsound;
                audioSource.Play();

            }

            else
            {
                roundactive = false;
                gameover = true;
                //do gameover = true instead of ^^

                Debug.Log(thresholdscore);
                Debug.Log("you lose");

                audioSource.clip = losesound;
                audioSource.Play();
            }

        }

    }

    public void resetgame()
    {
        roundnumber = 0;
        thresholdscore = thresholdcuttoff[roundnumber];

        GameObject.Find("thresholdscore").GetComponent<updatethresh>().newthresh();
        


        roundactive = true;
        gameover = false;
        
    
    }

}
