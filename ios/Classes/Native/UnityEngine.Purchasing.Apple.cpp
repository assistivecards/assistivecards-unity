#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>



// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C;
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
// System.IAsyncResult
struct IAsyncResult_t7B9B5A0ECB35DCEC31B8A8122C37D687369253B5;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.String
struct String_t;
// UnityEngine.Purchasing.UnityPurchasingCallback
struct UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// UnityEngine.Purchasing.iOSStoreBindings
struct iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E;

struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_t4C00C1EFBBF42D901D63C66F365574C5EA10B872 
{
};
struct Il2CppArrayBounds;

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

// UnityEngine.Purchasing.iOSStoreBindings
struct iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E  : public RuntimeObject
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

// UnityEngine.Purchasing.UnityPurchasingCallback
struct UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D  : public MulticastDelegate_t
{
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void UnityEngine.Purchasing.iOSStoreBindings::setUnityPurchasingCallback(UnityEngine.Purchasing.UnityPurchasingCallback)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_setUnityPurchasingCallback_mC81D3CFFC1A696A7B544AC3E78F404D51CA493C1 (UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D* ___AsyncCallback0, const RuntimeMethod* method) ;
// System.String UnityEngine.Purchasing.iOSStoreBindings::getUnityPurchasingAppReceipt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* iOSStoreBindings_getUnityPurchasingAppReceipt_m433D81E20669CD44CB5433D7898D677C64DB5909 (const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Purchasing.iOSStoreBindings::getUnityPurchasingCanMakePayments()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool iOSStoreBindings_getUnityPurchasingCanMakePayments_m7165B2D78FC134F2FB59BC3C526608D37ED46CE4 (const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Purchasing.iOSStoreBindings::getSimulateAskToBuy()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool iOSStoreBindings_getSimulateAskToBuy_m501AF46B73C5A1342A5C093232F1E01F8071819A (const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::setSimulateAskToBuy(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_setSimulateAskToBuy_mC9852DE91DE9B52E01C55EAFBB9A4158CD35A7F8 (bool ___enabled0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingRetrieveProducts(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRetrieveProducts_m42525F0667E3A76B7E5C5B6DA5E5EB599BFDE3DE (String_t* ___json0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingPurchase(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingPurchase_mA2C0009A6B4DEF4CBCE1731D6460A6BCB1485DD6 (String_t* ___json0, String_t* ___developerPayload1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingFinishTransaction(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingFinishTransaction_m8AC4AED5DD0D03966512020380D4EB8C3BD89BB6 (String_t* ___productJSON0, String_t* ___transactionId1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingRestoreTransactions()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRestoreTransactions_mABD58E5CFAEF13D3EEE8EBBD2393C86D3B0B1099 (const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingRefreshAppReceipt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRefreshAppReceipt_m326F49CF1D69D848C47B43429D6FC9A476EBE19E (const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingAddTransactionObserver()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingAddTransactionObserver_mDAE9E8FF1BFDDA43A9BED7156F154C238638C420 (const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingSetApplicationUsername(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingSetApplicationUsername_mAA258904A394645E60C8024C599CC406CCDBEB5F (String_t* ___username0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingFetchStorePromotionOrder()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingFetchStorePromotionOrder_m2F95709BA1BDC8982C7919877F5CE3EADFFDB8AA (const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingUpdateStorePromotionOrder(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingUpdateStorePromotionOrder_mC1E8D1C7B69BE15C82DF1C934928D6D90C903635 (String_t* ___json0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingFetchStorePromotionVisibility(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingFetchStorePromotionVisibility_m81718997786F6EAE2A2F89CC82F8418E950CA120 (String_t* ___productId0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingUpdateStorePromotionVisibility(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingUpdateStorePromotionVisibility_m0976B5438459E52603A1A5C3AA4DF8BE982F8CD9 (String_t* ___productId0, String_t* ___visibility1, const RuntimeMethod* method) ;
// System.String UnityEngine.Purchasing.iOSStoreBindings::getUnityPurchasingTransactionReceiptForProductId(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* iOSStoreBindings_getUnityPurchasingTransactionReceiptForProductId_m2F9C011209E04D17A86F89297F3298C9F4102D96 (String_t* ___productId0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingInterceptPromotionalPurchases()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingInterceptPromotionalPurchases_mC95655465276823D57CABBE7DE98095F7FF34D26 (const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingContinuePromotionalPurchases()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingContinuePromotionalPurchases_m219EE72E8AA4E71EF434D6F0DEBD148544A70BDF (const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingPresentCodeRedemptionSheet()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingPresentCodeRedemptionSheet_m7C2F91F6425B220B21150C9D8A82A84259EC4446 (const RuntimeMethod* method) ;
// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingRetrieveProducts(char*);
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingPurchase(char*, char*);
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingFinishTransaction(char*, char*);
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingRestoreTransactions();
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingRefreshAppReceipt();
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingAddTransactionObserver();
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingSetApplicationUsername(char*);
IL2CPP_EXTERN_C void DEFAULT_CALL setUnityPurchasingCallback(Il2CppMethodPointer);
IL2CPP_EXTERN_C char* DEFAULT_CALL getUnityPurchasingAppReceipt();
IL2CPP_EXTERN_C char* DEFAULT_CALL getUnityPurchasingTransactionReceiptForProductId(char*);
IL2CPP_EXTERN_C int32_t DEFAULT_CALL getUnityPurchasingCanMakePayments();
IL2CPP_EXTERN_C void DEFAULT_CALL setSimulateAskToBuy(int32_t);
IL2CPP_EXTERN_C int32_t DEFAULT_CALL getSimulateAskToBuy();
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingFetchStorePromotionOrder();
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingUpdateStorePromotionOrder(char*);
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingFetchStorePromotionVisibility(char*);
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingUpdateStorePromotionVisibility(char*, char*);
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingInterceptPromotionalPurchases();
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingContinuePromotionalPurchases();
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingPresentCodeRedemptionSheet();
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
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingRetrieveProducts(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRetrieveProducts_m42525F0667E3A76B7E5C5B6DA5E5EB599BFDE3DE (String_t* ___json0, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*);

	// Marshaling of parameter '___json0' to native representation
	char* ____json0_marshaled = NULL;
	____json0_marshaled = il2cpp_codegen_marshal_string(___json0);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingRetrieveProducts)(____json0_marshaled);

