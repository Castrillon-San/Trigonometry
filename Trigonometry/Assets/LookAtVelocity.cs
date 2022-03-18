using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtVelocity : MonoBehaviour
{
    Vector3 velocity, displacement; 
    [SerializeField] float constante;
    void Update()
    {
        //transform.position = GetWorldMousePosition();
        Vector3 mousePos = GetWorldMousePosition();
        Vector3 diference = mousePos - transform.position;
        if(diference.magnitude > 0f)
    
        velocity = diference.normalized;
        displacement = velocity * Time.deltaTime;
        transform.position += displacement * constante;
        
    }

    private Vector3 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        Debug.DrawLine(Vector3.zero, transform.position);
        return worldPos;
    }
}
