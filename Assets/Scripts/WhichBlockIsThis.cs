using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhichBlockIsThis : MonoBehaviour
{
    BoxCollider boxCollider;
    string blockName;
    bool isWest;
    bool isEast;
    bool isNorth;
    bool isSouth;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key" || other.tag == "Portal") 
        {
            return;
        }
        else
        {
            blockName = other.transform.parent.name;
            //Debug.Log(blockName.ToString());
            OnEast();
            OnNorth();
            OnSouth();
            OnWest();
        }
    }

    #region String Check Methods
    void OnWest()
    { 
        if (blockName.Contains("0,")) { isWest = true; }
        else { isWest = false; }
    }

    void OnEast()
    {
        if (blockName.Contains("7,")) { isEast = true; }
        else { isEast = false; }
    }

    void OnNorth()
    {
        if (blockName.Contains(", 7")) { isNorth = true; }
        else { isNorth = false; }
    }

    void OnSouth()
    {
        if (blockName.Contains(", 0")) { isSouth = true; }
        else { isSouth = false; }
    }
    #endregion

    #region Public GET Bools
    public bool GetIsWest() { return isWest; }
    public bool GetIsEast() { return isEast; } 
    public bool GetIsNorth() {  return isNorth; }
    public bool GetIsSouth() { return isSouth;}
    #endregion
}
