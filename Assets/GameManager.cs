using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName;
    public int score;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadPlayerData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }
    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.playerName = PlayerName;
        data.bestScore = score;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(UnityEngine.Application.persistentDataPath + ("/datafile.json"), json);
    }
    public void LoadPlayerData()
    {
        string path = UnityEngine.Application.persistentDataPath + ("/datafile.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            PlayerName = data.playerName;
            score = data.bestScore;
        }
    }
}
