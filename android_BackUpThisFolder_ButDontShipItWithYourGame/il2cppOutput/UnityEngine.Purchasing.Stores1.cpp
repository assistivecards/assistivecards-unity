#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename R, typename T1, typename T2>
struct GenericInterfaceFuncInvoker2
{
	typedef R (*Func)(void*, T1, T2, const RuntimeMethod*);

	static inline R Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};

// System.Action`1<System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>>
struct Action_1_tA72D33CF2F54A3A2B5EA5FC85BF59006A8BCC2BE;
// System.Action`1<UnityEngine.Purchasing.Models.GoogleRetrieveProductsFailureReason>
struct Action_1_t827DD5268A2273F9357827BCDAB0FD15F77CD462;
// System.Func`2<UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper,System.String>
struct Func_2_t75667D71F159AEB8D73106C0895991743541AD05;
// System.Func`2<System.Object,System.Object>
struct Func_2_tACBF5A1656250800CE861707354491F0611F6624;
// System.Collections.Generic.IEnumerable`1<UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper>
struct IEnumerable_1_tB0D4C9D42D0F386807EF901F8E037DC889F14D09;
// System.Collections.Generic.IEnumerable`1<System.Object>
struct IEnumerable_1_tF95C9E01A913DD50575531C8305932628663D9E9;
// System.Collections.Generic.IEnumerable`1<System.String>
struct IEnumerable_1_t349E66EC5F09B881A8E52EE40A1AB9EC60E08E44;
// System.Collections.Generic.IList`1<UnityEngine.Purchasing.ProductDefinition>
struct IList_1_t59F64BD4671A3CFD9A6FC01A4FF2F4B732DD697D;
// System.Collections.Generic.List`1<System.Object>
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D;
// System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>
struct List_1_tC907BA3C053A12CF512BC52B3657F30C756D4B7B;
// System.Collections.Generic.List`1<System.String>
struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD;
// System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>
struct ReadOnlyCollection_1_tA49701F42E3782EB8804C53D26901317BAD43A9E;
// System.Byte[]
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
// System.Object[]
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;
// System.String[]
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
// UnityEngine.AndroidJavaClass
struct AndroidJavaClass_tE6296B30CC4BF84434A9B765267F3FD0DD8DDB03;
// UnityEngine.AndroidJavaObject
struct AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0;
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
// UnityEngine.GlobalJavaObjectRef
struct GlobalJavaObjectRef_t20D8E5AAFC2EB2518FCABBF40465855E797FF0D8;
// UnityEngine.Purchasing.Models.GoogleBillingResult
struct GoogleBillingResult_t745A56EF536C75D42537F287C4BF137739AC6EA4;
// UnityEngine.Purchasing.Models.GooglePurchase
struct GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF;
// UnityEngine.Purchasing.Models.GooglePurchaseStateEnumProvider
struct GooglePurchaseStateEnumProvider_t4F9C48DADF977FD31FFE29D767F092126332683A;
// UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper
struct IAndroidJavaObjectWrapper_tC1A612D0FB5242E0B7B6FE0D545945956CFF7DF4;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// UnityEngine.Purchasing.Models.ProductDescriptionQuery
struct ProductDescriptionQuery_t03B36576574F6E71672313472421EE2FB8C5BFAE;
// System.String
struct String_t;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// UnityEngine.Purchasing.Models.GooglePurchase/<>c
struct U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2;

IL2CPP_EXTERN_C RuntimeClass* AndroidJavaClass_tE6296B30CC4BF84434A9B765267F3FD0DD8DDB03_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Func_2_t75667D71F159AEB8D73106C0895991743541AD05_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral001453AEE96196C60F5094DBB37BD7779972F12D;
IL2CPP_EXTERN_C String_t* _stringLiteral262420555EA5B16B5A4C3D90B8838492D7CA04F9;
IL2CPP_EXTERN_C String_t* _stringLiteral2778FD4BAB0076B85A6DC02C1B233BF0A7848FC0;
IL2CPP_EXTERN_C String_t* _stringLiteral450C8EF3D0450ABCD23C53730AAA221835C6A350;
IL2CPP_EXTERN_C String_t* _stringLiteral4DA292056609E91DF87CFB0BE26ACC4860B8C273;
IL2CPP_EXTERN_C String_t* _stringLiteral63C24B473E127CB6B089ACEF244BCB238A34E135;
IL2CPP_EXTERN_C String_t* _stringLiteral6DAB35E4EA4BBD5AF1473155FA1288D974D1DAD9;
IL2CPP_EXTERN_C String_t* _stringLiteral9303FDBBA3EA9F42A781A1107ABF8F1702BF684C;
IL2CPP_EXTERN_C String_t* _stringLiteral9C65AE428D66E9596028DEE3D50639FC92DA9E83;
IL2CPP_EXTERN_C String_t* _stringLiteralA44250C90C4461C6F602B3B9DC9B873627787D3B;
IL2CPP_EXTERN_C String_t* _stringLiteralC0996A36415E22F8B9021DA5470FAD41831458D9;
IL2CPP_EXTERN_C String_t* _stringLiteralC5EE8C59C90DE1E698A3010542A9B964C720ED30;
IL2CPP_EXTERN_C String_t* _stringLiteralD1BC95382E937429BD5741792056300D87684F48;
IL2CPP_EXTERN_C String_t* _stringLiteralE621E6581BCE23AE171A5EFE8813FCCCF6DC45FF;
IL2CPP_EXTERN_C String_t* _stringLiteralF169275544223C785E8F3C2E7F2BB05FB2885329;
IL2CPP_EXTERN_C String_t* _stringLiteralF3DB8521ADB71488B0A3D538F58F98B35E326552;
IL2CPP_EXTERN_C const RuntimeMethod* AndroidJavaObjectExtensions_Enumerate_TisString_t_mACBF5A02F47B293C90E2E62AF3B5E90B471E1599_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AndroidJavaObject_Call_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mDC5FD095AFC55DFE596907E5B055B5774DA5B5AC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AndroidJavaObject_Call_TisString_t_m67FC2931E81004C3F259008314180511C3D2AF40_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* AndroidJavaObject_GetStatic_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m740F3401DEA4A75BADD753EFF71D2328B4147BFC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerable_FirstOrDefault_TisString_t_m9CA8A9DE7F8DCB619529414D42C259BDF6C05A5B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerable_Select_TisIAndroidJavaObjectWrapper_tC1A612D0FB5242E0B7B6FE0D545945956CFF7DF4_TisString_t_m762C1F9DB2640F02FBC59A9060856067CB3119E3_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerable_ToList_TisString_t_m86360148F90DE6EA1A8363F38B7C2A88FD139131_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* IAndroidJavaObjectWrapper_Call_TisAndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0_m1C8F17EDFAB334D7CEB13FB9A68A1B0CD4E9A77E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* IAndroidJavaObjectWrapper_Call_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m5F286AAE3D9A081053469736CC66C2873A0A9900_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* IAndroidJavaObjectWrapper_Call_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m57AD306FDEC5BDE85E9715C1A0B7CFFFB7C00753_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* IAndroidJavaObjectWrapper_Call_TisString_t_m1A02C80883EF91CD3314D0856FE96818794AA538_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CU3Ec_U3C_ctorU3Eb__26_0_mB666CC9852E094F68F830014EA039871BBF416BA_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;

struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.EmptyArray`1<System.Object>
struct EmptyArray_1_tDF0DD7256B115243AA6BD5558417387A734240EE  : public RuntimeObject
{
};

struct EmptyArray_1_tDF0DD7256B115243AA6BD5558417387A734240EE_StaticFields
{
	// T[] System.EmptyArray`1::Value
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___Value_0;
};

// System.Collections.Generic.List`1<System.String>
struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___s_emptyArray_5;
};

