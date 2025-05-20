using UnityEngine;
using System.Collections;

public class balllogic : MonoBehaviour
{
    private float ballsizemod;
    private Vector3 ballsize;

    private Rigidbody rb;
    void Start()
    {
        ballsizemod = GameObject.Find("ModSystem").GetComponent<ModSystem>().ballsizemod;

        ballsizemod = ballsizemod * 0.4f;
        transform.localScale =  new Vector3 (ballsizemod, ballsizemod,ballsizemod);


        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 30, ForceMode.Impulse);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(despawn());
    }

    private IEnumerator despawn()
    {
        rb.linearVelocity = Vector3.zero;
        rb.useGravity = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
