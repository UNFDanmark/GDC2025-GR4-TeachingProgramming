using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public float moneyCooldown;
    public float moneyAreaMin;
    public float moneyAreaMax;
    public float moneyLift;
    public float enemyCooldown;
    public Quaternion initRot;
    public GameObject moneyPrefab;
    public GameObject enemyPrefab;

    float actualCooldown = 0;

    public float actualEnemyCooldown = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        actualCooldown -= Time.deltaTime;
        if (actualCooldown <= 0)
        {
            actualCooldown = moneyCooldown;
            Vector3 pos = new Vector3(Random.Range(moneyAreaMin, moneyAreaMax), moneyLift,
                Random.Range(moneyAreaMin, moneyAreaMax));
            Instantiate(moneyPrefab, pos, initRot);
        }

        actualEnemyCooldown -= Time.deltaTime;
        if (actualEnemyCooldown <= 0)
        {
            actualEnemyCooldown = enemyCooldown;
            Vector3 pos = new Vector3(Random.Range(moneyAreaMin, moneyAreaMax), moneyLift,
                Random.Range(moneyAreaMin, moneyAreaMax));
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }
}
