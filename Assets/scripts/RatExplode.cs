using UnityEngine;
using System.Collections;

public class RatExplode : MonoBehaviour
{
    bool explode = false;
    public float torquePower;
    public float forcePower;
    public ParticleSystem bloodEffect;
    public GameObject[] parts;
    
    public void Explode()
    {
        explode = true;
    }
    
    void Update()
    {
        if (explode) {
            rigidbody2D.isKinematic = true;
            foreach (Transform child in transform) {
                child.parent = null;
                child.collider2D.isTrigger = false;
                child.rigidbody2D.isKinematic = false;
                child.rigidbody2D.AddTorque(Random.Range(-torquePower, torquePower));
                child.rigidbody2D.AddForce(new Vector2(Random.Range(-.5f, .5f), 1.0f) * forcePower);
            }
            Destroy(gameObject);
                
            ParticleSystem part = GameObject.Instantiate(bloodEffect, transform.position, Quaternion.identity) as ParticleSystem;
            part.Play();
            
            ThrowPart();
            ThrowPart();
            ThrowPart();
            ThrowPart();
            ThrowPart();
        }
    }
    
    void ThrowPart()
    {
        GameObject part = (GameObject)Instantiate(parts[Random.Range(0, 11)], transform.position, Quaternion.identity);
        part.rigidbody2D.AddTorque(Random.Range(-torquePower, torquePower));
        part.rigidbody2D.AddForce(new Vector2(Random.Range(-.5f, .5f), 1.0f) * forcePower);
    }
}
