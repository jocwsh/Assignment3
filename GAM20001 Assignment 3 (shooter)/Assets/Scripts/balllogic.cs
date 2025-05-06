using UnityEngine;
using System.Collections;

public class balllogic : MonoBehaviour
{
    
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
