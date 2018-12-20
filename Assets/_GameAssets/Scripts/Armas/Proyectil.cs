using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    // DA UN COLLIDER POR COLISION
    private void OnTriggerEnter(Collider other) {
        // RECOJO EL GAMEOBJECT QUE ES CON EL QUE COLISIONA LA BALA
        GameObject objetivoImpacto = other.gameObject;
        //print("Nombre: " + other.name);
        //print("Tag: " + other.tag);

        // LOS BUSCAMOS POR SU TAG PARA SABER CONTRA QUIEN GOLPEO
        if (objetivoImpacto.tag == "Enemigo") 
        {
            // RECOGEMOS SU COMPONENTE PARA PODER QUITAR LA VIDA DEL ENEMIGO
            objetivoImpacto.GetComponent<Enemigo>().Recibirdanyo(1);
            
        }
        // DESTRUIR BALA
        Destroy(this.gameObject);
    }
}
