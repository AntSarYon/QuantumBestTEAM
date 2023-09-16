using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraCenter;
    private Vector2 followDirection;

    private Rigidbody2D rb;
    [SerializeField] private float movForce;

    //Flag de "Puede seguir"
    private bool canFollow;

    #region GETTERS Y SETTERS

    public bool CanFollow { get => canFollow; set => canFollow = value; }

    #endregion

    //----------------------------------------------------------

    private void Awake()
    {
        //Obtenemos referencia al RigidBody
        rb = GetComponent<Rigidbody2D>();

        //Inicializamos la capacidad de Seguir en True...
        canFollow = true;
    }

    //--------------------------------------------------

    private void Update()
    {
        //Obtenemos la direccion de la camara
        followDirection = cameraCenter.position - transform.position;
    }

    //----------------------------------------------------------

    void FixedUpdate()
    {
        //Seguimos a la camara solo si el Flag esta activo
        if (canFollow) rb.AddForce(followDirection * movForce, ForceMode2D.Force);
        
    }

}
