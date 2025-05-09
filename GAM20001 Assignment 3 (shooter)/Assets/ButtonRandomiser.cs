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
    public TMP_Text button1Text;
    public TMP_Text button2Text;

    private List<Modifier> availableModifiers;

    private void Start()
    {
        // Create list of function references
        availableModifiers = new List<Modifier>
        {
            new Modifier("A", Color.red, ModifierA),
            new Modifier("B", Color.green, ModifierB),
            new Modifier("C", Color.red, ModifierC),
            new Modifier("D", Color.green, ModifierD),
            new Modifier("E", Color.red, ModifierE),
            new Modifier("F", Color.green, ModifierF),
            new Modifier("G", Color.red, ModifierG),
        };

        AssignButtons();

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
    }

    void ModifierB()
    {
        Debug.Log("Modifier B selected");
    }

    void ModifierC()
    {
        Debug.Log("Modifier C selected");
    }

    void ModifierD()
    {
        Debug.Log("Modifier D selected");
    }

    void ModifierE()
    {
        Debug.Log("Modifier E selected");
    }

    void ModifierF()
    {
        Debug.Log("Modifier F selected");
    }

    void ModifierG()
    {
        Debug.Log("Modifier G selected");
    }
}