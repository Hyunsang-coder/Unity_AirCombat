using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrottlePower : MonoBehaviour
{
    
    public float factor = 10;

    void Start()
    {
        
    }
    void Update()
    {
        float count = 1f * Time.deltaTime * factor;
        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z+count);
                
    }
}
