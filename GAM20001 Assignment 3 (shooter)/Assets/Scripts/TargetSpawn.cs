using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    [SerializeField] GameObject Target;

    private float countdown = 0;
    private bool spawnactive;

    private float spawntime = 2f;
    private float spawntimemod;
    private float randomiser = 0.2f;
    

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
        spawntimemod= GameObject.Find ("ModSystem").GetComponent<ModSystem>().spawntimemod;
        countdown = Random.Range (spawntime * spawntimemod * (1f - randomiser) , spawntime * spawntimemod * (1f + randomiser));
    }
}