// System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>
struct ReadOnlyCollection_1_tA49701F42E3782EB8804C53D26901317BAD43A9E  : public RuntimeObject
{
	// System.Collections.Generic.IList`1<T> System.Collections.ObjectModel.ReadOnlyCollection`1::list
	RuntimeObject* ___list_0;
	// System.Object System.Collections.ObjectModel.ReadOnlyCollection`1::_syncRoot
	RuntimeObject* ____syncRoot_1;
};

// <PrivateImplementationDetails>
struct U3CPrivateImplementationDetailsU3E_t8D0DB3264ABFAB6DDFFE3BB44566FFCAE6765D0D  : public RuntimeObject
{
};

// UnityEngine.AndroidJavaObject
struct AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0  : public RuntimeObject
{
	// UnityEngine.GlobalJavaObjectRef UnityEngine.AndroidJavaObject::m_jobject
	GlobalJavaObjectRef_t20D8E5AAFC2EB2518FCABBF40465855E797FF0D8* ___m_jobject_1;
	// UnityEngine.GlobalJavaObjectRef UnityEngine.AndroidJavaObject::m_jclass
	GlobalJavaObjectRef_t20D8E5AAFC2EB2518FCABBF40465855E797FF0D8* ___m_jclass_2;
};

struct AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0_StaticFields
{
	// System.Boolean UnityEngine.AndroidJavaObject::enableDebugPrints
	bool ___enableDebugPrints_0;
};
struct Il2CppArrayBounds;

// UnityEngine.Purchasing.Models.GoogleBillingResult
struct GoogleBillingResult_t745A56EF536C75D42537F287C4BF137739AC6EA4  : public RuntimeObject
{
	// UnityEngine.Purchasing.Models.GoogleBillingResponseCode UnityEngine.Purchasing.Models.GoogleBillingResult::<responseCode>k__BackingField
	int32_t ___U3CresponseCodeU3Ek__BackingField_0;
	// System.String UnityEngine.Purchasing.Models.GoogleBillingResult::<debugMessage>k__BackingField
	String_t* ___U3CdebugMessageU3Ek__BackingField_1;
};

// UnityEngine.Purchasing.Models.GoogleBillingStrings
struct GoogleBillingStrings_t48F0D3FE154AC4ACDCD81C88AA5A1937ECB6E085  : public RuntimeObject
{
};

// UnityEngine.Purchasing.Models.GooglePurchase
struct GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF  : public RuntimeObject
{
	// UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper UnityEngine.Purchasing.Models.GooglePurchase::<javaPurchase>k__BackingField
	RuntimeObject* ___U3CjavaPurchaseU3Ek__BackingField_0;
	// System.Int32 UnityEngine.Purchasing.Models.GooglePurchase::<purchaseState>k__BackingField
	int32_t ___U3CpurchaseStateU3Ek__BackingField_1;
	// System.Collections.Generic.List`1<System.String> UnityEngine.Purchasing.Models.GooglePurchase::<skus>k__BackingField
	List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* ___U3CskusU3Ek__BackingField_2;
	// System.String UnityEngine.Purchasing.Models.GooglePurchase::<orderId>k__BackingField
	String_t* ___U3CorderIdU3Ek__BackingField_3;
	// System.String UnityEngine.Purchasing.Models.GooglePurchase::<receipt>k__BackingField
	String_t* ___U3CreceiptU3Ek__BackingField_4;
	// System.String UnityEngine.Purchasing.Models.GooglePurchase::<signature>k__BackingField
	String_t* ___U3CsignatureU3Ek__BackingField_5;
	// System.String UnityEngine.Purchasing.Models.GooglePurchase::<originalJson>k__BackingField
	String_t* ___U3CoriginalJsonU3Ek__BackingField_6;
	// System.String UnityEngine.Purchasing.Models.GooglePurchase::<purchaseToken>k__BackingField
	String_t* ___U3CpurchaseTokenU3Ek__BackingField_7;
};

// UnityEngine.Purchasing.Models.GooglePurchaseStateEnum
struct GooglePurchaseStateEnum_tDDCC9F3F35E2DE86B6D790F7B4147DE728EACC7D  : public RuntimeObject
{
};

// UnityEngine.Purchasing.Models.GooglePurchaseStateEnumProvider
struct GooglePurchaseStateEnumProvider_t4F9C48DADF977FD31FFE29D767F092126332683A  : public RuntimeObject
{
};

// UnityEngine.Purchasing.Models.GoogleSkuTypeEnum
struct GoogleSkuTypeEnum_t9471ABA55B0D1C212ADDB21BFEEC7DEA6571335C  : public RuntimeObject
{
};

// UnityEngine.Purchasing.Models.ProductDescriptionQuery
struct ProductDescriptionQuery_t03B36576574F6E71672313472421EE2FB8C5BFAE  : public RuntimeObject
{
	// System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition> UnityEngine.Purchasing.Models.ProductDescriptionQuery::products
	ReadOnlyCollection_1_tA49701F42E3782EB8804C53D26901317BAD43A9E* ___products_0;
	// System.Action`1<System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>> UnityEngine.Purchasing.Models.ProductDescriptionQuery::onProductsReceived
	Action_1_tA72D33CF2F54A3A2B5EA5FC85BF59006A8BCC2BE* ___onProductsReceived_1;
	// System.Action`1<UnityEngine.Purchasing.Models.GoogleRetrieveProductsFailureReason> UnityEngine.Purchasing.Models.ProductDescriptionQuery::onRetrieveProductsFailed
	Action_1_t827DD5268A2273F9357827BCDAB0FD15F77CD462* ___onRetrieveProductsFailed_2;
};

// System.String
struct String_t  : public RuntimeObject
{
	// System.Int32 System.String::_stringLength
	int32_t ____stringLength_4;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_5;
};

struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

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

// UnityEngine.Purchasing.Models.GooglePurchase/<>c
struct U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2  : public RuntimeObject
{
};

struct U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_StaticFields
{
	// UnityEngine.Purchasing.Models.GooglePurchase/<>c UnityEngine.Purchasing.Models.GooglePurchase/<>c::<>9
	U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2* ___U3CU3E9_0;
	// System.Func`2<UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper,System.String> UnityEngine.Purchasing.Models.GooglePurchase/<>c::<>9__26_0
	Func_2_t75667D71F159AEB8D73106C0895991743541AD05* ___U3CU3E9__26_0_1;
};

// UnityEngine.AndroidJavaClass
struct AndroidJavaClass_tE6296B30CC4BF84434A9B765267F3FD0DD8DDB03  : public AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0
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

// System.Char
struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17 
{
	// System.Char System.Char::m_value
	Il2CppChar ___m_value_0;
};

struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17_StaticFields
{
	// System.Byte[] System.Char::s_categoryForLatin1
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___s_categoryForLatin1_3;
};

// System.Int32
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;
};

// System.IntPtr
struct IntPtr_t 
{
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;
};

// System.UInt32
struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	// System.UInt32 System.UInt32::m_value
	uint32_t ___m_value_0;
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

// System.Delegate
struct Delegate_t  : public RuntimeObject
{
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject* ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.IntPtr System.Delegate::interp_method
	intptr_t ___interp_method_7;
	// System.IntPtr System.Delegate::interp_invoke_impl
	intptr_t ___interp_invoke_impl_8;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t* ___method_info_9;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t* ___original_method_info_10;
	// System.DelegateData System.Delegate::data
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_12;
};
// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};

// System.MulticastDelegate
struct MulticastDelegate_t  : public Delegate_t
{
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates_13;
};
// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_13;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_13;
};

// System.Action`1<System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>>
struct Action_1_tA72D33CF2F54A3A2B5EA5FC85BF59006A8BCC2BE  : public MulticastDelegate_t
{
};

// System.Action`1<UnityEngine.Purchasing.Models.GoogleRetrieveProductsFailureReason>
struct Action_1_t827DD5268A2273F9357827BCDAB0FD15F77CD462  : public MulticastDelegate_t
{
};

