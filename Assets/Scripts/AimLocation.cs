using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLocation : MonoBehaviour
{
    bool isTouched = false;

    public bool IsTouched
    {
        get { return isTouched; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isTouched = true;
        }
    }
}
