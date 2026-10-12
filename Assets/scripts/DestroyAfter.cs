using Unity.VisualScripting;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float delay = 0;
  
    float Dtime = 0;
    void Start()
    {
        Dtime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - Dtime) > delay)
        {
            Destroy(gameObject);
        }
    }
}
