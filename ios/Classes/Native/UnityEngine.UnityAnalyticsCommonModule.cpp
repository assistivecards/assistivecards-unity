#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>



// System.String
struct String_t;



IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_tD1F0B9705D5594A42609E77459719A6C0DB9DD53 
{
};

// UnityEngine.Analytics.AnalyticsCommon
struct AnalyticsCommon_t9A0DD5EB3A8E861A4481AA17C2105396E9C4E34C  : public RuntimeObject
{
};
struct Il2CppArrayBounds;

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void UnityEngine.Analytics.AnalyticsCommon::set_ugsAnalyticsEnabledInternal(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnalyticsCommon_set_ugsAnalyticsEnabledInternal_m4264C600AC21370AB14F1A2D811CF8976C63E864 (bool ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Analytics.AnalyticsCommon::set_ugsAnalyticsEnabled(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnalyticsCommon_set_ugsAnalyticsEnabled_m998A626F754515EF4257B9FC3BD0850DDF4370F3 (bool ___value0, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.Analytics.AnalyticsCommon::set_ugsAnalyticsEnabledInternal(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnalyticsCommon_set_ugsAnalyticsEnabledInternal_m4264C600AC21370AB14F1A2D811CF8976C63E864 (bool ___value0, const RuntimeMethod* method) 
{
	typedef void (*AnalyticsCommon_set_ugsAnalyticsEnabledInternal_m4264C600AC21370AB14F1A2D811CF8976C63E864_ftn) (bool);
	static AnalyticsCommon_set_ugsAnalyticsEnabledInternal_m4264C600AC21370AB14F1A2D811CF8976C63E864_ftn _il2cpp_icall_func;
	if (!_il2cpp_icall_func)
	_il2cpp_icall_func = (AnalyticsCommon_set_ugsAnalyticsEnabledInternal_m4264C600AC21370AB14F1A2D811CF8976C63E864_ftn)il2cpp_codegen_resolve_icall ("UnityEngine.Analytics.AnalyticsCommon::set_ugsAnalyticsEnabledInternal(System.Boolean)");
	_il2cpp_icall_func(___value0);
}
// System.Void UnityEngine.Analytics.AnalyticsCommon::set_ugsAnalyticsEnabled(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnalyticsCommon_set_ugsAnalyticsEnabled_m998A626F754515EF4257B9FC3BD0850DDF4370F3 (bool ___value0, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___value0;
		AnalyticsCommon_set_ugsAnalyticsEnabledInternal_m4264C600AC21370AB14F1A2D811CF8976C63E864(L_0, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.Analytics.UGSAnalyticsInternalTools::SetPrivacyStatus(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void UGSAnalyticsInternalTools_SetPrivacyStatus_mF4F04D971EBA3A54A9AD22DC4E8D95711334516A (bool ___status0, const RuntimeMethod* method) 
{
	{
		bool L_0 = ___status0;
		AnalyticsCommon_set_ugsAnalyticsEnabled_m998A626F754515EF4257B9FC3BD0850DDF4370F3(L_0, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
