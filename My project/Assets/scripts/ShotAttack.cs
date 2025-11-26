using UnityEngine;

public class ShotAttack 
{
    public static void SimpleShot (Vector2 origin, Vector2 velocity)
    {
        Bullet bullet = Bulletpool.Instance.RequestBullet();
        bullet.transform.position = origin;
        bullet.Velocity = velocity;
    }

    public static void RadialShot (Vector2 origin, RadialShotSettings settings)
    {
        float angleStep = 360f / settings.numberOfBullets;
        Vector2 baseDirection = Vector2.up;
        
        if (settings.angleOffset != 0f || settings.PhaseOffset != 0f)
        {
            baseDirection = Vector2.up.Rotate(settings.angleOffset + (settings.PhaseOffset * angleStep) );
        }

        for (int i = 0; i < settings.numberOfBullets; i++)
        {
            float bulletAngle = i * angleStep;

            if(settings.RadialMask && bulletAngle > settings.MaskAngleStart)
                break;

            Vector2 bulletDirection = baseDirection.Rotate(bulletAngle);
            SimpleShot(origin, bulletDirection * settings.bulletSpeed);
        }
    }
}