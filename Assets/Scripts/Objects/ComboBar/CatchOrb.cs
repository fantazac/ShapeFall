using UnityEngine;
using System.Collections;

public class CatchOrb : MonoBehaviour
{
    public delegate void OnOrbCaughtHandler();
    public event OnOrbCaughtHandler OnOrbCaught;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Orb")
        {
            OnOrbCaught();
            Destroy(collider.gameObject);
        }
    }
}
