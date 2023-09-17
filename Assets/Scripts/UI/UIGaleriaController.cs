using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGaleriaController : MonoBehaviour
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

    //---------------------------------------------

    public void IrAMainMenu()
    {
        //Disparamos el Trigger para el FadeIn
        PonerPanelNegroDelante();
        mAnimator.SetTrigger("FadeIn");
        ScenesManager.Instance.SolicitarCambioDeEscena("MainMenu");
    }
}
