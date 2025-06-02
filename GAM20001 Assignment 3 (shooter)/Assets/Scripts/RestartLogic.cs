using UnityEngine;

public class RestartLogic : MonoBehaviour
{
    private bool gameover;
    public GameObject deathscreen, hud;

    /*void Start()
    {
        moveaway();
    }*/
    // Update is called once per frame
    void Update()
    {
        gameover = GameObject.Find("RoundSystem").GetComponent<RoundLogic>().gameover;

        if (gameover == false)
        {
            transform.localPosition = new Vector2(5000, 0);
            deathscreen.transform.localPosition = new Vector2(5000, 0);

            hud.SetActive(true);
        }

        else if (gameover == true)
        {

            GameObject.Find("ModSystem").GetComponent<ModSystem>().resetgame();

            GameObject.Find("RoundSystem").GetComponent<RoundLogic>().buttonclicked();

            GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();


            transform.localPosition = new Vector2(-80, 0);
            deathscreen.transform.localPosition = new Vector2(0, 0);

            hud.SetActive(false);

        }
        //check gameover bool in roundlogic here and move button on screen or something
    }

    /*public void restartscreen()
    {
        GameObject.Find("ModSystem").GetComponent<ModSystem>().resetgame();

        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().buttonclicked();

        GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();


        transform.localPosition = new Vector2(-80, 0);
        deathscreen.transform.localPosition = new Vector2(0, 0);

        hud.SetActive(false);

    }

    private void moveaway()
    {
        transform.localPosition = new Vector2(5000, 0);
        deathscreen.transform.localPosition = new Vector2(5000, 0);

        hud.SetActive(true);
    }*/

    public void RestartGame()
    {
        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().resetgame();
        //moveaway();

    }
}
