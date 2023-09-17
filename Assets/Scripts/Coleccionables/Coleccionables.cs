using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coleccionables : MonoBehaviour
{
    //ID de recuerdo
    [SerializeField] private int recuerdoID;

    //Flag de Recuerdo activado
    [SerializeField] private bool activado;

    [SerializeField] private ScriptableR recuerdoScriptable;
    [SerializeField] private AudioSource audioS;

    //--------------------------------------------------------------

    public void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    //--------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Si chocamos con el Trigger del Player
        if (col.CompareTag("Player"))
        {
            //Algo más debe ocurrir aqui
            recuerdoScriptable.activado = true;
            Debug.Log("Recuerdo numero " + recuerdoID);
            GameManager.Instance.ReproducirRecuerdoConseguido();
            gameObject.SetActive(false);
        }
    }
}
