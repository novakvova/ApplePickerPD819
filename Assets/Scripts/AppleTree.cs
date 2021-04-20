using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Шаблон для створення яблук
    public GameObject applePrefab;
    //Швидкість переміщення яблуні
    public float speed = 1f;
    //Межу руху яблуні
    public float leftAndRightEdge = 10f;

    //Імовірність зміні напряку руху яблуні
    public float changeToChangeDirections = 0.1f;

    //Частота скидання яблук
    public float secondsBetweenAppleDrops = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple",2f);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    private void FixedUpdate()
    {
        if(Random.value < changeToChangeDirections)
        {
            speed *= -1;
        }
        
    }
}
