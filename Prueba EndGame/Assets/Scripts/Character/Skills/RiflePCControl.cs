using UnityEngine;

/// <summary>
/// allow control the Rifle with the keyboard
/// </summary>
public class RiflePCControl : MonoBehaviour
{
    private AssaultRifle rifle;

    private void Awake()
    {
        rifle = this.GetComponent<AssaultRifle>();
    }

    private void Update()
    {
        InputSkill();
    }

    /// <summary>
    /// receive the inputs and call the rifle methods
    /// </summary>
    private void InputSkill()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!rifle.Shooting)
            {
                rifle.PrepareGun();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (rifle.Shooting)
            {
                rifle.StopShoot();
            }
        }
    }
}
