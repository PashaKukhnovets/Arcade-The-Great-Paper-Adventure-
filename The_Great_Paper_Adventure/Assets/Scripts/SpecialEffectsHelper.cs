using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectsHelper : MonoBehaviour
{
    public static SpecialEffectsHelper Instance;

    public ParticleSystem Smoke;
    public ParticleSystem Fire;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("��������� ����������� SpecialEffectsHelper!");
        }

        Instance = this;
    }

    public void Explosion(Vector3 position) {
        instantiate(Smoke, position);
        instantiate(Fire, position);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position) {
        ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;
        Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);
        return newParticleSystem;
    }
}
