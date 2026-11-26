using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

/* Mettre ceci pour appeler le son
FindObjectOfType<AudioManager>().Play ou PlayOneShot("Nomduson");
*/
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake() 
    {   
        /*
        //Permet que la musique ne se reset pas entre niveaux (attention, peut faire que ça se rajoute à l'autre)
        if (instance == null)
            instance = this;
        else 
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        */
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop =  s.loop;
        }
    }

    public void Play (string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.PlayOneShot(s.source.clip);
    }
}
