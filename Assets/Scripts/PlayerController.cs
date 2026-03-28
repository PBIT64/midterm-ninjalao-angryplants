using GLTFast.Schema;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject CamPosObject;
    [SerializeField] GameObject Slingshot;
    [SerializeField] GameObject SampleBullet;
    [SerializeField] float HoverSpeed = 1;
    bool ShootCD = false;
    
    void Reload()
    {
        SampleBullet.SetActive(true);
        ShootCD = false;
    }

    void Shoot()
    {
        if (ShootCD) { return; }
        SampleBullet.SetActive(false);
        ShootCD = true;

        // New Bullet
        GameObject bullet = Instantiate(SampleBullet);
        bullet.SetActive(true);
        // Extra Components
        SphereCollider sphereCollider = bullet.AddComponent<SphereCollider>();
        Rigidbody bulletRb = bullet.AddComponent<Rigidbody>();
        bulletRb.mass = 0.1f;
        bullet.transform.position = CamPosObject.transform.position;
        bullet.transform.rotation = CamPosObject.transform.rotation;
        bulletRb.AddRelativeForce(new Vector3(0,0,-100));
        Invoke("Reload", 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Rotate LeftRight
        if (Keyboard.current.aKey.isPressed)
        {
            Slingshot.transform.Rotate(new Vector3(0, -HoverSpeed, 0));
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            Slingshot.transform.Rotate(new Vector3(0,HoverSpeed,0));
        }
        // Look UpDown
        if (Keyboard.current.wKey.isPressed)
        {
            CamPosObject.transform.Rotate(new Vector3(-HoverSpeed, 0, 0));
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            CamPosObject.transform.Rotate(new Vector3(HoverSpeed,0, 0));
        }

        if (!ShootCD && Keyboard.current.spaceKey.isPressed)
        {
            Shoot();
        }
    }
}
