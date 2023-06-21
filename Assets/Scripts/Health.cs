using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 100;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;

    ScoreKeeper scoreKeeper;

    LevelManager LevelManager;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        LevelManager = FindObjectOfType<LevelManager>();
    }

    public int GetHealth()
    {
        return health;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            //Take damage
            TakeDamage(damageDealer.GetDamage());
            PlayHitEeffect();
            ShakeCamera();
            damageDealer.Hit();
        }


    }


    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isPlayer == false)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            LevelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEeffect() 
    { 
        if (hitEffect != null) 
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            audioPlayer.PlayDamageClip();
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }


    private void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    
}
