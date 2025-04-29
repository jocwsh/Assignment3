using UnityEngine;

public class TargetLogic : MonoBehaviour
{
    private float elapsedtime;
    public float desiredtime;
    private float percentageComplete;

    private Vector3 SpawnPos;
    private Vector3 endPos;

    public float EasyScale, MediumScale, HardScale;
    private Vector3 EasySize, MediumSize, HardSize;
    

    private int targetroll;


    public bool EasyTarget, MediumTarget, HardTarget;


    private int hardchance = 20;
    private int mediumchance = 30;
    private int easychance = 50;



    void Start()
    {
        SpawnPos = transform.position;
        
        endPos = new Vector3 (-SpawnPos.x, SpawnPos.y,SpawnPos.z);

        EasySize = new Vector3 (EasyScale, 0.06f, EasyScale);
        MediumSize = new Vector3 (MediumScale, 0.06f, MediumScale);
        HardSize = new Vector3 (HardScale, 0.06f, HardScale);


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
           
    }

    void Update()
    {
        //timer for target speed and destroying
        elapsedtime += Time.deltaTime;
        percentageComplete = elapsedtime / desiredtime;

        transform.position = Vector3.Lerp(SpawnPos, endPos, percentageComplete);

        if (percentageComplete >= 1 || GameObject.Find("Round Manager").GetComponent<RoundLogic>().roundactive == false)
        {

            
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //link to score here
        

        //play destroy animation here
        Destroy(gameObject);
    }
}
