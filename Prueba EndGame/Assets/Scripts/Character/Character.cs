using UnityEngine;


public class Character : MonoBehaviour
{
    #region attributes
    [SerializeField]
    private string characterName;


    [SerializeField]
    private int maxLife = 100;
    private int currentLife;

    public System.Action e_dead; //event to the death of this character
    public System.Action e_updateLife; // the life receive a changed
    #endregion

    #region attributes|components
    private ControlMov m_controlMov;
    private AssaultRifle m_rifle;
    private ItemsBag bag;
    #endregion

    #region constructors
    public string CharacterName
    {
        get
        {
            return characterName;
        }
    }
    public int CurrentLife
    {
        get
        {
            return currentLife;
        }
    }
    public int MaxLife
    {
        get
        {
            return maxLife;
        }
    }

    public ItemsBag Bag
    {
        get
        {
            return bag;
        }
    }
    public ControlMov ControlMov
    {
        get
        {
            return m_controlMov;
        }
    }
    public AssaultRifle Rifle
    {
        get
        {
            return m_rifle;
        }
    }
    #endregion

    private void Awake()
    {
        bag = this.GetComponent<ItemsBag>();
        m_controlMov = this.GetComponent<ControlMov>();
        m_rifle = this.GetComponent<AssaultRifle>();
        currentLife = maxLife;
    }

    /// <summary>
    /// Allow generate damage to the character
    /// </summary>
    /// <param name="damage"></param>
    public void SetDamage(int damage) {
        currentLife -= damage;
        try{
            e_updateLife();//notify a update to the character life
        }catch {
            Debug.LogError("there is not a listener to this event");
        }
        
        if (currentLife <= 0) { //check if the character is dead
            currentLife = 0;

            try
            {
                e_dead(); //notify the death
                if (characterName == "Player")
                {
                    Debug.LogError("End Game"); //when dead the player
                }
                else
                {
                    Destroy(gameObject); //when dead a enemy
                }
            }
            catch
            {
                throw new System.NotImplementedException();
            }
        }

        
    }

}
