using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Game settings")]
public class GameSettingsSO : ScriptableObject
{
    [field: SerializeField] public float GameSpeed { get; private set; } = 1;
    [field: SerializeField] public int DronesCount { get; private set; } = 2;
    [field: SerializeField] public int DronesSpeed { get; private set; } = 3;
    [field: SerializeField] public int ResourcesSpeed { get; private set; } = 40;
    [field: SerializeField] public bool ShowDronesPath { get; private set; } = true;
}
