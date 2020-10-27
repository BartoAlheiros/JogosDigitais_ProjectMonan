using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatchet : MonoBehaviour
{
    public int damage;
    private Carnivorous_plant plant;

    private void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Plant")) {
            plant = other.gameObject.GetComponent<Carnivorous_plant>();
            plant.DamagePlant(damage);
        }
    }
}
