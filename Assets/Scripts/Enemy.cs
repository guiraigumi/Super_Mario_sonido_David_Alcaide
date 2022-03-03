using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //variable para controlar la velocidad del Goomba.
    public float speed = 4.5f;
    //variable para saber en que direccion se mueve en el eje X
    private int directionX = 1;
    //variable para almacenar el rigidbody del enemigo.
    private Rigidbody2D rigidBody;

    //variable para saber si el goomba esta muerto
    public bool isAlive = true;

    private GameManager gameManager;


    // Awake se ejecuta antes que Start. Es la primera función que se ejecuta.
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // FixedUpdate es independiente a los frames del juego, al contrario que Update.
    void FixedUpdate()
    {
        if(isAlive)
        {
             //Añade velocidad en el eje X y deja el eje Y sin tocar por codigo.
        rigidBody.velocity = new Vector2(directionX * speed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
           
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        //== compara entre la primera palabra y la segunda. Si detecta colision con un objeto con tag Pared entonces...
        if(hit.gameObject.tag == "Pared" || hit.gameObject.tag == "Goombas")
        {
            Debug.Log("me he chocado");
            
            if(directionX == 1)
            {
                directionX = -1;
            }
            //si nos movemos a la izquierda la cambia a la derecha.
            else
            {
                directionX = 1;
            }

        }
        //si 
        else if(hit.gameObject.tag == "MuereMario")
        {
            Destroy(hit.gameObject);
            gameManager.DeathMario();
        }
    }
}
