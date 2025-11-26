using UnityEngine;
using TMPro;

public class BulletCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;

    private void Update()
    {
        if (counterText != null)
            counterText.text = "Balas activas: " + Bullet.ActiveCount;
    }
}
