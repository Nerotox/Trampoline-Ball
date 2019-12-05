using UnityEngine;
using UnityEngine.UI;

namespace Level
{
    public class LevelHandler : MonoBehaviour
    {
        public GameObject ball;
        public Button pauseButton;
        public Button playButton;
        public Button resetButton;

        private float _lastAngularVelocity = 0;
        private Vector2 _lastVelocity = Vector2.zero;

        // Start is called before the first frame update
        void Start()
        {
            ball.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        // Update is called once per frame
        void Update()
        {
        }


    
        public void SelectResetButton()
        {
            Debug.Log("Clicked Reset Button.");
            ball.transform.position = new Vector3(-10,4,0);
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
    }
}