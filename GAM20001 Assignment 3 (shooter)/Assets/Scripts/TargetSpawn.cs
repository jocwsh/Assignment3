using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    [SerializeField] GameObject Target;

    private float countdown = 0;
    private bool spawnactive;

    

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Round Manager").GetComponent<RoundLogic>().roundactive == true)
        {
            countdown -= Time.deltaTime;
            if (countdown < 0)
            {
                Instantiate(Target, transform.position, transform.rotation);
                randomspawn();
            } 
        }
    }

    void randomspawn()
    {
        countdown = Random.Range (0.75f,2f);
    }
}