	// Marshaling cleanup of parameter '___json0' native representation
	il2cpp_codegen_marshal_free(____json0_marshaled);
	____json0_marshaled = NULL;

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingPurchase(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingPurchase_mA2C0009A6B4DEF4CBCE1731D6460A6BCB1485DD6 (String_t* ___json0, String_t* ___developerPayload1, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*, char*);

	// Marshaling of parameter '___json0' to native representation
	char* ____json0_marshaled = NULL;
	____json0_marshaled = il2cpp_codegen_marshal_string(___json0);

	// Marshaling of parameter '___developerPayload1' to native representation
	char* ____developerPayload1_marshaled = NULL;
	____developerPayload1_marshaled = il2cpp_codegen_marshal_string(___developerPayload1);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingPurchase)(____json0_marshaled, ____developerPayload1_marshaled);

	// Marshaling cleanup of parameter '___json0' native representation
	il2cpp_codegen_marshal_free(____json0_marshaled);
	____json0_marshaled = NULL;

	// Marshaling cleanup of parameter '___developerPayload1' native representation
	il2cpp_codegen_marshal_free(____developerPayload1_marshaled);
	____developerPayload1_marshaled = NULL;

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingFinishTransaction(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingFinishTransaction_m8AC4AED5DD0D03966512020380D4EB8C3BD89BB6 (String_t* ___productJSON0, String_t* ___transactionId1, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*, char*);

	// Marshaling of parameter '___productJSON0' to native representation
	char* ____productJSON0_marshaled = NULL;
	____productJSON0_marshaled = il2cpp_codegen_marshal_string(___productJSON0);

	// Marshaling of parameter '___transactionId1' to native representation
	char* ____transactionId1_marshaled = NULL;
	____transactionId1_marshaled = il2cpp_codegen_marshal_string(___transactionId1);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingFinishTransaction)(____productJSON0_marshaled, ____transactionId1_marshaled);

	// Marshaling cleanup of parameter '___productJSON0' native representation
	il2cpp_codegen_marshal_free(____productJSON0_marshaled);
	____productJSON0_marshaled = NULL;

