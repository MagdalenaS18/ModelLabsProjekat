using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.IES_Projects
{
    public class RegularIntervalSchedule : BasicIntervalSchedule
    {
        private DateTime endTime;
        private float timeStep;

        public RegularIntervalSchedule(long globalId) : base(globalId)
        {
        }

        public DateTime EndTime
        {
            get => endTime;
            set => endTime = value;
        }

        public float TimeStep
        {
            get => timeStep;
            set => timeStep = value;
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                RegularIntervalSchedule x = (RegularIntervalSchedule)obj;
                return ((x.endTime == this.endTime) &&
                        (x.timeStep == this.timeStep));
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
                case ModelCode.REGULARINTERVALSCHED_ENDTIME:
                case ModelCode.REGULARINTERVALSCHED_TIMESTEP:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.REGULARINTERVALSCHED_ENDTIME:
                    prop.SetValue(endTime);
                    break;
                case ModelCode.REGULARINTERVALSCHED_TIMESTEP:
                    prop.SetValue(timeStep);
                    return;
            }
            base.GetProperty(prop);
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.REGULARINTERVALSCHED_ENDTIME:
                    endTime = property.AsDateTime();
                    break;
                case ModelCode.REGULARINTERVALSCHED_TIMESTEP:
                    timeStep = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }

            //base.SetProperty(property);
        }

        #endregion IAccess implementation	
    }
}
