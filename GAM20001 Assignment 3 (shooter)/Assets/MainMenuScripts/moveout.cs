using UnityEngine;

public class moveout : MonoBehaviour
{

    public GameObject canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void closerules()
    {
        canvas.transform.position = new Vector2(5000, 0);
    }
}
