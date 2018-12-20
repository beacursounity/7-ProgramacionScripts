using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("ESTADO")]
    [SerializeField] int vidaActual = 20;
    [SerializeField] int vidaMaxima = 5;
    [SerializeField] bool estaVivo = true; // si no ponemos private sera private por defecto
  

    // PARA ALMACENAR LOS TIPOS DE ARMA CON UN TIPO ARMA(SCRIPT)
    [Header("TIPOS DE ARMA")]
    private const int NUM_ARMAS = 4; // LA HACEMOS CONSTANTE PQ NO LA VAMOS A MODIFICAR
    [SerializeField] GameObject[] armas = new GameObject[NUM_ARMAS]; // seran o prefabs o GameObjects
    // SI PONEMOS EL NUMERO 4 DIRECTAMENTE ESTO SE LLAMA HARDCODE
    // VARIABLE PARA SABER QUE ARMA TENGO ACTIVA,
    [SerializeField] int armaActiva = 0;

    [Header("REFERENCIAS")]
    [SerializeField] GameObject enemigo;

    [Header("REFERENCIAS DEL TEXTO")]
    [SerializeField] TextMesh tm;

    //Incrementar la Vida del personaje
    public void Start() {
        // SOLUCION CUTRE
        // armas[0].SetActive(true);
        // armas[0].SetActive(false);
        // armas[0].SetActive(false);
        // armas[0].SetActive(false);

        // SOLUCION BUENA BUCLE FOR
        /*for ( int i = 0; i < armas.Length; i++) 
        {
            armas[i].SetActive(false);
        }*/

        // TAMBIEN SE PODRIA HACER CON EL FOR EACH
        // NO SE VE EL INDICE Y NO PODEMOS RECORRER EL ARRAY DEL FINAL AL PRINCIPIO O DE 2 EN 2 COMO
        // EN EL FOR
        // METODO PARA DESACTIVAR TODAS LAS ARMAS
        //DesactivarArmas();
        // ACTIVAMOS UN ARMA
        //armas[armaActiva].SetActive(true);


        // HACEMOS LA LLAMADA A LA 0 PARA QUE ME ACTIVE EL ARMA 0
        ActivarArma(armaActiva);

    }

    // DESACTIVAMOS TODAS LAS ARMAS
    private void DesactivarArmas() {
        foreach (var arma in armas) {
            arma.SetActive(false);
        }
    }

    public void Update() {

        // ACTUALIZAMOS LAS VIDAS
        tm.text = " " + vidaActual; // LE PONEMOS "" PARA QUE LO TRANFORME A TEXTO

        // DEPENDIENDO QUE TECLA PULSE ACTIVAREMOS UN ARMA U OTRA
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            ActivarArma(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivarArma(1);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            ActivarArma(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            ActivarArma(3);
        }
    }

    // METODO PARA LLAMAR DESACTIVARARMAS Y LUEGO MEDIANTE PARAMETRO LE PASO EL
    // ARMA QUE QUIERO ACTIVAR SEGUN EL TECLADO
    private void ActivarArma(int armaActiva) {
        DesactivarArmas();
        armas[armaActiva].SetActive(true);
    }

    //Incrementar la Vida del personaje
    public void IncrementarVida(int incrementoVida)
    {
        Debug.Log("incremento vida " + incrementoVida);
        
        vidaActual = vidaActual + incrementoVida;
        Debug.Log("Vida Actual " + vidaActual);
        if (vidaActual > vidaMaxima) vidaActual = vidaMaxima;
    }


    // El enemigo reciben un daño
    public void Recibirdanyo(int danyo) {
        // Restamos la vida 
        vidaActual = vidaActual - danyo;
 
        // vida si es 0 se tiene que morir el jugador
        if (vidaActual <= 0) {
            vidaActual = 0;
            Morir();
        }
    }

    private void OnMouseDown() {
        Debug.Log("PULSADO CON EL RATON PLAYER");
        // es el daño que producimos al Enemigo
        Recibirdanyo(10);
    }
    // El Player 
    public void Morir() {
        estaVivo = false;

    }

    //  
    public void Atacar() {


    }

    // 
    public void CambiarArma() {


    }

}