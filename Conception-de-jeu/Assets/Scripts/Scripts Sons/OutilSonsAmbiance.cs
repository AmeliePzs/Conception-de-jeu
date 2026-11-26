using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutilSonsAmbiance : MonoBehaviour
{
    [SerializeField] private AudioClip[] ListeMusique;
    [SerializeField] private AudioClip[] ListeSon;
    [SerializeField] private AudioSource AudioSourceMusique;
    [SerializeField] private AudioSource AudioSourceSon;

    private int PickSound;
    private bool AudioOn = false;
    private bool MusicOn = false;
    public float tempsEntreMusiqueMIN;
    public float tempsEntreMusiqueMAX;
    void Start()
    {
    
    }

    void Update()
    {
        if (!AudioOn)
        {
            StartCoroutine(ChoixSon());
        }

        if (!MusicOn)
        {
            StartCoroutine(ChoixMusique());
        }
    }

    IEnumerator ChoixMusique() 
    {
            MusicOn = true;
            yield return new WaitForSeconds(3f);
            PickSound = Random.Range(0, ListeMusique.Length);
            AudioSourceMusique.clip = ListeMusique[PickSound];
            AudioSourceMusique.Play();
            yield return new WaitForSeconds(AudioSourceMusique.clip.length);
            AudioSourceMusique.Stop();
            MusicOn = false;
    }

    IEnumerator ChoixSon()
    {
        AudioOn = true;
        yield return new WaitForSeconds(Random.Range(tempsEntreMusiqueMIN, tempsEntreMusiqueMAX));
        PickSound = Random.Range(0, ListeSon.Length);
        AudioSourceSon.clip = ListeSon[PickSound];
        AudioSourceSon.Play();
        yield return new WaitForSeconds(AudioSourceSon.clip.length);
        AudioSourceSon.Stop();
        AudioOn = false;
    }
}
