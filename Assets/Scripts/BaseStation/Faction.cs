using System;
using UnityEngine;

[Serializable]
public class Faction
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Color Color { get; private set; }
}
