using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float cooldownHit;
    public float speed;
    public InputAction moveAction;
    public InputAction rotationAction;
    public InputAction shootAction;
    public float shootingSpeed;
    public float bulletLiveTime;

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    
    float actualCooldown = 0f;
    Rigidbody rb;
    void Start()
    {
        print("UwU i'm a cute start message UwU, you look cute today!");
        moveAction.Enable();
        rotationAction.Enable();
        shootAction.Enable();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        actualCooldown -= Time.deltaTime;
        print("cooldown: " + actualCooldown);
        if (0 >= actualCooldown && shootAction.WasPerformedThisFrame())
        {
            print("tries");
            actualCooldown = cooldownHit;
            GameObject obj = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);

            obj.GetComponent<Rigidbody>().linearVelocity = transform.forward * shootingSpeed;
            
            GameObject.Destroy(obj, bulletLiveTime);
        } 
            
        print("Update: you still look cute!");
        //transform.position += new Vector3(speed*Time.deltaTime, 0,0);

        transform.position = transform.position + transform.forward  * (moveAction.ReadValue<float>() * speed* Time.deltaTime);
        
        transform.Rotate(0,rotationAction.ReadValue<float>(),0);
        
    }
}
