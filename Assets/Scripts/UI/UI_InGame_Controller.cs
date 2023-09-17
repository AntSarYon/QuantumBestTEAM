using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InGame_Controller : MonoBehaviour
{
    public static UI_InGame_Controller Instance;

    private Animator mAnimator;
    [SerializeField] Transform blackPanel;

    //-------------------------------------------

     void Awake()
    {
        Instance = this;

        mAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            MostrarMemoriaUno();
            GameManager.Instance.ReproducirRecuerdoConseguido();
        }
        if (Input.GetKey(KeyCode.X))
        {
            MostrarMemoriaDos();
            GameManager.Instance.ReproducirRecuerdoConseguido();
        }
        if (Input.GetKey(KeyCode.C))
        {
            MostrarMemoriaTres();
            GameManager.Instance.ReproducirRecuerdoConseguido();
        }

    }

    //-------------------------------------------

    public void PonerPanelNegroDetras()
    {
        blackPanel.SetAsFirstSibling();
        blackPanel.gameObject.SetActive(false);
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
