using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{
    //Variables de Salud
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private float autoHurt;

    //Referencia al comp. imagen de HealthBar
    [SerializeField] private Image healthBar;

    //Flag de "puede recibir da�o"
    public bool canHurt = true;

    //-----------------------------------------------------------------------

    void Start()
    {
        //La salud al maximo
        currentHealth = maxHealth;

        //Iniciamos corutina para recibir da�o
        StartCoroutine(TakeRepeatingDamage());
    }

    //-----------------------------------------------------------------------

    public void TakeDamage(float damage)
    {
        //Si despues de recibir da�o aun nos queda vida, simplemente reducimos
        if (currentHealth - damage > 0) currentHealth -= damage;

        //En caso de que el Da�o conlleve a la muerte
        else
        {
            //Dejamos la vida en 0 de forma constante
            currentHealth = 0;

            //GAME OVER
            // ()...
        }

        //Seteamos la proporci�n de la imagen que se muestra en base a la Vida restante
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    //-----------------------------------------------------------------------

    public IEnumerator TakeRepeatingDamage()
    {
        //Mientras el Flag de "Puede recibir da�o" este activa
        while(canHurt) 
        {
            //Tomamos el da�o
            TakeDamage(autoHurt);

            //Repetimos cada segundo
            yield return new WaitForSeconds(1f);
        }
    }
}
