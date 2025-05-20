using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class throwObject : MonoBehaviour
{

    public Transform camera;
    public Transform throwPoint;
    public GameObject throwingObject;

    public float throwRate;

    public float throwForce;
    public float throwUpwardForce;

    private bool throwactive;
    private float fireratemod;
    private float timesincelastthrow;

    private bool roundactive;

    
    private void Update()
    {
        fireratemod = GameObject.Find("ModSystem").GetComponent<ModSystem>().fireratemod;
        roundactive = GameObject.Find("RoundSystem").GetComponent<RoundLogic>().roundactive;


        timesincelastthrow += Time.deltaTime;
        //0.5 will become its own variable 
        if (timesincelastthrow > 0.5f * fireratemod && roundactive == true)
        {
            throwactive = true;
        }

        else if (timesincelastthrow < 0.5f * fireratemod || roundactive == false)
        {
            throwactive = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && throwactive == true)
        {
            Throw();
            timesincelastthrow = 0;
        }
    }

    public void Throw()
    {
        //GameObject projectile = Instantiate(throwingObject, throwPoint.position, throwPoint.rotation);


        GameObject projectile = Instantiate(throwingObject, throwPoint.position, Quaternion.identity);

        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

        projectileRB.useGravity = false;

        projectileRB.linearDamping = 0f;


        Vector3 targetPoint;

        RaycastHit hit;

        if (Physics.Raycast(camera.position, camera.forward, out hit, 500f))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = camera.position + camera.forward * 500f;
        }

        Vector3 direction = (targetPoint - throwPoint.position).normalized;
        float distance = Vector3.Distance(throwPoint.position, targetPoint);

        float timeToReachTarget = 0.5f;

        float speed = distance / timeToReachTarget;

        projectileRB.linearVelocity = direction * speed;

        Destroy(projectile, 10f);

    }
}
