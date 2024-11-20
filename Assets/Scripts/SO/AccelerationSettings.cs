using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AccelerationSettingsAsset", menuName = "Project/Acceleration Settings", order = 101)]
public class AccelerationSettings : ScriptableObject
{
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float accelerationDuration = 1.0f;
    [SerializeField] private AnimationCurve accelerationCurve;

    public float ComputeSpeed(float timer)
    {
        return maxSpeed * accelerationCurve.Evaluate(timer / accelerationDuration);
    }
}
