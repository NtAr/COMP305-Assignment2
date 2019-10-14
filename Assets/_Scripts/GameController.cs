using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Util
{
    [System.Serializable]
    public class GameController : MonoBehaviour
    {
        [Header("Score board")]
        [SerializeField]
        private int _score;
        public Text scoreLabel;

        [SerializeField]
        private int _lives;
        public Text livesLabel;


        //score get-setter 
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                scoreLabel.text = "Score: " + _score.ToString();
            }
        }

        //lives get-setter 
        public int Lives
        {
            get { return _lives; }
            set
            {
                _lives = value;
                //if (_lives <= 0)
                //{
                //    SceneManager.LoadScene("end");
                //}
                livesLabel.text = "Lives: " + _lives.ToString();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            Lives = 5;
            Score = 0;

        }
        // Update is called once per frame
        void Update()
        {
            ////chechk if the "+100" object is on the scene
            //if (GameObject.FindGameObjectWithTag("fly") != null)
            //{
            //    //start adding points
            //    Score += 1;
            //}
        }
    }
}