using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class multhud : MonoBehaviour
{
    private TextMeshProUGUI hudtext;
    private float mult;

    private float speedscoremult, sizescoremult, spawnfrequencyscoremult, fireratescoremult;

    void Start()
    {
        hudtext = GetComponent<TextMeshProUGUI>();
    }

    public void NewRound()
    {
        hudtext.text = "";
        mult = GameObject.Find("ModSystem").GetComponent<ModSystem>().scoremult;
        speedscoremult = GameObject.Find("ModSystem").GetComponent<ModSystem>().speedscoremult;
        sizescoremult = GameObject.Find("ModSystem").GetComponent<ModSystem>().sizescoremult;
        spawnfrequencyscoremult = GameObject.Find("ModSystem").GetComponent<ModSystem>().spawnfrequencyscoremult;
        fireratescoremult = GameObject.Find("ModSystem").GetComponent<ModSystem>().fireratescoremult;

        if (speedscoremult != 0)
        {
            hudtext.text += "Speed Multiplier: +" + speedscoremult + "x ";
        }
        if (sizescoremult != 0)
        {
            hudtext.text += "Size Multipler: +" + sizescoremult + "x ";
        }
        if (spawnfrequencyscoremult != 0)
        {
            hudtext.text += "Spawn Rate Multiplier: +" + spawnfrequencyscoremult +"x ";
        }
        if (fireratescoremult != 0)
        {
            hudtext.text += "Firerate Multiplier: +" + fireratescoremult +"x " ;
        }

        hudtext.text += "Total Multiplier: " + mult + "x";


        //hudtext.text = "Speed Multiplier: +" + speedscoremult +"x " + "Size Multipler: +" + sizescoremult +"x " + "Spawn Rate Multiplier: +" + spawnfrequencyscoremult +"x " + "Firerate Multiplier: +" + fireratescoremult +"x " + "Total Multiplier: " + mult +"x";
    }
}
