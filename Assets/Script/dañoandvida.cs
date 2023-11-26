using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dañoandvida : MonoBehaviour
{
    [SerializeField] private PlayerController player; 
    private float vida = 5.0f; // Cambiado a float para reflejar el tipo de datos.
    public life vida_canvas;
    public life vida_corazones;
    public LayerMask itemsLayer;
    public Text scoreText;
    private bool puedeRecibirDaño = true; // Variable para evitar daño repetido en una sola pulsación.
    public static bool jugando = false;
    // Start is called before the first frame update
    void Start()
    {
        player.Muerto += Die;
        jugando = true;
        player.Daño += DisminucionLife;
        player.aumento += Aumentolife;
    }

    // Update is called once per frame
    void Update()
    {
        vida_canvas.CambioVida((int)vida);

        // Verifica si la barra espaciadora está siendo presionada.
        if (Input.GetKeyDown(KeyCode.Space) && puedeRecibirDaño)
        {
            // Reduce la vida del jugador en 1 punto.
            vida -= 1;

            if (vida <= 0)
            {
                Die();
            }

            // Desactiva la capacidad de recibir daño hasta que se suelte la barra espaciadora.
            puedeRecibirDaño = false;
        }
        // Verifica si se ha soltado la barra espaciadora para volver a permitir el daño.
        if (Input.GetKeyUp(KeyCode.Space))
        {
            puedeRecibirDaño = true;
        }
    }
    public void Die()
    {
        if (vida == 0)
        {
            jugando = false;
            scoreText.text = ("Game Over");
        }
        
    }
    private void OnDisable()
    {
        player.Muerto -= Die;
        player.aumento -= Aumentolife;
        player.Daño -= DisminucionLife;
    }
    public void DisminucionLife()
    {
        if (vida < 5)
        {
            vida = vida - 1;
            vida_canvas.CambioVida((int)vida);
        }
    }
    public void Aumentolife()
    {
        if(vida < 5)
        {
            vida = vida + 1;
            vida_canvas.CambioVida((int)vida);
        }
    }
}
