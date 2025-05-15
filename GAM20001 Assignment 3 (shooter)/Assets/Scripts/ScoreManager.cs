using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //maybe display score as an int
    public float score;

    //for laters maybe
    //public float easymult, mediummult, hardmult;
    private float scoremult = 1;

    //defs make score into its own object later when scoreboard model in game
    private TextMeshPro scoretext;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoretext = GetComponent<TextMeshPro>();

    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = ((int)score).ToString();
    }

    public void newround()
    {

        scoremult = GameObject.Find ("ModSystem").GetComponent<ModSystem>().calcualtescoremult();

        score = 0;

        //connect to modsystem script here
        //scoremult = GameObject.Find("ItemSystem").GetComponent<ItemSystem>().scoremultiplier;
    }

    public void easyhit()
    {
        score += 50 * scoremult; 
    }
    public void mediumhit()
    {
        score += 80 * scoremult;
    }
    public void hardhit()
    {
        score += 100 * scoremult;
    }
}
