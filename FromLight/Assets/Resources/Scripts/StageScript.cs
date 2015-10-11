using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StageScript : MonoBehaviour {
    public enum SpellSetEnum {Basic, Test};
    public SpellSetEnum SpellSet;  
    List<Spell> RequiredSpells = new List<Spell>();
    List<Spell> ForbiddenSpells = new List<Spell>();
    public uint RequiredMana;

    //call this right after instantiation
    public void LoadEnum() {
        Debug.Log("inside load ENUM");
        switch (SpellSet) {
            case SpellSetEnum.Basic:
                RequiredSpells.Add(Spell.SpellBook["Spell1"]);
                RequiredSpells.Add(Spell.SpellBook["Spell2"]);
                break;
            case SpellSetEnum.Test:
                RequiredSpells.Add(Spell.SpellBook["Spell3"]);
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
    //arguments are spells required and forbidden in other stages in current level segment
    public bool TrySpellset(ref List<Spell> AvailableSpells, ref List<Spell> RestrictedSpells) {
        Debug.Log("before/after");
        Debug.Log(AvailableSpells.Count);
        IEnumerable<Spell> list1 = AvailableSpells.Intersect(ForbiddenSpells);
        IEnumerable<Spell> list2 = RestrictedSpells.Intersect(AvailableSpells);
        Debug.Log(AvailableSpells.Count);
        if (list1.Count() > 0 || list2.Count() > 0) return false;
        AvailableSpells = AvailableSpells.Union(RequiredSpells).ToList();
        RestrictedSpells = RestrictedSpells.Union(ForbiddenSpells).ToList();
        Debug.Log("available");
        Debug.Log(RequiredSpells.Count);
        Debug.Log(AvailableSpells.Count);
        return true;
    }

}
