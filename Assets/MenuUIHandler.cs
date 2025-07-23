using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public string playerName;
    public TMP_InputField playerNameInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        NameUpdate();
    }

    // Update is called once per frame

    public void NameUpdate()
    {
        if (!string.IsNullOrEmpty(GameManager.Instance.PlayerName))
        {
            playerName = GameManager.Instance.PlayerName;
            playerNameInput.text = playerName;
            Debug.Log("PlayerName in ClearName(): " + playerName);
        }
    }
    public void ClearName()
    {
        if (string.IsNullOrEmpty(playerNameInput.text))
        {
            playerName = null;
            Debug.Log("PlayerName in ClearName(): " + playerName);
        }
    }
     public void NewName()
    {
        playerName = playerNameInput.text;  
        Debug.Log("PlayerName in newName(): " + playerName);
        GameManager.Instance.PlayerName = playerName;
    }

    public void StartGame()
    {
        if (string.IsNullOrEmpty(playerName) && string.IsNullOrEmpty(GameManager.Instance.PlayerName))
        {
            playerName = "UN" + Random.Range(10000, 99999);
            GameManager.Instance.PlayerName = playerName;
            Debug.Log($"{playerName}");
        }

        SceneManager.LoadScene(1);
        Debug.Log("Loading scene");
    }
}
