using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InGame_Controller : MonoBehaviour
{

    private Animator mAnimator;
    [SerializeField] Transform blackPanel;

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

    public void MostrarMemoriaUno()
    {
        mAnimator.SetTrigger("Memoria1");
    }

    public void MostrarMemoriaDos()
    {
        mAnimator.SetTrigger("Memoria2");
    }

    public void MostrarMemoriaTres()
    {
        mAnimator.SetTrigger("Memoria3");
    }

    public void MostrarMemoriaCuatro()
    {
        mAnimator.SetTrigger("Memoria4");
    }

    public void MostrarMemoriaCinco()
    {
        mAnimator.SetTrigger("Memoria5");
    }

    public void MostrarMemoriaSeis()
    {
        mAnimator.SetTrigger("Memoria6");
    }

    public void MostrarMemoriaSiete()
    {
        mAnimator.SetTrigger("Memoria7");
    }
}
