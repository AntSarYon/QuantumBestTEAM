using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private AudioSource mAudioSource;
    [SerializeField] private AudioClip[] clipsRecuerdos = new AudioClip[2];

    //-------------------------------------------------------------------------

    private void Awake()
    {
        //Controlamos unica instancia de este Singleton
        ControlarUnicaInstancia();

        mAudioSource = GetComponent<AudioSource>();
    }

    //-------------------------------------------------------------------------

    public void ReproducirRecuerdoConseguido()
    {
        mAudioSource.PlayOneShot(clipsRecuerdos[Random.Range(0, 1)],0.55f);
    }

    //------------------------------------------------------------

    private void ControlarUnicaInstancia()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
