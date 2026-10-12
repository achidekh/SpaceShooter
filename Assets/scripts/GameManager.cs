using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance!=this)
        {             
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    public PlayerState playerState = PlayerState.Play;
    [SerializeField] GameObject UIgameover;
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] GameObject UIpause;
    [SerializeField] GameObject scoretext;
    int score = 0;

    public enum PlayerState
    {
        Play,
        Pause,
        GameOver
    }
    public void mort()
    {
        playerState = PlayerState.GameOver;
        UIgameover.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        inputmanager.instance.gameObject.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        if (playerState == PlayerState.Pause)
        {
            Resume();
        }
        else
        {
            playerState = PlayerState.Pause;
            UIpause.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            inputmanager.instance.gameObject.SetActive(false);
        }
    }

    public void Resume()
    {
        playerState = PlayerState.Play;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        UIpause.SetActive(false);
        inputmanager.instance.gameObject.SetActive(true);
    }

    public void Startgame()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void AddScore(int nb)
    {
        score += nb;
        scoretext.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();

    }


}