﻿using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.IES_Projects
{
    public class Equipment : PowerSystemResource
    {
		private bool aggregated;
		private bool normallyInService;

		public Equipment(long globalId) : base(globalId)
		{
		}

		public bool Aggregated
		{
			get
			{
				return aggregated;
			}

			set
			{
				aggregated = value;
			}
		}
		public bool NormallyInService
		{
			get
			{
				return normallyInService;
			}

			set
			{
				normallyInService = value;
			}
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				Equipment x = (Equipment)obj;
				return ((x.aggregated == this.aggregated) &&
						(x.normallyInService == this.normallyInService));
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
				case ModelCode.EQUIPMENT_AGGREGATED:
				case ModelCode.EQUIPMENT_NORMALLYINSERVICE:

					return true;
				default:
					return base.HasProperty(property);
			}
		}

		public override void GetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.EQUIPMENT_AGGREGATED:
					property.SetValue(aggregated);
					break;

				case ModelCode.EQUIPMENT_NORMALLYINSERVICE:
					property.SetValue(normallyInService);
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
				case ModelCode.EQUIPMENT_AGGREGATED:
					aggregated = property.AsBool();
					break;

				case ModelCode.EQUIPMENT_NORMALLYINSERVICE:
					normallyInService = property.AsBool();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation
	}
}