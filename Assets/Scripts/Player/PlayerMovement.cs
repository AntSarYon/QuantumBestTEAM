using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float suavidadMovimiento = 10f; // Controla la suavidad del movimiento

    private Rigidbody2D rb;

    private Vector2 velocidadDeseada = Vector2.zero;

    private float movimientoHorizontal;
    private float movimientoVertical;

    public bool canWalk;

    //----------------------------------------------------------------------------

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //----------------------------------------------------------------------------

    private void Start()
    {
        Invoke("StartMovement", 2f);
    }

    //----------------------------------------------------------------------------
    private void Update()
    {
        if(canWalk)
        {
            // Obtener la entrada del jugador en los ejes horizontal y vertical.
            movimientoHorizontal = Input.GetAxis("Horizontal");
            movimientoVertical = Input.GetAxis("Vertical");
        }
        else
        {
            movimientoHorizontal = 0f;
            movimientoVertical = 0f;
            rb.velocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        // Crear un vector de movimiento usando la entrada del jugador.
        Vector2 movimiento = new Vector2(movimientoHorizontal, movimientoVertical);

        // Normalizar el vector de movimiento para evitar movimientos más rápidos en diagonal.
        //movimiento.Normalize();

        // Aplicar aceleración y desaceleración gradual al movimiento.
        velocidadDeseada = Vector2.Lerp(velocidadDeseada, movimiento * velocidadMovimiento, Time.deltaTime * suavidadMovimiento);

        // Mover el jugador usando Rigidbody2D.
        rb.velocity = velocidadDeseada;
    }

    public void StartMovement()
    {
        canWalk = true;
    }
}
