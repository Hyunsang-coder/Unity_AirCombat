using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    [SerializeField] float WaitForSeconds = 1f;
    
    void Update()
    {
        Destroy(gameObject, WaitForSeconds);
    }
}
