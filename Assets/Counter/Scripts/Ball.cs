using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip collideSound;
    public AudioClip scoreSound;
    public ParticleSystem explo;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish")){
            playerAudio.PlayOneShot(scoreSound, 0.8f);
            explo.Play();
        }
        else
        {
            playerAudio.PlayOneShot(collideSound, 0.4f);
            explo.Play();
        }
    }
    void OnDestroy()
    {
        explo.Play();
    }
}