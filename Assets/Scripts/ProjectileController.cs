using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float projectileSpeed = 30f;
    public float projectileDamage = 4f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(gameObject.transform.position.x) > 50)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyController enemy = hitInfo.GetComponent<EnemyController>();

        if (enemy)
            enemy.TakeDamage(projectileDamage);

        if(hitInfo.name != "Player"){
            Destroy(gameObject);
        }
    }
}
