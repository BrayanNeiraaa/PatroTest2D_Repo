using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float speed = 5; //velocidad de la plataforma
    [SerializeField] int startingPoint; //determinador punto inicio plataforma
    [SerializeField] Transform[] points; //Array que almacena la posicion de los diferentes puntos de alcance
    int i; //indice del array = punto al que va a perseguir la plataforma

    // Start is called before the first frame update
    void Start()
    {
    
        //al inicio del juego la plataforma se teleporta a la posicion de igual valor que starting point
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //suma 1 al valor del indicie, persigue el siguiente punto
            if (i == points.Length) i = 0; //resetea el circuito de puntos
        }

        //mueve la plataforma a la posicion de punto en el array que coincida con el valor de i
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

    }
}
