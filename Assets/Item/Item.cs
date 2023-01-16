using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.parent.CompareTag("Player") && Active(other))
        {
            Destroy(gameObject);
        }
    }

    public virtual bool Active(Collider collider) { return false; }
}
