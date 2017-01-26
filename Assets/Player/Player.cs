﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    public int currentHealthPoints; // TODO remove
    [SerializeField] int initialHealthPoints = 100;
    [SerializeField] int maxHealthPoints = 100;
    [SerializeField] Material ghostMaterial;
<<<<<<< Updated upstream
    [SerializeField] AudioClip deathSound;
=======
    [SerializeField] AudioClip[] deathSounds;
    [SerializeField] AudioClip[] startSounds;
>>>>>>> Stashed changes

    bool isAlive = true;
    SkinnedMeshRenderer playerSkin;
       

    // Use this for initialization
    void Start () {
        currentHealthPoints = initialHealthPoints;
        playerSkin = GetComponentInChildren<SkinnedMeshRenderer>();
        AudioSource.PlayClipAtPoint(startSounds[Random.Range(0, startSounds.Length)], transform.position);
    }

    public float healthAsPercentage {
        get
        {
            return currentHealthPoints / (float)maxHealthPoints;
        }
    }

    public void DealDamage(int damagePoints)
    {
        var newHealthPoints = currentHealthPoints - damagePoints;
        currentHealthPoints = Mathf.Clamp(newHealthPoints, 0, maxHealthPoints);
    }

    void Update()
    {
        if (!isAlive) { return; }

        if (currentHealthPoints == 0)
        {
            isAlive = false;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            playerSkin.material = ghostMaterial;
            gameObject.SetActive(false);
        }
    }
}
