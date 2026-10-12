using UnityEngine;

public class Heightsystem : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject grid;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            float YHeight = Player.transform.position.y*0.018f;
            gameObject.transform.position = new Vector3(grid.transform.position.x+0.01f, grid.transform.position.y+YHeight, grid.transform.position.z);
        }
    }
}
