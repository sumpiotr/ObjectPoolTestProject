using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager = null;
    public FixedSizePool audioPool;
    [SerializeField]
    private GameObject audioSourcePrefab;

    void Start()
    {
        if (audioManager != null)
        {
            Destroy(gameObject);
            return;
        }
        audioManager = this;
        audioPool = new FixedSizePool(4, audioSourcePrefab, transform);
    }

    public void PlayClip(AudioClip clip) 
    {
        GameObject audioObject =  audioPool.SpawnObject(Vector3.zero);
        if (audioObject == null) return;
        audioObject.GetComponent<AudioSource>().PlayOneShot(clip);
        StartCoroutine(DeactiveAudioObject(audioObject, clip.length));
    }

    private IEnumerator DeactiveAudioObject(GameObject audioObject, float time) 
    {
        yield return new WaitForSeconds(time);
        audioObject.SetActive(false);
    }

}

