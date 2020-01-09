using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float targetHealth = 50f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float amount)
    {
        targetHealth -= amount;
        if(targetHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
