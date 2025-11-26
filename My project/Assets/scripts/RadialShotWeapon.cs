using UnityEngine;
using System.Collections;

public class RadialShotWeapon : MonoBehaviour
{
    [SerializeField] private RadialShotPattern radialShotPattern;

    private bool isShooting = false;

    private void Update()
    {
        if (isShooting)
            return;

        StartCoroutine(ExecuteRadialShotPattern(radialShotPattern));
    }

    private IEnumerator ExecuteRadialShotPattern(RadialShotPattern pattern)
    {
        isShooting = true;
        int lap = 0;
        Vector2 aimDirection = transform.up;
        Vector2 center = transform.position;

        yield return new WaitForSeconds(pattern.startWait);

        while (lap < pattern.Repetitions)
        {
            if (lap > 0 && pattern.AngleOffsetBetweenLaps != 0f)
            {
                aimDirection = aimDirection.Rotate(pattern.AngleOffsetBetweenLaps);
            }   

            for (int i = 0; i < pattern.PatternSettings.Length; i++)
            {
                ShotAttack.RadialShot(center, pattern.PatternSettings[i]);
                yield return new WaitForSeconds(pattern.PatternSettings[i].Cooldown);
            }
            lap++;
        }
        yield return new WaitForSeconds(pattern.endWait);
        isShooting = false;
    }
}
