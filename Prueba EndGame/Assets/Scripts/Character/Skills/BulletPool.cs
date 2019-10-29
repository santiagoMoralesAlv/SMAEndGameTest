using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    #region Singleton
    public static BulletPool instance;

    public static BulletPool Instance
    {
        get
        {
            if (instance == null) instance = new BulletPool();
            return instance;
        }
    }
    #endregion

    #region attributes
    [SerializeField]
    private float sizeMin;

    [SerializeField]
    private GameObject pf_Bullet;

    [SerializeField]
    private List<Bullet> l_bullets = new List<Bullet>();
    #endregion

    private void Awake()
    {
        //Check the singleton instance
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
  
    }

    private void Start()
    {
        StartThePool();

    }

    /// <summary>
    /// Instance and fill the bullets list
    /// </summary>
    private void StartThePool() {
        l_bullets = new List<Bullet>();
        for (int i = 0; i < sizeMin; i++)
        {
            GameObject t_bullet = Instantiate(pf_Bullet);
            t_bullet.transform.SetParent(this.transform);
            t_bullet.SetActive(false);
            l_bullets.Add(t_bullet.GetComponent<Bullet>());
        }
    }

    /// <summary>
    /// return a free bullet in the pool, if there are no bullets then instance a new bullet
    /// </summary>
    /// <returns></returns>
    public Bullet GetBullet()
    {
        for (int i = 0; i < l_bullets.Count; i++)
        {
            if (!l_bullets[i].gameObject.activeInHierarchy)
            {
                return l_bullets[i];
            }
        }

        GameObject t_bullet = Instantiate(pf_Bullet);
        t_bullet.transform.SetParent(this.transform);
        t_bullet.SetActive(false);
        l_bullets.Add(t_bullet.GetComponent<Bullet>());

        return t_bullet.GetComponent<Bullet>();
    }
}
