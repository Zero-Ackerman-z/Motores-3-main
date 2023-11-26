using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class life : MonoBehaviour
{
    public Sprite[] corazones;
    public delegate void LifeChangeHandler(int newLife);
    public event LifeChangeHandler OnLifeChange;

    private int currentLife = 0;

    // Start is called before the first frame update
    void Start()
    {
        CambioVida(5);
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes agregar lógica adicional aquí si es necesario.
    }

    public void CambioVida(int pos)
    {
        if (pos >= 0 && pos < corazones.Length)
        {
            currentLife = pos;
            this.GetComponent<Image>().sprite = corazones[pos];

            // Disparar el evento OnLifeChange para notificar a otros objetos del cambio en la vida.
            if (OnLifeChange != null)
            {
                OnLifeChange(currentLife);
            }
        }
    }

}
