using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class UI_InGame_Controller : MonoBehaviour
{
    public static UI_InGame_Controller Instance;

    private Animator mAnimator;
    [SerializeField] Transform blackPanel;

    private int contRecuerdos;

    //-------------------------------------------

     void Awake()
    {
        Instance = this;

        mAnimator = GetComponent<Animator>();
        contRecuerdos = 0;
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

        if (contRecuerdos == 7)
        {
            mAnimator.SetTrigger("Complete");

            Invoke(nameof(IrACreditos),2f);
            
        }

    }

    public void IrACreditos()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("CREDITS");
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
        contRecuerdos++;
    }

    public void MostrarMemoriaDos()
    {
        mAnimator.SetTrigger("Memoria2");
        contRecuerdos++;
    }

    public void MostrarMemoriaTres()
    {
        mAnimator.SetTrigger("Memoria3");
        contRecuerdos++;
    }

    public void MostrarMemoriaCuatro()
    {
        mAnimator.SetTrigger("Memoria4");
        contRecuerdos++;
    }

    public void MostrarMemoriaCinco()
    {
        mAnimator.SetTrigger("Memoria5");
        contRecuerdos++;
    }

    public void MostrarMemoriaSeis()
    {
        mAnimator.SetTrigger("Memoria6");
        contRecuerdos++;
    }

    public void MostrarMemoriaSiete()
    {
        mAnimator.SetTrigger("Memoria7");
        contRecuerdos++;
    }
}
