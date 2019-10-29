using UnityEngine;

public class AssaultRifle : MonoBehaviour
{
    #region attributes
    private Animator m_animator;

    [Header("Prefabs and Gameobjects attributes")]
    [SerializeField]
    private Bullet m_bullet;
    [SerializeField]
    private GameObject crosshairs;

    [Header("Gun attributes")]
    private bool shooting;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float bulletVelocity;
    #endregion

    #region constructors
    public bool Shooting
    {
        get
        {
            return shooting;
        }
    }

    #endregion

    private void Awake()
    {
        m_animator = this.GetComponent<Animator>();
        shooting = false;
    }
        
    /// <summary>
    /// Allow shoot
    /// </summary>
    public void PrepareGun() 
    {
        //prepare the var to shoot
        shooting = true;

        //prepare the animator
        m_animator.SetLayerWeight(1, 1);
        m_animator.SetBool("shoot", true);
    }

    /// <summary>
    /// Do the shoot, this need a prepared gun
    /// </summary>
    public void LaunchProjectiles()
    {
        if (shooting)
        {
            m_bullet = BulletPool.instance.GetBullet();
            m_bullet.BuildProjectile(damage);

            m_bullet.transform.position = crosshairs.transform.position;
            m_bullet.transform.rotation = this.transform.rotation;
            m_bullet.gameObject.SetActive(true);

            m_bullet.Launch(Vector3.forward, bulletVelocity);
        }
    }
    
    /// <summary>
    /// stop shooting, restart the parameter
    /// </summary>
    /// <returns></returns>
    public void StopShoot()
    {
        m_animator.SetBool("shoot", false);
        m_animator.SetLayerWeight(1, 0);
        shooting = false;
    }
}
