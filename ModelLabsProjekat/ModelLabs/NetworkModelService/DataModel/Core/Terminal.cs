using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class Terminal : IdentifiedObject
    {
        private bool connected;
        private int sequenceNumber;
        private PhaseCode phases;
        private List<long> regulatingControl = new List<long>();

        public Terminal(long globalId) : base(globalId)
        {
        }

        public bool Connected
        {
            get { return connected; }
            set { connected = value; }
        }

        public int SequenceNumber
        {
            get { return sequenceNumber; }
            set { sequenceNumber = value; }
        }

        public PhaseCode Phases
        {
            get { return phases; }
            set { phases = value; }
        }

        public List<long> RegulatingControl
        {
            get { return regulatingControl; }
            set { regulatingControl = value; }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Terminal x = (Terminal)obj;
                return ((x.connected == this.connected) &&
                        (x.sequenceNumber == this.sequenceNumber) &&
                        (x.phases == this.phases) &&
                        (CompareHelper.CompareLists(x.regulatingControl, this.regulatingControl)));
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
                case ModelCode.TERMINAL_CONN:
                case ModelCode.TERMINAL_SEQNUM:
                case ModelCode.TERMINAL_PHASES:
                case ModelCode.TERMINAL_REGULATINGCONTROL:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.TERMINAL_CONN:
                    prop.SetValue(connected);
                    return;
                case ModelCode.TERMINAL_SEQNUM:
                    prop.SetValue(sequenceNumber);
                    return;
                case ModelCode.TERMINAL_PHASES:
                    prop.SetValue((short)phases);
                    return;
                case ModelCode.TERMINAL_REGULATINGCONTROL:
                    prop.SetValue(regulatingControl);
                    return;
            }
            base.GetProperty(prop);
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TERMINAL_CONN:
                    connected = property.AsBool();
                    break;
                case ModelCode.TERMINAL_SEQNUM:
                    sequenceNumber = property.AsInt();
                    break;
                case ModelCode.TERMINAL_PHASES:
                    phases = (PhaseCode)property.AsEnum();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation	

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return regulatingControl.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (regulatingControl != null && regulatingControl.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_REGULATINGCONTROL] = regulatingControl.GetRange(0, regulatingControl.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.REGULATINGCONTROL_TERMINAL:
                    regulatingControl.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.REGULATINGCONTROL_TERMINAL:

                    if (regulatingControl.Contains(globalId))
                    {
                        regulatingControl.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }

        #endregion IReference implementation
    }
}
