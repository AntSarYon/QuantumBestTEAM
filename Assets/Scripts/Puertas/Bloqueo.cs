using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bloqueo : MonoBehaviour
{
    private bool canDetect = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canDetect)
        {
            if(Input.GetMouseButtonDown(0))
            {
                //Click Izquierdo
                EnviarLlave(0);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                //Click Derecho
                EnviarLlave(1);
            }
        }
    }

    private void EnviarLlave(int llave)
    {
        //Verificar si se teletrasporta a siguiente camino
        int cerradura = Random.Range(0,2);
        if (cerradura == llave)
        {
            Debug.Log("Entra al siguiente camino");
        }
        else Debug.Log("Piña pe causa");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pared"))
        {
            canDetect = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pared"))
        {
            canDetect = false;
        }
    }
}
