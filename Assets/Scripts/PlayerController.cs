using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject CamPosObject;
    [SerializeField] GameObject Slingshot;
    [SerializeField] GameObject SampleBullet;
    [SerializeField] float HoverSpeed = 1;
    bool ShootCD = false;
    
    void Shoot()
    {
        if (ShootCD) { return; }
        SampleBullet.SetActive(false);
        ShootCD = true;
    }

    // Update is called once per frame
    void Update()
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

        if (!ShootCD)
        {
            Shoot();
        }
    }
}
