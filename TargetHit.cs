using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public int points = 10; // Points to add when this object is hit

    void OnCollisionEnter(Collision collision)
    {
        // Check for collision with a specific object or tag
        if (collision.gameObject.tag == "Dart") // Make sure your projectile has the tag "Dart"
        {
            // Use the static instance to add score
            ScoreManager.Instance.AddScore(points);
            Destroy(gameObject); // Destroys the target object
        }
    }
}
