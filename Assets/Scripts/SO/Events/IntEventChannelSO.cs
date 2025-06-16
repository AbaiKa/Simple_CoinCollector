using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Events/Int Event")]
public class IntEventChannelSO : ScriptableObject
{
    public UnityAction<int> onRaised;

    public void RaiseEvent(int value)
    {
        onRaised?.Invoke(value);
    }
}