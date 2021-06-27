using System;

public class Car
{
	String model;
	float mpg;
	int cyl;
	float disp;
	int hp;
	float drat;
	float wt;
	float qsec;
	bool vs;
	bool am;
	int gear;
	int carb;
	public Car(String model, float mpg, int cyl, float disp, int hp, float drat, float wt, float qsec, bool vs, bool am, int gear, int carb)
	{
		this.model =  model;
		this.mpg = mpg;
		this.cyl = cyl;
		this.disp = disp;
		this.hp = hp;
		this.drat = drat;
		this.wt = wt;
		this.qsec = qsec;
		this.vs = vs;
		this.am = am;
		this.gear = gear;
		this.carb = carb;
	}

    public string Model { get => model; set => model = value; }
    public float Mpg { get => mpg; set => mpg = value; }
    public int Cyl { get => cyl; set => cyl = value; }
    public float Disp { get => disp; set => disp = value; }
    public int Hp { get => hp; set => hp = value; }
    public float Drat { get => drat; set => drat = value; }
    public float Wt { get => wt; set => wt = value; }
    public float Qsec { get => qsec; set => qsec = value; }
    public bool Vs { get => vs; set => vs = value; }
    public bool Am { get => am; set => am = value; }
    public int Gear { get => gear; set => gear = value; }
    public int Carb { get => carb; set => carb = value; }
}
