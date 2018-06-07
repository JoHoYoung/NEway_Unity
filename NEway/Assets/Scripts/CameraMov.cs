using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraMov : MonoBehaviour
{
    public PlayerController player;
    public Rigidbody2D rb2d;

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(player.velocity_Scale,0);
    }
}
