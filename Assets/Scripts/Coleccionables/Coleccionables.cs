using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coleccionables : MonoBehaviour
{
    [SerializeField] private CollectorManager CManager;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            CollectorManager.AumentarConteo();
            Destroy(this.gameObject);
        }
    }
}
