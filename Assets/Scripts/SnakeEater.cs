using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEater : MonoBehaviour
{
    private bool dead;
    private int eatenFruits;
    [SerializeField]
    private GameObject jointsParent;
    [SerializeField]
    private GameObject jointPrefab;
    private List<GameObject> snakeParts = new List<GameObject>();//List to store all the snake's joints and the head

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        eatenFruits = 0;
        this.snakeParts.Add(this.gameObject);//Add the head to the parts list
    }

    private void OnCollisionEnter(Collision collision)//Lose game if colliding with wall or self
    {      

        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("SnakeJoint"))
        {
            this.dead = true;           
        }
    }

    private void OnTriggerEnter(Collider trigger)//Grow when colliding with a fruit
{
        if (trigger.gameObject.CompareTag("Fruit"))
        {
            this.eatenFruits++;
            Destroy(trigger.gameObject);//Destroy the eaten fruit
            GrowJoint();//Grow a new joint
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

    private void GrowJoint()//Make a new joint behind the last existing joint
    {
        GameObject joint = Instantiate(jointPrefab, jointsParent.transform);//Add a new joint to the snake's body
        GameObject lastPart = this.snakeParts[this.snakeParts.Count - 1];
        joint.transform.position = lastPart.transform.position - lastPart.transform.forward;//Put the new joint after the last part of the snake
        this.snakeParts.Add(joint);//Add the joint to the parts list
    }
}
