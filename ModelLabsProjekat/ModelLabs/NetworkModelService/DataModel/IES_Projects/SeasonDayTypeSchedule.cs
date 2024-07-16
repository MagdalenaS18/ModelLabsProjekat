using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.IES_Projects
{
    public class SeasonDayTypeSchedule : RegularIntervalSchedule
    {
        private long season;
        private long dayType;

        public SeasonDayTypeSchedule(long globalId) : base(globalId)
        {
        }

        public long Season
        {
            get { return season; }
            set { season = value; }
        }

        public long DayType
        {
            get { return dayType; }
            set { dayType = value; }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                SeasonDayTypeSchedule x = (SeasonDayTypeSchedule)obj;
                return ((x.season == this.season) &&
                        (x.dayType == this.dayType));
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
                case ModelCode.SEASONDAYTYPESCHED_SEASON:
                case ModelCode.SEASONDAYTYPESCHED_DAYTYPE:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            //model code proeprtija
            switch (prop.Id)
            {
                case ModelCode.SEASONDAYTYPESCHED_SEASON:
                    prop.SetValue(season);
                    return;
                case ModelCode.SEASONDAYTYPESCHED_DAYTYPE:
                    prop.SetValue(dayType);
                    return;

            }
            base.GetProperty(prop);
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.SEASONDAYTYPESCHED_SEASON:
                    season = property.AsReference();
                    break;
                case ModelCode.SEASONDAYTYPESCHED_DAYTYPE:
                    dayType = property.AsReference();
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
            if (season != 0 && (refType != TypeOfReference.Reference || refType != TypeOfReference.Both))
            {
                references[ModelCode.SEASONDAYTYPESCHED_SEASON] = new List<long>();
                references[ModelCode.SEASONDAYTYPESCHED_SEASON].Add(season);
            }

            if (dayType != 0 && (refType != TypeOfReference.Reference || refType != TypeOfReference.Both))
            {
                references[ModelCode.SEASONDAYTYPESCHED_DAYTYPE] = new List<long>();
                references[ModelCode.SEASONDAYTYPESCHED_DAYTYPE].Add(dayType);
            }

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation
    }
}
