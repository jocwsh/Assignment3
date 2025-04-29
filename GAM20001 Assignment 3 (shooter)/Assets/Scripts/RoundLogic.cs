using UnityEngine;
using UnityEngine.UI;
public class RoundLogic : MonoBehaviour
{
    private int roundnumber = 1;
    private float roundtime = 2f;
    public bool roundactive = false;

    public GameObject btnNextRound;

    
    void Update()
    {

        if (roundactive == false)
        {
            roundactive = btnNextRound.GetComponent<buttonmanager>().buttonpressed;
            roundtime = 2f;

            if (btnNextRound.GetComponent<buttonmanager>().buttonpressed == true)
            {
                roundactive = true;
                btnNextRound.GetComponent<buttonmanager>().buttonpressed = false;

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
        roundtime -= Time.deltaTime;

        //logic for round in here

        if (roundtime < 0)
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
