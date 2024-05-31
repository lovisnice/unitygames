using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject applePrefab; //€блука, €ке буде падать ≥з дерева

    public float speed = 1f; //швидк≥сть перем≥щенн€ €блун≥

    public float leftAndRightEdge = 10f; //меж≥ за €к≥ не може заходить €блун€

    public float chanceToChangeDirections = 0.1f; //≥мов≥рн≥сть зм≥ни напр€мку

    public float secondsBetweenAppleDrops = 1f;//частота скиданн€ €блук

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DropApple), 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        //€блуко маЇ по€витис€ на м≥сц≥ €кому Ї €блун€
        apple.transform.position = transform.position;
        //знову викликаЇмо дл€ нового €блука - 1 секунда
        Invoke(nameof(DropApple), secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);
    }
    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
            speed *= -1;
    }
}
