using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLocation : MonoBehaviour
{
    bool isTouched = false;

    public GameObject InteractObject;
    Transform trans;
    Vector3 beginPos;

    float movedownDistance = 2.0f;
    float movedownSpeed = 1.0f;
    public bool IsTouched
    {
        get { return isTouched; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (InteractObject)
        {
            trans = InteractObject.GetComponent<Transform>();
            beginPos = trans.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched && InteractObject && trans.position.y > beginPos.y - movedownDistance)
        {
            trans.position -= new Vector3(0, Time.deltaTime * movedownSpeed, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isTouched = true;
        }
    }

    public bool IsInteractEnd()
    {
        if (!InteractObject) return false;

        if (trans.position.y > beginPos.y + movedownDistance)
        {
            return false;
        }
        else
            return true;
    }
}
