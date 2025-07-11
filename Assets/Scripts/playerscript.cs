using UnityEngine;
using UnityEngine.InputSystem;

public class playerscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int cooldownHit = 10;
    public float speed = 4f;
    public InputAction moveAction;
    public InputAction rotationAction;
    
    int actualCooldown = 0;
    Rigidbody rb;
    void Start()
    {
        print("UwU i'm a cute start message UwU, you look cute today!");
        moveAction.Enable();
        rotationAction.Enable();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        actualCooldown += 1;
        if (actualCooldown == cooldownHit)
        {
            print("pew");
        } 
            
        print("Update: you still look cute!");
        //transform.position += new Vector3(speed*Time.deltaTime, 0,0);

        transform.position = transform.position + transform.forward  * (moveAction.ReadValue<float>() * speed* Time.deltaTime);
        
        transform.Rotate(0,rotationAction.ReadValue<float>(),0);
        
    }
}
