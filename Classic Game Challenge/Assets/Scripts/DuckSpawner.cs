using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject duckPrefab;

    private float duckSpawnTimer = 7f;
    [SerializeField] private float attackDamage = 50f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDuck());
    }

    private IEnumerator SpawnDuck()
    {
        for(int i = 0; i < 10; i++)
        {
            WaitForSeconds wait = new WaitForSeconds(duckSpawnTimer);

            yield return new WaitForSeconds(duckSpawnTimer);
        
            Instantiate(duckPrefab, transform.position, Quaternion.identity);

            if (i == 9)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            Destroy(gameObject);
        }   

        if (other.gameObject.tag == "Sword")
        {
            Destroy(gameObject);
        }   
    }
}
