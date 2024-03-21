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
    // [System.Serializable]�F�V���A���C�Y(Json�f�[�^�ɕϊ��H)�\
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

            // �X�R�A���Ƀ\�[�g����
            // �Q�l�Fhttps://programmers.high-way.info/cs/list-sort.html
            Results.Sort((a, b) => (int)(a.Score - b.Score));

            // ���10���̂ݕۑ�����
            while (10 < Results.Count)
                Results.RemoveAt(Results.Count - 1);
        }
    }

    private string _directoryPath;
    private string _dataPath;
    private void Awake()
    {
        // �t�@�C���̃p�X���v�Z
        _directoryPath = Path.Combine(Application.persistentDataPath, "Data");
        _dataPath = Path.Combine(Application.persistentDataPath, "Data/Score.json");
    }

    // Start is called before the first frame update
    void Start()
    {
        // ����N�����Ȃ�json�����݂��Ȃ���΁A��̃f�[�^�ō���Ă���
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
        // ----- �X�R�A�ۑ� -----
        Result result = new Result();
        result.UserName = UserName;
        result.Score = Score;
        result.ClearTime = ClearTime;
        result.Date = DateTime.Now;

        // �����L���O�ɔ��f
        Ranking ranking = JsonUtility.FromJson<Ranking>(File.ReadAllText(_dataPath));
        ranking.Add(result);


        // ----- �������� -----
        Debug.Log(JsonUtility.ToJson(ranking));
        File.WriteAllText(_dataPath, JsonUtility.ToJson(ranking));


        // ----- debug -----
        foreach (var res in ranking.Results)
        {
            Debug.Log(res.Score);
        }
    }
}
