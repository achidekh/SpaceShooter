using Unity.VisualScripting;
using UnityEngine;

public class LaserMOVE : MonoBehaviour
{
    [SerializeField] float speed = 10;
    float lasertime = 0;
    void Start()
    {
        lasertime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
   
        Vector3 direction = gameObject.transform.forward;
        GetComponent<Rigidbody>().linearVelocity = direction * speed;

        if ((Time.time-lasertime)>5)
        {
            Destroy(gameObject);
        }
    }
}
