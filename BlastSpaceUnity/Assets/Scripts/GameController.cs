using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int numEnemy = 0;
    private GameObject[] enemies;

    [SerializeField]
    private GameObject spawner1;

    [SerializeField]
    private GameObject spawner2;

    [SerializeField] 
    private int lastTime = 2;

    public ParticleSystem poof;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndGame();
            Count();
        }
    }

    void EndGame()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Destroy(spawner1);
        Destroy(spawner2);

        foreach (GameObject enemy in enemies)
        {
            Rigidbody rb = enemy.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = new Vector3(0,0);
            }
        }

        GameObject mainChar = GameObject.FindGameObjectWithTag("Player");
        Animator animator = mainChar.GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = false;
        }
    }
    void Count()
    {
        numEnemy = enemies.Length;
        foreach (GameObject enemy in enemies)
        {
            poof = enemy.GetComponent<ParticleSystem>();
            if (poof != null)
            {
                poof.Play();
            }
            lastingEnemies(enemy);
        }
    }
    IEnumerator lastingEnemies(GameObject obj)
    {
        yield return new WaitForSeconds(lastTime);

    }
}
