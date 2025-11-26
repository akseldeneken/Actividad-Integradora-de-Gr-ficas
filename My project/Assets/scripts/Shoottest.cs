using UnityEngine;

public class Shoottest : MonoBehaviour
{
    [SerializeField] private float shootInterval = 0.5f;
    [SerializeField] private RadialShotSettings radialShotSettings;

    private float shootTimer = 0f;

    private void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            ShotAttack.RadialShot(transform.position, radialShotSettings);
            shootTimer = shootInterval;
        }
    }

    
}
