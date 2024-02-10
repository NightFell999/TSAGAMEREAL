using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class Spell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Canvas FightUICanvas;
    public TextMeshProUGUI buttonGUI;
    public TextMeshProUGUI description;
    public Button button;
    public Player player;
    public bool isHovering = false;

    //Spell Stuff
    public string spellName;
    public string spellDescription;
    public int spellDMG;
    public int spellDifficulty; //1- Easy 2- Medium 3-Hard 4-Impossible
    public GameObject spellBlockContainer;
    public GameObject summonPosition;
    public int spellCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "EmptySpell")
        {
            spellName = player.spells[0].GetComponent<Spell>().spellName;
            buttonGUI.text = spellName;
            spellDMG = player.spells[0].GetComponent<Spell>().spellDMG;
            spellDescription = player.spells[0].GetComponent<Spell>().spellDescription;
            spellDifficulty = player.spells[0].GetComponent<Spell>().spellDifficulty;
            spellBlockContainer = player.spells[0].GetComponent<Spell>().spellBlockContainer;
            spellCount = player.spells[0].GetComponent<Spell>().spellCount;
        }

        if (gameObject.name == "EmptySpell2")
        {
            spellName = player.spells[1].GetComponent<Spell>().spellName;
            buttonGUI.text = spellName;
            spellDMG = player.spells[1].GetComponent<Spell>().spellDMG;
            spellDescription = player.spells[1].GetComponent<Spell>().spellDescription;
            spellDifficulty = player.spells[1].GetComponent<Spell>().spellDifficulty;
            spellBlockContainer = player.spells[1].GetComponent<Spell>().spellBlockContainer;
            spellCount = player.spells[1].GetComponent<Spell>().spellCount;
        }

        if (gameObject.name == "EmptySpell3")
        {
            spellName = player.spells[2].GetComponent<Spell>().spellName;
            buttonGUI.text = spellName;
            spellDMG = player.spells[2].GetComponent<Spell>().spellDMG;
            spellDescription = player.spells[2].GetComponent<Spell>().spellDescription;
            spellDifficulty = player.spells[2].GetComponent<Spell>().spellDifficulty;
            spellBlockContainer = player.spells[2].GetComponent<Spell>().spellBlockContainer;
            spellCount = player.spells[2].GetComponent<Spell>().spellCount;
        }

        if (gameObject.name == "EmptySpell4")
        {
            spellName = player.spells[3].GetComponent<Spell>().spellName;
            buttonGUI.text = spellName;
            spellDMG = player.spells[3].GetComponent<Spell>().spellDMG;
            spellDescription = player.spells[3].GetComponent<Spell>().spellDescription;
            spellDifficulty = player.spells[3].GetComponent<Spell>().spellDifficulty;
            spellBlockContainer = player.spells[3].GetComponent<Spell>().spellBlockContainer;
            spellCount = player.spells[3].GetComponent<Spell>().spellCount;
        }


           
    }

    public void CastSpell()
    {
        player.spellCountCURRENT = 0;
        player.spellCountMAX = spellCount;
        player.hits = 0;

        if(player.isPlayersTurn == true)
        {
            FightUICanvas.enabled = false;
        }


        Instantiate(spellBlockContainer, summonPosition.transform.position, summonPosition.transform.rotation);

    }


}