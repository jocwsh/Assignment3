using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModSystem : MonoBehaviour
{
    public float scoremult;
    public float speedscoremult;
    public float sizescoremult;
    public float spawnfrequencyscoremult;
    public float fireratescoremult;

    //private float changingscoremult;
    //private int changingcounter;

    public float[] positivemult;




    public float speedmult;
    public int speedcounter;

    public GameObject stack1, stack2, stack3, stack4;
    public GameObject speedticket, speedtoken, text;
    private Vector3 spawnpos;

    void Start()
    {
        //have table on screen
        // For each token = -5%
        // 1 ticket = +20%
        // 2 ticktes = +40%
        // 3 tickets = +70%
        //and so on


        //if this changes, we need to change the array in button randomiser too
        positivemult = new float[] {0.15f, 0.4f, 0.7f, 1f, 1.4f, 2f};
    }

    public float changescoremult(float changingscoremult, int changingcounter)
    {
        if (changingcounter > 0)
        {
            changingscoremult = positivemult[changingcounter -1];
        }

        else if (changingcounter <= 0)
        {
            changingscoremult = -0.05f * Mathf.Abs(changingcounter);
        }


        return changingscoremult;
    }


    private void changestack(GameObject stack, int counter, string modname, float mult, GameObject ticket, GameObject token)//have to change which tokens/tickets will be created
    {
        if (counter == 0)
        {
            for (int a = stack.transform.childCount - 1; a >= 0; a--)
            {
                Destroy(stack.transform.GetChild(a).gameObject);
            }

            Instantiate(text, stack.transform);
            TextMeshProUGUI[] stacktext = stack.GetComponentsInChildren<TextMeshProUGUI>();

            //this is like this cuz destroying shit is stupid
            stacktext[0].text = "";
            stacktext[1].text = "";
            
        }

        else
        {
            for (int a = stack.transform.childCount - 1; a >= 0; a--)
            {
                Destroy(stack.transform.GetChild(a).gameObject);
            }

            if (counter > 0)
            {
                for (int i = 0; i < Mathf.Abs(counter); i++)
                {
                    spawnpos = stack.transform.position - new Vector3(0, 30 * i, 0);
                    Instantiate(ticket, spawnpos, Quaternion.identity, stack.transform);
                }
            }

            else if (counter < 0)
            {
                for (int i = 0; i < Mathf.Abs(counter); i++)
                {
                    spawnpos = stack.transform.position - new Vector3(0, 30 * i, 0);
                    Instantiate(token, spawnpos, Quaternion.identity, stack.transform);
                }
            }
            
            // can change position of text using above value if overlapping
            Instantiate(text, spawnpos - new Vector3(0, 125, 0), Quaternion.identity, stack.transform);
            TextMeshProUGUI[] stacktext = stack.GetComponentsInChildren<TextMeshProUGUI>();

            //this is like this cuz destroying shit is stupid
            stacktext[0].text = modname + mult * 100 + "%";
            stacktext[1].text = modname + mult * 100 + "%";

        }
        
        
    }

    public float calculatescoremult()
    {
        scoremult = 1 + speedscoremult + sizescoremult + spawnfrequencyscoremult + fireratescoremult;

        GameObject.Find("MultiplierHUD").GetComponent<multhud>().NewRound();

        return scoremult;
    }


    public void speedhard() //faster speed but more score
    {
        speedcounter += 1;
        speedmult = 1 + 0.1f * speedcounter;

        speedscoremult = changescoremult(speedscoremult, speedcounter);

        calculatescoremult();

        changestack(stack1, speedcounter, "Bonus Multiplier: ", speedscoremult, speedticket, speedtoken);

    }

    public void speedeasy() //-0.1 to mult
    {
        speedcounter -= 1;
        speedmult = 1 + 0.1f * speedcounter;

        speedscoremult = changescoremult(speedscoremult, speedcounter);

        calculatescoremult();
        changestack(stack1, speedcounter,  "Bonus Multiplier: ", speedscoremult, speedticket, speedtoken);
    }




    public float sizemult;
    public int sizecounter;

    public void sizehard() //smaller size but more score
    {
        sizecounter += 1;
        sizemult = 1 + 0.1f * -sizecounter;

        sizescoremult = changescoremult(sizescoremult, sizecounter);

        calculatescoremult();
        changestack(stack2, sizecounter, "Bonus Multiplier: ", sizescoremult, speedticket, speedtoken);
    }

    public void sizeeasy()
    {
        sizecounter -= 1;
        sizemult = 1 + 0.1f * -sizecounter;

        sizescoremult = changescoremult(sizescoremult, sizecounter);

        calculatescoremult();
        changestack(stack2, sizecounter, "Bonus Multiplier: ", sizescoremult, speedticket, speedtoken);
    }

    public float fireratemod;
    public int fireratecounter;

    public void fireratehard() //slower firerate but more score
    {
        fireratecounter += 1;
        fireratemod = 1 + 0.2f * fireratecounter;

        fireratescoremult = changescoremult(fireratescoremult, fireratecounter);

        calculatescoremult();
        changestack(stack3, fireratecounter, "Bonus Multiplier: ", fireratescoremult, speedticket, speedtoken);
    }

    public void firerateeasy()
    {
        fireratecounter -= 1;
        fireratemod = 1 + 0.2f * fireratecounter;

        fireratescoremult = changescoremult(fireratescoremult, fireratecounter);

        calculatescoremult();
        changestack(stack3, fireratecounter, "Bonus Multiplier: ", fireratescoremult, speedticket, speedtoken);
    }


    public float spawntimemod;
    public int spawntimecounter;

    public void targetspawnfrequencyhard() //less frequent spawns but more score
    {
        spawntimecounter += 1;
        spawntimemod = 1 + 0.1f * spawntimecounter;

        spawnfrequencyscoremult = changescoremult(spawnfrequencyscoremult, spawntimecounter);

        calculatescoremult();
        changestack(stack4, spawntimecounter, "Bonus Multiplier: ", spawnfrequencyscoremult, speedticket, speedtoken);
    }

    public void targetspawnfrequencyeasy()
    {
        spawntimecounter -= 1;
        spawntimemod = 1 + 0.1f * spawntimecounter;

        spawnfrequencyscoremult = changescoremult(spawnfrequencyscoremult, spawntimecounter);

        calculatescoremult();
        changestack(stack4, spawntimecounter, "Bonus Multiplier: ", spawnfrequencyscoremult, speedticket, speedtoken);
    }



    


    //havent added this as mod yet
    public float ballsizemod;
    public int ballsizecounter;

    public void ballsizehard() //smaller ball size but more score
    {
        ballsizecounter += 1;
        ballsizemod = 1 + 0.1f * -ballsizecounter;
    }

    public void ballsizeeasy()
    {
        ballsizecounter -= 1;
        ballsizemod = 1 + 0.1f * -ballsizecounter;
    }





    //currently unsure if this works

    /*public float hardtargetsizefrequency;
    public float easytargetsizefrequency;
    public int targetsizefrequencycounter;

    public void targetsizefrequencyhard() //more hard but more score
    {
        targetsizefrequencycounter += 1;

        easytargetsizefrequency = 1 + 5 * - targetsizefrequencycounter;

        hardtargetsizefrequency = 1 + 5 * targetsizefrequencycounter;
    }

    public void targetsizefrequencyeasy() //more easy but less score
    {
        targetsizefrequencycounter -= 1;

        
        easytargetsizefrequency = 1 + 5 * - targetsizefrequencycounter;

        hardtargetsizefrequency = 1 + 5 * targetsizefrequencycounter;
        
    }*/

}
