using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTonto : EnemigoMovil {

   
    // Use this for initialization
    void Start () {
		//velocidad 
        // VA A EMPEZAR A ANDAR Al 1 SEGUNDOS DE EMPEZAR 
        // Y LO REPITE CADA 2
        //InvokeRepeating("RotarAleatoriamente",inicioRotacion,tiempoRotacion);
	}
	
	// Update is called once per frame
	void Update () {
        Avanzar();
	} 

}

