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
        }
    
        public void SelectPlayButton()
        {
            playButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            ball.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            Debug.Log("Clicked Play.");
        }
    
        public void SelectPauseButton()
        {
            playButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            ball.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            Debug.Log("Clicked Pause.");
        }
    }
}