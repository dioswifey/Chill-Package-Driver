using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;


    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if  ( the thing we trigger is the package)
        //then print "package picked up" to the console.

        //tags

        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package is picked up.");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);

        }

        if (other.tag == "Customer"  && hasPackage)
        {
            Debug.Log("Package Delivered.");
            //once we DELIVER the package, we don't have package anymore
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }

    }
}

     

