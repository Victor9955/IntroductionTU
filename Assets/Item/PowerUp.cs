using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    public override bool Active(Collider collider)
    {
        if (collider.GetComponentInParent<EntityHealth>())
        {
            collider.GetComponentInParent<EntityHealth>().LifeMax();
            return true;
        }
        else
        {
            return false;
        }
    }
}
