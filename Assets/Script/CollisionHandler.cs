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
        Destroy(gameObject, 3f);         // gameobject�� ���� ������� Invoke ȣ�� �ȵ�
        Invoke("ReloadLevel", loadTime);
    }

    void ReloadLevel()
    {
        Debug.Log("ReloadLevel �Լ��� ����Ǿ����ϴ�");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
