using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SkillManager : MonoBehaviour
{
    private bool cooldownActive = false;
    private bool slowMotionActive = false;

    public float slowdownScale = 0.5f;
    public int timeSlowCooldown = 20;
    public int timeSkillDuration = 3;

    // serialized for debugging
    [SerializeField] private float currentSlowTime;
    [SerializeField] private float cooldownTimer;

    // for setting cooldown timer.
    private TextMeshProUGUI cooldownGUI;

    private void Start()
    {
        GameObject cooldownTextObj = GameObject.Find("CooldownText");

        cooldownGUI = cooldownTextObj.GetComponent<TextMeshProUGUI>();

        // need to call this to fix bug involving skills lasting between runs
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.002f;
    }

    private void Update()
    {
        trackTime();
        activateTimeSkill();
        setCooldownGUI();
    }

    void activateTimeSkill()
    {
        if (Input.GetKeyDown(KeyCode.E) && !cooldownActive)
        {
            startTimeSkill();
        }
    }

    void startTimeSkill()
    {
        // this slows down time
        Time.timeScale = slowdownScale;
        // physics to match the new time scale
        Time.fixedDeltaTime = Time.timeScale * 0.002f;

        slowMotionActive = true;

        // set the slow motion timer to 0, ready to track when to stop
        currentSlowTime = 0;
    }

    void trackTime()
    {
        if (slowMotionActive)
        {
            // must be unscaled delta time, because the timeScale effect will hinder the float values too,
            // this keeps it independant of the effect from timescale

            // this also fixes the jitter from being in slow motion, because the time tracking is choppy
            // from being slowed down
            currentSlowTime += Time.unscaledDeltaTime;

            // times up, and we leave the skill state
            if (currentSlowTime >= timeSkillDuration)
            {
                // set values back to normal (i like 0.002 for my timestep, its smoother i think?)
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.002f;

                slowMotionActive = false;
                cooldownActive = true;

                // set the cooldown timer to 0, so we're ready to begin the count
                cooldownTimer = 0;
            }
        }

        if (cooldownActive)
        {
            cooldownTimer += Time.unscaledDeltaTime;

            // if cooldown timer exceeds the cooldown we set
            if (cooldownTimer >= timeSlowCooldown)
            {
                // we can use our skill again
                cooldownActive = false;
            }
        }
    }

    void setCooldownGUI()
    {
        if (cooldownActive)
        {
         
            float cooldownCounter = timeSlowCooldown - cooldownTimer;
            // convert it to a int https://docs.unity3d.com/ScriptReference/Mathf.FloorToInt.html
            int cooldownDisplay = Mathf.FloorToInt(cooldownCounter);

            // and display it
            cooldownGUI.text = "   " + cooldownDisplay.ToString(); 
        }
        else
        {
            // display ready when cooldown bool is true again
            cooldownGUI.text = "Ready";
        }
    }
}
