using UnityEngine;
using System.Collections;

public class throwObject : MonoBehaviour
{

    public Transform camera;
    public Transform throwPoint;
    public GameObject throwingObject;

    public float throwRate;

    public float throwForce;
    public float throwUpwardForce;

    private bool throwready;
    private float fireratemod;
    private float timesincelastthrow;

    
    private void Update()
    {
        fireratemod = GameObject.Find("ModSystem").GetComponent<ModSystem>().fireratemod;


        timesincelastthrow += Time.deltaTime;
        //0.5 will become its own variable 
        if (timesincelastthrow > 0.5f * fireratemod)
        {
            throwready = true;
        }
        else
        {
            throwready = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && throwready == true)
        {
            Throw();
            timesincelastthrow = 0;
        }
    }

    public void Throw()
    {
        GameObject projectile = Instantiate(throwingObject, throwPoint.position, camera.rotation);

        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

        Vector3 forceDirection = camera.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(camera.position, camera.forward, out hit, 500f))
        {
            forceDirection = (hit.point - throwPoint.position).normalized;
        }

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRB.AddForce(forceToAdd, ForceMode.Impulse);

    }
}
