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
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
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

// System.Double
struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	// System.Double System.Double::m_value
	double ___m_value_0;
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
// System.Double UnityEngine.Purchasing.iOSStoreBindings::getUnityPurchasingAppReceiptModificationDate()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double iOSStoreBindings_getUnityPurchasingAppReceiptModificationDate_m2FC5CA9222966AB9871B34F8FF16C21531323937 (const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingRetrieveProducts(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRetrieveProducts_m42525F0667E3A76B7E5C5B6DA5E5EB599BFDE3DE (String_t* ___json0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingPurchase(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingPurchase_mA2C0009A6B4DEF4CBCE1731D6460A6BCB1485DD6 (String_t* ___json0, String_t* ___developerPayload1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingFinishTransaction(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingFinishTransaction_m8AC4AED5DD0D03966512020380D4EB8C3BD89BB6 (String_t* ___productJSON0, String_t* ___transactionId1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingRestoreTransactions()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRestoreTransactions_mABD58E5CFAEF13D3EEE8EBBD2393C86D3B0B1099 (const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingAddTransactionObserver()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingAddTransactionObserver_mDAE9E8FF1BFDDA43A9BED7156F154C238638C420 (const RuntimeMethod* method) ;
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingInterceptPromotionalPurchases()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingInterceptPromotionalPurchases_mC95655465276823D57CABBE7DE98095F7FF34D26 (const RuntimeMethod* method) ;
// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingRetrieveProducts(char*);
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingPurchase(char*, char*);
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingFinishTransaction(char*, char*);
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingRestoreTransactions();
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingAddTransactionObserver();
IL2CPP_EXTERN_C void DEFAULT_CALL setUnityPurchasingCallback(Il2CppMethodPointer);
IL2CPP_EXTERN_C char* DEFAULT_CALL getUnityPurchasingAppReceipt();
IL2CPP_EXTERN_C double DEFAULT_CALL getUnityPurchasingAppReceiptModificationDate();
IL2CPP_EXTERN_C void DEFAULT_CALL unityPurchasingInterceptPromotionalPurchases();
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
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingAddTransactionObserver()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingAddTransactionObserver_mDAE9E8FF1BFDDA43A9BED7156F154C238638C420 (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingAddTransactionObserver)();

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
// System.Double UnityEngine.Purchasing.iOSStoreBindings::getUnityPurchasingAppReceiptModificationDate()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double iOSStoreBindings_getUnityPurchasingAppReceiptModificationDate_m2FC5CA9222966AB9871B34F8FF16C21531323937 (const RuntimeMethod* method) 
{
	typedef double (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	double returnValue = reinterpret_cast<PInvokeFunc>(getUnityPurchasingAppReceiptModificationDate)();

	return returnValue;
}
// System.Void UnityEngine.Purchasing.iOSStoreBindings::unityPurchasingInterceptPromotionalPurchases()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingInterceptPromotionalPurchases_mC95655465276823D57CABBE7DE98095F7FF34D26 (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(unityPurchasingInterceptPromotionalPurchases)();

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
// System.Double UnityEngine.Purchasing.iOSStoreBindings::get_appReceiptModificationDate()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double iOSStoreBindings_get_appReceiptModificationDate_mC7AC0A0F94BF888309429DCDBB319CCDCD0330A2 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		// return getUnityPurchasingAppReceiptModificationDate();
		double L_0;
		L_0 = iOSStoreBindings_getUnityPurchasingAppReceiptModificationDate_m2FC5CA9222966AB9871B34F8FF16C21531323937(NULL);
		return L_0;
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