// System.Func`2<UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper,System.String>
struct Func_2_t75667D71F159AEB8D73106C0895991743541AD05  : public MulticastDelegate_t
{
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
// System.Object[]
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918  : public RuntimeArray
{
	ALIGN_FIELD (8) RuntimeObject* m_Items[1];

	inline RuntimeObject* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline RuntimeObject* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};


// T[] System.Array::Empty<System.Object>()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_gshared_inline (const RuntimeMethod* method) ;
// ReturnType UnityEngine.AndroidJavaObject::Call<System.Int32>(System.String,System.Object[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AndroidJavaObject_Call_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mDC5FD095AFC55DFE596907E5B055B5774DA5B5AC_gshared (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* __this, String_t* ___methodName0, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___args1, const RuntimeMethod* method) ;
// ReturnType UnityEngine.AndroidJavaObject::Call<System.Object>(System.String,System.Object[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* AndroidJavaObject_Call_TisRuntimeObject_mA5AF1A9E0463CE91F0ACB6AC2FE0C1922B579EF7_gshared (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* __this, String_t* ___methodName0, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___args1, const RuntimeMethod* method) ;
// TSource System.Linq.Enumerable::FirstOrDefault<System.Object>(System.Collections.Generic.IEnumerable`1<TSource>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Enumerable_FirstOrDefault_TisRuntimeObject_m7DE546C4F58329C905F662422736A44C50268ECD_gshared (RuntimeObject* ___source0, const RuntimeMethod* method) ;
// System.Collections.Generic.IEnumerable`1<T> UnityEngine.Purchasing.Models.AndroidJavaObjectExtensions::Enumerate<System.Object>(UnityEngine.AndroidJavaObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* AndroidJavaObjectExtensions_Enumerate_TisRuntimeObject_mBCE5BAC766D1BE338A897668497CB1A4CDD77A2E_gshared (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* ___androidJavaList0, const RuntimeMethod* method) ;
// System.Collections.Generic.List`1<TSource> System.Linq.Enumerable::ToList<System.Object>(System.Collections.Generic.IEnumerable`1<TSource>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* Enumerable_ToList_TisRuntimeObject_m6456D63764F29E6B5B2422C3DE25113577CF51EE_gshared (RuntimeObject* ___source0, const RuntimeMethod* method) ;
// System.Void System.Func`2<System.Object,System.Object>::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Func_2__ctor_m7F8A01C0B02BC1D4063F4EB1E817F7A48562A398_gshared (Func_2_tACBF5A1656250800CE861707354491F0611F6624* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
// System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Select<System.Object,System.Object>(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TResult>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Enumerable_Select_TisRuntimeObject_TisRuntimeObject_m67C538A5EBF57C4844107A8EF25DB2CAAFBAF8FB_gshared (RuntimeObject* ___source0, Func_2_tACBF5A1656250800CE861707354491F0611F6624* ___selector1, const RuntimeMethod* method) ;
// FieldType UnityEngine.AndroidJavaObject::GetStatic<System.Int32>(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AndroidJavaObject_GetStatic_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m740F3401DEA4A75BADD753EFF71D2328B4147BFC_gshared (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* __this, String_t* ___fieldName0, const RuntimeMethod* method) ;

// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
// T[] System.Array::Empty<System.Object>()
inline ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_inline (const RuntimeMethod* method)
{
	return ((  ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* (*) (const RuntimeMethod*))Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_gshared_inline)(method);
}
// ReturnType UnityEngine.AndroidJavaObject::Call<System.Int32>(System.String,System.Object[])
inline int32_t AndroidJavaObject_Call_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mDC5FD095AFC55DFE596907E5B055B5774DA5B5AC (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* __this, String_t* ___methodName0, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___args1, const RuntimeMethod* method)
{
	return ((  int32_t (*) (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0*, String_t*, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*, const RuntimeMethod*))AndroidJavaObject_Call_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mDC5FD095AFC55DFE596907E5B055B5774DA5B5AC_gshared)(__this, ___methodName0, ___args1, method);
}
// ReturnType UnityEngine.AndroidJavaObject::Call<System.String>(System.String,System.Object[])
inline String_t* AndroidJavaObject_Call_TisString_t_m67FC2931E81004C3F259008314180511C3D2AF40 (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* __this, String_t* ___methodName0, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___args1, const RuntimeMethod* method)
{
	return ((  String_t* (*) (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0*, String_t*, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*, const RuntimeMethod*))AndroidJavaObject_Call_TisRuntimeObject_mA5AF1A9E0463CE91F0ACB6AC2FE0C1922B579EF7_gshared)(__this, ___methodName0, ___args1, method);
}
// System.String System.String::Concat(System.String,System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m8855A6DE10F84DA7F4EC113CADDB59873A25573B (String_t* ___str00, String_t* ___str11, String_t* ___str22, const RuntimeMethod* method) ;
// System.Collections.Generic.List`1<System.String> UnityEngine.Purchasing.Models.GooglePurchase::get_skus()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* GooglePurchase_get_skus_mFB5A449AA1EE9433CFE668CDE90A55B7FDEB81A4_inline (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) ;
// TSource System.Linq.Enumerable::FirstOrDefault<System.String>(System.Collections.Generic.IEnumerable`1<TSource>)
inline String_t* Enumerable_FirstOrDefault_TisString_t_m9CA8A9DE7F8DCB619529414D42C259BDF6C05A5B (RuntimeObject* ___source0, const RuntimeMethod* method)
{
	return ((  String_t* (*) (RuntimeObject*, const RuntimeMethod*))Enumerable_FirstOrDefault_TisRuntimeObject_m7DE546C4F58329C905F662422736A44C50268ECD_gshared)(___source0, method);
}
// System.Collections.Generic.IEnumerable`1<T> UnityEngine.Purchasing.Models.AndroidJavaObjectExtensions::Enumerate<System.String>(UnityEngine.AndroidJavaObject)
inline RuntimeObject* AndroidJavaObjectExtensions_Enumerate_TisString_t_mACBF5A02F47B293C90E2E62AF3B5E90B471E1599 (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* ___androidJavaList0, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0*, const RuntimeMethod*))AndroidJavaObjectExtensions_Enumerate_TisRuntimeObject_mBCE5BAC766D1BE338A897668497CB1A4CDD77A2E_gshared)(___androidJavaList0, method);
}
// System.Collections.Generic.List`1<TSource> System.Linq.Enumerable::ToList<System.String>(System.Collections.Generic.IEnumerable`1<TSource>)
inline List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* Enumerable_ToList_TisString_t_m86360148F90DE6EA1A8363F38B7C2A88FD139131 (RuntimeObject* ___source0, const RuntimeMethod* method)
{
	return ((  List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* (*) (RuntimeObject*, const RuntimeMethod*))Enumerable_ToList_TisRuntimeObject_m6456D63764F29E6B5B2422C3DE25113577CF51EE_gshared)(___source0, method);
}
// System.Void System.Func`2<UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper,System.String>::.ctor(System.Object,System.IntPtr)
inline void Func_2__ctor_m466D04A215C45A0E59DACB1B32B8F0C6035D6871 (Func_2_t75667D71F159AEB8D73106C0895991743541AD05* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method)
{
	((  void (*) (Func_2_t75667D71F159AEB8D73106C0895991743541AD05*, RuntimeObject*, intptr_t, const RuntimeMethod*))Func_2__ctor_m7F8A01C0B02BC1D4063F4EB1E817F7A48562A398_gshared)(__this, ___object0, ___method1, method);
}
// System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Select<UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper,System.String>(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TResult>)
inline RuntimeObject* Enumerable_Select_TisIAndroidJavaObjectWrapper_tC1A612D0FB5242E0B7B6FE0D545945956CFF7DF4_TisString_t_m762C1F9DB2640F02FBC59A9060856067CB3119E3 (RuntimeObject* ___source0, Func_2_t75667D71F159AEB8D73106C0895991743541AD05* ___selector1, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (RuntimeObject*, Func_2_t75667D71F159AEB8D73106C0895991743541AD05*, const RuntimeMethod*))Enumerable_Select_TisRuntimeObject_TisRuntimeObject_m67C538A5EBF57C4844107A8EF25DB2CAAFBAF8FB_gshared)(___source0, ___selector1, method);
}
// System.String UnityEngine.Purchasing.Models.GooglePurchase::get_originalJson()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* GooglePurchase_get_originalJson_m6708011BD0AE03F2280CD86A0F07875EA578D5BA_inline (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) ;
// System.String UnityEngine.Purchasing.Models.GooglePurchase::get_signature()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* GooglePurchase_get_signature_m72063440F5794869DB8A4DE3F56A73F4444786AC_inline (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) ;
// System.String UnityEngine.Purchasing.Utils.GoogleReceiptEncoder::EncodeReceipt(System.String,System.String,System.Collections.Generic.List`1<System.String>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GoogleReceiptEncoder_EncodeReceipt_m17FC37EB777C0CD19B0A1345C320C17F030911D8 (String_t* ___purchaseOriginalJson0, String_t* ___purchaseSignature1, List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* ___skuDetailsJson2, const RuntimeMethod* method) ;
// UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper UnityEngine.Purchasing.Models.GooglePurchase::get_javaPurchase()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* GooglePurchase_get_javaPurchase_m82A168C3FB80849E2B85BED12EE4DCA6E58CEC18_inline (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) ;
// System.Int32 UnityEngine.Purchasing.Models.GooglePurchase::get_purchaseState()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t GooglePurchase_get_purchaseState_m25B05A607B60519FBA52843CAEF8FD8FEE0752A9_inline (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) ;
// System.Int32 UnityEngine.Purchasing.Models.GooglePurchaseStateEnum::Purchased()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t GooglePurchaseStateEnum_Purchased_m3791A59F7885C918735F78345549C35C39E661F0 (const RuntimeMethod* method) ;
// System.Int32 UnityEngine.Purchasing.Models.GooglePurchaseStateEnum::Pending()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t GooglePurchaseStateEnum_Pending_m419C6870D3097EADAF00FF0D6FF5C486BFB13171 (const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.Models.GooglePurchase/<>c::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_m696F4E3E542DD5C7ADEFA41805FB149F796B836A (U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.AndroidJavaClass::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AndroidJavaClass__ctor_mB5466169E1151B8CC44C8FED234D79984B431389 (AndroidJavaClass_tE6296B30CC4BF84434A9B765267F3FD0DD8DDB03* __this, String_t* ___className0, const RuntimeMethod* method) ;
// UnityEngine.AndroidJavaObject UnityEngine.Purchasing.Models.GooglePurchaseStateEnum::GetPurchaseStateJavaObject()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* GooglePurchaseStateEnum_GetPurchaseStateJavaObject_mBEFD71488906CB2105D270DACD285AFFE95C89E1 (const RuntimeMethod* method) ;
// FieldType UnityEngine.AndroidJavaObject::GetStatic<System.Int32>(System.String)
inline int32_t AndroidJavaObject_GetStatic_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m740F3401DEA4A75BADD753EFF71D2328B4147BFC (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* __this, String_t* ___fieldName0, const RuntimeMethod* method)
{
	return ((  int32_t (*) (AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0*, String_t*, const RuntimeMethod*))AndroidJavaObject_GetStatic_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m740F3401DEA4A75BADD753EFF71D2328B4147BFC_gshared)(__this, ___fieldName0, method);
}
// System.Char System.String::get_Chars(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3 (String_t* __this, int32_t ___index0, const RuntimeMethod* method) ;
// System.Int32 System.String::get_Length()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// UnityEngine.Purchasing.Models.GoogleBillingResponseCode UnityEngine.Purchasing.Models.GoogleBillingResult::get_responseCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t GoogleBillingResult_get_responseCode_m41C985D833239D91A30D60B5E0F78F63D40FCEDD (GoogleBillingResult_t745A56EF536C75D42537F287C4BF137739AC6EA4* __this, const RuntimeMethod* method) 
{
	{
		// public GoogleBillingResponseCode responseCode { get; }
		int32_t L_0 = __this->___U3CresponseCodeU3Ek__BackingField_0;
		return L_0;
	}
}
// System.String UnityEngine.Purchasing.Models.GoogleBillingResult::get_debugMessage()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GoogleBillingResult_get_debugMessage_mCBC8D3C771085DE43CFBF8A67CC21FDE52684CEA (GoogleBillingResult_t745A56EF536C75D42537F287C4BF137739AC6EA4* __this, const RuntimeMethod* method) 
{
	{
		// public string debugMessage { get; }
		String_t* L_0 = __this->___U3CdebugMessageU3Ek__BackingField_1;
		return L_0;
	}
}
// System.Void UnityEngine.Purchasing.Models.GoogleBillingResult::.ctor(UnityEngine.AndroidJavaObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GoogleBillingResult__ctor_mA4E4F80D1EF645AC6E72981FA7F7E141F6601377 (GoogleBillingResult_t745A56EF536C75D42537F287C4BF137739AC6EA4* __this, AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* ___billingResult0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AndroidJavaObject_Call_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mDC5FD095AFC55DFE596907E5B055B5774DA5B5AC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AndroidJavaObject_Call_TisString_t_m67FC2931E81004C3F259008314180511C3D2AF40_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4DA292056609E91DF87CFB0BE26ACC4860B8C273);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral63C24B473E127CB6B089ACEF244BCB238A34E135);
		s_Il2CppMethodInitialized = true;
	}
	{
		// internal GoogleBillingResult(AndroidJavaObject billingResult)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// if (billingResult != null)
		AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* L_0 = ___billingResult0;
		if (!L_0)
		{
			goto IL_0035;
		}
	}
	{
		// responseCode = (GoogleBillingResponseCode)billingResult.Call<int>("getResponseCode");
		AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* L_1 = ___billingResult0;
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_2;
		L_2 = Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_inline(Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		NullCheck(L_1);
		int32_t L_3;
		L_3 = AndroidJavaObject_Call_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mDC5FD095AFC55DFE596907E5B055B5774DA5B5AC(L_1, _stringLiteral4DA292056609E91DF87CFB0BE26ACC4860B8C273, L_2, AndroidJavaObject_Call_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_mDC5FD095AFC55DFE596907E5B055B5774DA5B5AC_RuntimeMethod_var);
		__this->___U3CresponseCodeU3Ek__BackingField_0 = L_3;
		// debugMessage = billingResult.Call<string>("getDebugMessage");
		AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* L_4 = ___billingResult0;
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_5;
		L_5 = Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_inline(Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		NullCheck(L_4);
		String_t* L_6;
		L_6 = AndroidJavaObject_Call_TisString_t_m67FC2931E81004C3F259008314180511C3D2AF40(L_4, _stringLiteral63C24B473E127CB6B089ACEF244BCB238A34E135, L_5, AndroidJavaObject_Call_TisString_t_m67FC2931E81004C3F259008314180511C3D2AF40_RuntimeMethod_var);
		__this->___U3CdebugMessageU3Ek__BackingField_1 = L_6;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CdebugMessageU3Ek__BackingField_1), (void*)L_6);
	}

