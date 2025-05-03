using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    public float scoremultiplier;

    public GameObject testbutton;

    public float finalspeedmod;
    private float speedmod = 0.1f;
    private float speedmult = 0.2f;

    //maybe use a list


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (testbutton.GetComponent<buttonmanager>().buttonpressed == true)
        {
            finalspeedmod = finalspeedmod + speedmod;

            scoremultiplier = scoremultiplier + speedmult;
        }
    }
}
