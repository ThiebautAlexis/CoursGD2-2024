using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TestClass
{
    void Test()
    {
        Vehicule _vehicule = new Voiture();
        _vehicule.Rouler(); 
    }
}

public interface IMotor
{
    void StartEngine();
    void StopEngine();
}

public abstract class Vehicule
{
    public Vehicule()
    {
    }

    public Vehicule(int _nbreRoues)
    {

    }

    public abstract void Rouler();
}
[Serializable]
public class Voiture : Vehicule, IMotor
{
    public Voiture() : base(4)
    { 
    }

    public Voiture(int _nbreRouesVoiture) : base(_nbreRouesVoiture)
    {

    }

    void IMotor.StartEngine()
    {

    }
    public void StopEngine()
    {

    }

    public override void Rouler()
    {
        // fais des trucs
        Rouler(120f); 
    }
    protected void Rouler(float _vitesse)
    {

    }

    public void RoulerPlusVite() { }
}

public class Karting : Voiture
{

    public override void Rouler()
    {
        base.Rouler(); 
        // Ajouter un nouveau comportement
    }


    private void Start()
    {
        Rouler(); 
    }
}
