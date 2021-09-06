using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] GameObject particleVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parentPosition;
    [SerializeField] public Scoreboard scoreboard;
    [SerializeField] int scorePoint;
    [SerializeField] int enemyHP = 5;
    

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();    
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
        hit.transform.parent = parentPosition;

    }

    private void KillEnemy()
    {
        GameObject particles = Instantiate(particleVFX, transform.position, Quaternion.identity);
        particles.transform.parent = parentPosition;

        Destroy(gameObject, 0.5f);
    }

    
}
