using System;

namespace FTN.Common
{
	//enum Decs dodavanje enumeracije
	public enum PhaseCode : short
	{
		A,
		AB,
		ABC,
		ABCN,
		ABN,
		AC,
		ACN,
		AN,
		B,
		BC,
		BCN,
		BN,
		C,
		CN,
		N,
		s1,
		s12,
		s12N,
		s1N,
		s2,
		s2N
	}

	public enum UnitMultiplier : short
	{
		G,
		M,
		T,
		c,
		d,
		k,
		m,
		micro,
		n,
		none,
		p
	}

	public enum UnitSymbol : short
	{
		A,
		F,
		H,
		Hz,
		J,
		N,
		Pa,
		S,
		V,
		VA,
		VAh,
		VAr,
		VArh,
		W,
		Wh,
		deg,
		degC,
		g,
		h,
		m,
		m2,
		m3,
		min,
		none,
		ohm,
		rad,
		s
	}

	public enum RegulatingControlModeKind : short
	{
		activePower,
		admittance,
		currentFlow,
		fixedd,
		powerFactor,
		reactivePower,
		temperature,
		timeScheduled,
		voltage
	}

}
