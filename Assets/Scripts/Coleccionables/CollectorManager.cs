using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectorManager : MonoBehaviour
{
    [SerializeField] private int conteo = 0;

    public static CollectorManager instance;

    private void Awake()
    {
        if ((instance != null && instance != this) || SceneManager.GetActiveScene().name == "Corousel" || SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AumentarConteo()
    {
        instance.conteo += 1;
    }
}
