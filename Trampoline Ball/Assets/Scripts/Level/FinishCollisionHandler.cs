using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class FinishCollisionHandler : MonoBehaviour
    {
        //public CircleCollider2D playerBallCollider;
        public GameObject playerBall;
        public GameObject finishPanel;
        public string levelSelectionSceneName;
        public string nextLevelSceneName;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other == playerBall.GetComponent<CircleCollider2D>()) {
                Debug.Log("hit the finish line!");
                playerBall.GetComponent<Rigidbody2D>().isKinematic = true;
                playerBall.GetComponent<Rigidbody2D>().angularVelocity = 0;
                playerBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                finishPanel.SetActive(true);
            }
        }

        public void SelectBackToLevelSelectionButton()
        {
            SceneManager.LoadScene(levelSelectionSceneName);
        }

        public void SelectNextLevelButton()
        {
            Debug.Log("next level");
            SceneManager.LoadScene(nextLevelSceneName);
        }
    }
}
