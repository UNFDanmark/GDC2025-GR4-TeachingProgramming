using System;
using UnityEngine;
using UnityEngine.AI;

public class MoneyScript : MonoBehaviour
{
    public float rotationSpeed;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
