using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaVida : MonoBehaviour {

    [SerializeField] int speedRotacion = 1;
    int rotacion = 0;

    [Header("MOVIMIENTO CAJAVIDA")]
    int deltaY = 0;
    bool subiendo = true;
    

    // MOVIMIENTO CAJAVIDA
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotacion = rotacion + speedRotacion;
        transform.eulerAngles = new Vector3(0, rotacion, 0);
        // ESTO TB FUNCIONA
        //transform.rotation = Quaternion.Euler(new Vector3(0, rotacion, 0));
        //rotacion = rotacion + 1;

        // PARA QUE SUBA Y BAJE
        if (subiendo) {
            deltaY++;
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        else {
            deltaY--;
            transform.Translate(Vector3.up * Time.deltaTime * -1);
        }

        if (deltaY > 50) {
            subiendo = false;
        }
        else if (deltaY <= 0) {
            subiendo = true;
        }
	}

    private void OnCollisionEnter(Collision collision) {

        GameObject colisionador = collision.gameObject;
        if( colisionador.name == "Player")
        {
            // RECOJO EL COMPONENTE PLAYER
            Player player = colisionador.GetComponent<Player>();
            // SUMO 1 A INCREMENTAR VIDA
            player.IncrementarVida(1);
        }
    }
}
