using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private Animator gateAnimator;

    private bool hasKey;

    void Start()
    {
        hasKey = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            particleSystem.transform.position = other.transform.position;
            particleSystem.Play();
            hasKey = true;
        }
        else if (other.gameObject.CompareTag("Gate")) {
            Debug.Log(hasKey);
            gateAnimator = other.GetComponent<Animator>();
            if (hasKey)
            {
                gateAnimator.Play("GateOpen", 0, 0);
            }
            
        }
        Debug.Log("Collided");
    }
}
