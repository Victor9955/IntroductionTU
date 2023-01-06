using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Active(other);
        Destroy(gameObject);
    }

    public virtual void Active(Collider collider) { }
}
