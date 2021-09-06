using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadTime = 1.5f;
    [SerializeField] ParticleSystem explosionVFX;

    
    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        explosionVFX.Play();
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", loadTime);
        Destroy(gameObject, 0.5f);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
