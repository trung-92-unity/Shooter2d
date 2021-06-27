using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 10f;//
    [SerializeField] float padding = 0.5f;//
    [SerializeField] int health = 100;
    [SerializeField] GameObject laserPrefab;//
    [SerializeField] float projectileSpeed = 10f;//
    [SerializeField] float projectileFiringPeriod = 0.1f;//

    Coroutine firingCorountine;//

    /// <summary>
    /// 
    /// </summary>
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        setUpMoveBoundaries();
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D lasers)
    {
        DamageDealer damageDealer = lasers.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        
    }
    /// <summary>
    /// 
    /// </summary>
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCorountine = StartCoroutine(FireContinously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCorountine);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject laser = Instantiate(
                    laserPrefab,
                    transform.position,
                    Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXpos, newYpos);
    }

    /// <summary>
    /// 
    /// </summary>
    private void setUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
