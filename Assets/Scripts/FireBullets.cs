using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{

    [SerializeField]
    private float shotTimer = 0.2f;
    private float timePassed;

    private bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= shotTimer)
        {
            canShoot = true;
            timePassed = 0;
        }

        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot = false;
            fire();
        }
    }

    void fire()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 bulletDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized;

        GameObject bul = ShootingPool01.ShootingPool01Instance.GetBullet();
        bul.transform.position = transform.position;
        bul.SetActive(true);
        bul.GetComponent<Bullet>().SetMoveDirection(bulletDirection);
    }
}
