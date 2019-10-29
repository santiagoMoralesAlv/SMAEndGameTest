using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    private Character targetHit; //character that this bullet hit

    /// <summary>
    /// prepare the bullet attributes
    /// </summary>
    /// <param name="t_damage"></param>
    public void BuildProjectile(int t_damage)
    {
        damage = t_damage;

        //Try to apply a critical strike
        float criticalStrike = Random.Range(0,1);
        if (criticalStrike < 0.2f) {
            damage = damage * 3; // 3 is the critical strike multiplier
        }
    }

    /// <summary>
    /// Apply the force
    /// </summary>
    /// <param name="force"></param>
    public void Launch(Vector3 force, float velocity)
    {
        this.GetComponent<Rigidbody>().AddRelativeForce(force* velocity, ForceMode.VelocityChange);
    }

    /// <summary>
    /// when a bullet hit with a character and need apply stats
    /// </summary>
    public void Hit()
    {
        targetHit.SetDamage(damage);
        Dead();
    }

    /// <summary>
    /// when the bullet collides
    /// </summary>
    public void Dead()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        damage = 0;
        targetHit = null;

        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            targetHit = collision.gameObject.GetComponent<Character>();
            Hit();
        }
        else
        {
            Dead();
        }
    }

    /// <summary>
    /// this is necessary for the sprite walls, they use a trigger 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Structure"))
        {
            Dead();
        }
    }
}
