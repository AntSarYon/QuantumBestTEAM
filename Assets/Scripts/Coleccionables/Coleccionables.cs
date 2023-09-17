using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coleccionables : MonoBehaviour
{
    [SerializeField] private int recuerdoID;
    [SerializeField] private bool activado;
    [SerializeField] private ScriptableR recuerdoScriptable;
    public void Start()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //Algo m�s debe ocurrir aqui
            recuerdoScriptable.activado = true;
            Debug.Log("Recuerdo numero " + recuerdoID);
            Destroy(this.gameObject);
        }
    }
}
