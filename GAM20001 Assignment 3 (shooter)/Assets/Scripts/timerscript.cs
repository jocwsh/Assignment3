using TMPro;
using UnityEngine;

public class timerscript : MonoBehaviour
{
    private float timer;
    private TextMeshPro timertext;
    private bool activeround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = GameObject.Find("RoundSystem").GetComponent<RoundLogic>().roundcountdown;
        activeround = GameObject.Find("RoundSystem").GetComponent<RoundLogic>().roundactive;
        timertext = GetComponent<TextMeshPro>();

        timertext.text = timer.ToString("0.000");
        
        if (activeround == false)
        {
            timertext.text = "0.000";
        }
    }
}
