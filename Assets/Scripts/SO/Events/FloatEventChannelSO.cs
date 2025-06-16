using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Events/Float Event")]
public class FloatEventChannelSO : ScriptableObject
{
    public UnityAction<float> OnRaised;

    public void RaiseEvent(float value)
    {
        OnRaised?.Invoke(value);
    }
}
