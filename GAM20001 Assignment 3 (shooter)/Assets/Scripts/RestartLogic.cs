using UnityEngine;

public class RestartLogic : MonoBehaviour
{
    private bool gameover;

    // Update is called once per frame
    void Update()
    {
        gameover = GameObject.Find("RoundSystem").GetComponent<RoundLogic>().gameover;

        if (gameover == false)
        {
            transform.localPosition = new Vector2(5000, 0);
        }

        else if (gameover == true)
        {
           transform.localPosition = new Vector2(0, 0); 
        }
        //check gameover bool in roundlogic here and move button on screen or something
    }

    public void RestartGame()
    {
        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().resetgame();
        GameObject.Find("ModSystem").GetComponent<ModSystem>().resetgame();

        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().buttonclicked();

        GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();
    }
}
