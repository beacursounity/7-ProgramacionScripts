﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovil : Enemigo {

    // SI LO DEJAMOS COMO PRIVATE HAY QUE HACER LOS METDOS GET Y SET PARA QUE EL HIJO 
    // PUEDA ACCEDER A ESA VARIABLES
    //[SerializeField] int velocidad; 

    // LO DEJAREMOS PROTEGIDO AUNQUE NO ES IDEAL Y ASI LO VEN SUS HIJOS
    [SerializeField] protected int velocidad = 10;


    [Header("Enemigo Movil")]
    [SerializeField] int inicioRotacion = 1;
    [SerializeField] int tiempoRotacion = 2;

    // METODO PARA ASIGNAR EL VALOR DESDE SU HIJO ENEMIGOTONTO
    /*public int GetSpeed() 
    {
        return velocidad
    }

    public int SetSpeed(int _velocidad) {
        this.velocidad = _velocidad;
    }*/

    // Use this for initialization
    void Start () {
        InvokeRepeating("RotarAleatoriamente", inicioRotacion, tiempoRotacion);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void RotarAleatoriamente() {
        // LE VAMOS HACER UN EJE DE ROTACION ALEATORIO enter 0 y 360
        float rotacion = Random.Range(0f, 360F);
        // VAMOS A ROTAR SOBRE EL EJE DE LA Y 
        transform.eulerAngles = new Vector3(0, rotacion, 0);
    }

    // METODO AVANZAR COMUN PARA TODOS LOS ENEMIGOS
    // LO PONEMOS PROTECT PARA QUE PODAMOS LLAMARLO EN EL E.TONTO Y E.LISTO
    // YA QUE LOS DOS VAN HACER LO MISMO.
    protected void Avanzar() {
        // SOLO SI ESTA VIVO AVANZA
        if (estaVivo) { 
            transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
        }   
    }

    private void OnCollisionEnter(Collision collision) {
        //Debug.Log("ha entrado");

        // METODO QUE ROTE ALEATORIAMENTE
        RotarAleatoriamente();

        // PARA SABER EL NOMBRE CON QUIEN NO HEMOS CHOCADO
        // SI ES PLAYER LO DESTRUIMOS 
        if (collision.gameObject.name == "Player") {
            estaVivo = false;

            // RECOGEMOS SU COMPONENTE PLAYER Y ASI PODREMOS LLAMAR A RECIBIRDANYO
            // LA VARIABLE DANYO TENDRIA QUE ESTAR EN PROTECTE EN EL PADRE PARA 
            // QUE PUEDA RECOGERLA SI NO DARIA ERROR
            collision.gameObject.GetComponent<Player>().Recibirdanyo(danyo);

            // SE HACE UN INSTANTIATE EN MODO DE EJECUCION Y LUEGO SE PUEDE HACER UN PLAY
            //ParticleSystem ps = Instantiate(explosion, transform);
            //ps.Play(); // PLAY PARA QUE SALGAN LAS PARTICULAS
            // DESACTIVAMOS
            //GetComponent<Renderer>().enabled = false; // EL RENDERER EL QUE DIBUJA EL OBJETO
            //Invoke("Destruir",1);

            // el Destroyinmediate se destruye y el Destroy 
            //termina de ejecutar si hay algo por detras de codigo

            // SE HACE UN INSTANTIATE EN MODO DE EJECUCION Y LUEGO SE PUEDE HACER UN PLAY
            // HACEMOS EL INSTANTIATE PERO DESDE LA POSICION 
            //ParticleSystem ps = Instantiate(explosion, transform.position, Quaternion.identity);
            //estaVivo = false;
            //ps.Play(); // PLAY PARA QUE SALGAN LAS PARTICULAS
            // YA NO HACE FALTA DESACTIVAR EL RENDER YA QUE NO HACEMOS EL TRANSFORM Y EL PARTICLESYSTEM LO
            // HEMOS GENERADO DE MANERA INDEPENDIENTE
            //GetComponent<Renderer>().enabled = false; // EL RENDERER EL QUE DIBUJA EL OBJETO
            //Invoke("Destruir", 1);
            //Destruir();
            // HEMOS QUITADO LO ANTERIOR Y LO HEMOS PUESTO EN ENEMIGOS MORIR()
            Morir();
        }
       }
    }
