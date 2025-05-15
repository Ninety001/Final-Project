using System.Collections.Generic;
using UnityEngine;

public class PlayHistoryManager : MonoBehaviour
{
    public static PlayHistoryManager Instance;

    private const string HistoryKey = "PlayHistory";

    [System.Serializable]
    public class PlayRecord
    {
        public float distance;
        public int coins;
    }

    private List<PlayRecord> history = new List<PlayRecord>();


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadHistory();
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void AddRecord(float distance, int coins)
    {
        history.Add(new PlayRecord { distance = distance, coins = coins });
        PlayHistoryManager.Instance.AddRecord(distance, coins); 
        SaveHistory();
    }

    public List<PlayRecord> GetHistory()
    {
        return history;
    }

    void SaveHistory()
    {
        string json = JsonUtility.ToJson(new Wrapper { list = history });
        PlayerPrefs.SetString(HistoryKey, json);
        PlayerPrefs.Save();
    }

    void LoadHistory()
    {
        if (PlayerPrefs.HasKey(HistoryKey))
        {
            string json = PlayerPrefs.GetString(HistoryKey);
            Wrapper wrapper = JsonUtility.FromJson<Wrapper>(json);
            history = wrapper.list ?? new List<PlayRecord>();
        }
    }


    [System.Serializable]
    private class Wrapper
    {
        public List<PlayRecord> list;
    }

}
