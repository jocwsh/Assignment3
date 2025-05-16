using System;
using System.Collections.Generic;
using UnityEngine;

public class ModSystem : MonoBehaviour
{
    public float scoremult;
    public float speedscoremult;
    public float sizescoremult;
    public float spawnfrequencyscoremult;
    public float fireratescoremult;

    private float changingscoremult;
    private int changingcounter;

    private float[] positivemult;




    public float speedmult;
    public int speedcounter;

    void Start()
    {
        //have table on screen
        // For each token = -10%
        // 1 ticket = +20%
        // 2 ticktes = +40%
        // 3 tickets = +70%
        //and so on
        positivemult = new float[] { 0.2f, 0.4f, 0.7f, 1f, 1.4f, 2f};
    }

    public float changescoremult()
    {
        if (changingcounter > 0)
        {
            changingscoremult = positivemult[changingcounter -1];
        }

        else if (changingcounter <= 0)
        {
            changingscoremult = -0.1f * Mathf.Abs(changingcounter);
        }

        return changingscoremult;
    }

    public float calculatescoremult()
    {
        scoremult = 1 + speedscoremult + sizescoremult + spawnfrequencyscoremult + fireratescoremult;

        return scoremult;
    }


    public void speedhard() //faster speed but more score
    {
        speedcounter += 1;
        speedmult = 1 + 0.1f * speedcounter;

        changingscoremult = speedscoremult;
        changingcounter = speedcounter;

        speedscoremult = changescoremult();

        calculatescoremult();

    }

    public void speedeasy() //-0.1 to mult
    {
        speedcounter -= 1;
        speedmult = 1 + 0.1f * speedcounter;

        changingscoremult = speedscoremult;
        changingcounter = speedcounter;

        speedscoremult = changescoremult();

        calculatescoremult();
    }




    public float sizemult;
    public int sizecounter;

    public void sizehard() //smaller size but more score
    {
        sizecounter += 1;
        sizemult = 1 + 0.1f * -sizecounter;

        changingscoremult = sizescoremult;
        changingcounter = sizecounter;

        sizescoremult = changescoremult();

        calculatescoremult();
    }

    public void sizeeasy()
    {
        sizecounter -= 1;
        sizemult = 1 + 0.1f * -sizecounter;

        changingscoremult = sizescoremult;
        changingcounter = sizecounter;

        sizescoremult = changescoremult();

        calculatescoremult();
    }



    public float spawntimemod;
    public int spawntimecounter;

    public void targetspawnfrequencyhard() //less frequent spawns but more score
    {
        spawntimecounter += 1;
        spawntimemod = 1 + 0.1f * -spawntimecounter;

        changingscoremult = spawnfrequencyscoremult;
        changingcounter = spawntimecounter;

        spawnfrequencyscoremult = changescoremult();

        calculatescoremult();
    }

    public void targetspawnfrequencyeasy()
    {
        spawntimecounter -= 1;
        spawntimemod = 1 + 0.1f * -spawntimecounter;

        changingscoremult = spawnfrequencyscoremult;
        changingcounter = spawntimecounter;

        spawnfrequencyscoremult = changescoremult();

        calculatescoremult();
    }



    public float fireratemod;
    public int fireratecounter;

    public void fireratehard() //slower firerate but more score
    {
        fireratecounter += 1;
        fireratemod = 1 + 0.2f * -fireratecounter;

        changingscoremult = fireratescoremult;
        changingcounter = fireratecounter;

        fireratescoremult = changescoremult();

        calculatescoremult();
    }

    public void firerateeasy()
    {
        fireratecounter -= 1;
        fireratemod = 1 + 0.2f * -fireratecounter;

        changingscoremult = fireratescoremult;
        changingcounter = fireratecounter;

        fireratescoremult = changescoremult();

        calculatescoremult();
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
