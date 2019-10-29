using UnityEngine;

/// <summary>
/// Movement to the Player
/// </summary>
public class ControlMovJoystick : ControlMov
{
    #region attributes
    private Vector3 directionJoystick; //the inputs vector
    private Vector3 directionMov; // the movement vector with velocity
    #endregion

    new void Awake()
    {
        base.Awake();
        m_rb = this.GetComponent<Rigidbody>();
    }

    override protected void Update()
    {
        base.Update();
        ReceiveInputs();
        Mov();
    }

    /// <summary>
    /// Introduce the inputs to a movement vector
    /// </summary>
    public void ReceiveInputs()
    {
        //this new var maybe can be shorter, like directionMov = new Vector3 (input.GetAxis..., 0, input.Get...)
        //but, I use this, beacause I usually create inputs to different platforms
        float h = 0;
        float v = 0;

        //get the inputs
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //Update the movement vector
        directionJoystick = new Vector3(h, 0, v);
    }

    /// <summary>
    /// apply the physical movement to the character
    /// </summary>
    public override void Mov()
    {
        directionMov = (directionJoystick.normalized); //could apply a velocity factor

        if (directionJoystick.magnitude > 0) //when there is movement, look at the forehead
        {
            this.transform.LookAt(this.transform.position + directionMov, Vector3.up);
        }

        m_rb.AddForce(directionMov, ForceMode.VelocityChange);
        currentVelocity = m_rb.velocity.magnitude;
    }
    
}

