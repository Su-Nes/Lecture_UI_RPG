using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Spear : Weapon
{
    public override void ApplyEffect(Character character)
    {
        print(character.name);
    }
}
