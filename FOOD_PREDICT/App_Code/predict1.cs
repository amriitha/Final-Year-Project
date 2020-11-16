using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for predict1
/// </summary>
public class predict1
{

    public List<cnn_disease2> Dendrites { get; set; }

    public cnn_disease1 OutputPulse { get; set; }

    private double Weight;

	public predict1()
	{
		//
		// TODO: Add constructor logic here
		//
        Dendrites = new List<cnn_disease2>();
        OutputPulse = new cnn_disease1();
        
    }

    public void Fire()
    {
        //OutputPulse.Value = Sum();

        OutputPulse.Value = Activation(OutputPulse.Value);
    }



    private double Activation(double input)
    {
        double threshold = 1;
        return input >= threshold ? 0 : threshold;
    }



}