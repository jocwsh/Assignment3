using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //maybe display score as an int
    public float score;

    //for laters maybe
    //public float easymult, mediummult, hardmult;
    private float scoremult;

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
        scoremult = GameObject.Find("ItemSystem").GetComponent<ItemSystem>().scoremultiplier;

        if (GameObject.Find("-diff").GetComponent<negbuttonmanager>().buttonpressed == true || GameObject.Find("+diff").GetComponent<posbuttonmanager>().buttonpressed == true)
        {
            score = 0;
        }
        scoretext.text = score.ToString();
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
