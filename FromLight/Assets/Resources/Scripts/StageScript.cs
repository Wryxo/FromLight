using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageScript : MonoBehaviour {
    public enum SpellSetEnum {Basic};
    public SpellSetEnum SpellSet;  
    List<Spell> RequiredSpells = new List<Spell>();
    List<Spell> ForbiddenSpells = new List<Spell>();

    void Start() {
        //in case enum was set in prefab, load here
        LoadEnum(SpellSet);
    }

    public void LoadEnum(SpellSetEnum spellSet) {
        switch (spellSet) {
            case SpellSetEnum.Basic:
                RequiredSpells.Add(Spell.SpellBook["Spell1"]);
                RequiredSpells.Add(Spell.SpellBook["Spell2"]);
                break;
            default:
                RequiredSpells.Add(Spell.SpellBook["Spell1"]);
                RequiredSpells.Add(Spell.SpellBook["Spell2"]);
                break;
        }
    }

    //tries to add spells required for this stage
    //returns false if impossible
    public bool TrySpellset(List<Spell> AvailibleSpells) {
        //TODO
        AvailibleSpells.Clear();
        
        return false;
    }
}
