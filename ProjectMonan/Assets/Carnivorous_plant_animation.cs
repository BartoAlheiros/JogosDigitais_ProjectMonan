using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnivorous_plant_animation : MonoBehaviour
{
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }
    
    public void AttackLeft() {
        anim.SetTrigger("AttackLeft");
    }

    public void AttackRight() {
        anim.SetTrigger("AttackRight");
    }

}
