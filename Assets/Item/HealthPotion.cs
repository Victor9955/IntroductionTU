using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] int heal;
    public override bool Active(Collider collider)
    {
        if (collider.GetComponentInParent<EntityHealth>())
        {
            collider.GetComponentInParent<EntityHealth>().Heal(heal);
            return true;
        }
        else
        {
            return false;
        }
    }
}
