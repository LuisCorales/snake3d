using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEater : MonoBehaviour
{
    private bool dead = false;
    private int eatenFruits = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)//Grow when colliding with a fruit, lose game if it with a
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            this.eatenFruits++;
        }

        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("SnakeJoint"))
        {
            this.dead = true;
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
