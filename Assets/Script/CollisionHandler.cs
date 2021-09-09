using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadTime = 2f;
    [SerializeField] ParticleSystem explosionVFX;

    
    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCrashSequence();

    }

    void StartCrashSequence()
    {
        explosionVFX.Play();
        GetComponent<PlayerControls>().enabled = false;
        Destroy(gameObject, 3f);         // gameobject가 먼저 사라지면 Invoke 호출 안됨
        Invoke("ReloadLevel", loadTime);
    }

    void ReloadLevel()
    {
        Debug.Log("ReloadLevel 함수가 실행되었습니다");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
