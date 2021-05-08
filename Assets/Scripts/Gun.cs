using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Gun : MonoBehaviour {
    public ParticleSystem muzzleFlash;
    public AudioSource bang;

    [SerializeField]
    private GameObject decal;
    public int maxDecals = 5;
    private Queue<UnityEngine.GameObject> decalPool = new Queue<UnityEngine.GameObject>();


    public Animator shootAnim;
    public int RPM;
    public bool auto = false;

    float timer = 0f;
    bool down;
    bool shooting;

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonUp(0)) {
            down = false;
        }

        // Izvrsi ako RPM timeout nije zavrsen
        if (shooting) {
            timer += Time.deltaTime;
            float delay = 60f / RPM;

            if (timer < delay) {
                return;
            }
            shooting = false;
            if (shootAnim) {
                shootAnim.SetBool("Shooting", false);
            }
        }

        // Pucaj ako je RPM zavrsija i ako ne drzimo botun cilo vrime
        // osim ako je automatsko oruzje
        if (Input.GetMouseButton(0) && (!down || auto)) {
            Shoot();
            down = true;
            shooting = true;
            if (shootAnim) {
                shootAnim.SetBool("Shooting", true);
            }
        }
    }

    void Shoot() {
        Vector2 screenMid = new Vector2(Screen.width / 2, Screen.height / 2);
        var ray = Camera.main.ScreenPointToRay(screenMid);
        RaycastHit hitPoint;

        LayerMask lm = ~Convert.ToInt32("110111110", 2);

        if (Physics.Raycast(ray, out hitPoint, Mathf.Infinity, lm)) {
            SpawnDecal(hitPoint);
        }
        //Debug.Log(hitPoint.point);
        //Debug.DrawLine(transform.position, hitPoint.point, Color.red);

        muzzleFlash.Play();
        if (bang) {
            bang.PlayOneShot(bang.clip, 1f);
        }

        timer = 0f;
    }

    private void SpawnDecal(RaycastHit hitInfo) {
        if (decalPool.Count >= maxDecals) {
            // Unisti bullet posto je limit prijeden
            UnityEngine.Object.Destroy(decalPool.Dequeue(), 0f);
        }

        var decalInst = Instantiate(decal);
        decalInst.transform.position = hitInfo.point;
        decalInst.transform.forward = hitInfo.normal * -1f;
        decalPool.Enqueue(decalInst);
    }
}
