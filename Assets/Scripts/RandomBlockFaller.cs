using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomBlockFaller : MonoBehaviour
{
    [SerializeField] float fallDuration = .75f;
    [SerializeField] float riseDuration = 2f;
    [SerializeField] float warningDuration = 3f;
    [SerializeField] Material redMat;
    [SerializeField] Material blueMat;
    [SerializeField] Material yellowMat;

    int amountEachTime;
    int randomIndex;
    Rigidbody[] allBlocks;
    AudioPlayer ap;

    void Start()
    {
        allBlocks = GetComponentsInChildren<Rigidbody>();
        InvokeRepeating("PickandProcessBlockMovement", 0, fallDuration + riseDuration + warningDuration);
        ap = FindObjectOfType<AudioPlayer>();
    }

    void PickandProcessBlockMovement()
    {
        amountEachTime = Random.Range(3, 7); // how many blocks will move

        while (amountEachTime > 0)
        {
            randomIndex = Random.Range(0, allBlocks.Length);
            if (!allBlocks[randomIndex].GetComponent<BlockAvailability>().GetIsAvailable())
            {
                //amountEachTime++;
                return;
            }
            else
            {
                StartCoroutine(MovementProcess(allBlocks[randomIndex]));
                amountEachTime--;
            }
        }
    }

    IEnumerator MovementProcess(Rigidbody choosenBlock)
    {
        //Local Constants of a Block
        Vector3 upPos = choosenBlock.transform.localPosition;
        Vector3 downPos = new Vector3(choosenBlock.transform.localPosition.x,
            -18.5f,
            choosenBlock.transform.localPosition.z);

        //WARNING
        choosenBlock.GetComponent<MeshRenderer>().material = redMat;
        yield return new WaitForSeconds(warningDuration);

        //FALLING
        choosenBlock.GetComponent<BlockAvailability>().SetFalse();
        ap.PlayBlockClip();
        StartCoroutine(MoveToPosition(choosenBlock, upPos, downPos, fallDuration));

        //RISING
        choosenBlock.GetComponent<MeshRenderer>().material = yellowMat;
        StartCoroutine(MoveToPosition(choosenBlock, downPos, upPos, riseDuration));
        yield return new WaitForSeconds(riseDuration + fallDuration);
        //GETTING AVAILABLE AGAIN
        choosenBlock.GetComponent<MeshRenderer>().material = blueMat;
        choosenBlock.GetComponent<BlockAvailability>().SetTrue();
    }

    public IEnumerator MoveToPosition(Rigidbody rb, Vector3 from, Vector3 to, float timeToMove)
    {
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            rb.transform.localPosition = Vector3.Lerp(from, to, t);
            yield return null;
        }
    }
}
