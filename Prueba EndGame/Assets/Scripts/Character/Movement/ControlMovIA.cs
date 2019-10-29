using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
/// <summary>
/// Movement to NPC enemys
/// </summary>
public class ControlMovIA : ControlMov
{
    #region attributes
    private Vector3 destiny;
    #endregion

    protected override void Update()
    {
        base.Update();
        currentVelocity = m_navAgent.velocity.magnitude;
    }

    /// <summary>
    /// mov the character to the old destiny
    /// </summary>
    public override void Mov()
    {
        m_navAgent.destination = destiny;
    }

    /// <summary>
    /// set a new destiny
    /// </summary>
    /// <param name="t_destiny"></param>
    public void Mov(Vector3 t_destiny)
    {
        destiny = t_destiny;
        m_navAgent.destination = destiny;
    }

}
