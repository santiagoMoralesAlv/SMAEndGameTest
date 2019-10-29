using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    #region attributes
    [SerializeField]
    private string password; //name of the key needed to open

    [SerializeField]
    private Collider m_collider; //collider that block

    [SerializeField]
    private Sprite[] doorSprites; //to the animation
    private SpriteRenderer m_spriteRenderer;
    [SerializeField]
    private float animationTime;
    #endregion

    private void Awake()
    {
        m_spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            if (collision.gameObject.GetComponent<ItemsBag>().ThereIsItem(password)) { //is the character has the key

                collision.gameObject.GetComponent<ItemsBag>().TakeOutItem(password); //use the key
                
                StartCoroutine("SpriteAnimation"); 
            }
        }
    } //try to open the door

    /// <summary>
    /// open animation with sprites
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpriteAnimation()
    {
        m_collider.enabled = false;
        for (int t = 0; t <= doorSprites.Length-1; t++)
        {
            m_spriteRenderer.sprite = doorSprites[t];
            yield return new WaitForSeconds(animationTime/doorSprites.Length);
        }
    }
}
