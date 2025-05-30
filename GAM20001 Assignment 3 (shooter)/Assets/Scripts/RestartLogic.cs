using UnityEngine;

public class RestartLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
