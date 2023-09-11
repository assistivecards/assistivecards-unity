#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>



struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
struct MethodInfo_t;
struct String_t;
struct UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
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
struct U3CModuleU3E_t4C00C1EFBBF42D901D63C66F365574C5EA10B872 
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E  : public RuntimeObject
{
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	double ___m_value;
};
struct IntPtr_t 
{
	void* ___m_value;
};
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
struct Delegate_t  : public RuntimeObject
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	RuntimeObject* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	bool ___method_is_virtual;
};
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	Il2CppIUnknown* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	int32_t ___method_is_virtual;
};
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	Il2CppIUnknown* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	int32_t ___method_is_virtual;
};
struct MulticastDelegate_t  : public Delegate_t
{
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates;
};
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates;
};
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates;
};
struct UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D  : public MulticastDelegate_t
{
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_setUnityPurchasingCallback_mC81D3CFFC1A696A7B544AC3E78F404D51CA493C1 (UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D* ___0_AsyncCallback, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* iOSStoreBindings_getUnityPurchasingAppReceipt_m433D81E20669CD44CB5433D7898D677C64DB5909 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double iOSStoreBindings_getUnityPurchasingAppReceiptModificationDate_m2FC5CA9222966AB9871B34F8FF16C21531323937 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRetrieveProducts_m42525F0667E3A76B7E5C5B6DA5E5EB599BFDE3DE (String_t* ___0_json, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingPurchase_mA2C0009A6B4DEF4CBCE1731D6460A6BCB1485DD6 (String_t* ___0_json, String_t* ___1_developerPayload, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingFinishTransaction_m8AC4AED5DD0D03966512020380D4EB8C3BD89BB6 (String_t* ___0_productJSON, String_t* ___1_transactionId, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRestoreTransactions_mABD58E5CFAEF13D3EEE8EBBD2393C86D3B0B1099 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingAddTransactionObserver_mDAE9E8FF1BFDDA43A9BED7156F154C238638C420 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingInterceptPromotionalPurchases_mC95655465276823D57CABBE7DE98095F7FF34D26 (const RuntimeMethod* method) ;
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
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRetrieveProducts_m42525F0667E3A76B7E5C5B6DA5E5EB599BFDE3DE (String_t* ___0_json, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*);

	char* ____0_json_marshaled = NULL;
	____0_json_marshaled = il2cpp_codegen_marshal_string(___0_json);

	reinterpret_cast<PInvokeFunc>(unityPurchasingRetrieveProducts)(____0_json_marshaled);

	il2cpp_codegen_marshal_free(____0_json_marshaled);
	____0_json_marshaled = NULL;

}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingPurchase_mA2C0009A6B4DEF4CBCE1731D6460A6BCB1485DD6 (String_t* ___0_json, String_t* ___1_developerPayload, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*, char*);

	char* ____0_json_marshaled = NULL;
	____0_json_marshaled = il2cpp_codegen_marshal_string(___0_json);

	char* ____1_developerPayload_marshaled = NULL;
	____1_developerPayload_marshaled = il2cpp_codegen_marshal_string(___1_developerPayload);

	reinterpret_cast<PInvokeFunc>(unityPurchasingPurchase)(____0_json_marshaled, ____1_developerPayload_marshaled);

	il2cpp_codegen_marshal_free(____0_json_marshaled);
	____0_json_marshaled = NULL;

	il2cpp_codegen_marshal_free(____1_developerPayload_marshaled);
	____1_developerPayload_marshaled = NULL;

}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingFinishTransaction_m8AC4AED5DD0D03966512020380D4EB8C3BD89BB6 (String_t* ___0_productJSON, String_t* ___1_transactionId, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (char*, char*);

	char* ____0_productJSON_marshaled = NULL;
	____0_productJSON_marshaled = il2cpp_codegen_marshal_string(___0_productJSON);

	char* ____1_transactionId_marshaled = NULL;
	____1_transactionId_marshaled = il2cpp_codegen_marshal_string(___1_transactionId);

	reinterpret_cast<PInvokeFunc>(unityPurchasingFinishTransaction)(____0_productJSON_marshaled, ____1_transactionId_marshaled);

	il2cpp_codegen_marshal_free(____0_productJSON_marshaled);
	____0_productJSON_marshaled = NULL;

	il2cpp_codegen_marshal_free(____1_transactionId_marshaled);
	____1_transactionId_marshaled = NULL;

}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingRestoreTransactions_mABD58E5CFAEF13D3EEE8EBBD2393C86D3B0B1099 (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	reinterpret_cast<PInvokeFunc>(unityPurchasingRestoreTransactions)();

}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingAddTransactionObserver_mDAE9E8FF1BFDDA43A9BED7156F154C238638C420 (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	reinterpret_cast<PInvokeFunc>(unityPurchasingAddTransactionObserver)();

}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_setUnityPurchasingCallback_mC81D3CFFC1A696A7B544AC3E78F404D51CA493C1 (UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D* ___0_AsyncCallback, const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (Il2CppMethodPointer);

	Il2CppMethodPointer ____0_AsyncCallback_marshaled = NULL;
	____0_AsyncCallback_marshaled = il2cpp_codegen_marshal_delegate(reinterpret_cast<MulticastDelegate_t*>(___0_AsyncCallback));

	reinterpret_cast<PInvokeFunc>(setUnityPurchasingCallback)(____0_AsyncCallback_marshaled);

}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* iOSStoreBindings_getUnityPurchasingAppReceipt_m433D81E20669CD44CB5433D7898D677C64DB5909 (const RuntimeMethod* method) 
{
	typedef char* (DEFAULT_CALL *PInvokeFunc) ();

	char* returnValue = reinterpret_cast<PInvokeFunc>(getUnityPurchasingAppReceipt)();

	String_t* _returnValue_unmarshaled = NULL;
	_returnValue_unmarshaled = il2cpp_codegen_marshal_string_result(returnValue);

	il2cpp_codegen_marshal_free(returnValue);
	returnValue = NULL;

	return _returnValue_unmarshaled;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double iOSStoreBindings_getUnityPurchasingAppReceiptModificationDate_m2FC5CA9222966AB9871B34F8FF16C21531323937 (const RuntimeMethod* method) 
{
	typedef double (DEFAULT_CALL *PInvokeFunc) ();

	double returnValue = reinterpret_cast<PInvokeFunc>(getUnityPurchasingAppReceiptModificationDate)();

	return returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_unityPurchasingInterceptPromotionalPurchases_mC95655465276823D57CABBE7DE98095F7FF34D26 (const RuntimeMethod* method) 
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	reinterpret_cast<PInvokeFunc>(unityPurchasingInterceptPromotionalPurchases)();

}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_SetUnityPurchasingCallback_m81C53A0B93AA28C42A99F4B8F7F9839AA6ACC2BC (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D* ___0_AsyncCallback, const RuntimeMethod* method) 
{
	{
		UnityPurchasingCallback_tFC58410D7A50DD05CC7430C76C7E0277A213757D* L_0 = ___0_AsyncCallback;
		iOSStoreBindings_setUnityPurchasingCallback_mC81D3CFFC1A696A7B544AC3E78F404D51CA493C1(L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* iOSStoreBindings_get_appReceipt_m5601637B09453E936F4EAAEBB1538C919BC27B24 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		String_t* L_0;
		L_0 = iOSStoreBindings_getUnityPurchasingAppReceipt_m433D81E20669CD44CB5433D7898D677C64DB5909(NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double iOSStoreBindings_get_appReceiptModificationDate_mC7AC0A0F94BF888309429DCDBB319CCDCD0330A2 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		double L_0;
		L_0 = iOSStoreBindings_getUnityPurchasingAppReceiptModificationDate_m2FC5CA9222966AB9871B34F8FF16C21531323937(NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_RetrieveProducts_m523D9AFA65C09DBDB8963047E72DEC16B667E824 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, String_t* ___0_json, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___0_json;
		iOSStoreBindings_unityPurchasingRetrieveProducts_m42525F0667E3A76B7E5C5B6DA5E5EB599BFDE3DE(L_0, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_Purchase_m7AEA75645B7492A678C63FF7CDE56F8E75AB64F7 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, String_t* ___0_productJSON, String_t* ___1_developerPayload, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___0_productJSON;
		String_t* L_1 = ___1_developerPayload;
		iOSStoreBindings_unityPurchasingPurchase_mA2C0009A6B4DEF4CBCE1731D6460A6BCB1485DD6(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_FinishTransaction_m566E3AFFFEADEE7F71D9934A0DBA2AB1BF76B49E (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, String_t* ___0_productJSON, String_t* ___1_transactionId, const RuntimeMethod* method) 
{
	{
		String_t* L_0 = ___0_productJSON;
		String_t* L_1 = ___1_transactionId;
		iOSStoreBindings_unityPurchasingFinishTransaction_m8AC4AED5DD0D03966512020380D4EB8C3BD89BB6(L_0, L_1, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_RestoreTransactions_m2177F40DC549B229C8660387DD433AE8FD2A8652 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		iOSStoreBindings_unityPurchasingRestoreTransactions_mABD58E5CFAEF13D3EEE8EBBD2393C86D3B0B1099(NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_AddTransactionObserver_m7FB956E6DB7B00AC684CDC5567EE3B77F4544F79 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		iOSStoreBindings_unityPurchasingAddTransactionObserver_mDAE9E8FF1BFDDA43A9BED7156F154C238638C420(NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void iOSStoreBindings_InterceptPromotionalPurchases_m626C7254EB165FC41BBFF57092C6638BEC054C41 (iOSStoreBindings_t90DCEE577BA3FB8D54AC584DC9FA27EC9203DE9E* __this, const RuntimeMethod* method) 
{
	{
		iOSStoreBindings_unityPurchasingInterceptPromotionalPurchases_mC95655465276823D57CABBE7DE98095F7FF34D26(NULL);
		return;
	}
}
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
