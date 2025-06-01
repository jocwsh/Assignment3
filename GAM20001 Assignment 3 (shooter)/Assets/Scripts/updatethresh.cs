using TMPro;
using UnityEngine;

public class updatethresh : MonoBehaviour
{
    private TextMeshPro threshtext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        threshtext = GetComponent<TextMeshPro>();
    }



    public void newthresh()
    {
        float threshscore = GameObject.Find("RoundSystem").GetComponent<RoundLogic>().thresholdscore;

        threshtext.text = threshscore.ToString();
    }
}
