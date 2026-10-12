using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class inputmanager : MonoBehaviour
{
    public static inputmanager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField] GameObject playerController;
    [SerializeField] GameObject gamemanagerobj;

    void OnMove(InputValue value)
    {
        playerController.GetComponent<PlayrControllr>().OnMove(value);
    }

    void OnAttack(InputValue value)
    {
        playerController.GetComponent<PlayrControllr>().OnAttack(value);
    }

    void OnPause(InputValue value)
    {
        GameManager.instance.Pause();
    }
}
