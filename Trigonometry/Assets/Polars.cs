using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polars : MonoBehaviour
{
    [Header("Polar")]
    [SerializeField] Vector2 coordenadas;

    [Header("Angular")]
    [SerializeField] float angularSpeed;
    [SerializeField] float angularAcceleration;
    [Header("Radial")]
    [SerializeField] float radialSpeed;
    [SerializeField] float radialAcceleration;

    float camera;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
    }
    void Update()
    {
        //coordenadas.x += 0.001f;
        //coordenadas.y += 0.01f;
        //this.gameObject.transform.position += PolarToCartesian(coordenadas) * Time.deltaTime;
        //DrawPolar(coordenadas);

        PolarVelocity();
        this.gameObject.transform.position = PolarToCartesian(coordenadas);
        if (this.gameObject.transform.position.x >= camera || this.gameObject.transform.position.x <= -camera 
            || this.gameObject.transform.position.y >= camera || this.gameObject.transform.position.y <= -camera)
        {
            radialSpeed *= -1;
        }
        
    }

    public void PolarVelocity()
    {
        //Radio
        radialSpeed += radialAcceleration * Time.deltaTime;
        coordenadas.x += radialSpeed * Time.deltaTime;
        
        //Theta
        angularSpeed += angularAcceleration * Time.deltaTime;
        coordenadas.y += angularSpeed * Time.deltaTime;
    }
    public void DrawPolar(Vector2 polarCoord)
    {
        Vector3 drawing = PolarToCartesian(polarCoord);
        Debug.DrawLine(Vector3.zero, drawing, Color.white);
    }

    public Vector3 PolarToCartesian(Vector2 polar)
    {
        Vector3 cartesian = new Vector3(Mathf.Cos(polar.y), Mathf.Sin(polar.y));
        cartesian *= polar.x;
        return cartesian;
    }
}
