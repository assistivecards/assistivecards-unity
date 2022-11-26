#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>



// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71;
// PlayerPrefsController
struct PlayerPrefsController_tBBB3C3071163468B9AAD0AE2BEB8BC799E37F2F0;
// System.String
struct String_t;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C String_t* _stringLiteral29AB3F09DEE8586763C60636812D160C3F57E1B1;
IL2CPP_EXTERN_C String_t* _stringLiteral464DD7369AA689E50C1515F12644A8E1961C80B6;
IL2CPP_EXTERN_C String_t* _stringLiteral7280E5718FA0093DE106B0C06DF759DC98282221;
IL2CPP_EXTERN_C String_t* _stringLiteralB91C0B9B01341768775B9133B367C86C196061C8;
IL2CPP_EXTERN_C String_t* _stringLiteralDDE05C1BC1F6C030824C517F9F1A5841CADF3DA2;
IL2CPP_EXTERN_C String_t* _stringLiteralE7EB567B70A048749F4A29F325DCCA7E03A248F9;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_t146199A02021DA0D045B30EB3E44B3F01298B20B 
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

// System.Single
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	// System.Single System.Single::m_value
	float ___m_value_0;
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

// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;
};

struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_StaticFields
{
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;
};
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};

// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.Behaviour
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
};

