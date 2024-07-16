﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using FTN.Common;



namespace FTN.Services.NetworkModelService.DataModel.Core
{
	public class PowerSystemResource : IdentifiedObject
	{		
		public PowerSystemResource(long globalId)
			: base(globalId)
		{
		}	

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				PowerSystemResource x = (PowerSystemResource)obj;
                return true;
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
			return base.HasProperty(property);
			
		}

		public override void GetProperty(Property property)
		{			
			base.GetProperty(property);						
		}

		public override void SetProperty(Property property)
		{
			base.SetProperty(property);								
		}

		#endregion IAccess implementation

		#region IReference implementation
		
		public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
		{
			base.GetReferences(references, refType);			
		}

		#endregion IReference implementation		
	}
}