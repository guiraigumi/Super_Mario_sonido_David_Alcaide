using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //clip de audio para la muerte de Mario
    public AudioClip deathSFX;
    public AudioClip goombaSFX;
    public AudioClip coinSFX;
    public AudioClip FlagpoleSFX;

    //variable del audio source
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void DeathSound()
    {
        _audioSource.PlayOneShot(deathSFX);
    }

    public void GoombaSound()
    {
        _audioSource.PlayOneShot(goombaSFX);
    }

    public void CoinSound()
    {
        _audioSource.PlayOneShot(coinSFX);
    }
    
    public void Flagpole()
    {
        _audioSource.PlayOneShot(FlagpoleSFX);
    }

}
