using UnityEngine;

namespace Level
{
    public class FinishCollisionHandler : MonoBehaviour
    {
        //public CircleCollider2D playerBallCollider;
        public GameObject playerBall;

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
            }
        }
    }
}
