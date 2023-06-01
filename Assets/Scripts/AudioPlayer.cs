using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] AudioClip jumpClip;
    [SerializeField][Range(0f, 1f)] float jumpVolume = 1f;

    [Header("Death")]
    [SerializeField] AudioClip deathClip;
    [SerializeField][Range(0f, 1f)] float deathVolume = 1f;

    [Header("Click")]
    [SerializeField] AudioClip clickClip;
    [SerializeField][Range(0f, 1f)] float clickVolume = 1f;

    [Header("Key")]
    [SerializeField] AudioClip keyClip;
    [SerializeField][Range(0f, 1f)] float keyVolume = 1f;

    [Header("Block")]
    [SerializeField] AudioClip blockClip;
    [SerializeField][Range(0f, 1f)] float blockVolume = 1f;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        int instance = FindObjectsOfType(GetType()).Length;
        if (instance > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayJumpClip()
    {
        PlayClip(jumpClip, jumpVolume);
    }

    public void PlayDeathClip()
    {
        PlayClip(deathClip, deathVolume);
    }

    public void PlayClickClip()
    {
        PlayClip(clickClip, clickVolume);
    }

    public void PlayKeyClip()
    {
        PlayClip(keyClip, keyVolume);
    }

    public void PlayBlockClip()
    {
        PlayClip(blockClip, blockVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}