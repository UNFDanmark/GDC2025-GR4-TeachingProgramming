using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public GameObject eyes;
    public GameObject bullet;
    public float shootingCooldown;
    public float bulletSpeed;
    public float bulletLiveTime;
    
    NavMeshAgent agent;
    GameObject target;

    float cooldownTimer;
	bool canSeeSomething;
    RaycastHit hit;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
        canSeeSomething = Physics.Raycast(eyes.transform.position, eyes.transform.forward, out hit);
        cooldownTimer -= Time.deltaTime;
        if (canSeeSomething && hit.transform.CompareTag("Player") && cooldownTimer <= 0f)
        {
            cooldownTimer = shootingCooldown;
            GameObject obj = Instantiate(bullet, eyes.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().linearVelocity = eyes.transform.forward * bulletSpeed;
            Destroy(obj, bulletLiveTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        if (canSeeSomething && hit.transform.CompareTag("Player"))
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        
        Gizmos.DrawRay(eyes.transform.position, eyes.transform.forward * 10f);
    }
}
