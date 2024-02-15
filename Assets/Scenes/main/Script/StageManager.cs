using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    private const string BLOCK_TAG = "Block";

    public const float STAGE_LIMIT_TOP = 14.5f;
    public const float STAGE_LIMIT_BOTTOM = -14.5f;
    public const float STAGE_LIMIT_LEFT = -9.5f;
    public const float STAGE_LIMIT_RIGHT = 9.5f;
    public float Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag(BLOCK_TAG);
        if (balls.Length == 0)
            GameObject.Find("Canvas").transform.Find("TextScore").GetComponent<Text>().text = "‚­‚è‚ ";
        else
        {
            GameObject.Find("Canvas").transform.Find("TextScore").GetComponent<Text>().text = ((int)Score).ToString();
            Debug.Log("‚Ì‚±‚è" + balls.Length);
        }
    }
}
