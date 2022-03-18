using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMouse : MonoBehaviour
{
    Vector3 velocity, displacement;
    Vector3 accel;
    void Update()
    {
        //transform.position = GetWorldMousePosition();
        Vector3 mousePos = GetWorldMousePosition();
        Vector3 diference = mousePos - transform.position;
        float radians = Mathf.Atan2(velocity.y, velocity.x) + Mathf.PI / 2;
        transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);
        accel = diference;
        velocity += accel * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position += displacement;

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
