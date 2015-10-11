using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StageScript : MonoBehaviour {
    public enum SpellSetEnum {Basic};
    public SpellSetEnum SpellSet;  
    List<Spell> RequiredSpells = new List<Spell>();
    List<Spell> ForbiddenSpells = new List<Spell>();
    public uint RequiredMana;

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
    public bool TrySpellset(List<Spell> AvailableSpells, List<Spell> RestrictedSpells) {
        IEnumerable<Spell> list1 = AvailableSpells.Intersect(ForbiddenSpells);
        IEnumerable<Spell> list2 = RestrictedSpells.Intersect(AvailableSpells);
        if (list1.Count() > 0 || list2.Count() > 0) return false;
        RequiredSpells = RequiredSpells.Union(AvailableSpells).ToList();
        ForbiddenSpells = ForbiddenSpells.Union(RestrictedSpells).ToList();
        return true;
    }

}
