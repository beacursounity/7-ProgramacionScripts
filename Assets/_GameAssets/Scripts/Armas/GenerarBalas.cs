using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarBalas : MonoBehaviour {

    // NECESITO EL PREFAB DE LA BALA
    [SerializeField] GameObject prefabBala;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.G))
        {
            //Debug.Log("espacio");
            GameObject nuevaBala = Instantiate(prefabBala,transform.position,transform.rotation);
            //nuevaBala.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100); 
            // PARA HACER LA FUERZA CON RESPECTO AL MUNDO 
            nuevaBala.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 500);
        }
	}
}