IL_0035:
	{
		// }
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
// System.String UnityEngine.Purchasing.Models.GoogleBillingStrings::getWarningMessageMoreThanOneSkuFound(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GoogleBillingStrings_getWarningMessageMoreThanOneSkuFound_m7537B087FDB054238E02B64C5998D2FD4D4C3FD1 (String_t* ___sku0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral2778FD4BAB0076B85A6DC02C1B233BF0A7848FC0);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9C65AE428D66E9596028DEE3D50639FC92DA9E83);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return "More than one SKU found when purchasing SKU " + sku + ". Please verify your Google Play Store in-app product settings.";
		String_t* L_0 = ___sku0;
		String_t* L_1;
		L_1 = String_Concat_m8855A6DE10F84DA7F4EC113CADDB59873A25573B(_stringLiteral2778FD4BAB0076B85A6DC02C1B233BF0A7848FC0, L_0, _stringLiteral9C65AE428D66E9596028DEE3D50639FC92DA9E83, NULL);
		return L_1;
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
// UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper UnityEngine.Purchasing.Models.GooglePurchase::get_javaPurchase()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* GooglePurchase_get_javaPurchase_m82A168C3FB80849E2B85BED12EE4DCA6E58CEC18 (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public IAndroidJavaObjectWrapper javaPurchase { get; }
		RuntimeObject* L_0 = __this->___U3CjavaPurchaseU3Ek__BackingField_0;
		return L_0;
	}
}
// System.Int32 UnityEngine.Purchasing.Models.GooglePurchase::get_purchaseState()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t GooglePurchase_get_purchaseState_m25B05A607B60519FBA52843CAEF8FD8FEE0752A9 (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public int purchaseState { get; }
		int32_t L_0 = __this->___U3CpurchaseStateU3Ek__BackingField_1;
		return L_0;
	}
}
// System.Collections.Generic.List`1<System.String> UnityEngine.Purchasing.Models.GooglePurchase::get_skus()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* GooglePurchase_get_skus_mFB5A449AA1EE9433CFE668CDE90A55B7FDEB81A4 (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public List<string> skus { get; }
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_0 = __this->___U3CskusU3Ek__BackingField_2;
		return L_0;
	}
}
// System.String UnityEngine.Purchasing.Models.GooglePurchase::get_receipt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GooglePurchase_get_receipt_mB7E801F89576DA092E7A95DC41037E0FDC9E026A (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public string receipt { get; }
		String_t* L_0 = __this->___U3CreceiptU3Ek__BackingField_4;
		return L_0;
	}
}
// System.String UnityEngine.Purchasing.Models.GooglePurchase::get_signature()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GooglePurchase_get_signature_m72063440F5794869DB8A4DE3F56A73F4444786AC (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public string signature { get; }
		String_t* L_0 = __this->___U3CsignatureU3Ek__BackingField_5;
		return L_0;
	}
}
// System.String UnityEngine.Purchasing.Models.GooglePurchase::get_originalJson()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GooglePurchase_get_originalJson_m6708011BD0AE03F2280CD86A0F07875EA578D5BA (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public string originalJson { get; }
		String_t* L_0 = __this->___U3CoriginalJsonU3Ek__BackingField_6;
		return L_0;
	}
}
// System.String UnityEngine.Purchasing.Models.GooglePurchase::get_purchaseToken()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GooglePurchase_get_purchaseToken_mEAE44EFF7955BD8A92147AC6A5B8A70A6541EDE7 (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public string purchaseToken { get; }
		String_t* L_0 = __this->___U3CpurchaseTokenU3Ek__BackingField_7;
		return L_0;
	}
}
// System.String UnityEngine.Purchasing.Models.GooglePurchase::get_sku()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GooglePurchase_get_sku_m58FFD30FBFB7CD671E343E2C61CAE80582C9EB94 (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerable_FirstOrDefault_TisString_t_m9CA8A9DE7F8DCB619529414D42C259BDF6C05A5B_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public string? sku => skus.FirstOrDefault();
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_0;
		L_0 = GooglePurchase_get_skus_mFB5A449AA1EE9433CFE668CDE90A55B7FDEB81A4_inline(__this, NULL);
		String_t* L_1;
		L_1 = Enumerable_FirstOrDefault_TisString_t_m9CA8A9DE7F8DCB619529414D42C259BDF6C05A5B(L_0, Enumerable_FirstOrDefault_TisString_t_m9CA8A9DE7F8DCB619529414D42C259BDF6C05A5B_RuntimeMethod_var);
		return L_1;
	}
}
// System.Void UnityEngine.Purchasing.Models.GooglePurchase::.ctor(UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper,System.Collections.Generic.IEnumerable`1<UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GooglePurchase__ctor_m1F2F9ED18508F3AC24E4C7364307ABED26EB7CED (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, RuntimeObject* ___purchase0, RuntimeObject* ___skuDetails1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AndroidJavaObjectExtensions_Enumerate_TisString_t_mACBF5A02F47B293C90E2E62AF3B5E90B471E1599_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerable_Select_TisIAndroidJavaObjectWrapper_tC1A612D0FB5242E0B7B6FE0D545945956CFF7DF4_TisString_t_m762C1F9DB2640F02FBC59A9060856067CB3119E3_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerable_ToList_TisString_t_m86360148F90DE6EA1A8363F38B7C2A88FD139131_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Func_2_t75667D71F159AEB8D73106C0895991743541AD05_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IAndroidJavaObjectWrapper_Call_TisAndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0_m1C8F17EDFAB334D7CEB13FB9A68A1B0CD4E9A77E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IAndroidJavaObjectWrapper_Call_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m57AD306FDEC5BDE85E9715C1A0B7CFFFB7C00753_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IAndroidJavaObjectWrapper_Call_TisString_t_m1A02C80883EF91CD3314D0856FE96818794AA538_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_U3C_ctorU3Eb__26_0_mB666CC9852E094F68F830014EA039871BBF416BA_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral262420555EA5B16B5A4C3D90B8838492D7CA04F9);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral450C8EF3D0450ABCD23C53730AAA221835C6A350);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9303FDBBA3EA9F42A781A1107ABF8F1702BF684C);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC0996A36415E22F8B9021DA5470FAD41831458D9);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralD1BC95382E937429BD5741792056300D87684F48);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralF169275544223C785E8F3C2E7F2BB05FB2885329);
		s_Il2CppMethodInitialized = true;
	}
	List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* V_0 = NULL;
	Func_2_t75667D71F159AEB8D73106C0895991743541AD05* G_B2_0 = NULL;
	RuntimeObject* G_B2_1 = NULL;
	Func_2_t75667D71F159AEB8D73106C0895991743541AD05* G_B1_0 = NULL;
	RuntimeObject* G_B1_1 = NULL;
	{
		// internal GooglePurchase(IAndroidJavaObjectWrapper purchase, IEnumerable<IAndroidJavaObjectWrapper> skuDetails)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// javaPurchase = purchase;
		RuntimeObject* L_0 = ___purchase0;
		__this->___U3CjavaPurchaseU3Ek__BackingField_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CjavaPurchaseU3Ek__BackingField_0), (void*)L_0);
		// purchaseState = purchase.Call<int>("getPurchaseState");
		RuntimeObject* L_1 = ___purchase0;
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_2;
		L_2 = Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_inline(Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		NullCheck(L_1);
		int32_t L_3;
		L_3 = GenericInterfaceFuncInvoker2< int32_t, String_t*, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* >::Invoke(IAndroidJavaObjectWrapper_Call_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m57AD306FDEC5BDE85E9715C1A0B7CFFFB7C00753_RuntimeMethod_var, L_1, _stringLiteralC0996A36415E22F8B9021DA5470FAD41831458D9, L_2);
		__this->___U3CpurchaseStateU3Ek__BackingField_1 = L_3;
		// skus = purchase.Call<AndroidJavaObject>("getSkus").Enumerate<string>().ToList();
		RuntimeObject* L_4 = ___purchase0;
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_5;
		L_5 = Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_inline(Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		NullCheck(L_4);
		AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* L_6;
		L_6 = GenericInterfaceFuncInvoker2< AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0*, String_t*, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* >::Invoke(IAndroidJavaObjectWrapper_Call_TisAndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0_m1C8F17EDFAB334D7CEB13FB9A68A1B0CD4E9A77E_RuntimeMethod_var, L_4, _stringLiteral262420555EA5B16B5A4C3D90B8838492D7CA04F9, L_5);
		RuntimeObject* L_7;
		L_7 = AndroidJavaObjectExtensions_Enumerate_TisString_t_mACBF5A02F47B293C90E2E62AF3B5E90B471E1599(L_6, AndroidJavaObjectExtensions_Enumerate_TisString_t_mACBF5A02F47B293C90E2E62AF3B5E90B471E1599_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_8;
		L_8 = Enumerable_ToList_TisString_t_m86360148F90DE6EA1A8363F38B7C2A88FD139131(L_7, Enumerable_ToList_TisString_t_m86360148F90DE6EA1A8363F38B7C2A88FD139131_RuntimeMethod_var);
		__this->___U3CskusU3Ek__BackingField_2 = L_8;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CskusU3Ek__BackingField_2), (void*)L_8);
		// orderId = purchase.Call<string>("getOrderId");
		RuntimeObject* L_9 = ___purchase0;
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_10;
		L_10 = Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_inline(Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		NullCheck(L_9);
		String_t* L_11;
		L_11 = GenericInterfaceFuncInvoker2< String_t*, String_t*, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* >::Invoke(IAndroidJavaObjectWrapper_Call_TisString_t_m1A02C80883EF91CD3314D0856FE96818794AA538_RuntimeMethod_var, L_9, _stringLiteralD1BC95382E937429BD5741792056300D87684F48, L_10);
		__this->___U3CorderIdU3Ek__BackingField_3 = L_11;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CorderIdU3Ek__BackingField_3), (void*)L_11);
		// originalJson = purchase.Call<string>("getOriginalJson");
		RuntimeObject* L_12 = ___purchase0;
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_13;
		L_13 = Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_inline(Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		NullCheck(L_12);
		String_t* L_14;
		L_14 = GenericInterfaceFuncInvoker2< String_t*, String_t*, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* >::Invoke(IAndroidJavaObjectWrapper_Call_TisString_t_m1A02C80883EF91CD3314D0856FE96818794AA538_RuntimeMethod_var, L_12, _stringLiteral9303FDBBA3EA9F42A781A1107ABF8F1702BF684C, L_13);
		__this->___U3CoriginalJsonU3Ek__BackingField_6 = L_14;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CoriginalJsonU3Ek__BackingField_6), (void*)L_14);
		// signature = purchase.Call<string>("getSignature");
		RuntimeObject* L_15 = ___purchase0;
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_16;
		L_16 = Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_inline(Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		NullCheck(L_15);
		String_t* L_17;
		L_17 = GenericInterfaceFuncInvoker2< String_t*, String_t*, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* >::Invoke(IAndroidJavaObjectWrapper_Call_TisString_t_m1A02C80883EF91CD3314D0856FE96818794AA538_RuntimeMethod_var, L_15, _stringLiteral450C8EF3D0450ABCD23C53730AAA221835C6A350, L_16);
		__this->___U3CsignatureU3Ek__BackingField_5 = L_17;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CsignatureU3Ek__BackingField_5), (void*)L_17);
		// purchaseToken = purchase.Call<string>("getPurchaseToken");
		RuntimeObject* L_18 = ___purchase0;
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_19;
		L_19 = Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_inline(Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		NullCheck(L_18);
		String_t* L_20;
		L_20 = GenericInterfaceFuncInvoker2< String_t*, String_t*, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* >::Invoke(IAndroidJavaObjectWrapper_Call_TisString_t_m1A02C80883EF91CD3314D0856FE96818794AA538_RuntimeMethod_var, L_18, _stringLiteralF169275544223C785E8F3C2E7F2BB05FB2885329, L_19);
		__this->___U3CpurchaseTokenU3Ek__BackingField_7 = L_20;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CpurchaseTokenU3Ek__BackingField_7), (void*)L_20);
		// var skuDetailsJson = skuDetails.Select(skuDetail => skuDetail.Call<string>("getOriginalJson")).ToList();
		RuntimeObject* L_21 = ___skuDetails1;
		il2cpp_codegen_runtime_class_init_inline(U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var);
		Func_2_t75667D71F159AEB8D73106C0895991743541AD05* L_22 = ((U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var))->___U3CU3E9__26_0_1;
		Func_2_t75667D71F159AEB8D73106C0895991743541AD05* L_23 = L_22;
		G_B1_0 = L_23;
		G_B1_1 = L_21;
		if (L_23)
		{
			G_B2_0 = L_23;
			G_B2_1 = L_21;
			goto IL_00bb;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var);
		U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2* L_24 = ((U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var))->___U3CU3E9_0;
		Func_2_t75667D71F159AEB8D73106C0895991743541AD05* L_25 = (Func_2_t75667D71F159AEB8D73106C0895991743541AD05*)il2cpp_codegen_object_new(Func_2_t75667D71F159AEB8D73106C0895991743541AD05_il2cpp_TypeInfo_var);
		NullCheck(L_25);
		Func_2__ctor_m466D04A215C45A0E59DACB1B32B8F0C6035D6871(L_25, L_24, (intptr_t)((void*)U3CU3Ec_U3C_ctorU3Eb__26_0_mB666CC9852E094F68F830014EA039871BBF416BA_RuntimeMethod_var), NULL);
		Func_2_t75667D71F159AEB8D73106C0895991743541AD05* L_26 = L_25;
		((U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var))->___U3CU3E9__26_0_1 = L_26;
		Il2CppCodeGenWriteBarrier((void**)(&((U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var))->___U3CU3E9__26_0_1), (void*)L_26);
		G_B2_0 = L_26;
		G_B2_1 = G_B1_1;
	}