	// Marshaling cleanup of parameter '___transactionId1' native representation
	il2cpp_codegen_marshal_free(____transactionId1_marshaled);
	____transactionId1_marshaled = NULL;

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingRestoreTransactions()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRestoreTransactions_mABD58E5CFAEF13D3EEE8EBBD2393C86D3B0B1099 (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingRestoreTransactions)();

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingRefreshAppReceipt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRefreshAppReceipt_m326F49CF1D69D848C47B43429D6FC9A476EBE19E (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingRefreshAppReceipt)();

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingAddTransactionObserver()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingAddTransactionObserver_mDAE9E8FF1BFDDA43A9BED7156F154C238638C420 (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingAddTransactionObserver)();

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingSetApplicationUsername(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingSetApplicationUsername_mAA258904A394645E60C8024C599CC406CCDBEB5F (String_t* ___username0, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*);

	// Marshaling of parameter '___username0' to native representation
	char* ____username0_marshaled = NULL;
	____username0_marshaled = il2cpp_codegen_marshal_string(___username0);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingSetApplicationUsername)(____username0_marshaled);

	// Marshaling cleanup of parameter '___username0' native representation
	il2cpp_codegen_marshal_free(____username0_marshaled);
	____username0_marshaled = NULL;

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::setUnityPurchasingCallback(UnityEngine.Purchasing.UnityPurchasingCallback)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_setUnityPurchasingCallback_mC81D3CFFC1A696A7B544AC3E78F404D51CA493C1 (UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D* ___AsyncCallback0, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (Il2CppMethodPointer);

	// Marshaling of parameter '___AsyncCallback0' to native representation
	Il2CppMethodPointer ____AsyncCallback0_marshaled = NULL;
	____AsyncCallback0_marshaled = il2cpp_codegen_marshal_delegate(reinterpret_cast<MulticastDelegate_t*>(___AsyncCallback0));

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(setUnityPurchasingCallback)(____AsyncCallback0_marshaled);

}
// System.String UnityEngine.Purchasing.iOSStoreBindings::getUnityPurchasingAppReceipt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* iOSStoreBindings_getUnityPurchasingAppReceipt_m433D81E20669CD44CB5433D7898D677C64DB5909 (const RuntimeMethod* method) 
{
	typedef char* (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	char* returnValue = reinterpret_cast<PInvokeFunc>(getUnityPurchasingAppReceipt)();

	// Marshaling of return value back from native representation
	String_t* _returnValue_unmarshaled = NULL;
	_returnValue_unmarshaled = il2cpp_codegen_marshal_string_result(returnValue);

	// Marshaling cleanup of return value native representation
	il2cpp_codegen_marshal_free(returnValue);
	returnValue = NULL;

	return _returnValue_unmarshaled;
}
// System.String UnityEngine.Purchasing.iOSStoreBindings::getUnityPurchasingTransactionReceiptForProductId(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* iOSStoreBindings_getUnityPurchasingTransactionReceiptForProductId_m2F9C011209E04D17A86F89297F3298C9F4102D96 (String_t* ___productId0, const RuntimeMethod* method) 
{
	typedef char* (DEFAULT_CALL *PInvokeFunc) (char*);

	// Marshaling of parameter '___productId0' to native representation
	char* ____productId0_marshaled = NULL;
	____productId0_marshaled = il2cpp_codegen_marshal_string(___productId0);

	// Native function invocation
	char* returnValue = reinterpret_cast<PInvokeFunc>(getUnityPurchasingTransactionReceiptForProductId)(____productId0_marshaled);

	// Marshaling of return value back from native representation
	String_t* _returnValue_unmarshaled = NULL;
	_returnValue_unmarshaled = il2cpp_codegen_marshal_string_result(returnValue);

	// Marshaling cleanup of return value native representation
	il2cpp_codegen_marshal_free(returnValue);
	returnValue = NULL;

	// Marshaling cleanup of parameter '___productId0' native representation
	il2cpp_codegen_marshal_free(____productId0_marshaled);
	____productId0_marshaled = NULL;

	return _returnValue_unmarshaled;
}
// System.Boolean UnityEngine.Purchasing.iOSStoreBindings::getUnityPurchasingCanMakePayments()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool iOSStoreBindings_getUnityPurchasingCanMakePayments_m7165B2D78FC134F2FB59BC3C526608D37ED46CE4 (const RuntimeMethod* method) 
{
	typedef int32_t (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	int32_t returnValue = reinterpret_cast<PInvokeFunc>(getUnityPurchasingCanMakePayments)();

	return static_cast<bool>(returnValue);
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::setSimulateAskToBuy(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_setSimulateAskToBuy_mC9852DE91DE9B52E01C55EAFBB9A4158CD35A7F8 (bool ___enabled0, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(setSimulateAskToBuy)(static_cast<int32_t>(___enabled0));

}
// System.Boolean UnityEngine.Purchasing.iOSStoreBindings::getSimulateAskToBuy()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool iOSStoreBindings_getSimulateAskToBuy_m501AF46B73C5A1342A5C093232F1E01F8071819A (const RuntimeMethod* method) 
{
	typedef int32_t (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	int32_t returnValue = reinterpret_cast<PInvokeFunc>(getSimulateAskToBuy)();

	return static_cast<bool>(returnValue);
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingFetchStorePromotionOrder()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingFetchStorePromotionOrder_m2F95709BA1BDC8982C7919877F5CE3EADFFDB8AA (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingFetchStorePromotionOrder)();

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingUpdateStorePromotionOrder(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingUpdateStorePromotionOrder_mC1E8D1C7B69BE15C82DF1C934928D6D90C903635 (String_t* ___json0, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*);

	// Marshaling of parameter '___json0' to native representation
	char* ____json0_marshaled = NULL;
	____json0_marshaled = il2cpp_codegen_marshal_string(___json0);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingUpdateStorePromotionOrder)(____json0_marshaled);

	// Marshaling cleanup of parameter '___json0' native representation
	il2cpp_codegen_marshal_free(____json0_marshaled);
	____json0_marshaled = NULL;

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingFetchStorePromotionVisibility(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingFetchStorePromotionVisibility_m81718997786F6EAE2A2F89CC82F8418E950CA120 (String_t* ___productId0, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*);

	// Marshaling of parameter '___productId0' to native representation
	char* ____productId0_marshaled = NULL;
	____productId0_marshaled = il2cpp_codegen_marshal_string(___productId0);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingFetchStorePromotionVisibility)(____productId0_marshaled);

	// Marshaling cleanup of parameter '___productId0' native representation
	il2cpp_codegen_marshal_free(____productId0_marshaled);
	____productId0_marshaled = NULL;

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingUpdateStorePromotionVisibility(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingUpdateStorePromotionVisibility_m0976B5438459E52603A1A5C3AA4DF8BE982F8CD9 (String_t* ___productId0, String_t* ___visibility1, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*, char*);

	// Marshaling of parameter '___productId0' to native representation
	char* ____productId0_marshaled = NULL;
	____productId0_marshaled = il2cpp_codegen_marshal_string(___productId0);

	// Marshaling of parameter '___visibility1' to native representation
	char* ____visibility1_marshaled = NULL;
	____visibility1_marshaled = il2cpp_codegen_marshal_string(___visibility1);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingUpdateStorePromotionVisibility)(____productId0_marshaled, ____visibility1_marshaled);

	// Marshaling cleanup of parameter '___productId0' native representation
	il2cpp_codegen_marshal_free(____productId0_marshaled);
	____productId0_marshaled = NULL;

	// Marshaling cleanup of parameter '___visibility1' native representation
	il2cpp_codegen_marshal_free(____visibility1_marshaled);
	____visibility1_marshaled = NULL;

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingInterceptPromotionalPurchases()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingInterceptPromotionalPurchases_mC95655465276823D57CABBE7DE98095F7FF34D26 (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingInterceptPromotionalPurchases)();

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingContinuePromotionalPurchases()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingContinuePromotionalPurchases_m219EE72E8AA4E71EF434D6F0DEBD148544A70BDF (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingContinuePromotionalPurchases)();

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingPresentCodeRedemptionSheet()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingPresentCodeRedemptionSheet_m7C2F91F6425B220B21150C9D8A82A84259EC4446 (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingPresentCodeRedemptionSheet)();

}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::SetUnityPurchasingCallback(UnityEngine.Purchasing.UnityPurchasingCallback)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_SetUnityPurchasingCallback_m81C53A0B93AA28C42A99F4B8F7F9839AA6ACC2BC (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D* ___AsyncCallback0, const RuntimeMethod* method) 
{
	{
		// setUnityPurchasingCallback(AsyncCallback);
		UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D* L_0 = ___AsyncCallback0;
		iOSStoreBindings_setUnityPurchasingCallback_mC81D3CFFC1A696A7B544AC3E78F404D51CA493C1(L_0, NULL);
		// }
		return;
	}
}
// System.String UnityEngine.Purchasing.iOSStoreBindings::get_appReceipt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* iOSStoreBindings_get_appReceipt_m5601637B09453E936F4EAAEBB1538C919BC27B24 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		// return getUnityPurchasingAppReceipt();
		String_t* L_0;
		L_0 = iOSStoreBindings_getUnityPurchasingAppReceipt_m433D81E20669CD44CB5433D7898D677C64DB5909(NULL);
		return L_0;
	}
}
// System.Boolean UnityEngine.Purchasing.iOSStoreBindings::get_canMakePayments()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool iOSStoreBindings_get_canMakePayments_mD295FD49B83BAAA36A0D0BD9008AE34E127390E9 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		// return getUnityPurchasingCanMakePayments();
		bool L_0;
		L_0 = iOSStoreBindings_getUnityPurchasingCanMakePayments_m7165B2D78FC134F2FB59BC3C526608D37ED46CE4(NULL);
		return L_0;
	}
}
// System.Boolean UnityEngine.Purchasing.iOSStoreBindings::get_simulateAskToBuy()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool iOSStoreBindings_get_simulateAskToBuy_mE2EA37FBA4998385EB924C24E88C4163A6F3EC2B (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		// return getSimulateAskToBuy();
		bool L_0;
		L_0 = iOSStoreBindings_getSimulateAskToBuy_m501AF46B73C5A1342A5C093232F1E01F8071819A(NULL);
		return L_0;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::set_simulateAskToBuy(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_set_simulateAskToBuy_m5280954CB6ACC39C66173404D610727C599E0DEB (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, bool ___value0, const RuntimeMethod* method) 
{
	{
		// setSimulateAskToBuy(value);
		bool L_0 = ___value0;
		iOSStoreBindings_setSimulateAskToBuy_mC9852DE91DE9B52E01C55EAFBB9A4158CD35A7F8(L_0, NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::RetrieveProducts(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_RetrieveProducts_m523D9AFA65C09DBDB8963047E72DEC16B667E824 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, String_t* ___json0, const RuntimeMethod* method) 
{
	{
		// unityPurchasingRetrieveProducts(json);
		String_t* L_0 = ___json0;
		iOSStoreBindings_unityPurchasingRetrieveProducts_m42525F0667E3A76B7E5C5B6DA5E5EB599BFDE3DE(L_0, NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::Purchase(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_Purchase_m7AEA75645B7492A678C63FF7CDE56F8E75AB64F7 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, String_t* ___productJSON0, String_t* ___developerPayload1, const RuntimeMethod* method) 
{
	{
		// unityPurchasingPurchase(productJSON, developerPayload);
		String_t* L_0 = ___productJSON0;
		String_t* L_1 = ___developerPayload1;
		iOSStoreBindings_unityPurchasingPurchase_mA2C0009A6B4DEF4CBCE1731D6460A6BCB1485DD6(L_0, L_1, NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::FinishTransaction(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_FinishTransaction_m566E3AFFFEADEE7F71D9934A0DBA2AB1BF76B49E (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, String_t* ___productJSON0, String_t* ___transactionId1, const RuntimeMethod* method) 
{
	{
		// unityPurchasingFinishTransaction(productJSON, transactionId);
		String_t* L_0 = ___productJSON0;
		String_t* L_1 = ___transactionId1;
		iOSStoreBindings_unityPurchasingFinishTransaction_m8AC4AED5DD0D03966512020380D4EB8C3BD89BB6(L_0, L_1, NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::RestoreTransactions()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_RestoreTransactions_m2177F40DC549B229C8660387DD433AE8FD2A8652 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		// unityPurchasingRestoreTransactions();
		iOSStoreBindings_unityPurchasingRestoreTransactions_mABD58E5CFAEF13D3EEE8EBBD2393C86D3B0B1099(NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::RefreshAppReceipt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_RefreshAppReceipt_m1B8EA825E6A6C7AB3151D08D6E247BD52941E651 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		// unityPurchasingRefreshAppReceipt();
		iOSStoreBindings_unityPurchasingRefreshAppReceipt_m326F49CF1D69D848C47B43429D6FC9A476EBE19E(NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::AddTransactionObserver()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_AddTransactionObserver_m7FB956E6DB7B00AC684CDC5567EE3B77F4544F79 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		// unityPurchasingAddTransactionObserver();
		iOSStoreBindings_unityPurchasingAddTransactionObserver_mDAE9E8FF1BFDDA43A9BED7156F154C238638C420(NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::SetApplicationUsername(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_SetApplicationUsername_mD70B935C15B6E9F4F73795A6949DEAE478DC3FDA (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, String_t* ___applicationUsername0, const RuntimeMethod* method) 
{
	{
		// unityPurchasingSetApplicationUsername(applicationUsername);
		String_t* L_0 = ___applicationUsername0;
		iOSStoreBindings_unityPurchasingSetApplicationUsername_mAA258904A394645E60C8024C599CC406CCDBEB5F(L_0, NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::FetchStorePromotionOrder()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_FetchStorePromotionOrder_mA2360E7A44BAAC14613690EA31B84BC606DEA312 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		// unityPurchasingFetchStorePromotionOrder();
		iOSStoreBindings_unityPurchasingFetchStorePromotionOrder_m2F95709BA1BDC8982C7919877F5CE3EADFFDB8AA(NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::SetStorePromotionOrder(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_SetStorePromotionOrder_m2ECDCB4F5F7DAA1E9D5B314B1652D6B4CFE624AD (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, String_t* ___json0, const RuntimeMethod* method) 
{
	{
		// unityPurchasingUpdateStorePromotionOrder(json);
		String_t* L_0 = ___json0;
		iOSStoreBindings_unityPurchasingUpdateStorePromotionOrder_mC1E8D1C7B69BE15C82DF1C934928D6D90C903635(L_0, NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::FetchStorePromotionVisibility(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_FetchStorePromotionVisibility_m319E4494BF15FAD600AFA8F0983EA62C1F699998 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, String_t* ___productId0, const RuntimeMethod* method) 
{
	{
		// unityPurchasingFetchStorePromotionVisibility(productId);
		String_t* L_0 = ___productId0;
		iOSStoreBindings_unityPurchasingFetchStorePromotionVisibility_m81718997786F6EAE2A2F89CC82F8418E950CA120(L_0, NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::SetStorePromotionVisibility(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_SetStorePromotionVisibility_m267B0F56BA1A13E3238EA630ECF99630F4A85774 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, String_t* ___productId0, String_t* ___visibility1, const RuntimeMethod* method) 
{
	{
		// unityPurchasingUpdateStorePromotionVisibility(productId, visibility);
		String_t* L_0 = ___productId0;
		String_t* L_1 = ___visibility1;
		iOSStoreBindings_unityPurchasingUpdateStorePromotionVisibility_m0976B5438459E52603A1A5C3AA4DF8BE982F8CD9(L_0, L_1, NULL);
		// }
		return;
	}
}
// System.String UnityEngine.Purchasing.iOSStoreBindings::GetTransactionReceiptForProductId(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* iOSStoreBindings_GetTransactionReceiptForProductId_mF001266D57BF247F77ADD318EF2831A80E8550BE (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, String_t* ___productId0, const RuntimeMethod* method) 
{
	{
		// return getUnityPurchasingTransactionReceiptForProductId(productId);
		String_t* L_0 = ___productId0;
		String_t* L_1;
		L_1 = iOSStoreBindings_getUnityPurchasingTransactionReceiptForProductId_m2F9C011209E04D17A86F89297F3298C9F4102D96(L_0, NULL);
		return L_1;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::InterceptPromotionalPurchases()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_InterceptPromotionalPurchases_m626C7254EB165FC41BBFF57092C6638BEC054C41 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		// unityPurchasingInterceptPromotionalPurchases();
		iOSStoreBindings_unityPurchasingInterceptPromotionalPurchases_mC95655465276823D57CABBE7DE98095F7FF34D26(NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::ContinuePromotionalPurchases()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_ContinuePromotionalPurchases_mE705BE7B13893882063C422377530143C629F9A4 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		// unityPurchasingContinuePromotionalPurchases();
		iOSStoreBindings_unityPurchasingContinuePromotionalPurchases_m219EE72E8AA4E71EF434D6F0DEBD148544A70BDF(NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::PresentCodeRedemptionSheet()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_PresentCodeRedemptionSheet_m85459B00B04D145BE21C970E9756686E347B590E (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		// unityPurchasingPresentCodeRedemptionSheet();
		iOSStoreBindings_unityPurchasingPresentCodeRedemptionSheet_m7C2F91F6425B220B21150C9D8A82A84259EC4446(NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings__ctor_m5021264195041D2BDE67FC23F449D81C7DFCFC1A (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
