using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float maxLifeSpan = 10f;
    private float lifeSpan = 0f;
    public Vector2 Velocity;

    // Conteo global de balas activas
    public static int ActiveCount { get; private set; }

    private void OnEnable()
    {
        lifeSpan = 0f;
        ActiveCount++;
    }

    private void OnDisable()
    {
        if (ActiveCount > 0)
            ActiveCount--;
    }

    void Update()
    {
        transform.position += (Vector3)(Velocity * Time.deltaTime);
        lifeSpan += Time.deltaTime;
        if (lifeSpan >= maxLifeSpan)
        {
           Disable();
        }

    }

    void Disable()
    {
        lifeSpan = 0f;
        gameObject.SetActive(false); // aquí se dispara OnDisable
    }
}