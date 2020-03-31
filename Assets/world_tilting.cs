using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class world_tilting : MonoBehaviour 
{
    
    public float tiltFactor = 0.1f;
    public float speed = 0.1f;

    private Rigidbody rb;

    public Text text;

    
    public float smooth = 0.4f;
   

    private Gyroscope my_Gyro;

    private float startX;
    private float startY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        my_Gyro = Input.gyro;
        my_Gyro.enabled = false;
        my_Gyro.enabled = true;
        startX = my_Gyro.attitude.x;
        startY = my_Gyro.attitude.y;

    }

    // Update is called once per frame
    void Update()
    {
        
        
        float currentX = my_Gyro.attitude.x;
        float currentY = my_Gyro.attitude.y;

        if (currentX != startX || currentY != startY)
        {
            Vector3 result = new Vector3((currentX - startX) ,0 , (currentY - startY));
        
            Quaternion deltaRotation = Quaternion.Euler(result*tiltFactor);
            rb.MoveRotation(deltaRotation);
        
            // Quaternion c = my_Gyro.attitude * Quaternion.Inverse(initialgyro);
            text.text = result + "";

            // rb.MoveRotation(c); 
        }
        
       
    }
    
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
                Vector3 m_EulerAngleVelocity = new Vector3(rb.rotation.x, rb.rotation.y,
                    rb.rotation.z + tiltFactor);
            
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            


        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            
                Vector3 m_EulerAngleVelocity = new Vector3(rb.rotation.x, rb.rotation.y,
                    rb.rotation.z - tiltFactor);
            
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            


        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
                Vector3 m_EulerAngleVelocity = new Vector3(rb.rotation.x +tiltFactor, rb.rotation.y,
                    rb.rotation.z);
            
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            


        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
              Vector3 m_EulerAngleVelocity = new Vector3(rb.rotation.x - tiltFactor, rb.rotation.y,
                    rb.rotation.z);
            
                Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            


        }
    }

    public void resetTilt()
    {
      //  Quaternion deltaRotation = new Quaternion(Quaternion.identity.x-transform.rotation.x,Quaternion.identity.y-transform.rotation.y,Quaternion.identity.z-transform.rotation.z,Quaternion.identity.w-transform.rotation.w);
      //  rb.MoveRotation(rb.rotation * deltaRotation);

    }
    
    
}
