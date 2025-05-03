using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    [SerializeField] GameObject Target;

    private float countdown = 0;
    private bool spawnactive;

    

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("RoundSystem").GetComponent<RoundLogic>().roundactive == true)
        {
            countdown -= Time.deltaTime;
            if (countdown < 0)
            {
                Instantiate(Target, transform.position, transform.rotation);
                randomspawn();
            } 
        }
        if (GameObject.Find("RoundSystem").GetComponent<RoundLogic>().roundactive == false)
        {
            countdown = 0;
        }
    }

    void randomspawn()
    {
        countdown = Random.Range (1f,2f);
    }
}
