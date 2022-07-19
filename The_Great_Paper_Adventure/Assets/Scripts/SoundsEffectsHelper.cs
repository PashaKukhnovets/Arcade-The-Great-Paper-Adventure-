using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffectsHelper : MonoBehaviour
{
    public static SoundsEffectsHelper Instance;

    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;

    void Awake() {
        if (Instance != null) {
            Debug.LogError("Несколько экземпляров SoundsEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeExplosionSound() {
        MakeSound(explosionSound);
    }

    public void MakePlayerShotSound() {
        MakeSound(playerShotSound);
    }

    public void MakeEnemyShotSound() {
        MakeSound(enemyShotSound);
    }

    private void MakeSound(AudioClip originalClip) {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
