using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class multhud : MonoBehaviour
{
    private TextMeshProUGUI hudtext;
    private float mult;

    void Start()
    {
        hudtext = GetComponent<TextMeshProUGUI>();
    }

    public void NewRound()
    {
        mult = GameObject.Find("ModSystem").GetComponent<ModSystem>().scoremult;
        hudtext.text = "Current Multipler: " + mult +"x";
    }
}
