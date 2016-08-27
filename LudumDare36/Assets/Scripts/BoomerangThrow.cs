using UnityEngine;
using System.Collections;

public class BoomerangThrow : MonoBehaviour {

    Rigidbody boomerangRB;

    void Start()
    {
        boomerangRB = GetComponent<Rigidbody>();
    }
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //StartCoroutine(ThrowBmrg(18.0F, 1.0F, Camera.main.transform.forward, 2.0F));
            StartCoroutine(ThrowBmrg(18.0F, 1.0F, -Camera.main.transform.forward, 2.0F));
        }
	}

    IEnumerator ThrowBmrg(float dist, float width, Vector3 direction, float time)
    {
        Vector3 pos = transform.position;
        float height = transform.position.y;
        Quaternion q = Quaternion.FromToRotation(Vector3.forward, direction);
        float timer = 0.0F;
        //boomerangRB.AddTorque(0F,400.0F,0F);
        boomerangRB.AddTorque(0, 200F, 0F);
        while (timer < time)
        {
            float t = Mathf.PI * 2.0F * timer / time - Mathf.PI / 2.0F;
            float x = width * Mathf.Cos(t);
            float z = dist * Mathf.Sin(t);
            //Vector3 v = new Vector3(x, height, z + dist);
            Vector3 v = new Vector3(x, height, z);
            boomerangRB.MovePosition(pos + (q * v));

            timer += Time.deltaTime;
            yield return null;
        }

        boomerangRB.angularVelocity = Vector3.zero;
        boomerangRB.velocity = Vector3.zero;
        boomerangRB.rotation = Quaternion.identity;
        boomerangRB.MovePosition(pos);
    }
}
