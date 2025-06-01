using System.Collections.Generic;
using UnityEngine;

public class ClowDownLights : MonoBehaviour
{
    private int offlight , previouslight;
    private float elapsedtime;


    public List<GameObject> listoflights = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //turnoff(0);

        for (int i = 0; i < 22; i++)
        {
            Light changecolour = listoflights[i].GetComponent<Light>();
            ColorUtility.TryParseHtmlString("#FFF443", out Color lightyellow);

            changecolour.color = lightyellow;
        }

    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            turnon(5);
        }*/
        elapsedtime += Time.deltaTime;

        if (elapsedtime > 0.1f)
        {
            offlight += 1;

            if (offlight == 22)
            {
                offlight = 0;
            }

            Debug.Log(offlight);

            turnoff(offlight);
            turnon(previouslight);

            previouslight = offlight;

            if (previouslight == 22)
            {
                previouslight = 0;
            }

            elapsedtime = 0;
        }
    }


    private void turnoff(int lightnumber)
    {
        Light offlight = listoflights[lightnumber].GetComponent<Light>();
        MeshRenderer offmaterial = listoflights[lightnumber].GetComponent<MeshRenderer>();

        offlight.intensity = 0;
        offmaterial.enabled = false;

        
    }

    private void turnon(int lightnumber)
    {
        Light onlight = listoflights[lightnumber].GetComponent<Light>();
        MeshRenderer onmaterial = listoflights[lightnumber].GetComponent<MeshRenderer>();


        onlight.intensity = 1;
        onmaterial.enabled = true;

    }
}
