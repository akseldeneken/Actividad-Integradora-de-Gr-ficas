using UnityEngine;

public class RadialShotPatternVisualizer : MonoBehaviour
{
    [SerializeField] private RadialShotPattern _pattern;
    [SerializeField] private float _radius;
    [SerializeField] private Color _color;
    [SerializeField, Range(0f, 5f             )] private float _testTime = 1f;

    private void OnDrawGizmos()
    {
        if (_pattern == null) return;

        Gizmos.color = _color;

        int lap = 0;
        Vector2 aimDirection = transform.up;
        Vector2 center = transform.position;

        float timer = _testTime;

        while (timer > 0f && lap < _pattern.Repetitions)
        {
            if (lap > 0 && _pattern.AngleOffsetBetweenLaps != 0f)
                aimDirection = aimDirection.Rotate(_pattern.AngleOffsetBetweenLaps);

            for (int i = 0; i < _pattern.PatternSettings.Length; i++)
            {
                if (timer < 0f)
                    break;

                DrawRadialShot(_pattern.PatternSettings[i], timer, aimDirection);

                timer -= _pattern.PatternSettings[i].Cooldown;
            }
            lap++;
        }
    }

    private void DrawRadialShot(RadialShotSettings settings, float lifeTime, Vector2 aimDirection)
    {
        float angleBetweenBullets = 360f / settings.numberOfBullets;
        if (settings.PhaseOffset != 0f || settings.angleOffset != 0f)
            aimDirection = aimDirection.Rotate(angleBetweenBullets * settings.PhaseOffset + settings.angleOffset);

        for (int i = 0; i < settings.numberOfBullets; i++)
        {
            float bulletDirectionAngle = angleBetweenBullets * i;

            if (settings.RadialMask && bulletDirectionAngle > settings.MaskAngleStart)
                break;

            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            Vector2 bulletPosition = (Vector2)transform.position + (bulletDirection * settings.bulletSpeed * lifeTime);

            Gizmos.DrawSphere(bulletPosition, _radius);
        }
    }
}