using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class crosshairmove : MonoBehaviour
{
    float speed = 0.75f;
    GameObject canvas;
    void Start()
    {
        canvas = GameObject.Find("Hud");
    }
    void Update()
    {
        float xaxis = Input.GetAxis("Mouse X");
        float zaxis = Input.GetAxis("Mouse Y");
 
        if ((gameObject.transform.position + new Vector3(xaxis, zaxis, 0) * Time.deltaTime * speed - canvas.transform.position).magnitude<0.15f)
        {
            gameObject.transform.position += new Vector3(xaxis, zaxis, 0) * Time.deltaTime * speed;
        }
    }
}
