﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DoorBoss : InteractableObject
{
    private Animator anim;
    private bool open = false;
    private bool interacted = false;

    public GameObject Key, NonKey;
    public bool checkIn = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        PlayerDataManager.Load();
    }

    public override bool onIneteractedByPlayer()
    {
        if(base.isInteracted && PlayerDataManager.player.key == true && open == false)
        {
            Key.SetActive(base.isInteracted);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Key.SetActive(false);
                open = true;
                anim.SetBool("Openn", base.isInteracted);
                return interacted = true;
            }
        }
        else if (base.isInteracted && PlayerDataManager.player.key == false && open == false)
        {
            NonKey.SetActive(base.isInteracted);
            return interacted = false;
        }
        else if (!base.isInteracted && checkIn == true)
        {
            NonKey.SetActive(false);
            anim.SetBool("Openn", false);
            return interacted = false;
        }
        else if (!base.isInteracted)
        {
            NonKey.SetActive(false);
            Key.SetActive(false);
            return interacted = false;
        }
        return interacted;
    }
}