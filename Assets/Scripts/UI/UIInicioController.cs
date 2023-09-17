using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIInicioController : MonoBehaviour
{
    private Animator mAnimator;
    [SerializeField] Transform blackPanel;

    //-------------------------------------------

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
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
    }

    public void DesactivarBtnPlay()
    {
        mAnimator.SetBool("PlayON", false);
    }

    public void ActivarBtnGallery()
    {
        mAnimator.SetBool("GalleryON", true);
    }

    public void DesactivarBtnGallery()
    {
        mAnimator.SetBool("GalleryON", false);
    }

    public void ActivarBtnExit()
    {
        mAnimator.SetBool("QuitON", true);
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
        ScenesManager.Instance.SolicitarCambioDeEscena("GALERIA");
    }
}
