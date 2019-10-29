using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Animator))]
/// <summary>
/// Movement for a character
/// </summary>
public abstract class ControlMov : MonoBehaviour
{
    #region attributes
    protected Character m_character;

    protected Animator m_animator;
    protected Rigidbody m_rb;
    protected NavMeshAgent m_navAgent;

    protected float currentVelocity;
    #endregion

    #region constructors
    public NavMeshAgent NavAgent
    {
        get
        {
            return m_navAgent;
        }
    }
    #endregion

    protected void Awake()
    {
        m_character = this.GetComponent<Character>();
        m_animator = this.GetComponent<Animator>();
        m_rb = this.GetComponent<Rigidbody>();
        m_navAgent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    protected virtual void Update()
    {
        UpdateAnimator();
    }

    /// <summary>
    /// apply the physical movement to the character
    /// </summary>
    public abstract void Mov();

    /// <summary>
    /// update the animator parameter
    /// </summary>
    public void UpdateAnimator()
    {
        m_animator.SetFloat("velocity", currentVelocity);
    }
}
