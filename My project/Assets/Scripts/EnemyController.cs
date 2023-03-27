using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    public float speed;
    public float range;
    public float maxDistance;
    private Rigidbody2D rb;
    public Weapon weapon;
    public float fireRate = 0.1f;
    private float nextFireTime;

    Vector2 wayPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }

        if(nextFireTime < Time.time)
        {
            weapon.Fire();
            fireRate = Random.Range(1f, 2f);
            nextFireTime = Time.time + fireRate;
        }
    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FriendlyBullet")
        {

            Destroy(gameObject);
        }
    }
}
