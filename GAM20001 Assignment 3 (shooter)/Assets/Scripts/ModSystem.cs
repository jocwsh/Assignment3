using UnityEngine;

public class ModSystem : MonoBehaviour
{
    public float scoremult;
    public float speedscoremult;
    public float sizescoremult;
    public float targetspawnfrequencyscoremult;
    public float fireratescoremult;




    public float speedmult;
    public int speedcounter;

    public float calcualtescoremult()
    {   
        if (speedcounter > 0)
        {
            speedscoremult = 0.3f * Mathf.Abs(speedcounter);
        }
        else if (speedcounter <= 0)
        {
            speedscoremult = -0.1f * Mathf.Abs(speedcounter);
        }


        if (sizecounter < 0)
        {
            sizescoremult = 0.2f * Mathf.Abs(sizecounter);
        }
        else if (sizecounter >= 0)
        {
            sizescoremult = -0.05f * Mathf.Abs(sizecounter);
        }


        if (spawntimecounter < 0)
        {
            targetspawnfrequencyscoremult = 0.3f * Mathf.Abs(spawntimecounter);
        }
        else if (spawntimecounter >= 0)
        {
            targetspawnfrequencyscoremult = -0.1f *Mathf.Abs(spawntimecounter);
        }


        if (fireratecounter < 0)
        {
            fireratescoremult = 0.2f * Mathf.Abs(fireratecounter);
        }
        else if (fireratecounter >= 0)
        {
            fireratescoremult = -0.1f * Mathf.Abs(fireratecounter);
        }




        scoremult = 1 + speedscoremult + sizescoremult + targetspawnfrequencyscoremult + fireratescoremult;
        return scoremult;
    }

    public void speedhard() //faster speed but more score //+0.4 to mult
    {
        speedcounter += 1;
        speedmult = 1 + 0.2f * speedcounter;
        
    }

    public void speedeasy() //-0.1 to mult
    {
        speedcounter -= 1;
        speedmult = 1 + 0.2f * speedcounter;
    }




    public float sizemult;
    public int sizecounter;

    public void sizehard() //smaller size but more score
    {
        sizecounter -= 1;
        sizemult = 1 + 0.1f * sizecounter;
    }

    public void sizeeasy()
    {
        sizecounter += 1;
        sizemult = 1 + 0.1f * sizecounter;
    }



    public float spawntimemod;
    public int spawntimecounter;

    public void targetspawnfrequencyhard() //less frequent spawns but more score
    {
        spawntimecounter -= 1;
        spawntimemod = 1 + 0.1f * - spawntimecounter;
    }

    public void targetspawnfrequencyeasy()
    {
        spawntimecounter += 1;
        spawntimemod = 1 + 0.1f * - spawntimecounter;
    }



    public float fireratemod;
    public int fireratecounter;

    public void fireratehard() //slower firerate but more score
    {
        fireratecounter -= 1;
        fireratemod = 1 + 0.2f *  fireratecounter;
    }

    public void firerateeasy()
    {
        fireratecounter += 1;
        fireratemod = 1 + 0.2f * fireratecounter;
    }


    //havent added this as mod yet
    public float ballsizemod;
    public int ballsizecounter;

    public void ballsizehard() //smaller ball size but more score
    {
        ballsizecounter -= 1;
        ballsizemod = 1 + 0.1f *  ballsizecounter;
    }

    public void ballsizeeasy()
    {
        ballsizecounter += 1;
        ballsizemod = 1 + 0.1f * ballsizecounter;
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
