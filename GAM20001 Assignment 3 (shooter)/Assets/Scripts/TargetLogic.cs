using UnityEngine;

public class TargetLogic : MonoBehaviour
{
    private float elapsedtime;
    public float desiredtime;
    private float percentageComplete;

    private Vector3 SpawnPos;
    private Vector3 endPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SpawnPos = transform.position;
        
        endPos = new Vector3 (-SpawnPos.x, SpawnPos.y,SpawnPos.z);

    }

    // Update is called once per frame
    void Update()
    {
        //timer for target speed and destroying
        elapsedtime += Time.deltaTime;
        percentageComplete = elapsedtime / desiredtime;

        transform.position = Vector3.Lerp(SpawnPos, endPos, percentageComplete);

        if (percentageComplete >= 1)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //link to score here

        Destroy(gameObject);
    }
}
