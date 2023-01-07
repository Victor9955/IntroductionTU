using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    bool touchPrey = false;
    bool coolDown = false;


    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.GetComponentInParent<EntityHealth>() && !coolDown)
        {
            touchPrey = true;
            coolDown = true;
            StartCoroutine(CoolDownUp());
            collision.gameObject.GetComponentInParent<EntityHealth>().TakeDamage(5);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<EntityHealth>())
        {
            touchPrey = false;
        }
    }


    IEnumerator CoolDownUp()
    {
        yield return new WaitForSeconds(2f);
        coolDown = false;
    }
}
