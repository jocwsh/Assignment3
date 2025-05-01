using UnityEngine;

public class TargetLogic : MonoBehaviour
{
    public float speed; 
    private float randomisedspeed;

    private bool rightspawn = false;
    private float spawnx;
    private float elapsedtime;

    private float ymov;
    public float maxymovamp;
    public float minymovamp;
    public float ymovfrequency;
    private float phaseshift;

    //private float randommult = 0.1f;


    //if changing size is for all then just do a global scale multiplier
    public float EasyScale, MediumScale, HardScale;
    private Vector3 EasySize, MediumSize, HardSize;
    

    private int targetroll;


    public bool EasyTarget, MediumTarget, HardTarget;


    private int hardchance = 20;
    private int mediumchance = 30;
    private int easychance = 50;

    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        randomisedspeed = Random.Range (speed - 0.15f, speed +0.15f);


        if (transform.position.x > 0)
        {
            rightspawn = true;
        }

        spawnx = transform.position.x;
        

        EasySize = new Vector3 (EasyScale, 0.06f, EasyScale);
        MediumSize = new Vector3 (MediumScale, 0.06f, MediumScale);
        HardSize = new Vector3 (HardScale, 0.06f, HardScale);


        //for type of target
        targetroll = Random.Range (0, hardchance + mediumchance + hardchance);

        if (targetroll >= hardchance + mediumchance && targetroll <= hardchance + mediumchance + easychance)
        {
            transform.localScale = EasySize;
            EasyTarget = true;
        }
        if (targetroll >= hardchance && targetroll < hardchance + mediumchance)
        {
            transform.localScale = MediumSize;
            MediumTarget = true;
        }
        if (targetroll >= 0 && targetroll < hardchance)
        {
            transform.localScale = HardSize;
            HardTarget = true;
        } 
        
        //dont make randomness into modifier (too stiff otherwise (can do maxymovamp))
        //maybe calculate randomness through multiplication but this works
        maxymovamp = Random.Range(minymovamp, maxymovamp);
        ymovfrequency = Random.Range(ymovfrequency - 1.5f, ymovfrequency + 1.5f);

        phaseshift = Random.Range(0, 2*Mathf.PI/ymovfrequency);
    }

    void Update()
    {
        
        if (transform.position.x >= -spawnx && rightspawn == false || transform.position.x <= -spawnx && rightspawn == true || GameObject.Find("Round Manager").GetComponent<RoundLogic>().roundactive == false)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        elapsedtime += Time.deltaTime;

        //add some randomness here (too stiff)
        ymov = maxymovamp * Mathf.Sin(ymovfrequency * (elapsedtime + phaseshift));

        if (rightspawn == false)
        {
            rb.linearVelocity = new Vector3 (randomisedspeed, ymov, 0);
        }

        if (rightspawn == true)
        {
            rb.linearVelocity = new Vector3 (-randomisedspeed, ymov, 0);
        }  

        //if want to change wave after 1 period then do something like
        /*if (elapsedtime > waveperiod)
        {
            calculatewave();
        }

        calculatewave()
        {
            blah blah blah
        }
        */
    }

    void OnCollisionEnter(Collision collision)
    {
        //link to score here


        //maybe also add text to show how many points a target actually is
        if (EasyTarget == true)
        {
            GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().easyhit();
        }
        if (MediumTarget == true)
        {
            GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().mediumhit();
        }
        if (HardTarget == true)
        {
            GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().hardhit();
        }
        

        //play destroy animation here (maybe put destroy in coroutine)
        Destroy(gameObject);
    }
}
