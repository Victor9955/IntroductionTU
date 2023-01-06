using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    [SerializeField] int amount;

    public override void Active(Collider collider)
    {
        if (collider.GetComponentInParent<EntityGold>())
        {
            collider.GetComponentInParent<EntityGold>().AddGold(amount);
        }
    }
}