IL_00bb:
	{
		RuntimeObject* L_27;
		L_27 = Enumerable_Select_TisIAndroidJavaObjectWrapper_tC1A612D0FB5242E0B7B6FE0D545945956CFF7DF4_TisString_t_m762C1F9DB2640F02FBC59A9060856067CB3119E3(G_B2_1, G_B2_0, Enumerable_Select_TisIAndroidJavaObjectWrapper_tC1A612D0FB5242E0B7B6FE0D545945956CFF7DF4_TisString_t_m762C1F9DB2640F02FBC59A9060856067CB3119E3_RuntimeMethod_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_28;
		L_28 = Enumerable_ToList_TisString_t_m86360148F90DE6EA1A8363F38B7C2A88FD139131(L_27, Enumerable_ToList_TisString_t_m86360148F90DE6EA1A8363F38B7C2A88FD139131_RuntimeMethod_var);
		V_0 = L_28;
		// receipt = GoogleReceiptEncoder.EncodeReceipt(
		//     originalJson,
		//     signature,
		//     skuDetailsJson
		// );
		String_t* L_29;
		L_29 = GooglePurchase_get_originalJson_m6708011BD0AE03F2280CD86A0F07875EA578D5BA_inline(__this, NULL);
		String_t* L_30;
		L_30 = GooglePurchase_get_signature_m72063440F5794869DB8A4DE3F56A73F4444786AC_inline(__this, NULL);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_31 = V_0;
		String_t* L_32;
		L_32 = GoogleReceiptEncoder_EncodeReceipt_m17FC37EB777C0CD19B0A1345C320C17F030911D8(L_29, L_30, L_31, NULL);
		__this->___U3CreceiptU3Ek__BackingField_4 = L_32;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CreceiptU3Ek__BackingField_4), (void*)L_32);
		// }
		return;
	}
}
// System.Boolean UnityEngine.Purchasing.Models.GooglePurchase::IsAcknowledged()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool GooglePurchase_IsAcknowledged_mE2F920ABCC295EA6F298E0AA74B4C3097C58F889 (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IAndroidJavaObjectWrapper_Call_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m5F286AAE3D9A081053469736CC66C2873A0A9900_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral001453AEE96196C60F5094DBB37BD7779972F12D);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return javaPurchase != null && javaPurchase.Call<bool>("isAcknowledged");
		RuntimeObject* L_0;
		L_0 = GooglePurchase_get_javaPurchase_m82A168C3FB80849E2B85BED12EE4DCA6E58CEC18_inline(__this, NULL);
		if (!L_0)
		{
			goto IL_001e;
		}
	}
	{
		RuntimeObject* L_1;
		L_1 = GooglePurchase_get_javaPurchase_m82A168C3FB80849E2B85BED12EE4DCA6E58CEC18_inline(__this, NULL);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_2;
		L_2 = Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_inline(Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		NullCheck(L_1);
		bool L_3;
		L_3 = GenericInterfaceFuncInvoker2< bool, String_t*, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* >::Invoke(IAndroidJavaObjectWrapper_Call_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_m5F286AAE3D9A081053469736CC66C2873A0A9900_RuntimeMethod_var, L_1, _stringLiteral001453AEE96196C60F5094DBB37BD7779972F12D, L_2);
		return L_3;
	}

IL_001e:
	{
		return (bool)0;
	}
}
// System.Boolean UnityEngine.Purchasing.Models.GooglePurchase::IsPurchased()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool GooglePurchase_IsPurchased_m0091EC5B71B28E403588B26FD73EC2C0A19D36D1 (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// return javaPurchase != null && purchaseState == GooglePurchaseStateEnum.Purchased();
		RuntimeObject* L_0;
		L_0 = GooglePurchase_get_javaPurchase_m82A168C3FB80849E2B85BED12EE4DCA6E58CEC18_inline(__this, NULL);
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		int32_t L_1;
		L_1 = GooglePurchase_get_purchaseState_m25B05A607B60519FBA52843CAEF8FD8FEE0752A9_inline(__this, NULL);
		int32_t L_2;
		L_2 = GooglePurchaseStateEnum_Purchased_m3791A59F7885C918735F78345549C35C39E661F0(NULL);
		return (bool)((((int32_t)L_1) == ((int32_t)L_2))? 1 : 0);
	}

