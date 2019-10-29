using UnityEngine;
using TMPro;

/// <summary>
/// allow display the character stats
/// </summary>
public class UIPlayer : MonoBehaviour
{
    [SerializeField]
    private Character m_character;
    [SerializeField]
    private TextMeshPro head;
    
    private void Start()
    {
        UpdateLife();
        m_character.e_dead += NotifyDeath;
        m_character.e_updateLife += UpdateLife;

        if (m_character == null || head == null) {
            Debug.LogError("you shoud do a reference of m_character and head");
        }
    }
    
    public void UpdateLife()
    {
        head.text = m_character.CharacterName + " | life: "+m_character.CurrentLife+"/"+m_character.MaxLife;
    }

    public void NotifyDeath()
    {
        head.text = m_character.CharacterName+" is dead";
    }
}
