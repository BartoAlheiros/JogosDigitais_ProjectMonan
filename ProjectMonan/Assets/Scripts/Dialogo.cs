using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public FalaNPC[] falas = new FalaNPC[2];
    private bool dialogoConcluido = false;
    DialogoController dialogoController;

    // Start is called before the first frame update
    void Start()
    {
        dialogoController = FindObjectOfType<DialogoController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // método responsável por 'disparar' o diálogo
    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Move(0);

            if(!dialogoConcluido) 
            {
                dialogoController.ProximaFala(falas[0]);
            } 
            else 
            {
                dialogoController.ProximaFala(falas[1]);
            }

            dialogoConcluido = true;
        }
    }
}
