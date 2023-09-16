using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coleccionables : MonoBehaviour
{

    public void Start()
    {
        //
    }

    [Range(0f, 1f)] private float probabilidadTeletransporte;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //Algo más debe ocurrir aqui
            Destroy(this.gameObject);
        }
    }
}
