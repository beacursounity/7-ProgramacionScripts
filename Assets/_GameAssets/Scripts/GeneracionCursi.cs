using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionCursi : MonoBehaviour {

    [SerializeField] GameObject prefabCuboCursi;

	// Use this for initialization
	void Start () {
        InvokeRepeating("GenerateCuboCursi", 2, 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void GenerateCuboCursi()
    {
        // INSTANCIAR EL ENEMIGO TONTO EN UN GO VACIO
        transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        
        GameObject newCuboCursi = Instantiate(prefabCuboCursi, transform);
    }
    
}
