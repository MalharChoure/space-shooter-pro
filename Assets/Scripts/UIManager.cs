using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text _game_over;
    [SerializeField]
    private float _blink_timer;
    private float _blink=0;
    private bool _player_dead = false;
    [SerializeField]
    private Text _restart_text;

    public int look_up_able_score;

    private GameManager _gamemanger;

    private int _player_lives;
    // Start is called before the first frame update
    void Start()
    {
        _score.text = "Score: " + 0;
        _game_over.enabled=false;
        _gamemanger = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _restart_text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameoversequence();

    }

    void gameoversequence()
    {
        if (_player_dead == true)
        {
            _gamemanger.GameOver();
            if (Time.time > _blink)
            {

                _blink = Time.time + _blink_timer;
                if (_game_over.enabled == true)
                {
                    _game_over.enabled = false;
                }
                else
                {
                    _game_over.enabled = true;
                }
            }
        }
    }

    public void addPlayerScore(int playerScore)
    {
        _score.text= "Score: " + playerScore;
                look_up_able_score=playerScore;
    }
    public void playercurrentLife(int playerlives)
    {
        _player_lives = playerlives;
        _livesImage.sprite = _liveSprites[_player_lives];
        if(_player_lives==0)
        {
            _player_dead = true;
        }
    }
    public void game_end()
    {
        _game_over.enabled = true;
        _restart_text.enabled = true;
    }
}
