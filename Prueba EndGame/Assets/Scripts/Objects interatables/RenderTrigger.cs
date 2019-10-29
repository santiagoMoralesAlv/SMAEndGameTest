using UnityEngine;

/// <summary>
/// Allow hide the render when the character is behind, need un trigger
/// </summary>
public class RenderTrigger : MonoBehaviour
{
    private SpriteRenderer m_sprite;

    private void Awake()
    {
        m_sprite = this.GetComponent<SpriteRenderer>();
    }
        
    private void OnTriggerEnter(Collider other)//Hide
    {
        if (other.CompareTag("Character"))
        {
            m_sprite.enabled = false;
        }
    } 

    private void OnTriggerExit(Collider other)//Unhide
    {
        if (other.CompareTag("Character"))
        {
            m_sprite.enabled = true;
        }
    } 
}
