using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float rotationSpeed = 5f;

    bool isMoving;
    bool isForward;
    bool isBackward;
    bool isLeft;
    bool isRight;
    BoxCollider bc;
    Vector3 currentPos;
    Rigidbody rb;
    Quaternion forward = Quaternion.Euler(0, 0, 0);
    Quaternion right = Quaternion.Euler(0, 90, 0);
    Quaternion left = Quaternion.Euler(0, -90, 0);
    Quaternion back = Quaternion.Euler(0, 180, 0);

    void Start()
    {
        bc = GetComponent<BoxCollider>();
        isMoving = false;
        rb = GetComponent<Rigidbody>();
        currentPos = transform.position;
    }

    void FixedUpdate()
    {
        GoForward();
        GoBackward();
        GoLeft();
        GoRight();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BlockAvailability>().GetIsAvailable())
        {
            return;
        }
        Death();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grid")
        {
            if (!other.GetComponent<BlockAvailability>().GetIsAvailable())
            {
                Death();
            }
        }
        else if (other.tag == "Portal")
        {
            FindAnyObjectByType<LevelManager>().LoadWinScene();
        }
        
    }

    void Death()
    {
        FindObjectOfType<AudioPlayer>().PlayDeathClip();
        //transform.Translate(Vector3.down);
        Invoke("JumpLastScene", 1f);
    }

    void JumpLastScene()
    {
        FindObjectOfType<LevelManager>().LoadLastScene();
    }

    #region Movement Methods
    void GoForward()
    {

        if (!isForward) { return; }
        Vector3 targetPos = new Vector3(currentPos.x, currentPos.y, currentPos.z + 10f);

        if (transform.position.z < targetPos.z )
        {
            isMoving = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, forward, rotationSpeed * Time.deltaTime);
            rb.velocity = Vector3.forward * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
            currentPos = targetPos;
            isForward = false;
            isMoving = false;
        }
    }

    void GoBackward()
    {
        if (!isBackward) { return; }
        Vector3 targetPos = new Vector3(currentPos.x, currentPos.y, currentPos.z - 10f);

        if (transform.position.z > targetPos.z)
        {
            isMoving = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, back, rotationSpeed * Time.deltaTime);
            rb.velocity = Vector3.back * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
            currentPos = targetPos;
            isBackward = false;
            isMoving = false;
        }
    }

    void GoLeft()
    {
        if (!isLeft) { return; }
        Vector3 targetPos = new Vector3(currentPos.x - 10f, currentPos.y, currentPos.z);

        if (transform.position.x > targetPos.x)
        {
            isMoving = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, left, rotationSpeed * Time.deltaTime);
            rb.velocity = Vector3.left * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
            currentPos = targetPos;
            isLeft = false;
            isMoving = false;
        }
    }

    void GoRight()
    {
        if (!isRight) { return; }
        Vector3 targetPos = new Vector3(currentPos.x + 10f, currentPos.y, currentPos.z);

        if (transform.position.x < targetPos.x)
        {
            isMoving = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, right, rotationSpeed * Time.deltaTime);
            rb.velocity = Vector3.right * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
            currentPos = targetPos;
            isRight = false;
            isMoving = false;
        }
    }
    #endregion

    #region Boolean GET & SET Methods
    public void SetIsForwardTrue() { isForward = true; }

    public void SetIsBackwardTrue() { isBackward = true; }

    public void SetIsLeftTrue() { isLeft = true; }

    public void SetIsRightTrue() { isRight = true; }

    public bool GetIsMoving() { return isMoving; }
    #endregion
}

