using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

/*
    public class SpaceFireScript : MonoBehaviour
{
    public GameObject dartPrefab;
    public Transform barrelLocation;
    public float shotPower = 1000f;

    public InputActionReference triggerActionReference; // Reference to the input action

    private void OnEnable()
    {
        // Enable the action and subscribe to the "performed" event
        triggerActionReference.action.Enable();
        triggerActionReference.action.performed += OnTriggerPressed;
    }

    private void OnDisable()
    {
        // Disable the action and unsubscribe from the "performed" event
        triggerActionReference.action.Disable();
        triggerActionReference.action.performed -= OnTriggerPressed;
    }

    private void OnTriggerPressed(InputAction.CallbackContext context)
    {

        Debug.Log("Trigger pressed with value: " + context.ReadValue<float>());
        if (context.ReadValue<float>() > 0.1f) // Trigger is pressed
        {

           
            Launch();
        }
    }

    void Launch()
    {
        // Instantiate a new dart at the location of the launcher
        var dart = Instantiate(dartPrefab, barrelLocation.position, barrelLocation.rotation);
        // Add dart force to the rigidbody component
        dart.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        // Optionally adjust the dart's orientation or spin
        dart.transform.Rotate(new Vector3(0, 90, 90));
        // Destroy the dart after 3 seconds

        Destroy(dart, 3f);
    }
}
*/


public class DartLauncher : MonoBehaviour
{

   
  //version 1
    public GameObject dartPrefab;
    public Transform barrelLocation;
    public float shotPower = 1000f;
   
    // Update is called once per frame
    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed");  // Confirming that the key press is detected
            Launch();
        }
    }

    void Launch()
    {
        var dart = Instantiate(dartPrefab, barrelLocation.position, barrelLocation.transform.rotation);
        //add force
        dart.GetComponent<Rigidbody>().AddForce(barrelLocation.up * Time.deltaTime * shotPower);

        //spin dart toward object
        dart.transform.eulerAngles += new Vector3(0, -90, 90);
        // cool down period
     
        // destroy dart
        Destroy(dart, 3f);
       
    } 
    
   /* version 2
    public GameObject dartPrefab;
    public Transform barrelLocation;
    public float shotPower = 1000f;
    public float cooldown = 0.5f; // Cooldown in seconds before another dart can be fired

    private bool isCooldown = false; // Tracks whether the launcher is on cooldown

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isCooldown)
        {
            StartCoroutine(LaunchDart());
        }
    }

    IEnumerator LaunchDart()
    {
        isCooldown = true; // Set cooldown to true to prevent multiple launches

        // Instantiate a new dart at the location of the launcher
        GameObject dart = Instantiate(dartPrefab, barrelLocation.position, barrelLocation.transform.rotation);
        Rigidbody dartRb = dart.GetComponent<Rigidbody>();
        if (dartRb != null)
        {
       
            dartRb.AddForce(barrelLocation.forward * Time.deltaTime * shotPower); // Apply force to the dart
            dartRb.transform.eulerAngles += new Vector3(-90,-90, 0);
        }
        else
        {
            Debug.LogError("No Rigidbody attached to dartPrefab!");
        }

        yield return new WaitForSeconds(cooldown); // Wait for the cooldown period to end

        isCooldown = false; // Reset cooldown state
        // Destroy the dart after 3 seconds
        Destroy(dartRb, 1.5f);
        Destroy(dart, 1.5f);
    }
  */


}
