using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public static ScenesManager Instance;

    //-----------------------------------------------------------

    private void Awake()
    {
        //Controlamos unica instancia de este Singleton
        ControlarUnicaInstancia();
    }

    //-----------------------------------------------------------

    public void SolicitarCambioDeEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    //-----------------------------------------------------------
    private void ControlarUnicaInstancia()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
