using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float Length;
    public float RoofLength;
    public float multiplier;
    public LayerMask enviromentLayer;
    public LayerMask RoofLayer;
    public int speed;
    public int Camspeed;
    private Transform wallTarget;
    private Transform roofTarget;
    private float t = 1.0f;
    private float materialAlpha;

	void Update(){
        float x = Input.GetAxis("Horizontal") * speed;
        float xCam = Input.GetAxis("HorizontalCamera") * Camspeed;
        float z = Input.GetAxis("Vertical") * speed;

        Vector3 m_EulerAngleVelocity = new Vector3(0, xCam, 0);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        this.GetComponent<Rigidbody>().MoveRotation(this.GetComponent<Rigidbody>().rotation * deltaRotation);
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * z);
        this.GetComponent<Rigidbody>().AddForce(this.transform.right * x);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward * -1), out hit, Length, enviromentLayer))
        {
            hit.transform.GetComponent<Renderer>().material.color = new Color (hit.transform.GetComponent<Renderer>().material.color.r,hit.transform.GetComponent<Renderer>().material.color.g,hit.transform.GetComponent<Renderer>().material.color.b, hit.distance * multiplier);
            wallTarget = hit.transform;
        } else {
            if(wallTarget != null){
                wallTarget.GetComponent<Renderer>().material.color = new Color (wallTarget.GetComponent<Renderer>().material.color.r,wallTarget.GetComponent<Renderer>().material.color.g,wallTarget.GetComponent<Renderer>().material.color.b, 1f);
                wallTarget = null;
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, RoofLength, RoofLayer))
        {
            hit.transform.GetComponent<Renderer>().material.color = new Color (hit.transform.GetComponent<Renderer>().material.color.r,hit.transform.GetComponent<Renderer>().material.color.g,hit.transform.GetComponent<Renderer>().material.color.b, t);
            if(t > 0.1f){
                t -= 0.1f;
            }
            roofTarget = hit.transform;
        } else {
            if(roofTarget != null){
                if(t < 1.0f){
                    t += 0.1f;
                }
                materialAlpha = roofTarget.GetComponent<Renderer>().material.color.a;
                roofTarget.GetComponent<Renderer>().material.color = new Color (roofTarget.GetComponent<Renderer>().material.color.r,roofTarget.GetComponent<Renderer>().material.color.g,roofTarget.GetComponent<Renderer>().material.color.b, t);
                if(roofTarget.GetComponent<Renderer>().material.color.a >= 0.9999f){
                    t = 1.0f;
                    roofTarget.GetComponent<Renderer>().material.color = new Color (roofTarget.GetComponent<Renderer>().material.color.r,roofTarget.GetComponent<Renderer>().material.color.g,roofTarget.GetComponent<Renderer>().material.color.b, 1.0f);
                    roofTarget = null;
                }
            }
        }
    }
}
