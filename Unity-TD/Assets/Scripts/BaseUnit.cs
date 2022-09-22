using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [Header("Attributes")]
    public float Range = 15f;
    public float RotationSpeed = 10f;
    public float FireRate = 1f;
    public float FireCountdown = 0f;

    [Header("UnitySetup")]
    public Transform m_target;
    public Transform TowerModel;
    public GameObject PREFAB_BULLET;
    public Transform FireLocation;

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

        if(FireCountdown <= 0f)
        {
            ShootTarget();
            FireCountdown = 1f / FireRate;
        }
        FireCountdown -= Time.deltaTime;

    }

    private void ShootTarget()
    {
        var b = Instantiate(PREFAB_BULLET, FireLocation.position, Quaternion.identity);
        if(b != null)
        b.GetComponent<Bullet>().SetTarget(m_target);
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
