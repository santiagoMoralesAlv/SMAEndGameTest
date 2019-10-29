using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    protected string id;

    public string ID{
        get {
            return id;
        }
    }
}
