using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;

    [SerializeField] float destroyDelay = 0.25f;

    ParticleSystem packageEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        packageEffect = GetComponent<ParticleSystem>();
        
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package picked!");
            hasPackage = true;
            packageEffect.Play();
            Destroy(collision.gameObject, destroyDelay);
        }  
        
        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Package delivered!");
            hasPackage = false;
            Destroy(collision.gameObject, destroyDelay);
            packageEffect.Stop();
        }
    }
}
