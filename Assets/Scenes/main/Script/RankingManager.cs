using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static RankingManager;

public class RankingManager : MonoBehaviour
{
    // [System.Serializable]：シリアライズ(Jsonデータに変換？)可能
    [System.Serializable]
    public class Result
    {
        public string UserName = "";
        public float Score = 0;
        public float ClearTime = 0;
        public DateTime Date = DateTime.Now;
    }

    [System.Serializable]
    public class Ranking
    {
        public List<Result> Results = new List<Result>();
        public void Add(Result result)
        {
            Results.Add(result);

            // スコア順にソートする
            // 参考：https://programmers.high-way.info/cs/list-sort.html
            Results.Sort((a, b) => (int)(a.Score - b.Score));

            // 上位10名のみ保存する
            while (10 < Results.Count)
                Results.RemoveAt(Results.Count - 1);
        }
    }

    private string _directoryPath;
    private string _dataPath;
    private void Awake()
    {
        // ファイルのパスを計算
        _directoryPath = Path.Combine(Application.persistentDataPath, "Data");
        _dataPath = Path.Combine(Application.persistentDataPath, "Data/Score.json");
    }

    // Start is called before the first frame update
    void Start()
    {
        // 初回起動時などjsonが存在しなければ、空のデータで作っておく
        if (!File.Exists(_dataPath))
        {
            if (!File.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
            File.WriteAllText(_dataPath, JsonUtility.ToJson(new Ranking()));
        }
        Debug.Log(File.ReadAllText(_dataPath));
        Ranking ranking = JsonUtility.FromJson<Ranking>(File.ReadAllText(_dataPath));
        Debug.Log(ranking.Results[0].Date);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveScore(String UserName, float Score, float ClearTime)
    {
        // ----- スコア保存 -----
        Result result = new Result();
        result.UserName = UserName;
        result.Score = Score;
        result.ClearTime = ClearTime;
        result.Date = DateTime.Now;

        // ランキングに反映
        Ranking ranking = JsonUtility.FromJson<Ranking>(File.ReadAllText(_dataPath));
        ranking.Add(result);


        // ----- 書き込み -----
        Debug.Log(JsonUtility.ToJson(ranking));
        File.WriteAllText(_dataPath, JsonUtility.ToJson(ranking));


        // ----- debug -----
        foreach (var res in ranking.Results)
        {
            Debug.Log(res.Score);
        }
    }
}
