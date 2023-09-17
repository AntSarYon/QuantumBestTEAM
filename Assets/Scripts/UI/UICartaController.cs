using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICartaController : MonoBehaviour
{

    private Animator mAnimator;
    private AudioSource mAudioSource;
    [SerializeField] Transform blackPanel;

    //--------------------------------------------------

    void Awake()
    {
        mAnimator = GetComponent<Animator>();
        mAudioSource = GetComponent<AudioSource>();
    }

    //--------------------------------------------------

    public void PonerPanelNegroDetras()
    {
        blackPanel.SetAsFirstSibling();
    }

    public void PonerPanelNegroDelante()
    {
        blackPanel.SetAsLastSibling();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Disparamos el Trigger para el FadeIn
            PonerPanelNegroDelante();
            mAnimator.SetTrigger("FadeIn");
            Destroy(GameObject.Find("MenuMusic"));
     }
    }

    public void CargarJuego()
    {
        ScenesManager.Instance.SolicitarCambioDeEscena("Integracion");
    }
}
