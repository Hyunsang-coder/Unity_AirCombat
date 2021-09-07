using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] GameObject particleVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePoint;
    [SerializeField] int enemyHP = 5;
    Scoreboard scoreboard;
    GameObject parentPosition;

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        parentPosition = GameObject.FindWithTag("ParticleGroup");
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other) // isTrigger 꺼져 있어야 함!
    {
        ProcessHit();
        enemyHP--;
        if (enemyHP < 1)
        {
            KillEnemy();
        }
            

    }

    private void ProcessHit()
    {
        scoreboard.IncreaseScore(scorePoint);
        GameObject hit = Instantiate(hitVFX, transform.position, Quaternion.identity);
        hit.transform.parent = parentPosition.transform;

    }

    private void KillEnemy()
    {
        GameObject particles = Instantiate(particleVFX, transform.position, Quaternion.identity);
        particles.transform.parent = parentPosition.transform;

        Destroy(gameObject, 0.5f);
    }

    
}
