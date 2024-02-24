using UnityEngine.AI;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{

    //public float speed = 5f;
    private Vector3 target;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 1 for the right click, 0 - for the left  
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}
