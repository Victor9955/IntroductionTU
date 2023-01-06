using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class HitEntity : MonoBehaviour
{
    [SerializeField] int damage;
    List<GameObject> currents;

    private void OnTriggerEnter(Collider other)
    {
        if(!currents.Contains(other.transform.parent.gameObject))
        {
            currents.Add(other.transform.parent.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currents.Remove(other.transform.parent.gameObject);
    }

    public void Hit()
    {
        foreach (GameObject item in currents)
        {
            if(item.GetComponent<EntityHealth>())
            {
                item.GetComponent<EntityHealth>().TakeDamage(damage);
            }
            
        }
    }

    [Button("Damage")]
    private void Damage() { Hit(); }
}
