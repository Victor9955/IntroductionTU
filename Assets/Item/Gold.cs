using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    [SerializeField] int amount;

    public override bool Active(Collider collider)
    {
        if (collider.GetComponentInParent<EntityGold>())
        {
            collider.GetComponentInParent<EntityGold>().AddGold(amount);
            return true;
        }
        else
        {
            return false;
        }
    }
}
