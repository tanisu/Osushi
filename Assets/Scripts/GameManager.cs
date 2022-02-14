using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager i;
    public static GameManager I { get => i; }
    [SerializeField] UIController ui;
    [SerializeField] GameObject eatMan;
    SpriteRenderer sp;
    EatmanController eat;
    public enum GAMESTATE
    {
        PLAY,
        GAMEOVER,
        GAMECLEAR
    }
    public GAMESTATE gamestate;


    int score = 0;
    float t = 0f;
    float startTime = 0f;
    
    


    private void Awake()
    {
        i = GetComponent<GameManager>();
        sp = eatMan.GetComponent<SpriteRenderer>();
        eat = eatMan.GetComponent<EatmanController>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if(gamestate == GAMESTATE.GAMEOVER && Input.GetKeyDown(KeyCode.Space))
        {
            Reload();
        }

        startTime += Time.deltaTime;
        Debug.Log(startTime);
        if (startTime > 30.0f && t < 1.1f)
        {
            t = (startTime - 30.0f) / 10;
            
            sp.color = new Color(1, 1, 1, t);
        }
        if(t > 1.1f)
        {
            eat.EatStart();
        }
        
    }



    public void EatCount()
    {
        score++;
        ui.UpdateScoreBorad(score);
    }

    public void GameOver()
    {
        gamestate = GAMESTATE.GAMEOVER;
        ui.ShowGameOverPanel();
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }

    public void Reload()
    {
        SceneManager.LoadScene("Main");
    }


}
