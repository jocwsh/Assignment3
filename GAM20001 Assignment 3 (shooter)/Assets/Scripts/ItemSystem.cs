using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    public float scoremultiplier;
    
    private bool speedselected;
    private int selectedcounter;
    private float selectedmod;
    private float seclectedmult;

    public float finalspeedmod;
    private int speedcounter = 0;
    private float speedmod = 0.1f;
    private float speedmult = 0.2f;

    public float finalsizemod;
    private int sizecounter = 0;
    private float sizemod = 0.05f;
    private float sizemult = 0.1f;

    

    //maybe use a list


    //im pretty sure this is broke
    public void posbutton()
    {
        speedcounter += 1;
        speedmod = speedmod * speedcounter;
        finalspeedmod = 1 + speedmod ;

        //scoremultiplier doesnt work
        scoremultiplier = scoremultiplier + speedmult;

        Debug.Log (speedmod);
    }

    public void negbutton()
    {
        speedcounter -= 1;
        finalspeedmod = 1 + speedmod * speedcounter;


        //scoremultiplier doesnt work
        scoremultiplier = scoremultiplier + speedmult;

        Debug.Log (finalspeedmod);
    }
}
