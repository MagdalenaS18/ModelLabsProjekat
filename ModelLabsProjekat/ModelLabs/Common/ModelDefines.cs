using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Common
{
	
	public enum DMSType : short
    {       //definises konkretne tipove od 1 do 6
            
        MASK_TYPE							= unchecked((short)0xFFFF),

        TERMINAL							= 0x0001,
		REGULATINGCONTROL					= 0x0002,
		DAYTYPE								= 0x0003,
		SEASON								= 0x0004,
		REGULATIONSCHED						= 0x0005,
		ASYNCMACHINE						= 0x0006,

    }

    [Flags]
	public enum ModelCode : long
	{
		IDOBJ								= 0x1000000000000000,
		IDOBJ_GID							= 0x1000000000000104,
		IDOBJ_ALIASNAME						= 0x1000000000000207,
		IDOBJ_MRID							= 0x1000000000000307,
		IDOBJ_NAME							= 0x1000000000000407,	

		PSR									= 0x1100000000000000,
		//PSR_CUSTOMTYPE						= 0x1100000000000107,
		//PSR_LOCATION						= 0x1100000000000209,

		TERMINAL							= 0x1200000000010000,
		TERMINAL_CONN						= 0x1200000000010101, // bool
		TERMINAL_SEQNUM						= 0x1200000000010203, // int - ako je int32 onda je 3, a ako je int64 onda je 4
		TERMINAL_PHASES						= 0x120000000001030a, // PhaseCode - enum
		TERMINAL_REGULATINGCONTROL			= 0x1200000000010419, // referenca

		SEASON								= 0x1300000000040000,
		SEASON_ENDDATE						= 0x1300000000040108, // DateTime
		SEASON_STARTDATE					= 0x1300000000040208, // DateTime
		SEASON_SEASONDAYTYPESCHEDS			= 0x1300000000040319, // referenca

		DAYTYPE								= 0x1400000000030000,
		DAYTYPE_SEASONDAYTYPESCHEDS			= 0x1400000000030119, // referenca

		BASICINTERVALSCHED					= 0x1500000000000000,
		BASICINTERVALSCHED_STARTTIME		= 0x1500000000000108, // DateTime
		BASICINTERVALSCHED_VAL1MUL			= 0x150000000000020a, // UnitMultiplier - enum
		BASICINTERVALSCHED_VAL2MUL			= 0x150000000000030a, //
		BASICINTERVALSCHED_VAL1UNIT			= 0x150000000000040a, // UnitSymbol - enum
		BASICINTERVALSCHED_VAL2UNIT			= 0x150000000000050a, //

		EQUIPMENT							= 0x1110000000000000,
		EQUIPMENT_AGGREGATED				= 0x1110000000000101, // bool
		EQUIPMENT_NORMALLYINSERVICE			= 0x1110000000000201, //

		REGULATINGCONTROL					= 0x1120000000020000,
		REGULATINGCONTROL_DISCRETE			= 0x1120000000020101, // bool
		REGULATINGCONTROL_MODE				= 0x112000000002020a, // RegulatingControlModeKind - enum
		REGULATINGCONTROL_MONPHASE			= 0x112000000002030a, // PhaseCode - enum
		REGULATINGCONTROL_TARRANGE			= 0x1120000000020405, // float
		REGULATINGCONTROL_TARVALUE			= 0x1120000000020505, // float
		REGULATINGCONTROL_TERMINAL			= 0x1120000000020609, // referenca
		REGULATINGCONTROL_REGULATINGCONDEQ	= 0x1120000000020719, // referenca
		REGULATINGCONTROL_REGULATIONSCHED	= 0x1120000000020819, // referenca

		REGULARINTERVALSCHED				= 0x1510000000000000,
		REGULARINTERVALSCHED_ENDTIME		= 0x1510000000000108, // DateTime
		REGULARINTERVALSCHED_TIMESTEP		= 0x1510000000000205, // sekunde

		CONDUCTINGEQP						= 0x1111000000000000,

		SEASONDAYTYPESCHED					= 0x1511000000000000,
		SEASONDAYTYPESCHED_DAYTYPE			= 0x1511000000000109, // referenca
		SEASONDAYTYPESCHED_SEASON			= 0x1511000000000209, // referenca

		REGULATINGCONDEQP					= 0x1111100000000000,
		REGULATINGCONDEQP_REGCONTROL		= 0x1111100000000109, // referenca
		
		REGULATIONSCHED						= 0x1511100000050000,
		REGULATIONSCHED_REGCONTROL			= 0x1511100000050109, // referenca

		ROTATINGMACHINE						= 0x1111110000000000,
		ROTATINGMACHINE_DAMPING				= 0x1111110000000105, // float
		ROTATINGMACHINE_SATFACTOR			= 0x1111110000000205, //
		ROTATINGMACHINE_SATFACTOR120		= 0x1111110000000305, //
		ROTATINGMACHINE_INERTIA				= 0x1111110000000405, // sekunde
		ROTATINGMACHINE_RATEDS				= 0x1111110000000505, // ApparentPower
		ROTATINGMACHINE_STATLEAKREAC		= 0x1111110000000605, // reaktansa
		ROTATINGMACHINE_STATRESIS			= 0x1111110000000705, // rezistansa

		ASYNCMACHINE						= 0x1111111000060000,
		ASYNCMACHINE_RR1					= 0x1111111000060105, // rezistansa
		ASYNCMACHINE_RR2					= 0x1111111000060205, //
		ASYNCMACHINE_TPO					= 0x1111111000060305, // sekunde
		ASYNCMACHINE_TPPO					= 0x1111111000060405, //
		ASYNCMACHINE_XLR1					= 0x1111111000060505, // reaktansa
		ASYNCMACHINE_XLR2					= 0x1111111000060605, //
		ASYNCMACHINE_XM						= 0x1111111000060705, //
		ASYNCMACHINE_XP						= 0x1111111000060805, //
		ASYNCMACHINE_XPP					= 0x1111111000060905, //
		ASYNCMACHINE_XS						= 0x1111111000061005, //

		//TERMINAL							= 0x1200000000010000,
		//TERMINAL_CONN						= 0x1200000000010101, // bool
		//TERMINAL_SEQNUM						= 0x1200000000010203, // int - ako je int32 onda je 3, a ako je int64 onda je 4
		//TERMINAL_PHASES						= 0x120000000001030a, // PhaseCode - enum
		//TERMINAL_REGULATINGCONTROL			= 0x1200000000010419, // referenca


		//REGULATINGCONTROL					= 0x1120000000020000,
		//REGULATINGCONTROL_DISCRETE			= 0x1120000000020101, // bool
		//REGULATINGCONTROL_MODE				= 0x112000000002020a, // RegulatingControlModeKind - enum
		//REGULATINGCONTROL_MONPHASE			= 0x112000000002030a, // PhaseCode - enum
		//REGULATINGCONTROL_TARRANGE			= 0x1120000000020405, // float
		//REGULATINGCONTROL_TARVALUE			= 0x1120000000020505, // float
		//REGULATINGCONTROL_TERMINAL			= 0x1120000000020609, // referenca
		//REGULATINGCONTROL_REGULATINGCONDEQ	= 0x1120000000020719, // referenca
		//REGULATINGCONTROL_REGULATIONSCHED	= 0x1120000000020819, // referenca

		//SEASON								= 0x1300000000040000,
		//SEASON_ENDDATE						= 0x1300000000040108, // DateTime
		//SEASON_STARTDATE					= 0x1300000000040208, // DateTime
		//SEASON_SEASONDAYTYPESCHEDS			= 0x1300000000040319, // referenca

		//DAYTYPE								= 0x1400000000030000,
		//DAYTYPE_SEASONDAYTYPESCHEDS			= 0x1400000000030119, // referenca

		//BASICINTERVALSCHED					= 0x1500000000000000,
		//BASICINTERVALSCHED_STARTTIME		= 0x1500000000000108, // DateTime
		//BASICINTERVALSCHED_VAL1MUL			= 0x150000000000020a, // UnitMultiplier - enum
		//BASICINTERVALSCHED_VAL2MUL			= 0x150000000000030a, //
		//BASICINTERVALSCHED_VAL1UNIT			= 0x150000000000040a, // UnitSymbol - enum
		//BASICINTERVALSCHED_VAL2UNIT			= 0x150000000000050a, //

		//REGULARINTERVALSCHED				= 0x1510000000000000,
		//REGULARINTERVALSCHED_ENDTIME		= 0x1510000000000108, // DateTime
		//REGULARINTERVALSCHED_TIMESTEP		= 0x1510000000000205, // sekunde

		//SEASONDAYTYPESCHED					= 0x1511000000000000,
		//SEASONDAYTYPESCHED_DAYTYPE			= 0x1511000000000109, // referenca
		//SEASONDAYTYPESCHED_SEASON			= 0x1511000000000209, // referenca

		//REGULATIONSCHED						= 0x1511100000050000,
		//REGULATIONSCHED_REGCONTROL			= 0x1511100000050109, // referenca

	}

	[Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}


