using UnityEngine;

public class rotatingarm : MonoBehaviour
{
    //private float xrot, yrot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 camerapos = GameObject.Find("Main Camera").GetComponent<Transform>().transform.position;

        transform.position = camerapos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camrot = GameObject.Find("Main Camera").GetComponent<Transform>().transform.localEulerAngles;

        transform.eulerAngles = camrot;

        Debug.Log(camrot);
    }
}
