using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEater : MonoBehaviour
{
    private bool dead;
    private int eatenFruits;
    
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        eatenFruits = 0;
    }

    private void OnCollisionEnter(Collision other) //Grow when colliding with a fruit, lose game if it with a
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            this.eatenFruits++;
        }

        if(other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("SnakeJoint"))
        {
            this.dead = true;
            Debug.Log(dead);
        }
    }

    public int GetEatenFruits()
    {
        return this.eatenFruits;
    }

    public bool IsDead()
    {
        return this.dead;
    }
}
