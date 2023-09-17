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

    public void ActivarRecuerdo(int i)
    {
        switch (i)
        {
            case 1:
                UI_InGame_Controller.Instance.MostrarMemoriaUno();
                break;
            case 2:
                UI_InGame_Controller.Instance.MostrarMemoriaDos();
                break;
            case 3:
                UI_InGame_Controller.Instance.MostrarMemoriaTres();
                break;
            case 4:
                UI_InGame_Controller.Instance.MostrarMemoriaCuatro();
                break;
            case 5:
                UI_InGame_Controller.Instance.MostrarMemoriaCinco();
                break;
            case 6:
                UI_InGame_Controller.Instance.MostrarMemoriaSeis();
                break;
            case 7:
                UI_InGame_Controller.Instance.MostrarMemoriaSiete();
                break;

            default:
                break;

        }
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
