using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] GameObject particleVFX;
    [SerializeField] Transform parentPosition;
    [SerializeField] public Scoreboard scoreboard;
    [SerializeField] int scorePoint;
    

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();    
    }

    void OnParticleCollision(GameObject other) // isTrigger 꺼져 있어야 함!
    {
        ProcessHit();
        KillEnemy();

    }

    private void ProcessHit()
    {
        scoreboard.IncreaseScore(scorePoint);
    }

    private void KillEnemy()
    {
        GameObject particles = Instantiate(particleVFX, transform.position, Quaternion.identity);
        particles.transform.parent = parentPosition;

        Destroy(gameObject, 0.5f);
    }

    
}
