using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerazoom : MonoBehaviour
{
    private Camera cam;

    public float desiredtime;
    private float elapsedtime;

    private float percentageComplete;

    public float startzoom;
    public float endzoom;
    

    [SerializeField]
    private AnimationCurve curve;


    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        elapsedtime += Time.deltaTime;
        percentageComplete = elapsedtime / desiredtime;
        
        //camera zoom
        cam.orthographicSize = Mathf.Lerp(startzoom,endzoom, curve.Evaluate(percentageComplete));
    }

    // camera shake
    void FixedUpdate()
    {
        cam.transform.localPosition = new Vector3 (Random.Range (0, 0.09f), Random.Range (0, 0.09f), -10);
    }

}
