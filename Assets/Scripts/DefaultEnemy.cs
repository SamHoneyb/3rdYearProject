using UnityEngine;

public class DefaultEnemy : MonoBehaviour
{
    private Transform Server;
    public float Speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Server = GameObject.FindGameObjectWithTag("Server").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Server.transform.position, Speed * Time.deltaTime);
    }
}
