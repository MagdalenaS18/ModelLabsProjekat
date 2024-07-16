using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using FTN.Services.NetworkModelService.DataModel.IES_Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class RegulatingCondEq : ConductingEquipment
    {
        private long regulationControl;

        public RegulatingCondEq(long globalId) : base(globalId)
        {
        }
        public long RegulationControl
        {
            get { return regulationControl; }
            set { regulationControl = value; }
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                RegulatingCondEq x = (RegulatingCondEq)obj;
                return (x.regulationControl == this.regulationControl);
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

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.REGULATINGCONDEQP_REGCONTROL:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.REGULATINGCONDEQP_REGCONTROL:
                    property.SetValue(regulationControl);
                    return;

            }
            base.GetProperty(property);
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.REGULATINGCONDEQP_REGCONTROL:
                    regulationControl = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation	

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (regulationControl != 0 && (refType != TypeOfReference.Reference || refType != TypeOfReference.Both))
            {
                references[ModelCode.REGULATINGCONDEQP_REGCONTROL] = new List<long>();
                references[ModelCode.REGULATINGCONDEQP_REGCONTROL].Add(regulationControl);
            }

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation
    }
}
