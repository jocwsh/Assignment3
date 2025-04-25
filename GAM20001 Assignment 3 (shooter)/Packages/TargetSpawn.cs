using UnityEngine;
using UnityEngine.InputSystem;

public class TargetSpawn : MonoBehaviour
{
    [SerializeField] GameObject Target;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Target);
        }
    }
}
