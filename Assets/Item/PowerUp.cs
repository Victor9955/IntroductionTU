using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    public override void Active(Collider collider)
    {
        if (collider.GetComponentInParent<EntityHealth>())
        {
            collider.GetComponentInParent<EntityHealth>().LifeMax();
        }
    }
}
