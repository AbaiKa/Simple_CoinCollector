using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Events/Int Event")]
public class IntEventChannelSO : ScriptableObject
{
    public UnityAction<int> OnRaised;

    public void RaiseEvent(int value)
    {
        OnRaised?.Invoke(value);
    }
}