using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float MoveSpeed = 70f;

    public GameObject PREFAB_IMPACTEFFECT;

    public void SetTarget(Transform t)
    {
        target = t;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 lastPostion;

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 direction = target.position - this.transform.position;

        float distanceThisFrame = MoveSpeed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        lastPostion = this.transform.position;

        this.transform.Translate(direction.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        var vfx = Instantiate(PREFAB_IMPACTEFFECT, lastPostion, this.transform.rotation);
        Destroy(vfx, 2f);

        Destroy(target.gameObject);

        Destroy(this.gameObject);
    }

}
