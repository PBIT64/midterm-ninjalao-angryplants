using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int BulletRemain = 10;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject CamPosObject;
    [SerializeField] GameObject Slingshot;
    [SerializeField] GameObject SampleBullet;
    [SerializeField] GameObject CurretCamera;
    [SerializeField] float HoverSpeed = 1;
    [SerializeField] float BulletSpeed = 150;
    bool ShootCD = false;

    void UpdateBulletText()
    {
        text.text = $"Fruit Remains: {BulletRemain}";
    }

    private void Start()
    {
        UpdateBulletText();
    }

    void Reload()
    {
        SampleBullet.SetActive(true);
        ShootCD = false;
    }

    void Shoot()
    {
        if (ShootCD || BulletRemain <= 0) { return; }
        SampleBullet.SetActive(false);
        ShootCD = true;
        BulletRemain--;
        UpdateBulletText();

        // New Bullet
        GameObject bullet = Instantiate(SampleBullet);
        bullet.SetActive(true);
        // Extra Components
        SphereCollider sphereCollider = bullet.AddComponent<SphereCollider>();
        Rigidbody bulletRb = bullet.AddComponent<Rigidbody>();
        bulletRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        bulletRb.mass = 0.1f;
        bullet.transform.localScale = SampleBullet.transform.localScale;
        bullet.transform.position = CamPosObject.transform.position + CamPosObject.transform.forward;
        bullet.transform.rotation = CamPosObject.transform.rotation;
        bulletRb.AddForce(CamPosObject.transform.forward * BulletSpeed);
        if (BulletRemain > 0)
        {
            Invoke("Reload", 5f);
        }
        else
        {

        }
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
        float scrollwheelspeed = Mouse.current.scroll.ReadValue().y;
        if (scrollwheelspeed != 0)
        {
            UnityEngine.Camera Cam = CurretCamera.GetComponent<UnityEngine.Camera>();
            Cam.fieldOfView = Mathf.Clamp(Cam.fieldOfView - (scrollwheelspeed * 2), 10, 60);
        }
    }
}
