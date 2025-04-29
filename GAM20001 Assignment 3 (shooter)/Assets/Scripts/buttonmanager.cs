using UnityEngine;

public class buttonmanager : MonoBehaviour
{
    public bool buttonpressed = false;

    public void selected()
    {
        buttonpressed = true;
    }
    
    public void makefalse()
    {
        buttonpressed = false;  
    }
}
