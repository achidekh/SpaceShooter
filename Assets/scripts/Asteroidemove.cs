using UnityEngine;

public class Asteroidemove : MonoBehaviour
{
    [SerializeField] float speed = 5;
    float astetime = 0;
    void Start()
    {
        astetime = Time.time;
        speed = Random.Range(speed-1, speed+1);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.value, Random.value, Random.value)*5;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, 0, -1);
        GetComponent<Rigidbody>().linearVelocity = direction * speed;

        if ((Time.time - astetime) > 30)
        {
            Destroy(gameObject);

        }
    }
}
