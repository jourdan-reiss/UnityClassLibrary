using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDestroyable, IDamageable
{
    //what does a character need?

    int healthPoints;
    int damage;


    Rigidbody characterRigidbody;
    Collider characterCollider;


    public Character (int healthPoints, float damage)
    {
        characterRigidbody = GetComponent<Rigidbody>();
        characterCollider = GetComponent<Collider>();
    }

    public virtual void Attack(int damage)
    {

    }

    public virtual void TakeDamage()
    {

    }

    public virtual void Destroy()
    {

    }
    
	
}
