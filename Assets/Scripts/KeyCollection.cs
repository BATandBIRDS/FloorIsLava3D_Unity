using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollection : MonoBehaviour
{
    [SerializeField] RawImage keyImg;
    [SerializeField] GameObject portal;
    bool hasKey;

    void Start()
    {
        portal.SetActive(false);
        hasKey = false;
        keyImg.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Key")
        {
            return;
        }
        CollectKey();
        Destroy(other.gameObject);
    }

    void CollectKey()
    {
        hasKey = true;
        keyImg.enabled = true;
        FindObjectOfType<AudioPlayer>().PlayKeyClip();
        portal.SetActive(true);
    }

    public bool GetHasKey()
    {
        return hasKey;
    }
}
