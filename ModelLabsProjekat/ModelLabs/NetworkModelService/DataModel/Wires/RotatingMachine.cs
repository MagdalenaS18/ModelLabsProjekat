using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class RotatingMachine : RegulatingCondEq
    {
		private float damping;
		private float saturationFactor;
		private float saturationFactor120;
		private float inertia;
		private float ratedS;
		private float statorLeakageReactance;
		private float statorResistance;

		public RotatingMachine(long globalId) : base(globalId)
		{
		}

		public float Damping { get => damping; set => damping = value; }
		public float SaturationFactor { get => saturationFactor; set => saturationFactor = value; }
		public float SaturationFactor120 { get => saturationFactor120; set => saturationFactor120 = value; }
		public float Inertia { get => inertia; set => inertia = value; }
		public float RatedS { get => ratedS; set => ratedS = value; }
		public float StatorLeakageReactance { get => statorLeakageReactance; set => statorLeakageReactance = value; }
		public float StatorResistance { get => statorResistance; set => statorResistance = value; }

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				RotatingMachine x = (RotatingMachine)obj;
				return ((x.damping == this.damping) &&
						(x.saturationFactor == this.saturationFactor) &&
						(x.saturationFactor120 == this.saturationFactor120) &&
						(x.inertia == this.inertia) &&
						(x.ratedS == this.ratedS) &&
						(x.StatorLeakageReactance == this.statorLeakageReactance) &&
						(x.statorResistance == this.statorResistance));
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#region IAccess implementation

		public override bool HasProperty(ModelCode property)
		{
			switch (property)
			{
				case ModelCode.ROTATINGMACHINE_DAMPING:
				case ModelCode.ROTATINGMACHINE_SATFACTOR:
				case ModelCode.ROTATINGMACHINE_SATFACTOR120:
				case ModelCode.ROTATINGMACHINE_INERTIA:
				case ModelCode.ROTATINGMACHINE_RATEDS:
				case ModelCode.ROTATINGMACHINE_STATLEAKREAC:
				case ModelCode.ROTATINGMACHINE_STATRESIS:

					return true;
				default:
					return base.HasProperty(property);
			}
		}

		public override void GetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.ROTATINGMACHINE_DAMPING:
					property.SetValue(damping);
					break;

				case ModelCode.ROTATINGMACHINE_SATFACTOR:
					property.SetValue(saturationFactor);
					break;
				case ModelCode.ROTATINGMACHINE_SATFACTOR120:
					property.SetValue(saturationFactor120);
					break;

				case ModelCode.ROTATINGMACHINE_INERTIA:
					property.SetValue(inertia);
					break;
				case ModelCode.ROTATINGMACHINE_RATEDS:
					property.SetValue(ratedS);
					break;

				case ModelCode.ROTATINGMACHINE_STATLEAKREAC:
					property.SetValue(statorLeakageReactance);
					break;
				case ModelCode.ROTATINGMACHINE_STATRESIS:
					property.SetValue(statorResistance);
					break;

				default:
					base.GetProperty(property);
					break;
			}
		}

		public override void SetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.ROTATINGMACHINE_DAMPING:
					damping = property.AsFloat();
					break;

				case ModelCode.ROTATINGMACHINE_SATFACTOR:
					saturationFactor = property.AsFloat();
					break;
				case ModelCode.ROTATINGMACHINE_SATFACTOR120:
					saturationFactor120 = property.AsFloat();
					break;

				case ModelCode.ROTATINGMACHINE_INERTIA:
					inertia = property.AsFloat();
					break;
				case ModelCode.ROTATINGMACHINE_RATEDS:
					ratedS = property.AsFloat();
					break;

				case ModelCode.ROTATINGMACHINE_STATLEAKREAC:
					statorLeakageReactance = property.AsFloat();
					break;
				case ModelCode.ROTATINGMACHINE_STATRESIS:
					statorResistance = property.AsFloat();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation
	}
}
