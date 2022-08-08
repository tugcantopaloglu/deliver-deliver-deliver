using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage;
    [SerializeField] GameObject packageObject;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,255);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1,255);
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Customer" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        if (collision.tag == "Location" && hasPackage)
        {
            Debug.Log("Package delivered!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}