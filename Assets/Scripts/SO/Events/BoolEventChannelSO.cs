using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Events/Bool Event")]
public class BoolEventChannelSO : ScriptableObject
{
    public UnityAction<bool> OnRaised;

    public void RaiseEvent(bool value)
    {
        OnRaised?.Invoke(value);
    }
}