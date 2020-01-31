using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Level
{
    public class LevelHandler : MonoBehaviour
    {
        public GameObject ball;
        public Button pauseButton;
        public Button playButton;
        public Button resetButton;
        public Button deleteButton;

        private float _lastAngularVelocity = 0;
        private Vector2 _lastVelocity = Vector2.zero;

        public bool deletionEnabled = false;

        private int lastRotation = 0;
        private int frames = 0;

        private Vector3 ballStartingCoords;

        // Start is called before the first frame update
        void Start()
        {
            ballStartingCoords = ball.transform.position;
            ball.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (deletionEnabled)
            {
                frames++;
                if (frames == 2)
                {
                    frames = 0;
                    UpdateShake();
                }
            }
        }

        private void UpdateShake()
        {
            deleteButton.transform.Rotate(0,0,-lastRotation);
            lastRotation = Random.Range(-3, 3);
            deleteButton.transform.Rotate(0,0,lastRotation);
        }


        public void SelectResetButton()
        {
            //reset to level default
            Debug.Log("Clicked Reset Button.");
            //ball.transform.position = new Vector3((float) -8.5,4,(float) -1.1);
            ball.transform.position = ballStartingCoords;
            ball.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            ball.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            SelectPauseButton();
        }
    
        public void SelectPlayButton()
        {
            playButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            ball.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            ball.gameObject.GetComponent<Rigidbody2D>().angularVelocity = _lastAngularVelocity;
            ball.gameObject.GetComponent<Rigidbody2D>().velocity = _lastVelocity;
            Debug.Log("Clicked Play.");
        }
    
        public void SelectPauseButton()
        {
            playButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            ball.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            _lastAngularVelocity = ball.gameObject.GetComponent<Rigidbody2D>().angularVelocity;
            _lastVelocity = ball.gameObject.GetComponent<Rigidbody2D>().velocity;
            ball.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            ball.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
            Debug.Log("Clicked Pause.");
        }

        public void SelectDeleteButton()
        {
            //Implement deletion of game objects while deletion mode is enabled.
            deletionEnabled = deletionEnabled == false;
            if (deletionEnabled == false)
            {
                deleteButton.transform.rotation = new Quaternion(0,0,0,0);
            }
        }
    }
}