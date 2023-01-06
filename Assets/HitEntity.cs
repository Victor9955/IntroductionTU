using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class HitEntity : MonoBehaviour
{
    [SerializeField] int damage;
    List<GameObject> currents;
    private void Start()
    {
        currents = new List<GameObject>();
    }

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
        for (int s = 0; s < currents.Count; s++)
        {
            if (currents[s].GetComponent<EntityHealth>())
            {
                currents[s].GetComponent<EntityHealth>().TakeDamage(damage);
                currents.RemoveAt(s);
            }
        }
    }

    [Button("Damage")]
    private void Damage() { Hit(); }
}
