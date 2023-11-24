using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioInstance {get; private set;}
    private AudioSource audioSource;
    [SerializeField] private AudioClip laserShoot;
    [SerializeField] private AudioClip rayShoot;
    [SerializeField] private AudioClip meteorDestroy;
    [SerializeField] private AudioClip asteoridDestroy;
      private void Awake()
    {
        if(AudioInstance==null)
        {
            AudioInstance=this;
            audioSource=GetComponent<AudioSource>();   
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void LaserSound()
    {
        audioSource.PlayOneShot(laserShoot);
    }
    public void RaySound()
    {
        audioSource.PlayOneShot(rayShoot);
    }
    public void MeteorSound()
    {
        audioSource.PlayOneShot(meteorDestroy);
    }
    public void AsteroidSound()
    {
        audioSource.PlayOneShot(asteoridDestroy);
    }
}
