using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ESTAMOS HACIENDO EL ENEMIGO BASE
public class Enemigo : MonoBehaviour {

    [Header("ESTADO")]
    [SerializeField] protected bool estaVivo = true;
    [SerializeField] int vida = 10;

    [Header("ATAQUE")]
    [SerializeField] int distanciaDeteccion = 5 ; // PARA EL ENEMIGO QUE SE MUEVE
    [SerializeField] protected int danyo = 2; // que realiza a nuestro personaje

    // Tenemos que tener nuestro personaje para saber la distancia pero respecto del player
    [Header("REFERENCIAS")]
    [SerializeField] protected GameObject personaje; // PARA SABER DONDE ESTA SOLO NECESITO SU TRANSFOMR

    [Header("FX")]
    [SerializeField] protected ParticleSystem explosion;

    //int speed;
    //int distanciaExplosion; // 
    // LE HACEMOS DAÑO AL ENEMIGO Y NO SE REGENERA


    private void Start() {
        vida = 100;
    }

    public int DetectarDistanciaAlPersonaje() {
        


        return 0;
    }

    // El Enemigo muere y ya esta
    public void Morir() 
    {
        Debug.Log("MURIENDO");
        /*
        1. Indicar que esta muerto 
        2. Sistema de particulas
        3. Gritos horibles de dolor / Despedirse de los seres queridos
        4. Destruir el enemigo
        5.¿Aumentar salud? ¿Incremetar puntuacion? ¿Recompensas?....
        */
        // LANZAMOS LA EXPLOSION
        // LO HEMOS PUESTO EL PS INDEPENDIENTEMENTE PARA PODER HACER EL DESTUIR Y QUE NO SE
        // DESTRUYAN LAS BALAS
        ParticleSystem ps = Instantiate(explosion, transform.position, Quaternion.identity);
        // ESTADOVIVO A FALSE
        estaVivo = false;
        // EXPLOSION
        explosion.Play();
        // DESTRUYE AL ENEMIGO
        Destruir();
        
    }

    // Todos los enemigos van a atacar
    public void Atacar() {

    }

    // Todos los enemigos reciben un daño
    // EL DAÑO LO DA EL ARMA QUE TENDREMOS QUE DECIDIRLO NOSOTROS
    public void Recibirdanyo(int danyo) 
     {
        Debug.Log("Recibir daño");
        // Restamos la vida 
        vida = vida - danyo;
        // vida si es 0 se tiene que morir los enemigos
        if (vida <= 0) 
        {
            vida = 0;
            Morir();
        }
    }

    protected void Destruir()
    {
        Destroy(this.gameObject);
    }
    // CUANDO PUSEMOS SOBRE ESA GEOMETRIA SALGA EL DEBU POR CONSOLA
    // 
    /*private void OnMouseDown() {
        Debug.Log("PULSADO CON EL RATON");
        // es el daño que producimos al Player
        Recibirdanyo(10);
    }*/
}
