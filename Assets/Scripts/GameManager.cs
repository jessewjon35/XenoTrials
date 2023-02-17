using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState State { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeState(GameState newstate)
    {
        State = newstate;
        switch (newstate)
        {
            case GameState.Starting:
                HandleStarting();
                break;

            
        }
    }

    private void HandleStarting()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum GameState
    {
        Starting = 0,

    }
}
