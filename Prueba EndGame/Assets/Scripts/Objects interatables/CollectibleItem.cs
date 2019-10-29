using UnityEngine;

/// <summary>
/// Item that can be save in the bag
/// </summary>
public class CollectibleItem : MonoBehaviour
{
    [SerializeField]
    private Item m_item;

    public void Awake() {
        if (m_item == null)
        {
            Debug.LogError("There is not a item, it is necessary");
        }
    }

    private void OnCollisionEnter(Collision collision) //check the character bag
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            if (collision.gameObject.GetComponent<Character>().Bag != null) {
                collision.gameObject.GetComponent<Character>().Bag.PutInItem(m_item);
                Destroy(gameObject);
            }
        }
    } 
}
