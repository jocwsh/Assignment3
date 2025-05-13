using UnityEngine;

public class ModSystem : MonoBehaviour
{
    public float scoremult;

    public float speedscoremult;
    public float sizescoremult;
    public float targetspawnfrequencyscoremult;


    public float speedmult;
    public int speedcounter;

    public void speedhard() //faster speed but more score
    {
        speedcounter += 1;
        speedmult = 1 + 0.2f * speedcounter;

        speedscoremult = 0.25f * speedcounter;
        calculatescoremult();
    }

    public void speedeasy()
    {
        speedcounter -= 1;
        speedmult = 1 + 0.2f * speedcounter;

        speedscoremult = 0.25f * speedcounter;
        calculatescoremult();
    }


    public float sizemult;
    public int sizecounter;

    public void sizehard() //smaller size but more score
    {
        sizecounter -= 1;
        sizemult = 1 + 0.2f * sizecounter;

        sizescoremult =0.1f * sizecounter;
        calculatescoremult();
    }

    public void sizeeasy()
    {
        sizecounter += 1;
        sizemult = 1 + 0.2f * sizecounter;

        sizescoremult = 0.1f * sizecounter;
        calculatescoremult();
    }



    public float spawntimemod;
    public int spawntimecounter;

    public void targetspawnfrequencyhard() //less frequent spawns but more score
    {
        spawntimecounter -= 1;
        spawntimemod = 1 + 0.1f * - spawntimecounter;

        targetspawnfrequencyscoremult = 0.15f * spawntimecounter;
        calculatescoremult();
    }

    public void targetspawnfrequencyeasy()
    {
        spawntimecounter += 1;
        spawntimemod = 1 + 0.1f * - spawntimecounter;

        targetspawnfrequencyscoremult = 0.15f * spawntimecounter;
        calculatescoremult();
    }

    public float ballsizemod;
    public int ballsizecounter;

    public void ballsizehard() //smaller ball size but more score
    {
        ballsizecounter -= 1;
        ballsizemod = 0.1f *  ballsizecounter;

        calculatescoremult();
    }

    public void ballsizeeasy()
    {
        ballsizecounter += 1;
        ballsizemod = 0.1f * ballsizecounter;

        calculatescoremult();
    }

    private void calculatescoremult()
    {
        scoremult = 1 + sizescoremult + speedscoremult + targetspawnfrequencyscoremult;

        GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();
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
