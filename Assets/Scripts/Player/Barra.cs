using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private float autoHurt;

    [SerializeField] private Image healthBar;
    public bool canHurt = true;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        StartCoroutine(TakeRepeatingDamage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth - damage > 0) currentHealth -= damage;
        else
        {
            currentHealth = 0;
            //que ocurra algo que indique el game over
        }
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public IEnumerator TakeRepeatingDamage()
    {
        while(canHurt) 
        {
            TakeDamage(autoHurt);
            yield return new WaitForSeconds(1f);
        }
    }
}
