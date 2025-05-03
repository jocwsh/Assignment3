using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    public float scoremultiplier;

    public GameObject easybutton;
    public GameObject hardbutton;
    
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (hardbutton.GetComponent<buttonmanager>().buttonpressed == true)
        {
            speedcounter += 1;
            speedmod = speedmod * speedcounter;
            finalspeedmod = 1 + speedmod ;

            scoremultiplier = scoremultiplier + speedmult;

            Debug.Log (speedcounter);
        }

        if (easybutton.GetComponent<buttonmanager>().buttonpressed == true)
        {
            speedcounter -= 1;
            speedmod = speedmod * speedcounter;
            finalspeedmod = 1 + speedmod ;

            scoremultiplier = scoremultiplier + speedmult;

            Debug.Log (speedcounter);
        }
    }
}
