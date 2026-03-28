using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject CamPosObject;
    [SerializeField] GameObject Slingshot;
    [SerializeField] GameObject SampleBullet;
    [SerializeField] GameObject CurretCamera;
    [SerializeField] float HoverSpeed = 1;
    [SerializeField] float BulletSpeed = 100;
    Camera Cam;
    bool ShootCD = false;

    private void Start()
    {
        Camera Cam = GetComponent<Camera>();
    }

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
        bullet.transform.localScale = SampleBullet.transform.localScale;
        bullet.transform.position = CamPosObject.transform.position + CamPosObject.transform.forward;
        bullet.transform.rotation = CamPosObject.transform.rotation;
        bulletRb.AddForce(CamPosObject.transform.forward * BulletSpeed);
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
        if (Mouse.current.scroll.ReadValue().y != 0)
        {
            if (Mouse.current.scroll.ReadValue().y > 0)
            {
                Cam.fieldOfView = Mathf.Clamp(Cam.fieldOfView - 1, 10, 60);
            }
            else
            {
                Cam.fieldOfView = Mathf.Clamp(Cam.fieldOfView + 1, 10, 60);
            }
        }
    }
}
