using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAvailability : MonoBehaviour
{
    // to make player sure about not to jump over a moving block.

    bool isAvailable;

    void Start()
    {
        isAvailable = true;
    }

    public bool GetIsAvailable()
    {
        return isAvailable;
    }

    public void SetFalse()
    {
        isAvailable = false;
    }

    public void SetTrue()
    {
        isAvailable = true;
    }
}
