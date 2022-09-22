using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    private Transform m_target;
    public float Range = 15f;

    public Transform TowerModel;

    public float RotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, .2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_target == null)
            return;

        // else: kill it :D

        Vector3 lookDirection = m_target.position - this.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
        Vector3 rotation = Quaternion.Lerp(TowerModel.rotation, lookRotation, RotationSpeed * Time.deltaTime).eulerAngles;
        TowerModel.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyUnit");

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position);

            if(distToEnemy < shortestDistance)
            {
                shortestDistance = distToEnemy;
                nearestEnemy = enemy;
            }

        }

        if(nearestEnemy != null && shortestDistance <= Range)
        {
            m_target = nearestEnemy.transform;
        }
        else
        {
            m_target = null;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Range);
    }


}
