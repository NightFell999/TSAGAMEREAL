using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellBook : MonoBehaviour
{
    public Canvas spellBook;
    public Spell spell;

    private void OnMouseOver()
    {
        
    }

    void Start()
    {
        gameObject.GetComponentInChildren<TextMeshPro>().text = spell.spellName;
    }

    void Update()
    {
        
    }
}
