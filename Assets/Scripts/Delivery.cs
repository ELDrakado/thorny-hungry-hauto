using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package"))
        {
            Debug.Log("Package picked!");
            hasPackage = true;
        }  
        
        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Package delivered!");
            hasPackage = false;
        }
    }
}
