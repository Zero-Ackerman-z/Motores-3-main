using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public delegate void MyDelegate();
    public event MyDelegate Muerto;
    public event MyDelegate Daño;
    public event MyDelegate aumento;
    public event MyDelegate Puntaje;

    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float rayDistance = 0.2f;
    [SerializeField] private Color rayDebugColor = Color.red;

    private Vector2 movement;
    private Rigidbody2D myRB;
    private bool canJump;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        canJump = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayers);

        Debug.DrawRay(transform.position, Vector2.down * rayDistance, rayDebugColor);
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        myRB.velocity = new Vector2(movement.x * speed, myRB.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemigo")
        {
            Debug.Log("El jugador ha recibido daño por colisión con un enemigo");
            Daño?.Invoke();
            Muerto?.Invoke();
        }
        if (collision.gameObject.tag == "items")
        {
            Debug.Log("itemn");
            aumento?.Invoke();
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "moneda")
        {
            Debug.Log("moneda");

            Puntaje?.Invoke();

        }


    }

}

    


