using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "collection", menuName = "ScriptableObjects/Inventory", order = 2)]
public class Inventory : ScriptableObject
{
    public int lenses = 0;
    public bool coin = false;
    public float money = -0;

}
