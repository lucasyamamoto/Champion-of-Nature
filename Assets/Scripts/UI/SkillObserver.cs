using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class SkillObserver : MonoBehaviour
{
    [SerializeField] private Toggle aquaslide, stoneshield, firedart, windstep;
    [SerializeField] private PlayerSkills playerskills;
    private Stack<PlayerSkills.Element> elements;
    // Start is called before the first frame update
    void Start()
    {
        elements = new Stack<PlayerSkills.Element>();
    }
    void Disable(PlayerSkills.Element Skill){
        switch(Skill){
            case PlayerSkills.Element.Water:
                aquaslide.isOn = false;
                break;
            case PlayerSkills.Element.Earth:
                stoneshield.isOn = false;
                break;
            case PlayerSkills.Element.Fire:
                firedart.isOn = false;
                break;
            case PlayerSkills.Element.Wind:
                windstep.isOn = false;
                break;
        }
    }
    public void SkillSetter(){
        playerskills.skill2 = elements.Pop();
        playerskills.skill1 = elements.Pop();
    }
    public void OnToggleChanged(int Entrada)
    {   
        PlayerSkills.Element Skill = (PlayerSkills.Element)Entrada;
        if(elements.Count == 0){
            elements.Push(Skill);
            return;
        }
        if (Convert.ToByte(aquaslide.isOn) + Convert.ToByte(stoneshield.isOn) + Convert.ToByte(firedart.isOn) + Convert.ToByte(windstep.isOn) > 2){
            Disable(Skill);
            return;
        }
        if(elements.Contains(Skill)){
            PlayerSkills.Element  aux;
            aux = elements.Pop();
            if(aux != Skill){
                elements.Pop();
                elements.Push(aux);
            }

        }
        else{
            elements.Push(Skill);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
