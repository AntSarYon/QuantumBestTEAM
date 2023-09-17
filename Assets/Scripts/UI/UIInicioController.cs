using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIInicioController : MonoBehaviour
{
    private Animator mAnimator;
    [SerializeField] Transform blackPanel;

    private AudioSource mAudioSource;
    [SerializeField] private AudioClip clipHover;

    private bool gallerySelected;
    private bool playSelected;
    private bool quitSelected;

    //-------------------------------------------

    void Awake()
    {
        //Obtenemos referencias
        mAnimator = GetComponent<Animator>();
        mAudioSource = GetComponent<AudioSource>();
    }

    //-------------------------------------------

    void Start()
    {
        gallerySelected = false;
        playSelected = false;
        quitSelected = false;
    }


    //-------------------------------------------

    public void PonerPanelNegroDetras()
    {
        blackPanel.SetAsFirstSibling();
    }

    public void PonerPanelNegroDelante()
    {
        blackPanel.SetAsLastSibling();
    }

    //-------------------------------------------

    public void TerminarIntro()
    {
        mAnimator.SetBool("IntroFinalizada", true);
    }

    //------------------------------------------

    #region ACTIVACION y DESACTIVACION de BOTONES

    public void ActivarBtnPLay()
    {
        mAnimator.SetBool("PlayON", true);
        mAudioSource.PlayOneShot(clipHover, 0.75f);
    }

    public void DesactivarBtnPlay()
    {
        mAnimator.SetBool("PlayON", false);
    }

    public void ActivarBtnGallery()
    {
        mAnimator.SetBool("GalleryON", true);
        mAudioSource.PlayOneShot(clipHover, 0.75f);
    }

    public void DesactivarBtnGallery()
    {
        mAnimator.SetBool("GalleryON", false);
    }

    public void ActivarBtnExit()
    {
        mAnimator.SetBool("QuitON", true);
        mAudioSource.PlayOneShot(clipHover, 0.75f);
    }

    public void DesactivarBtnExit()
    {
        mAnimator.SetBool("QuitON", false);
    }

    #endregion

    //-------------------------------------------

    public void IrAGaleria()
    {
        //Disparamos el Trigger para el FadeIn
        PonerPanelNegroDelante();
        mAnimator.SetTrigger("FadeIn");
        gallerySelected = true;
    }

    public void EmpezarJuego()
    {
        //Disparamos el Trigger para el FadeIn
        PonerPanelNegroDelante();
        mAnimator.SetTrigger("FadeIn");
        playSelected = true;
    }

    public void SalirDelJuego()
    {
        //Disparamos el Trigger para el FadeIn
        PonerPanelNegroDelante();
        mAnimator.SetTrigger("FadeIn");
        quitSelected = true;
    }

    public void CargarOpcion()
    {
        if (gallerySelected) ScenesManager.Instance.SolicitarCambioDeEscena("GALERIA");
        else if (playSelected) ScenesManager.Instance.SolicitarCambioDeEscena("Integracion");
        else if (quitSelected)
        {
            Application.Quit();
        }
    }
    
}
