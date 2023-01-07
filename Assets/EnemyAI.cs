using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    bool coolDown = false;
    bool foundEnemy = false;
    int waypointNum = 0;
    bool isPatrol = true;

    [SerializeField] Transform[] wapoints;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponentInParent<EntityHealth>())
        {
            foundEnemy = true;
            if (Vector3.Distance(transform.parent.position, other.transform.position) >= 3f)
            {
                transform.parent.position = Vector3.MoveTowards(transform.parent.position, other.transform.position, 0.025f);
            }
            else if(!coolDown)
            {
                coolDown = true;
                StartCoroutine(WaitForCoolDown(other.gameObject));
            }
        }

        IEnumerator WaitForCoolDown(GameObject enemy)
        {
            enemy.GetComponentInParent<EntityHealth>().TakeDamage(5);
            yield return new WaitForSeconds(2.5f);
            coolDown = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<EntityHealth>())
        {
            foundEnemy = false;
        }
    }

    private void Update()
    {
        if(!foundEnemy)
        {
            Vector2 cashPos = Vector2.MoveTowards(new Vector2(transform.parent.position.x, transform.parent.position.z), new Vector2(wapoints[waypointNum].position.x, wapoints[waypointNum].position.z), 1f * Time.deltaTime);
            transform.parent.position = new Vector3(cashPos.x, transform.parent.position.y, cashPos.y);
            if(isPatrol)
            {
                isPatrol = false;
                StartCoroutine(SwitchWapoint());
            }
        }
        else if(foundEnemy)
        {
            isPatrol = true;
            StopCoroutine(SwitchWapoint());
        }
        
    }

    IEnumerator SwitchWapoint()
    {
        while (true)
        {            
            yield return new WaitUntil(() => Vector2.Distance(new Vector2(transform.parent.position.x, transform.parent.position.z), new Vector2(wapoints[waypointNum].position.x, wapoints[waypointNum].position.z)) <= 0.1f);
            if(waypointNum >= wapoints.Length - 1)
            {
                waypointNum = 0;
            }
            else
            {
                waypointNum++;
            }
        }
    }

}
