using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class ButtonRandomiser : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    private RectTransform butt1trans, butt2trans, butt3trans;

    public TMP_Text button1Text;
    public TMP_Text button2Text;

    private List<Modifier> availableModifiers;

    private bool activeround;

    private ModSystem modscript;
    

    private void Start()
    {
        butt1trans = button1.GetComponent<RectTransform>();
        butt2trans = button2.GetComponent<RectTransform>();
        butt3trans = button3.GetComponent<RectTransform>();

        modscript = GameObject.Find ("ModSystem").GetComponent<ModSystem>();

        // Create list of function references
        availableModifiers = new List<Modifier>
        {
            new Modifier("+ Speed", Color.red, ModifierA),
            new Modifier("- Speed", Color.green, ModifierB),
            new Modifier("- Size", Color.red, ModifierC),
            new Modifier("+ Size", Color.green, ModifierD),
            new Modifier("- Targets", Color.red, ModifierE),
            new Modifier("+ Targets", Color.green, ModifierF),
            new Modifier("- Firerate", Color.red, ModifierG),
            new Modifier("+ Firerate", Color.green, ModifierH),
        };

        AssignButtons();

    }

    private void Update()
    {
        activeround= GameObject.Find("RoundSystem").GetComponent<RoundLogic>().roundactive;

        if (activeround == false)
        {
            butt1trans.transform.localPosition = new Vector2(-115, 0);
            butt2trans.transform.localPosition = new Vector2(115, 0);
            butt3trans.transform.localPosition = new Vector2(0, -110);

            button1.interactable = true;
            button2.interactable = true;   
            button3.interactable = true;
        }
        else if (activeround == true)
        {
            butt1trans.transform.localPosition = new Vector2(5000, 0);
            butt2trans.transform.localPosition = new Vector2(5000, 0);
            butt3trans.transform.localPosition = new Vector2(5000, 0);

            button1.interactable = false;
            button2.interactable = false;
            button3.interactable = false;
        }   
    }

    [System.Serializable]
    public class Modifier
    {
        public string label;
        public Color color;
        public Action action;

        public Modifier(string label, Color color, Action action)
        {
            this.label = label;
            this.color = color;
            this.action = action;
    }
    }

    public void AssignButtons()
    {
        AssignModifier();
    }

    void AssignModifier()
    {
        // Clone the list
        List<Modifier> shuffledModifiers = new List<Modifier>(availableModifiers);

        // Shuffle the list and assign first two
        for (int i = 0; i < shuffledModifiers.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, shuffledModifiers.Count);
            Modifier temp = shuffledModifiers[i];
            shuffledModifiers[i] = shuffledModifiers[randomIndex];
            shuffledModifiers[randomIndex] = temp;
        }

        // First two modifiers
        Modifier mod1 = shuffledModifiers[0];
        Modifier mod2 = shuffledModifiers[1];

        // Clear functions
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();

        // add new functions
        button1.onClick.AddListener(() => mod1.action());
        button2.onClick.AddListener(() => mod2.action());

        // Update button look
        button1Text.text = mod1.label;
        button1.image.color = mod1.color;

        button2Text.text = mod2.label;
        button2.image.color = mod2.color;
    }

    void ModifierA()
    {
        Debug.Log("Modifier A selected");

        modscript.speedhard();

        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().buttonclicked();
        GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();
    }

    void ModifierB()
    {
        Debug.Log("Modifier B selected");
        modscript.speedeasy();

        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().buttonclicked();
        GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();
    }

    void ModifierC()
    {
        Debug.Log("Modifier C selected");

        modscript.sizehard();

        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().buttonclicked();
        GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();
    }

    void ModifierD()
    {
        Debug.Log("Modifier D selected");

        modscript.sizeeasy();

        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().buttonclicked();
        GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();
    }

    void ModifierE()
    {
        Debug.Log("Modifier E selected");

        modscript.targetspawnfrequencyhard();

        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().buttonclicked();
        GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();
    }

    void ModifierF()
    {
        Debug.Log("Modifier F selected");

        modscript.targetspawnfrequencyeasy();

        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().buttonclicked();
        GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();
    }

    void ModifierG()
    {
        Debug.Log("Modifier G selected");

        modscript.fireratehard();

        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().buttonclicked();
        GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();
    }

    void ModifierH()
    {
        Debug.Log("Modifier H selected");

        modscript.firerateeasy();

        GameObject.Find("RoundSystem").GetComponent<RoundLogic>().buttonclicked();
        GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().newround();
    }

    
}