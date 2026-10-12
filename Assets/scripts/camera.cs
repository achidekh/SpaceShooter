using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Update()
    {
        if (player != null)
        {
            Vector3 playerpo = player.transform.position;
            Vector3 newPosition = playerpo+new Vector3(0, 1, -4);
            transform.position = newPosition;
        }
    }
}
