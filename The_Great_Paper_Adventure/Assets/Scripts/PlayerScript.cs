using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);

    private Vector2 movement;

    private Rigidbody2D _rigidbody2D;

    

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
                SoundsEffectsHelper.Instance.MakePlayerShotSound();
            }
        }

        movement = new Vector2(speed.x * inputX, speed.y * InputY);

        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), 
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder), transform.position.z);
    }

    private void FixedUpdate() {
        _rigidbody2D.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        bool damagePlayer = false;
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null) {
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(enemyHealth.hp);
            }
            damagePlayer = true;
        }

        if (damagePlayer) {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null) {
                playerHealth.Damage(1);
            }
        }
    }

    void OnDestroy() {
        transform.parent.gameObject.AddComponent<GameOverScript>();
    }
}
