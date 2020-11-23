using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointShotty : MonoBehaviour
{
    public GameObject shot;
    public GameObject boi;
    public GameObject p;
    public bool paused;
    void Update()
    {
        paused = p.GetComponent<Pause>().paused;
        if (!paused)
        {
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
            positionOnScreen = new Vector2(positionOnScreen.x * -1, positionOnScreen.y * -1);

            //Get the Screen position of the mouse


            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            mouseOnScreen = new Vector2(mouseOnScreen.x * -1, mouseOnScreen.y * -1);

            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            //Ta Daaa
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));


            if (Input.GetMouseButtonDown(0) && boi.GetComponent<PlayerMovement>().click == false)
            {

                StartCoroutine(LateCall(0.2f));
            }
        }

        float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }

    }

    IEnumerator LateCall(float sec)
    {
        shot.SetActive(true);
        yield return new WaitForSeconds(sec);

        shot.SetActive(false);
        //Do Function here...
        StopAllCoroutines();
    }
}
