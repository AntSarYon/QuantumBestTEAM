using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLimiter : MonoBehaviour
{
    public static MouseLimiter Instance;

    //Coordenadas del Mouse (en el Mundo)
    private Vector2 coorMouse;

    #region GETTERS Y SETTERS

    public Vector2 CoorMouse { get => coorMouse; set => coorMouse = value; }

    #endregion CONSTRUCTORES

    //-----------------------------------------------------------

    private void Awake()
    {
        //Controlamos unica instancia de este Singleton
        ControlarUnicaInstancia();
    }

    //-----------------------------------------------------------
    void Start()
    {
        //Centramos el Mouse y lo confinamos a la Pantalla de juego
        CentrarMouse();
    }

    //--------------------------------------------------------

    void Update()
    {
        //Acrtualizamos coordenadas X e Y del Mouse
        coorMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    //------------------------------------------------------------

    private void CentrarMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Cursor.visible = false;
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
