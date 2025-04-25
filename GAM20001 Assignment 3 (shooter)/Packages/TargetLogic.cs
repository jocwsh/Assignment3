using UnityEngine;

public class TargetLogic : MonoBehaviour
{
    private float elapsedtime;
    public float desiredtime;
    private float percentageComplete;

    public Vector3 start = new Vector3(0f,0f,0f);
    private Vector3 end = new Vector3 ();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedtime += Time.deltaTime;
        percentageComplete = elapsedtime / desiredtime;

        transform.position = Vector3.Lerp(start, end, percentageComplete);
    }
}
