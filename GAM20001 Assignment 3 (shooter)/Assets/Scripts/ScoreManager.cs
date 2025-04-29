using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //maybe display score as an int
    public float score;

    //for laters
    //public float easymult, mediummult, hardmult;

    private TextMeshPro scoretext;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoretext = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Button").GetComponent<buttonmanager>().buttonpressed == true)
        {
            score = 0;
        }
        scoretext.text = score.ToString();
    }

    public void easyhit()
    {
        score += 50; 
    }
    public void mediumhit()
    {
        score += 80;
    }
    public void hardhit()
    {
        score += 100;
    }
}
