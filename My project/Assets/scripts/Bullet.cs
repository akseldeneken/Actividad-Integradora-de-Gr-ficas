using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float maxLifeSpan = 10f;
    private float lifeSpan = 0f;
    public Vector2 Velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
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
        gameObject.SetActive(false);
    }
}
