using UnityEngine;


public class BalloonScript : MonoBehaviour
{

    //points
    public int points = 10; // Points to add when this object is hit

    // materials
    private Material m_Materials;
    // create array for wayPoints
   
    public GameObject[] wayPoints;

    private int nextWayPointIndex = 0;
    // create health variable
  
    public int health = 1;
    // create speed variable
 
    public float speed = 1;

    // on start find waypoint tag

    private void Start()
    {
        //on start get the material of balloon
        m_Materials = GetComponent<Renderer>().material;
        wayPoints = GameObject.FindGameObjectsWithTag("Waypoints");
    }
    // Update is called once per frame
    void Update()
    {
        MoveBalloon();

        if (health == 3)
        {
            m_Materials.color = Color.red;
        }
        else if (health == 2)
        {
            m_Materials.color = Color.blue;
        }
        else if (health == 1)
        {
            m_Materials.color = Color.green;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart"))
        {
            //health value check before destroy
            health--;
             if(health <= 0)
         
            {
                // Use the static instance to add score
                ScoreManager.Instance.AddScore(points);
                Destroy(gameObject); // Destroys the target object
                Destroy(this.gameObject);
            }
           
        }
    }
    private void MoveBalloon()
    {

        var lastWayPointIndex = wayPoints.Length - 1;
        Vector3 lastWayPoint = wayPoints[lastWayPointIndex].transform.position + new Vector3(0,2, 0);
        Vector3 nextWayPoint = wayPoints[nextWayPointIndex].transform.position + new Vector3(0, 2, 0);
        Vector3 direction = nextWayPoint - transform.position;


        // If enemy is more than 0.1 meters from the last waypoint

        if (Vector3.Distance(transform.position, lastWayPoint) > 0.1f)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }

        // increase index so if enemy reaches one waypoint

        if (Vector3.Distance(transform.position, nextWayPoint) < 0.05f && nextWayPointIndex < lastWayPointIndex)
        {
            nextWayPointIndex++;
        }
        // if Balloon reaches finish
        if (nextWayPointIndex == lastWayPointIndex && Vector3.Distance(transform.position, lastWayPoint) < 0.3f) 
        {
            Destroy(this.gameObject);
        }
      
    }
}



