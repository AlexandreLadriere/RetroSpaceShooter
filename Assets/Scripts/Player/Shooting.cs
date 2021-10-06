using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    private InputAction leftMouseClick;
    public Transform firePoint;
    public GameObject laserBeamPrefab;
    private void Awake() {
        leftMouseClick = new InputAction(binding: "<Mouse>/leftButton");
        leftMouseClick.performed += context => shootButtonPressed(context);
        leftMouseClick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootButtonPressed(InputAction.CallbackContext context) {
        // Perform action only once (and not when phase started and performed)
        if(context.performed) {
            Shoot();
        }
    }

    public void Shoot() {
        GameObject laserBeam = Instantiate(laserBeamPrefab, firePoint.position, firePoint.rotation);
    }
}
