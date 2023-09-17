using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coleccionables : MonoBehaviour
{
    [SerializeField] private int recuerdoID;
    [SerializeField] private bool activado;
    [SerializeField] private ScriptableR recuerdoScriptable;
    [SerializeField] private AudioSource audioS;

    public void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //Algo más debe ocurrir aqui
            recuerdoScriptable.activado = true;
            Debug.Log("Recuerdo numero " + recuerdoID);
            GameManager.Instance.ReproducirRecuerdoConseguido();
            Destroy(this.gameObject);
        }
    }
}
