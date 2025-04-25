using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ImageControl : MonoBehaviour
{
    private float gametime;
    private float elapsedtime;


    private Rigidbody rb;

    public float percentageComplete;

    private float randomforcetimer;
    private float forcecountdown;


    public float randomforcemin;
    public float randomforcemax;

    private Vector2 randomforce;

    private bool validforce = true;
    private bool validspawn = false;

    [SerializeField]
    private AnimationCurve maxspeedcurve;

    public float startmaxSpeed;
    public float endmaxSpeed;
    private float maxSpeed;


    void Start()
    {
        rb= GetComponent<Rigidbody>();
        gametime = GameObject.Find("Main Camera").GetComponent<camerazoom>().desiredtime;
    
        transform.position = new Vector2 (Random.Range(-4f,4f), Random.Range(-4f,4f));

        randomforcetimer = 0.5f;
    }

    void Update()
    {
        elapsedtime += Time.deltaTime;
        percentageComplete = elapsedtime / gametime;

        //max image move speed
        maxSpeed = Mathf.Lerp(startmaxSpeed,endmaxSpeed,maxspeedcurve.Evaluate(percentageComplete));
        if (rb.velocity.magnitude > maxSpeed)
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        

        //calculating adding random force
        forcecountdown = randomforcetimer - elapsedtime;

        if (validforce == false)
        {
            randomforce = new Vector2 (Random.Range (-randomforcemax,randomforcemax), Random.Range (-randomforcemax,randomforcemax));
        }
        
        if (randomforce.x > -randomforcemin && randomforce.x <randomforcemin && randomforce.y > -randomforcemin && randomforce.y <randomforcemin)
            {
                validforce = false;
            }
            else
            {
                validforce= true;
            }

        //add randomforce
        if (percentageComplete < 0.9f && forcecountdown < 0 && validforce == true )
        {

            rb.AddForce (randomforce); 
            randomforcetimer += Random.Range (2f,2.5f);

            validforce = false;
        }
        
    }

    //from here it is touchscreen inputs and using that to determine force applied to image

    private PlayerInput playerInput;


    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    public float forcemultipler;

    private Vector2 OldPos;
    private Vector2 RelativePos;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPositionAction = playerInput.actions["TouchPosition"];

        OldPos = transform.position;
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed (InputAction.CallbackContext context)
    {
        
        Vector2 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());

        //this makes force a comparison to last touch with a slight bias to where it was tapped relative to screen
        RelativePos = OldPos - position * 1.3f;

        rb.AddForce(RelativePos * forcemultipler * Random.Range (0.75f, 1.75f), ForceMode.Acceleration);

        OldPos = position;

    }
    
}
