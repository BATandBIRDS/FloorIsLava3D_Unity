using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsDeactivator : MonoBehaviour
{
    [SerializeField] Button btnForward;
    [SerializeField] Button btnBack;
    [SerializeField] Button btnLeft;
    [SerializeField] Button btnRight;

    PlayerMovement playerMovement;
    WhichBlockIsThis wBIt;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        wBIt = FindObjectOfType<WhichBlockIsThis>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.GetIsMoving())
        {
            DeactivateAll();
        }
        else
        {
            EdgeCheck();
        } 
    }

    #region DeActivate Methods
    void DeactivateAll()
    {
        DeactivateForward();
        DeactivateBack();
        DeactivateLeft();
        DeactivateRight();
    }

    void DeactivateLeft()
    {
        btnLeft.GetComponent<Button>().interactable = false;
    }

    void DeactivateRight()
    {
        btnRight.GetComponent<Button>().interactable = false;
    }

    void DeactivateForward()
    {
        btnForward.GetComponent<Button>().interactable = false;
    }

    void DeactivateBack()
    {
        btnBack.GetComponent<Button>().interactable = false;
    }
    #endregion

    #region Activate Methods
void ActivateAll()
    {
        ActivateBack();
        ActivateForward();
        ActivateLeft();
        ActivateRight();
    }

    void ActivateLeft()
    {
        btnLeft.GetComponent<Button>().interactable = true;
    }

    void ActivateRight()
    {
        btnRight.GetComponent<Button>().interactable = true;
    }

    void ActivateForward()
    {
        btnForward.GetComponent<Button>().interactable = true;
    }

    void ActivateBack()
    {
        btnBack.GetComponent<Button>().interactable = true;
    }
    #endregion

    void EdgeCheck()
    {
        if (wBIt.GetIsEast()) { DeactivateRight(); }
        else { ActivateRight(); }

        if (wBIt.GetIsNorth()) { DeactivateForward(); }
        else { ActivateForward(); }

        if (wBIt.GetIsSouth()) { DeactivateBack(); }
        else { ActivateBack(); }

        if (wBIt.GetIsWest()) { DeactivateLeft(); }
        else { ActivateLeft(); }
    }
}
