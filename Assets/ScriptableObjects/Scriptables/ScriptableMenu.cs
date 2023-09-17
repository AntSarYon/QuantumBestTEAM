using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableMenu : MonoBehaviour
{
    [SerializeField] private ScriptableR recuerdoScriptable;
    [SerializeField] private string Titulo;
    [SerializeField] private string DescripcionMenu;
    [SerializeField] private bool activado;
    // Start is called before the first frame update
    void Start()
    {
        activado = recuerdoScriptable.activado;
        if(activado)
        {
            Titulo = recuerdoScriptable.TituloRecuerdo;
            DescripcionMenu = recuerdoScriptable.DescripcionRecuerdo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
