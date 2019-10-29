using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
/// <summary>
/// Item management for a player
/// </summary>
public class ItemsBag : MonoBehaviour
{
    #region attributes
    [SerializeField]
    private List<Item> l_items = new List<Item>();
    [SerializeField]
    private GameObject bag;
    #endregion

    /// <summary>
    /// let store the items
    /// </summary>
    /// <param name="t_item"></param>
    public void PutInItem(Item t_item)
    {
        t_item.gameObject.transform.SetParent(bag.transform);
        l_items.Add(t_item);
    }

    /// <summary>
    /// Check if there an item
    /// </summary>
    /// <param name="t_itemName"></param>
    /// <returns></returns>
    public bool ThereIsItem(string t_itemName)
    {
        if (l_items.Find(t_item => t_item.ID == t_itemName) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// get out the item
    /// </summary>
    /// <param name="t_itemName"></param>
    /// <returns></returns>
    public Item TakeOutItem(string t_itemName)
    {
        Item t_resultItem = l_items.Find(t_item => t_item.ID == t_itemName);
        l_items.Remove(t_resultItem);
        Destroy(t_resultItem.gameObject);

        if (t_resultItem != null)
        {
            return t_resultItem;
        }
        else {
            throw new System.NullReferenceException();
        }
    }
}