IL_0016:
	{
		return (bool)0;
	}
}
// System.Boolean UnityEngine.Purchasing.Models.GooglePurchase::IsPending()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool GooglePurchase_IsPending_mB50CFCB4540C15FEEE6853C95CE3155C3D4C9E66 (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// return javaPurchase != null && purchaseState == GooglePurchaseStateEnum.Pending();
		RuntimeObject* L_0;
		L_0 = GooglePurchase_get_javaPurchase_m82A168C3FB80849E2B85BED12EE4DCA6E58CEC18_inline(__this, NULL);
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		int32_t L_1;
		L_1 = GooglePurchase_get_purchaseState_m25B05A607B60519FBA52843CAEF8FD8FEE0752A9_inline(__this, NULL);
		int32_t L_2;
		L_2 = GooglePurchaseStateEnum_Pending_m419C6870D3097EADAF00FF0D6FF5C486BFB13171(NULL);
		return (bool)((((int32_t)L_1) == ((int32_t)L_2))? 1 : 0);
	}

IL_0016:
	{
		return (bool)0;
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
// System.Void UnityEngine.Purchasing.Models.GooglePurchase/<>c::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__cctor_m3B5205D71CD68DEE8540207194DC751BCC9794B5 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2* L_0 = (U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2*)il2cpp_codegen_object_new(U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		U3CU3Ec__ctor_m696F4E3E542DD5C7ADEFA41805FB149F796B836A(L_0, NULL);
		((U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var))->___U3CU3E9_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_StaticFields*)il2cpp_codegen_static_fields_for(U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2_il2cpp_TypeInfo_var))->___U3CU3E9_0), (void*)L_0);
		return;
	}
}
// System.Void UnityEngine.Purchasing.Models.GooglePurchase/<>c::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CU3Ec__ctor_m696F4E3E542DD5C7ADEFA41805FB149F796B836A (U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
// System.String UnityEngine.Purchasing.Models.GooglePurchase/<>c::<.ctor>b__26_0(UnityEngine.Purchasing.Utils.IAndroidJavaObjectWrapper)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* U3CU3Ec_U3C_ctorU3Eb__26_0_mB666CC9852E094F68F830014EA039871BBF416BA (U3CU3Ec_t5F4A44F3BE5DBDC253279EFFC260CCE4AC510CC2* __this, RuntimeObject* ___skuDetail0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IAndroidJavaObjectWrapper_Call_TisString_t_m1A02C80883EF91CD3314D0856FE96818794AA538_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9303FDBBA3EA9F42A781A1107ABF8F1702BF684C);
		s_Il2CppMethodInitialized = true;
	}
	{
		// var skuDetailsJson = skuDetails.Select(skuDetail => skuDetail.Call<string>("getOriginalJson")).ToList();
		RuntimeObject* L_0 = ___skuDetail0;
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_1;
		L_1 = Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_inline(Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_RuntimeMethod_var);
		NullCheck(L_0);
		String_t* L_2;
		L_2 = GenericInterfaceFuncInvoker2< String_t*, String_t*, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* >::Invoke(IAndroidJavaObjectWrapper_Call_TisString_t_m1A02C80883EF91CD3314D0856FE96818794AA538_RuntimeMethod_var, L_0, _stringLiteral9303FDBBA3EA9F42A781A1107ABF8F1702BF684C, L_1);
		return L_2;
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
// UnityEngine.AndroidJavaObject UnityEngine.Purchasing.Models.GooglePurchaseStateEnum::GetPurchaseStateJavaObject()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* GooglePurchaseStateEnum_GetPurchaseStateJavaObject_mBEFD71488906CB2105D270DACD285AFFE95C89E1 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AndroidJavaClass_tE6296B30CC4BF84434A9B765267F3FD0DD8DDB03_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralF3DB8521ADB71488B0A3D538F58F98B35E326552);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return new AndroidJavaClass(k_AndroidPurchaseStateClassName);
		AndroidJavaClass_tE6296B30CC4BF84434A9B765267F3FD0DD8DDB03* L_0 = (AndroidJavaClass_tE6296B30CC4BF84434A9B765267F3FD0DD8DDB03*)il2cpp_codegen_object_new(AndroidJavaClass_tE6296B30CC4BF84434A9B765267F3FD0DD8DDB03_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		AndroidJavaClass__ctor_mB5466169E1151B8CC44C8FED234D79984B431389(L_0, _stringLiteralF3DB8521ADB71488B0A3D538F58F98B35E326552, NULL);
		return L_0;
	}
}
// System.Int32 UnityEngine.Purchasing.Models.GooglePurchaseStateEnum::Purchased()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t GooglePurchaseStateEnum_Purchased_m3791A59F7885C918735F78345549C35C39E661F0 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AndroidJavaObject_GetStatic_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m740F3401DEA4A75BADD753EFF71D2328B4147BFC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral6DAB35E4EA4BBD5AF1473155FA1288D974D1DAD9);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return GetPurchaseStateJavaObject().GetStatic<int>("PURCHASED");
		AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* L_0;
		L_0 = GooglePurchaseStateEnum_GetPurchaseStateJavaObject_mBEFD71488906CB2105D270DACD285AFFE95C89E1(NULL);
		NullCheck(L_0);
		int32_t L_1;
		L_1 = AndroidJavaObject_GetStatic_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m740F3401DEA4A75BADD753EFF71D2328B4147BFC(L_0, _stringLiteral6DAB35E4EA4BBD5AF1473155FA1288D974D1DAD9, AndroidJavaObject_GetStatic_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m740F3401DEA4A75BADD753EFF71D2328B4147BFC_RuntimeMethod_var);
		return L_1;
	}
}
// System.Int32 UnityEngine.Purchasing.Models.GooglePurchaseStateEnum::Pending()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t GooglePurchaseStateEnum_Pending_m419C6870D3097EADAF00FF0D6FF5C486BFB13171 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AndroidJavaObject_GetStatic_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m740F3401DEA4A75BADD753EFF71D2328B4147BFC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralE621E6581BCE23AE171A5EFE8813FCCCF6DC45FF);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return GetPurchaseStateJavaObject().GetStatic<int>("PENDING");
		AndroidJavaObject_t8FFB930F335C1178405B82AC2BF512BB1EEF9EB0* L_0;
		L_0 = GooglePurchaseStateEnum_GetPurchaseStateJavaObject_mBEFD71488906CB2105D270DACD285AFFE95C89E1(NULL);
		NullCheck(L_0);
		int32_t L_1;
		L_1 = AndroidJavaObject_GetStatic_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m740F3401DEA4A75BADD753EFF71D2328B4147BFC(L_0, _stringLiteralE621E6581BCE23AE171A5EFE8813FCCCF6DC45FF, AndroidJavaObject_GetStatic_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m740F3401DEA4A75BADD753EFF71D2328B4147BFC_RuntimeMethod_var);
		return L_1;
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
// System.Int32 UnityEngine.Purchasing.Models.GooglePurchaseStateEnumProvider::Purchased()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t GooglePurchaseStateEnumProvider_Purchased_m367280B3C4A0D25DE27159A38A1F7E8E10835F40 (GooglePurchaseStateEnumProvider_t4F9C48DADF977FD31FFE29D767F092126332683A* __this, const RuntimeMethod* method) 
{
	{
		// return GooglePurchaseStateEnum.Purchased();
		int32_t L_0;
		L_0 = GooglePurchaseStateEnum_Purchased_m3791A59F7885C918735F78345549C35C39E661F0(NULL);
		return L_0;
	}
}
// System.Int32 UnityEngine.Purchasing.Models.GooglePurchaseStateEnumProvider::Pending()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t GooglePurchaseStateEnumProvider_Pending_mDF35C16DB0772027E6013DFBA15969B13E3C0B75 (GooglePurchaseStateEnumProvider_t4F9C48DADF977FD31FFE29D767F092126332683A* __this, const RuntimeMethod* method) 
{
	{
		// return GooglePurchaseStateEnum.Pending();
		int32_t L_0;
		L_0 = GooglePurchaseStateEnum_Pending_m419C6870D3097EADAF00FF0D6FF5C486BFB13171(NULL);
		return L_0;
	}
}
// System.Void UnityEngine.Purchasing.Models.GooglePurchaseStateEnumProvider::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GooglePurchaseStateEnumProvider__ctor_mBE9E27B95EC11A8AD90B102BF49D0DD6CCA80780 (GooglePurchaseStateEnumProvider_t4F9C48DADF977FD31FFE29D767F092126332683A* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
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
// System.String UnityEngine.Purchasing.Models.GoogleSkuTypeEnum::InApp()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GoogleSkuTypeEnum_InApp_m3D8DF28E36C52A558A171EBE49300FE42E73C0B9 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralA44250C90C4461C6F602B3B9DC9B873627787D3B);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return "inapp";
		return _stringLiteralA44250C90C4461C6F602B3B9DC9B873627787D3B;
	}
}
// System.String UnityEngine.Purchasing.Models.GoogleSkuTypeEnum::Sub()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* GoogleSkuTypeEnum_Sub_m67C8DA9DA489930486A1A308049B9C52C2C071C3 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC5EE8C59C90DE1E698A3010542A9B964C720ED30);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return "subs";
		return _stringLiteralC5EE8C59C90DE1E698A3010542A9B964C720ED30;
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
// System.Void UnityEngine.Purchasing.Models.ProductDescriptionQuery::.ctor(System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>,System.Action`1<System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>>,System.Action`1<UnityEngine.Purchasing.Models.GoogleRetrieveProductsFailureReason>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ProductDescriptionQuery__ctor_m359F071042E9EC689BA607F3D222FB59EB0DE04B (ProductDescriptionQuery_t03B36576574F6E71672313472421EE2FB8C5BFAE* __this, ReadOnlyCollection_1_tA49701F42E3782EB8804C53D26901317BAD43A9E* ___products0, Action_1_tA72D33CF2F54A3A2B5EA5FC85BF59006A8BCC2BE* ___onProductsReceived1, Action_1_t827DD5268A2273F9357827BCDAB0FD15F77CD462* ___onRetrieveProductsFailed2, const RuntimeMethod* method) 
{
	{
		// internal ProductDescriptionQuery(ReadOnlyCollection<ProductDefinition> products, Action<List<ProductDescription>> onProductsReceived, Action<GoogleRetrieveProductsFailureReason> onRetrieveProductsFailed)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// this.products = products;
		ReadOnlyCollection_1_tA49701F42E3782EB8804C53D26901317BAD43A9E* L_0 = ___products0;
		__this->___products_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___products_0), (void*)L_0);
		// this.onProductsReceived = onProductsReceived;
		Action_1_tA72D33CF2F54A3A2B5EA5FC85BF59006A8BCC2BE* L_1 = ___onProductsReceived1;
		__this->___onProductsReceived_1 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___onProductsReceived_1), (void*)L_1);
		// this.onRetrieveProductsFailed = onRetrieveProductsFailed;
		Action_1_t827DD5268A2273F9357827BCDAB0FD15F77CD462* L_2 = ___onRetrieveProductsFailed2;
		__this->___onRetrieveProductsFailed_2 = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___onRetrieveProductsFailed_2), (void*)L_2);
		// }
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
// System.UInt32 <PrivateImplementationDetails>::ComputeStringHash(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t U3CPrivateImplementationDetailsU3E_ComputeStringHash_m88B6F9ABC0B2644814DC58FB9602948572F7E971 (String_t* ___s0, const RuntimeMethod* method) 
{
	uint32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		String_t* L_0 = ___s0;
		if (!L_0)
		{
			goto IL_002a;
		}
	}
	{
		V_0 = ((int32_t)-2128831035);
		V_1 = 0;
		goto IL_0021;
	}

