using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class AsynchronousMachine : RotatingMachine
    {
		private float rr1;
		private float rr2;
		private float tpo;
		private float tppo;
		private float xlr1;
		private float xlr2;
		private float xm;
		private float xp;
		private float xpp;
		private float xs;

		public float Rr1 { get => rr1; set => rr1 = value; }
		public float Rr2 { get => rr2; set => rr2 = value; }
		public float Tpo { get => tpo; set => tpo = value; }
		public float Tppo { get => tppo; set => tppo = value; }
		public float Xlr1 { get => xlr1; set => xlr1 = value; }
		public float Xlr2 { get => xlr2; set => xlr2 = value; }
		public float Xm { get => xm; set => xm = value; }
		public float Xp { get => xp; set => xp = value; }
		public float Xpp { get => xpp; set => xpp = value; }
		public float Xs { get => xs; set => xs = value; }

		public AsynchronousMachine(long globalId) : base(globalId)
		{
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				AsynchronousMachine x = (AsynchronousMachine)obj;
				return ((x.rr1 == this.rr1) &&
						(x.rr2 == this.rr2) &&
						(x.tpo == this.tpo) &&
						(x.tppo == this.tppo) &&
						(x.xlr1 == this.xlr1) &&
						(x.xlr2 == this.xlr2) &&
						(x.xm == this.xm) &&
						(x.xp == this.xp) &&
						(x.xpp == this.xpp) &&
						(x.xs == this.xs));
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
				case ModelCode.ASYNCMACHINE_RR1:
				case ModelCode.ASYNCMACHINE_RR2:
				case ModelCode.ASYNCMACHINE_TPO:
				case ModelCode.ASYNCMACHINE_TPPO:
				case ModelCode.ASYNCMACHINE_XLR1:
				case ModelCode.ASYNCMACHINE_XLR2:
				case ModelCode.ASYNCMACHINE_XM:
				case ModelCode.ASYNCMACHINE_XP:
				case ModelCode.ASYNCMACHINE_XPP:
				case ModelCode.ASYNCMACHINE_XS:

					return true;
				default:
					return base.HasProperty(property);
			}
		}

		public override void GetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.ASYNCMACHINE_RR1:
					property.SetValue(rr1);
					break;

				case ModelCode.ASYNCMACHINE_RR2:
					property.SetValue(rr2);
					break;
				case ModelCode.ASYNCMACHINE_TPO:
					property.SetValue(tpo);
					break;

				case ModelCode.ASYNCMACHINE_TPPO:
					property.SetValue(tppo);
					break;
				case ModelCode.ASYNCMACHINE_XLR1:
					property.SetValue(xlr1);
					break;

				case ModelCode.ASYNCMACHINE_XLR2:
					property.SetValue(xlr2);
					break;
				case ModelCode.ASYNCMACHINE_XM:
					property.SetValue(xm);
					break;
				case ModelCode.ASYNCMACHINE_XP:
					property.SetValue(xp);
					break;
				case ModelCode.ASYNCMACHINE_XPP:
					property.SetValue(xpp);
					break;
				case ModelCode.ASYNCMACHINE_XS:
					property.SetValue(xs);
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
				case ModelCode.ASYNCMACHINE_RR1:
					rr1 = property.AsFloat();
					break;

				case ModelCode.ASYNCMACHINE_RR2:
					rr2 = property.AsFloat();
					break;
				case ModelCode.ASYNCMACHINE_TPO:
					tpo = property.AsFloat();
					break;

				case ModelCode.ASYNCMACHINE_TPPO:
					tppo = property.AsFloat();
					break;
				case ModelCode.ASYNCMACHINE_XLR1:
					xlr1 = property.AsFloat();
					break;

				case ModelCode.ASYNCMACHINE_XLR2:
					xlr2 = property.AsFloat();
					break;
				case ModelCode.ASYNCMACHINE_XM:
					xm = property.AsFloat();
					break;
				case ModelCode.ASYNCMACHINE_XP:
					xp = property.AsFloat();
					break;
				case ModelCode.ASYNCMACHINE_XPP:
					xpp = property.AsFloat();
					break;
				case ModelCode.ASYNCMACHINE_XS:
					xs = property.AsFloat();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation
	}
}
