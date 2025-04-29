using UnityEngine;

public class buttonmanager : MonoBehaviour
{
    public bool buttonpressed = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selected()
    {
        buttonpressed = true;


        
    }
    public void makefalse()
    {
        buttonpressed = false;  
    }
}
