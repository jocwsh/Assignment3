using UnityEngine;

public class TargetLogic : MonoBehaviour
{
    private float elapsedtime;
    public float desiredtime;
    private float percentageComplete;

    private GameObject Spawner;
    private Vector3 SpawnPos;
    private Vector3 endPos;
    private float xend;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //might need better way to reference seperate gameobject but works for now
        Spawner = GameObject.Find("Target Spawner");
        
        SpawnPos = Spawner.transform.position;

        xend = - SpawnPos.x;
        
        endPos = new Vector3 (xend, 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedtime += Time.deltaTime;
        percentageComplete = elapsedtime / desiredtime;

        transform.position = Vector3.Lerp(SpawnPos, endPos, percentageComplete);

        if (percentageComplete >= 1)
        {
            Destroy(gameObject);
        }
        
    }
}
