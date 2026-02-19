using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ContactGetter : MonoBehaviour
{
    int HP = 3;
    [SerializeField]
    GameObject brokenSelf;
    GameObject current;
    [SerializeField]
    MeshRenderer[] parts;

    [SerializeField]
    AudioSource sourceBreak;

    [SerializeField]
    float ParticleSize = 0.25f;
    [SerializeField]
    BoxCollider myCollider;

    [SerializeField]
    GameObject playerSword;

    [SerializeField]
    AttackScript playerAtk;

    private void Start()
    {
        playerSword = GameObject.FindGameObjectWithTag("PlayerSword");

        playerAtk = GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<AttackScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        HP--;

        if (playerAtk != null)
        {
            playerAtk.pitchSet(  1 + (Mathf.Abs(HP - 3) * .10f));
        }

        if (HP <= 0)
        {
            current = Instantiate(brokenSelf, transform.position, Quaternion.identity);
            myCollider.enabled = false;
            foreach (MeshRenderer part in parts)
            {
                part.enabled = false;
                sourceBreak.pitch = Random.Range(0.15f, 0.3f);
                sourceBreak.Play();
            }
            playerAtk.stutterFrame(1.5f);
            Invoke("Refresh", 10f);
        }
        else
        {
            playerAtk.stutterFrame(1f);
        }
    }

    void Refresh()
    {
        myCollider.enabled = true;
        Destroy(current); 
        foreach (MeshRenderer part in parts)
        {
            part.enabled = true;

        }
        HP = 3;
    }
}
