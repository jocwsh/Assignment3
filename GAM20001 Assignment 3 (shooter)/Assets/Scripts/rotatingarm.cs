using UnityEngine;

public class rotatingarm : MonoBehaviour
{
    private float xrot, yrot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yrot = GameObject.Find("Player").GetComponent<Transform>().transform.localEulerAngles.y;
        xrot = GameObject.Find("Main Camera").GetComponent<Transform>().transform.localEulerAngles.x;
        transform.eulerAngles = new Vector3(xrot, yrot, 0);

        Debug.Log(xrot + " " + yrot);
    }
}
