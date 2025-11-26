using UnityEngine;
using System.Collections;

public class BossBulletController : MonoBehaviour
{
    [Header("3 patrones del boss (ScriptableObjects)")]
    [SerializeField] private RadialShotPattern pattern1;
    [SerializeField] private RadialShotPattern pattern2;
    [SerializeField] private RadialShotPattern pattern3;

    [Header("Tiempo entre patrones")]
    [SerializeField] private float waitBetweenPatterns = 1f;

    private bool running;

    private void OnEnable()
    {
        if (!running) StartCoroutine(BossLoop());
    }

    private IEnumerator BossLoop()
    {
        running = true;

        while (true)
        {
            if (pattern1 != null) yield return ExecutePattern(pattern1);
            yield return new WaitForSeconds(waitBetweenPatterns);

            if (pattern2 != null) yield return ExecutePattern(pattern2);
            yield return new WaitForSeconds(waitBetweenPatterns);

            if (pattern3 != null) yield return ExecutePattern(pattern3);
            yield return new WaitForSeconds(waitBetweenPatterns);
        }
    }

    private IEnumerator ExecutePattern(RadialShotPattern pattern)
    {
        int lap = 0;
        Vector2 aimDirection = transform.up;

        yield return new WaitForSeconds(pattern.startWait);

        while (lap < pattern.Repetitions)
        {
            if (lap > 0 && pattern.AngleOffsetBetweenLaps != 0f)
                aimDirection = aimDirection.Rotate(pattern.AngleOffsetBetweenLaps); // usa tu extensión :contentReference[oaicite:1]{index=1}

            for (int i = 0; i < pattern.PatternSettings.Length; i++)
            {
               
                Vector2 origin = transform.position;

                
                RadialShotSettings s = CloneSettings(pattern.PatternSettings[i]);
                float ang = Vector2.SignedAngle(Vector2.up, aimDirection);
                s.angleOffset += ang;

                ShotAttack.RadialShot(origin, s); 
                yield return new WaitForSeconds(s.Cooldown);
            }

            lap++;
        }

        yield return new WaitForSeconds(pattern.endWait);
    }

    private RadialShotSettings CloneSettings(RadialShotSettings o)
    {
        return new RadialShotSettings
        {
            numberOfBullets = o.numberOfBullets,
            bulletSpeed = o.bulletSpeed,
            Cooldown = o.Cooldown,
            PhaseOffset = o.PhaseOffset,
            angleOffset = o.angleOffset,
            RadialMask = o.RadialMask,
            MaskAngleStart = o.MaskAngleStart
        };
    }
}
