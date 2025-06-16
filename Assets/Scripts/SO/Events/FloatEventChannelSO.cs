using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Events/Float Event")]
public class FloatEventChannelSO : ScriptableObject
{
    public UnityAction<float> onRaised;

    public void RaiseEvent(float value)
    {
        onRaised?.Invoke(value);
    }
}