// PlayerPrefsController
struct PlayerPrefsController_tBBB3C3071163468B9AAD0AE2BEB8BC799E37F2F0  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void UnityEngine.PlayerPrefs::SetString(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefs_SetString_mF4F457C81BB75F0213547C6287BA36E15E1F0256 (String_t* ___key0, String_t* ___value1, const RuntimeMethod* method) ;
// System.Void UnityEngine.PlayerPrefs::Save()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefs_Save_m82567E045D69C838112EA204B60C144D4C1EA3AE (const RuntimeMethod* method) ;
// System.Void UnityEngine.PlayerPrefs::SetInt(System.String,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefs_SetInt_m956D3E2DB966F20CF42F842880DDF9E2BE94D948 (String_t* ___key0, int32_t ___value1, const RuntimeMethod* method) ;
// System.Void UnityEngine.PlayerPrefs::SetFloat(System.String,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefs_SetFloat_m1E8EA662BB9D8CF339D7DA2C452FCDFED88C5285 (String_t* ___key0, float ___value1, const RuntimeMethod* method) ;
// System.Void UnityEngine.PlayerPrefs::DeleteKey(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefs_DeleteKey_mF3A7857B52DCEF4139843CD28716788624C2AD30 (String_t* ___key0, const RuntimeMethod* method) ;
// System.Void UnityEngine.PlayerPrefs::DeleteAll()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefs_DeleteAll_m7687D47AE64203DB76AC6754EC276DFFD0DFAB0E (const RuntimeMethod* method) ;
// System.Void UnityEngine.MonoBehaviour::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E (MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71* __this, const RuntimeMethod* method) ;
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
// System.Void PlayerPrefsController::AddTestStrings()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefsController_AddTestStrings_m264832048215B30824CAFF1D0D7285BAE1ED6BBF (PlayerPrefsController_tBBB3C3071163468B9AAD0AE2BEB8BC799E37F2F0* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral29AB3F09DEE8586763C60636812D160C3F57E1B1);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral7280E5718FA0093DE106B0C06DF759DC98282221);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralB91C0B9B01341768775B9133B367C86C196061C8);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDDE05C1BC1F6C030824C517F9F1A5841CADF3DA2);
		s_Il2CppMethodInitialized = true;
	}
	{
		// PlayerPrefs.SetString("Runtime_String", "boing");
		PlayerPrefs_SetString_mF4F457C81BB75F0213547C6287BA36E15E1F0256(_stringLiteral7280E5718FA0093DE106B0C06DF759DC98282221, _stringLiteralDDE05C1BC1F6C030824C517F9F1A5841CADF3DA2, NULL);
		// PlayerPrefs.SetString("Runtime_String2", "foo");
		PlayerPrefs_SetString_mF4F457C81BB75F0213547C6287BA36E15E1F0256(_stringLiteral29AB3F09DEE8586763C60636812D160C3F57E1B1, _stringLiteralB91C0B9B01341768775B9133B367C86C196061C8, NULL);
		// PlayerPrefs.Save();
		PlayerPrefs_Save_m82567E045D69C838112EA204B60C144D4C1EA3AE(NULL);
		// }
		return;
	}
}
// System.Void PlayerPrefsController::AddTestInt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefsController_AddTestInt_mC83200E994F920D5F446BCB6FBD2621C8C55A871 (PlayerPrefsController_tBBB3C3071163468B9AAD0AE2BEB8BC799E37F2F0* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralE7EB567B70A048749F4A29F325DCCA7E03A248F9);
		s_Il2CppMethodInitialized = true;
	}
	{
		// PlayerPrefs.SetInt("Runtime_Int", 1234);
		PlayerPrefs_SetInt_m956D3E2DB966F20CF42F842880DDF9E2BE94D948(_stringLiteralE7EB567B70A048749F4A29F325DCCA7E03A248F9, ((int32_t)1234), NULL);
		// PlayerPrefs.Save();
		PlayerPrefs_Save_m82567E045D69C838112EA204B60C144D4C1EA3AE(NULL);
		// }
		return;
	}
}
// System.Void PlayerPrefsController::AddTestFloat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefsController_AddTestFloat_mEA569791323EC373986808E925F98ABB1E0B3625 (PlayerPrefsController_tBBB3C3071163468B9AAD0AE2BEB8BC799E37F2F0* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral464DD7369AA689E50C1515F12644A8E1961C80B6);
		s_Il2CppMethodInitialized = true;
	}
	{
		// PlayerPrefs.SetFloat("Runtime_Float", 3.14f);
		PlayerPrefs_SetFloat_m1E8EA662BB9D8CF339D7DA2C452FCDFED88C5285(_stringLiteral464DD7369AA689E50C1515F12644A8E1961C80B6, (3.1400001f), NULL);
		// PlayerPrefs.Save();
		PlayerPrefs_Save_m82567E045D69C838112EA204B60C144D4C1EA3AE(NULL);
		// }
		return;
	}
}
// System.Void PlayerPrefsController::RemoveTestStrings()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefsController_RemoveTestStrings_m3FC4A090440463768ECF21EBF44A3E3E5E7AEA49 (PlayerPrefsController_tBBB3C3071163468B9AAD0AE2BEB8BC799E37F2F0* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral29AB3F09DEE8586763C60636812D160C3F57E1B1);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral7280E5718FA0093DE106B0C06DF759DC98282221);
		s_Il2CppMethodInitialized = true;
	}
	{
		// PlayerPrefs.DeleteKey("Runtime_String");
		PlayerPrefs_DeleteKey_mF3A7857B52DCEF4139843CD28716788624C2AD30(_stringLiteral7280E5718FA0093DE106B0C06DF759DC98282221, NULL);
		// PlayerPrefs.DeleteKey("Runtime_String2");
		PlayerPrefs_DeleteKey_mF3A7857B52DCEF4139843CD28716788624C2AD30(_stringLiteral29AB3F09DEE8586763C60636812D160C3F57E1B1, NULL);
		// PlayerPrefs.Save();
		PlayerPrefs_Save_m82567E045D69C838112EA204B60C144D4C1EA3AE(NULL);
		// }
		return;
	}
}
// System.Void PlayerPrefsController::RemoveTestInt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefsController_RemoveTestInt_mDD8846AAC5048D31EA9B8BE0C5503D11AC2E6AEC (PlayerPrefsController_tBBB3C3071163468B9AAD0AE2BEB8BC799E37F2F0* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralE7EB567B70A048749F4A29F325DCCA7E03A248F9);
		s_Il2CppMethodInitialized = true;
	}
	{
		// PlayerPrefs.DeleteKey("Runtime_Int");
		PlayerPrefs_DeleteKey_mF3A7857B52DCEF4139843CD28716788624C2AD30(_stringLiteralE7EB567B70A048749F4A29F325DCCA7E03A248F9, NULL);
		// PlayerPrefs.Save();
		PlayerPrefs_Save_m82567E045D69C838112EA204B60C144D4C1EA3AE(NULL);
		// }
		return;
	}
}
// System.Void PlayerPrefsController::RemoveTestFloat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefsController_RemoveTestFloat_mB0134C1263A3A59DD9891A185E9D375C110E16D3 (PlayerPrefsController_tBBB3C3071163468B9AAD0AE2BEB8BC799E37F2F0* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral464DD7369AA689E50C1515F12644A8E1961C80B6);
		s_Il2CppMethodInitialized = true;
	}
	{
		// PlayerPrefs.DeleteKey("Runtime_Float");
		PlayerPrefs_DeleteKey_mF3A7857B52DCEF4139843CD28716788624C2AD30(_stringLiteral464DD7369AA689E50C1515F12644A8E1961C80B6, NULL);
		// PlayerPrefs.Save();
		PlayerPrefs_Save_m82567E045D69C838112EA204B60C144D4C1EA3AE(NULL);
		// }
		return;
	}
}
// System.Void PlayerPrefsController::DeleteAll()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefsController_DeleteAll_mE0D383E04784F81D55545AE407B289B3A0CABFF8 (PlayerPrefsController_tBBB3C3071163468B9AAD0AE2BEB8BC799E37F2F0* __this, const RuntimeMethod* method) 
{
	{
		// PlayerPrefs.DeleteAll();
		PlayerPrefs_DeleteAll_m7687D47AE64203DB76AC6754EC276DFFD0DFAB0E(NULL);
		// PlayerPrefs.Save();
		PlayerPrefs_Save_m82567E045D69C838112EA204B60C144D4C1EA3AE(NULL);
		// }
		return;
	}
}
// System.Void PlayerPrefsController::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PlayerPrefsController__ctor_m5F41C7F0327EBF9F8139A19B7C9F0B5C331B5853 (PlayerPrefsController_tBBB3C3071163468B9AAD0AE2BEB8BC799E37F2F0* __this, const RuntimeMethod* method) 
{
	{
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
