using UnityEngine;

public class playerscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int cooldownHit = 10;
    public float speed = 4f;
    void Start()
    {
        print("UwU i'm a cute start message UwU, you look cute today!");
       
    }

    // Update is called once per frame
    void Update()
    {
        print("Update: you still look cute!");
        transform.position += new Vector3(speed*Time.deltaTime, 0,0);
        
    }
}
