using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Minable Object Settings")]
public class MinableObjectsSO : ScriptableObject
{
    public int valueToGive;
    public ParticleSystem destructionParticles;
}
