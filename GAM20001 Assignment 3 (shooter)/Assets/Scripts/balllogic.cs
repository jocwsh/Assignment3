using UnityEngine;
using System.Collections;

public class balllogic : MonoBehaviour
{
    private float ballsizemod;
    private Vector3 ballsize;
    void Start()
    {
        ballsizemod = GameObject.Find("ModSystem").GetComponent<ModSystem>().ballsizemod;

        ballsizemod = ballsizemod * 0.4f;
        transform.localScale =  new Vector3 (ballsizemod, ballsizemod,ballsizemod);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(despawn());
    }

    private IEnumerator despawn()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
