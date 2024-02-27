using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellBook : MonoBehaviour
{
    public GameObject spellBook;
    public GameObject UI;
    public Spell spell;
    public GameObject cantrip;
    public GameObject terra;
    public GameObject serpentine;
    public GameObject ashborn;



    public void OpenSpellBook()
    {
        spellBook.SetActive(true);
        UI.SetActive(false);
    }

    public void CloseSpellBook()
    {
        spellBook.SetActive(false);
        UI.SetActive(true);
    }

    public void Cantrip()
    {
        cantrip.SetActive(true);
        terra.SetActive(false);
        serpentine.SetActive(false);
        ashborn.SetActive(false);
    }

    public void Terra()
    {
        cantrip.SetActive(false);
        terra.SetActive(true);
        serpentine.SetActive(false);
        ashborn.SetActive(false);
    }

    public void Serpentine()
    {
        cantrip.SetActive(false);
        terra.SetActive(false);
        serpentine.SetActive(true);
        ashborn.SetActive(false);
    }

    public void Ashborn()
    {
        cantrip.SetActive(false);
        terra.SetActive(false);
        serpentine.SetActive(false);
        ashborn.SetActive(true);
    }


}
