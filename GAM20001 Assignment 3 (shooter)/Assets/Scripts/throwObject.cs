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

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Throw();
            Debug.Log("throwing ball");
        }
    }

    public void Throw()
    {
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

        float timeToReachTarget = 0.2f;

        float speed = distance / timeToReachTarget;

        projectileRB.linearVelocity = direction * speed;

        Destroy(projectile, 10f);

    }
}
