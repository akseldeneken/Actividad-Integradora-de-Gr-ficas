using UnityEngine;
using System.Collections.Generic;

public class Bulletpool : MonoBehaviour
{
    private static Bulletpool instance;
    public static Bulletpool Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("BulletPool instance is null!");
            }
            return instance;
        }
    }

   [SerializeField] private GameObject bulletPrefab;
   [SerializeField] private int initial_poolSize = 10;

   private List<Bullet> bulletPool = new List<Bullet>();

   private void Awake()
   {
    if (instance != null && instance != this)
    {
        Destroy(this.gameObject);
        return;
    }
    else
    {
        instance = this;
    }
    AddBulletsToPool(initial_poolSize);
   }

   private void AddBulletsToPool(int amount)
   {
        for (int i = 0; i < amount; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
            bullet.gameObject.SetActive(false);
            bulletPool.Add(bullet);
            bullet.transform.parent = transform;
        }
   }

   public Bullet RequestBullet()
   {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].gameObject.activeSelf)
            {
                bulletPool[i].gameObject.SetActive(true);
                return bulletPool[i];
            }
        }
        AddBulletsToPool(1);
        bulletPool[bulletPool.Count - 1].gameObject.SetActive(true);
        return bulletPool[bulletPool.Count - 1];
   }
}