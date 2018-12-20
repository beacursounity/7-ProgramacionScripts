using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{

    // RECOGEMOS LA REFERENCIA DEL PREFAB
    [SerializeField] GameObject prefabEnemigo;

    [Header("COSAS DE GENERACION")]
    [SerializeField] float ratioGeneracionEnemigoTonto = 5f;

    int numEnemigos = 0; // VARIABLE CONTADOR DE ENEMIGOS 
    [SerializeField] int numEnemigosMaximo = 5; // SE PODRIA HACER CONSTANTE

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("GenerateEnemigoTonto", 2, ratioGeneracionEnemigoTonto);
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    void GenerateEnemigoTonto()
    {
        // INSTANCIAR EL ENEMIGO TONTO EN UN GO VACIO
        ///GameObject newEnemigo = Instantiate(prefabEnemigo, transform);
        GameObject newEnemigo = Instantiate(prefabEnemigo, transform.position, Quaternion.identity);
        //.position, Quaternion.identity);
        numEnemigos++;
        if (numEnemigos == numEnemigosMaximo)
        {
            CancelInvoke();
        }

    }
}
