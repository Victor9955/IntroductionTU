using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] int heal;
    public override void Active(Collider collider)
    {
        if (collider.GetComponentInParent<EntityHealth>())
        {
            collider.GetComponentInParent<EntityHealth>().Heal(heal);
        }
    }
}
