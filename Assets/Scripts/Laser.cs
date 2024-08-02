using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LayerMask jumpableLayers;
    LineRenderer lineRenderer;
    float laserTime = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        RaycastHit2D hitInfo = Physics2D.Raycast(
            gameObject.transform.position, 
            gameObject.transform.right,
            Mathf.Infinity,
            jumpableLayers
        );

        if(hitInfo){
            EnemyController enemy = hitInfo.transform.GetComponent<EnemyController>();
            if(enemy)
                enemy.TakeDamage(1f);
            
            lineRenderer.SetPosition(0, gameObject.transform.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        laserTime -= Time.deltaTime;
        if(laserTime <=0)
            Destroy(gameObject);        
    }
}
