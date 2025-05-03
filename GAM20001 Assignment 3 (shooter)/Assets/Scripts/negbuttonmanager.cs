using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class negbuttonmanager : MonoBehaviour
{
    public bool buttonpressed = false;
    private Button btn;
    private RectTransform trans;

    private bool roundactive;

    void Start()
    {
        btn = GetComponent<Button>();
        trans = GetComponent<RectTransform>();
    }

    void Update()
    {
        roundactive = GameObject.Find("Round Manager").GetComponent<RoundLogic>().roundactive;

        if (roundactive == true)
        {
            trans.localPosition = new Vector2 (0,500);
            btn.interactable = false;
        }
        if (roundactive == false)
        {
            trans.localPosition = new Vector2 (-210,0);
            btn.interactable = true;
        }

    }

    public void selected()
    {
        //buttonpressed = true;
        GameObject.Find("Round Manager").GetComponent<RoundLogic>().buttonclicked();
        GameObject.Find("ItemSystem").GetComponent<ItemSystem>().negbutton();
        
    }
    
    public void makefalse()
    {
        buttonpressed = false;  
    }
}
