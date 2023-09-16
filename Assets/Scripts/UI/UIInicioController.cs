using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void TerminarIntro()
    {
        mAnimator.SetBool("IntroFinalizada", true);
    }

    //------------------------------------------

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
}
