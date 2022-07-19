using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private WeaponScript[] weapons;
    private bool hasSpawn;
    private MoveScript moveScript;
    private Collider2D _collider2D;

    void Start() {
        _collider2D = GetComponent<Collider2D>();
        hasSpawn = false;
        _collider2D.enabled = false;
        moveScript.enabled = false;
        foreach (WeaponScript weapon in weapons) {
            weapon.enabled = false;
        }
    }

    void Update()
    {
        if (hasSpawn == false)
        {
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            foreach (WeaponScript weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                    SoundsEffectsHelper.Instance.MakeEnemyShotSound();
                }
            }
            if (GetComponent<Transform>().position.x + 15 < Camera.main.transform.position.x) {
                Destroy(gameObject);
            }
        }
    }

    void Awake()
    {
        weapons = GetComponentsInChildren<WeaponScript>();
        moveScript = GetComponent<MoveScript>();
    }

    private void Spawn() {
        hasSpawn = true;
        _collider2D.enabled = true;
        moveScript.enabled = true;

        foreach (WeaponScript weapon in weapons) {
            weapon.enabled = true;
        }
    }
}