IL_000d:
	{
		String_t* L_1 = ___s0;
		int32_t L_2 = V_1;
		NullCheck(L_1);
		Il2CppChar L_3;
		L_3 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_1, L_2, NULL);
		uint32_t L_4 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_multiply(((int32_t)((int32_t)L_3^(int32_t)L_4)), ((int32_t)16777619)));
		int32_t L_5 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_5, 1));
	}

IL_0021:
	{
		int32_t L_6 = V_1;
		String_t* L_7 = ___s0;
		NullCheck(L_7);
		int32_t L_8;
		L_8 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_7, NULL);
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_000d;
		}
	}

IL_002a:
	{
		uint32_t L_9 = V_0;
		return L_9;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* GooglePurchase_get_skus_mFB5A449AA1EE9433CFE668CDE90A55B7FDEB81A4_inline (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public List<string> skus { get; }
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_0 = __this->___U3CskusU3Ek__BackingField_2;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* GooglePurchase_get_originalJson_m6708011BD0AE03F2280CD86A0F07875EA578D5BA_inline (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public string originalJson { get; }
		String_t* L_0 = __this->___U3CoriginalJsonU3Ek__BackingField_6;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR String_t* GooglePurchase_get_signature_m72063440F5794869DB8A4DE3F56A73F4444786AC_inline (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public string signature { get; }
		String_t* L_0 = __this->___U3CsignatureU3Ek__BackingField_5;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* GooglePurchase_get_javaPurchase_m82A168C3FB80849E2B85BED12EE4DCA6E58CEC18_inline (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public IAndroidJavaObjectWrapper javaPurchase { get; }
		RuntimeObject* L_0 = __this->___U3CjavaPurchaseU3Ek__BackingField_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t GooglePurchase_get_purchaseState_m25B05A607B60519FBA52843CAEF8FD8FEE0752A9_inline (GooglePurchase_tFABB74E360ED620F60451B0E688B98BA378C0EDF* __this, const RuntimeMethod* method) 
{
	{
		// public int purchaseState { get; }
		int32_t L_0 = __this->___U3CpurchaseStateU3Ek__BackingField_1;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____stringLength_4;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* Array_Empty_TisRuntimeObject_mFB8A63D602BB6974D31E20300D9EB89C6FE7C278_gshared_inline (const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(method->rgctx_data, 2));
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_0 = ((EmptyArray_1_tDF0DD7256B115243AA6BD5558417387A734240EE_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(method->rgctx_data, 2)))->___Value_0;
		return L_0;
	}
}
