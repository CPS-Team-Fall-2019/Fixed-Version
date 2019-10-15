﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the water flow between modules
/// </summary>
public class WaterFlowController : MonoBehaviour
{
    public Reservoir Reservoir;

    [SerializeField]
    private Module firstModule;
    [SerializeField]
    private Module endModule;


    private int index=0;
    private void Start()
    {
        /* 
        Module currMod = Reservoir;
        while (currMod.PreviousModule)
        {
            currMod = currMod.PreviousModule;
        }
        this.firstModule = currMod;
       
        this.firstModule.Water = new WaterObject(); */
    }

    /// <summary>
    /// Makes time move (tick) forward for the modules.  Ticking time forward allows for the water to flow through
    /// the system.
    /// </summary>
    
    public void ClearWater()
    {

    }
    public void SimulateWater()
    {
        //asumes no diverging paths for now
        Module currMod = firstModule;

        this.firstModule.Water = new WaterObject();
        firstModule.NextModule[0].WaterFlow(); //takes first one


    }
    //not used for now
    public void TickModules()
    {
        index++;
        Debug.Log("Tick Module: " + index);
        this.Reservoir.Tick(); //this also calls the onflow method //this sucks in 

        this.firstModule.Water = new WaterObject();
        //StartWaterFlow(5f);
    }

    /// <summary>
    /// Starts ticking time forward for the modules in regular intervals
    /// </summary>
    /// <param name="secondsBetweenTicks">The amount of time in between ticks</param>
    public void StartWaterFlow(float secondsBetweenTicks)
    {

        Debug.Log("Invoke Repeating Tick Modules with " + secondsBetweenTicks + " seconds between ticks");
        this.InvokeRepeating("TickModules", 0.1f, secondsBetweenTicks);
    }
}