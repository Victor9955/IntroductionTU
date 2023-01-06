using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class HitEntity : MonoBehaviour
{
    [SerializeField] bool isZone;
    [SerializeField] int damage;
    List<GameObject> currents;

    private void Start()
    {
        currents = new List<GameObject>();

        if (isZone)
        {
            StartCoroutine(HitZone());
            StartCoroutine(ClearList());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!currents.Contains(other.gameObject))
        {
            currents.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
         currents.Remove(other.gameObject);
    }

    public void Hit()
    {
        for (int s = 0; s < currents.Count; s++)
        {
            if (currents[s].GetComponentInParent<EntityHealth>())
            {
                currents[s].GetComponentInParent<EntityHealth>().TakeDamage(damage);
                currents.RemoveAt(s);
            }
        }
    }

    [Button("Damage")]
    private void Damage() { Hit(); }

    IEnumerator HitZone()
    {
        while (true)
        {
            yield return new WaitUntil(() => GetComponent<BoxCollider>().enabled);
            Hit();
        }
    }

    IEnumerator ClearList()
    {
        while (true)
        {
            yield return new WaitUntil(() => !GetComponent<BoxCollider>().enabled);
            currents.Clear();
        }
    }
}
