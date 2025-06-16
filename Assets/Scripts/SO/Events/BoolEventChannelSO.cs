using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Events/Bool Event")]
public class BoolEventChannelSO : ScriptableObject
{
    public UnityAction<bool> onRaised;

    public void RaiseEvent(bool value)
    {
        onRaised?.Invoke(value);
    }
}