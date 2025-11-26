using UnityEngine;

[System.Serializable]

public class RadialShotSettings 
{
    [Header("Radial Shot Settings")]
    public int numberOfBullets = 8;
    public float bulletSpeed = 5f;
    public float Cooldown = 1f;

    [Header("Offset")]
    [Range(-1f, 1f)] public float PhaseOffset = 0f;
    [Range(-180f, 180f)] public float angleOffset = 0f;

    [Header("Mask")]
    public bool RadialMask;
    [Range(0f, 360f)] public float MaskAngleStart = 360f;

    
}