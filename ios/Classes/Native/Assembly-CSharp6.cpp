#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


struct VirtualActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1>
struct InvokerActionInvoker1;
template <typename T1>
struct InvokerActionInvoker1<T1*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1)
	{
		void* params[1] = { p1 };
		method->invoker_method(methodPtr, method, obj, params, params[0]);
	}
};

// System.Collections.Generic.Dictionary`2<System.Int32,System.Globalization.CultureInfo>
struct Dictionary_2_t9FA6D82CAFC18769F7515BB51D1C56DAE09381C3;
// System.Collections.Generic.Dictionary`2<System.String,System.Globalization.CultureInfo>
struct Dictionary_2_tE1603CE612C16451D1E56FF4D4859D4FE4087C28;
// System.Collections.Generic.List`1<Defective.JSON.JSONObject>
struct List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E;
// System.Collections.Generic.List`1<System.String>
struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD;
// System.Collections.Generic.List`1<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>
struct List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A;
// System.Byte[]
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
// System.Char[]
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
// System.Int32[]
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
// System.IntPtr[]
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
// Defective.JSON.JSONObject[]
struct JSONObjectU5BU5D_t95855C82EA715A0850032E38D20926E75F68ED0A;
// UnityEngine.Material[]
struct MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D;
// System.Single[]
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
// System.String[]
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
// UnityEngine.Transform[]
struct TransformU5BU5D_tBB9C5F5686CAE82E3D97D43DF0F3D68ABF75EC24;
// UnityEngine.Vector2[]
struct Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA;
// UnityEngine.Vector3[]
struct Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C;
// Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType[]
struct __Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC;
// System.Action
struct Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07;
// System.ArgumentException
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263;
// System.ArgumentNullException
struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129;
// System.Globalization.Calendar
struct Calendar_t0A117CC7532A54C17188C2EFEA1F79DB20DF3A3B;
// System.Globalization.CompareInfo
struct CompareInfo_t1B1A6AC3486B570C76ABA52149C9BD4CD82F9E57;
// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3;
// System.Globalization.CultureData
struct CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D;
// System.Globalization.CultureInfo
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0;
// System.Globalization.DateTimeFormatInfo
struct DateTimeFormatInfo_t0457520F9FA7B5C8EAAEB3AD50413B6AEEB7458A;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F;
// PathCreation.GlobalDisplaySettings
struct GlobalDisplaySettings_t16BF530513ABA3A70B008EA750EAAF4CFB02E33D;
// System.Collections.IDictionary
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
// System.Collections.IEnumerator
struct IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA;
// System.IFormatProvider
struct IFormatProvider_tC202922D43BFF3525109ABF3FB79625F5646AB52;
// System.InvalidOperationException
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB;
// Defective.JSON.JSONObject
struct JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC;
// Defective.JSON.JSONObjectEnumerator
struct JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5;
// UnityEngine.Material
struct Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3;
// UnityEngine.Mesh
struct Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4;
// UnityEngine.MeshFilter
struct MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5;
// UnityEngine.MeshRenderer
struct MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71;
// System.Globalization.NumberFormatInfo
struct NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472;
// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C;
// PathCreation.PathCreator
struct PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE;
// PathCreation.PathCreatorData
struct PathCreatorData_tF6A229D948EA8F716EEE4748FE122754CFFF5D52;
// PathCreation.Examples.PathFollower
struct PathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E;
// PathCreation.Examples.PathSceneTool
struct PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4;
// PathCreation.Examples.PathSpawner
struct PathSpawner_tD3271976E287B5EB44C0EAB8C074C147A9DBE86B;
// UnityEngine.Renderer
struct Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF;
// PathCreation.Examples.RoadMeshCreator
struct RoadMeshCreator_t765ECF7A91520B0A606D722BB015194B9BFC0AF9;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
// System.Diagnostics.Stopwatch
struct Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043;
// System.String
struct String_t;
// System.Text.StringBuilder
struct StringBuilder_t;
// System.Globalization.TextInfo
struct TextInfo_tD3BAFCFD77418851E7D5CB8D2588F47019E414B4;
// UnityEngine.Transform
struct Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1;
// PathCreation.VertexPath
struct VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C RuntimeClass* Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Convert_t7097FF336D592F7C06D88A98349A44646F91EFFC_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* FormatException_tCD210E92627903FFEDAAA706C08FB6222B4D012B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* GameObject_t76FEDD663AB33C991A9C9A23129337651094216F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* OverflowException_t6F6AD8CACE20C37F701C05B373A215C4802FAB0C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* StringBuilder_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____13BA99FB374DE24EB2656ACE253C54E2DA7EBAEDA4DD3DAB04852553EAF91EF6_0_FieldInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____6E6A276CCCD4455AE240A4C37DD0783E9BCC737B1CCCC3EA145A08E2364FC998_2_FieldInfo_var;
IL2CPP_EXTERN_C RuntimeField* U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____BA75250079507D98AC2F48E9A2457F6C7346902BC6C52203B97DCACED687EE8F_3_FieldInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral0074C49CE7D7ED9232C28459AA9DB19B1D06C223;
IL2CPP_EXTERN_C String_t* _stringLiteral00B28FF06B788B9B67C6B259800F404F9F3761FD;
IL2CPP_EXTERN_C String_t* _stringLiteral053D8D6CEEBA9453C97D0EE5374DB863E6F77AD4;
IL2CPP_EXTERN_C String_t* _stringLiteral06B4A96E9E13BC375962BF44CF7B409D3020362D;
IL2CPP_EXTERN_C String_t* _stringLiteral0C3C6829C3CCF8020C6AC45B87963ADC095CD44A;
IL2CPP_EXTERN_C String_t* _stringLiteral19967C1E48314D711A74F7072B6A080EC2E7DCF0;
IL2CPP_EXTERN_C String_t* _stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3;
IL2CPP_EXTERN_C String_t* _stringLiteral2C3D4826D5236B3C9A914C5CE2E3D8CEA48AC7CE;
IL2CPP_EXTERN_C String_t* _stringLiteral3B2C1C62D4D1C2A0C8A9AC42DB00D33C654F9AD0;
IL2CPP_EXTERN_C String_t* _stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5;
IL2CPP_EXTERN_C String_t* _stringLiteral49A5AAB83859C60FC692064F7CA72853E8B6B189;
IL2CPP_EXTERN_C String_t* _stringLiteral4A85F7924EB5D4EE9D1DD6344A4679BFEB95F45C;
IL2CPP_EXTERN_C String_t* _stringLiteral4D8D9C94AC5DA5FCED2EC8A64E10E714A2515C30;
IL2CPP_EXTERN_C String_t* _stringLiteral54154E1F5FCB5154DF6748F2558087DBA8903D65;
IL2CPP_EXTERN_C String_t* _stringLiteral544DC80A2A82A08B6321F56F8987CB7E5DEED1C4;
IL2CPP_EXTERN_C String_t* _stringLiteral5962E944D7340CE47999BF097B4AFD70C1501FB9;
IL2CPP_EXTERN_C String_t* _stringLiteral5B22DE498A248A5D137E9D01CFAA089B3CA784EA;
IL2CPP_EXTERN_C String_t* _stringLiteral5B4F028A4070094FCA4E7762E2C376A65E2D59C6;
IL2CPP_EXTERN_C String_t* _stringLiteral5BEFD8CC60A79699B5BB00E37BAC5B62D371E174;
IL2CPP_EXTERN_C String_t* _stringLiteral6BDD6023A35877E4881FA93114DF2689C56BC822;
IL2CPP_EXTERN_C String_t* _stringLiteral70EEFAA66DA29FAC9E1A81759A5984878FB67ED3;
IL2CPP_EXTERN_C String_t* _stringLiteral763076C684EFEFA1B5A84D92C472EA6FF54AB95D;
IL2CPP_EXTERN_C String_t* _stringLiteral77D38C0623F92B292B925F6E72CF5CF99A20D4EB;
IL2CPP_EXTERN_C String_t* _stringLiteral785F17F45C331C415D0A7458E6AAC36966399C51;
IL2CPP_EXTERN_C String_t* _stringLiteral7E9AAA262720DD1434B6C5339B3252FC1055AD36;
IL2CPP_EXTERN_C String_t* _stringLiteral7F3238CD8C342B06FB9AB185C610175C84625462;
IL2CPP_EXTERN_C String_t* _stringLiteral848E5ED630B3142F565DD995C6E8D30187ED33CD;
IL2CPP_EXTERN_C String_t* _stringLiteral9CA8C44D8001E19877B2F2B86EC61A60048AF615;
IL2CPP_EXTERN_C String_t* _stringLiteral9ED931619E39F59A8520C1E3B03FEA2E9A56FB60;
IL2CPP_EXTERN_C String_t* _stringLiteralA5A52E47B1F94FFB41929E7E93154B6B04402E29;
IL2CPP_EXTERN_C String_t* _stringLiteralA7C3FCA8C63E127B542B38A5CA5E3FEEDDD1B122;
IL2CPP_EXTERN_C String_t* _stringLiteralB18401C35133C78B1809EA9659B10913E2F430A7;
IL2CPP_EXTERN_C String_t* _stringLiteralB78F235D4291950A7D101307609C259F3E1F033F;
IL2CPP_EXTERN_C String_t* _stringLiteralB7C45DD316C68ABF3429C20058C2981C652192F2;
IL2CPP_EXTERN_C String_t* _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB;
IL2CPP_EXTERN_C String_t* _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677;
IL2CPP_EXTERN_C String_t* _stringLiteralD9691C4FD8A1F6B09DB1147CA32B442772FB46A1;
IL2CPP_EXTERN_C String_t* _stringLiteralDB5B55A9B215F744DB82517864984D073F2E8F8C;
IL2CPP_EXTERN_C String_t* _stringLiteralDE28F98354F48E7C0878BBA93033C6BDC68B27E2;
IL2CPP_EXTERN_C String_t* _stringLiteralE166C9564FBDE461738077E3B1B506525EB6ACCC;
IL2CPP_EXTERN_C String_t* _stringLiteralF269C8AA670766E94BF5B0AB838989B114D6C9D8;
IL2CPP_EXTERN_C String_t* _stringLiteralF3E84B722399601AD7E281754E917478AA9AD48D;
IL2CPP_EXTERN_C String_t* _stringLiteralFA9F4ADBA883DCCA70B2BFF2E103994E8AA5A599;
IL2CPP_EXTERN_C const RuntimeMethod* Array_IndexOf_TisChar_t521A6F19B456D956AF452D926C32709DC03D6B17_m6E2BDAD7B5A1E51CA8029C65DCA4E847D543DDF9_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_Dispose_m9AB7547595606304114C14F0450F15FD30F51468_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_MoveNext_mB602A35E50D2614F8EB42D0EAB33B023FB737E4B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Enumerator_get_Current_m1499EAC836D33EE4BDFBC30928D75545E8F29523_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_AddComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mEAB8177A64DF1A50BB7996ACEEEADCD65358AC94_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_AddComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_mCDD3E77673305199F52C772AE8C7952F3864740D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_GetComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mDF6525BCE37B444313BE0AA2305BDF4EB8B92FE8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* GameObject_GetComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_m7FF948365C38BC39333D82B235A7C4EAD219960D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* JSONObjectEnumerator__ctor_m24FA52671B6CD2C9492B8273FD881FA9B0499383_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* JSONObject_BeginParse_m5DC3434F026462D2385421261304923E197E6C27_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_m67DC8AAA1F867623E0668663DD6FECC08D3CB03C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_GetEnumerator_m2EA9CF993A1757CD6FA450F8FB76CE5C4797CA95_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m512620C35691CD7C02708077DD0A844BD071283D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Count_m919AA1B61CF20232484BC458BCED3FFAA510E11C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Item_m72F3DB0603A408B7B91C4591FADFC8E855D81490_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Object_Instantiate_TisPathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE_m31FEE817E86702ADD34DC6FFC0C98979B42D491C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Object_Instantiate_TisPathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E_m1F52C8D2E3D958BB9F53D6C4745BC997DF361190_RuntimeMethod_var;
struct CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D_marshaled_com;
struct CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D_marshaled_pinvoke;
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_com;
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_pinvoke;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D;
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C;
struct TransformU5BU5D_tBB9C5F5686CAE82E3D97D43DF0F3D68ABF75EC24;
struct Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA;
struct Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C;
struct __Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.List`1<Defective.JSON.JSONObject>
struct List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	JSONObjectU5BU5D_t95855C82EA715A0850032E38D20926E75F68ED0A* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

struct List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	JSONObjectU5BU5D_t95855C82EA715A0850032E38D20926E75F68ED0A* ___s_emptyArray_5;
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

// System.Collections.Generic.List`1<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>
struct List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	__Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

struct List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	__Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC* ___s_emptyArray_5;
};
struct Il2CppArrayBounds;

// System.Globalization.CultureInfo
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0  : public RuntimeObject
{
	// System.Boolean System.Globalization.CultureInfo::m_isReadOnly
	bool ___m_isReadOnly_3;
	// System.Int32 System.Globalization.CultureInfo::cultureID
	int32_t ___cultureID_4;
	// System.Int32 System.Globalization.CultureInfo::parent_lcid
	int32_t ___parent_lcid_5;
	// System.Int32 System.Globalization.CultureInfo::datetime_index
	int32_t ___datetime_index_6;
	// System.Int32 System.Globalization.CultureInfo::number_index
	int32_t ___number_index_7;
	// System.Int32 System.Globalization.CultureInfo::default_calendar_type
	int32_t ___default_calendar_type_8;
	// System.Boolean System.Globalization.CultureInfo::m_useUserOverride
	bool ___m_useUserOverride_9;
	// System.Globalization.NumberFormatInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::numInfo
	NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* ___numInfo_10;
	// System.Globalization.DateTimeFormatInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::dateTimeInfo
	DateTimeFormatInfo_t0457520F9FA7B5C8EAAEB3AD50413B6AEEB7458A* ___dateTimeInfo_11;
	// System.Globalization.TextInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::textInfo
	TextInfo_tD3BAFCFD77418851E7D5CB8D2588F47019E414B4* ___textInfo_12;
	// System.String System.Globalization.CultureInfo::m_name
	String_t* ___m_name_13;
	// System.String System.Globalization.CultureInfo::englishname
	String_t* ___englishname_14;
	// System.String System.Globalization.CultureInfo::nativename
	String_t* ___nativename_15;
	// System.String System.Globalization.CultureInfo::iso3lang
	String_t* ___iso3lang_16;
	// System.String System.Globalization.CultureInfo::iso2lang
	String_t* ___iso2lang_17;
	// System.String System.Globalization.CultureInfo::win3lang
	String_t* ___win3lang_18;
	// System.String System.Globalization.CultureInfo::territory
	String_t* ___territory_19;
	// System.String[] System.Globalization.CultureInfo::native_calendar_names
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___native_calendar_names_20;
	// System.Globalization.CompareInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::compareInfo
	CompareInfo_t1B1A6AC3486B570C76ABA52149C9BD4CD82F9E57* ___compareInfo_21;
	// System.Void* System.Globalization.CultureInfo::textinfo_data
	void* ___textinfo_data_22;
	// System.Int32 System.Globalization.CultureInfo::m_dataItem
	int32_t ___m_dataItem_23;
	// System.Globalization.Calendar System.Globalization.CultureInfo::calendar
	Calendar_t0A117CC7532A54C17188C2EFEA1F79DB20DF3A3B* ___calendar_24;
	// System.Globalization.CultureInfo System.Globalization.CultureInfo::parent_culture
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___parent_culture_25;
	// System.Boolean System.Globalization.CultureInfo::constructed
	bool ___constructed_26;
	// System.Byte[] System.Globalization.CultureInfo::cached_serialized_form
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___cached_serialized_form_27;
	// System.Globalization.CultureData System.Globalization.CultureInfo::m_cultureData
	CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D* ___m_cultureData_28;
	// System.Boolean System.Globalization.CultureInfo::m_isInherited
	bool ___m_isInherited_29;
};

struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_StaticFields
{
	// System.Globalization.CultureInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::invariant_culture_info
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___invariant_culture_info_0;
	// System.Object System.Globalization.CultureInfo::shared_table_lock
	RuntimeObject* ___shared_table_lock_1;
	// System.Globalization.CultureInfo System.Globalization.CultureInfo::default_current_culture
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___default_current_culture_2;
	// System.Globalization.CultureInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::s_DefaultThreadCurrentUICulture
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___s_DefaultThreadCurrentUICulture_34;
	// System.Globalization.CultureInfo modreq(System.Runtime.CompilerServices.IsVolatile) System.Globalization.CultureInfo::s_DefaultThreadCurrentCulture
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___s_DefaultThreadCurrentCulture_35;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.Globalization.CultureInfo> System.Globalization.CultureInfo::shared_by_number
	Dictionary_2_t9FA6D82CAFC18769F7515BB51D1C56DAE09381C3* ___shared_by_number_36;
	// System.Collections.Generic.Dictionary`2<System.String,System.Globalization.CultureInfo> System.Globalization.CultureInfo::shared_by_name
	Dictionary_2_tE1603CE612C16451D1E56FF4D4859D4FE4087C28* ___shared_by_name_37;
	// System.Globalization.CultureInfo System.Globalization.CultureInfo::s_UserPreferredCultureInfoInAppX
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___s_UserPreferredCultureInfoInAppX_38;
	// System.Boolean System.Globalization.CultureInfo::IsTaiwanSku
	bool ___IsTaiwanSku_39;
};
// Native definition for P/Invoke marshalling of System.Globalization.CultureInfo
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_pinvoke
{
	int32_t ___m_isReadOnly_3;
	int32_t ___cultureID_4;
	int32_t ___parent_lcid_5;
	int32_t ___datetime_index_6;
	int32_t ___number_index_7;
	int32_t ___default_calendar_type_8;
	int32_t ___m_useUserOverride_9;
	NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* ___numInfo_10;
	DateTimeFormatInfo_t0457520F9FA7B5C8EAAEB3AD50413B6AEEB7458A* ___dateTimeInfo_11;
	TextInfo_tD3BAFCFD77418851E7D5CB8D2588F47019E414B4* ___textInfo_12;
	char* ___m_name_13;
	char* ___englishname_14;
	char* ___nativename_15;
	char* ___iso3lang_16;
	char* ___iso2lang_17;
	char* ___win3lang_18;
	char* ___territory_19;
	char** ___native_calendar_names_20;
	CompareInfo_t1B1A6AC3486B570C76ABA52149C9BD4CD82F9E57* ___compareInfo_21;
	void* ___textinfo_data_22;
	int32_t ___m_dataItem_23;
	Calendar_t0A117CC7532A54C17188C2EFEA1F79DB20DF3A3B* ___calendar_24;
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_pinvoke* ___parent_culture_25;
	int32_t ___constructed_26;
	Il2CppSafeArray/*NONE*/* ___cached_serialized_form_27;
	CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D_marshaled_pinvoke* ___m_cultureData_28;
	int32_t ___m_isInherited_29;
};
// Native definition for COM marshalling of System.Globalization.CultureInfo
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_com
{
	int32_t ___m_isReadOnly_3;
	int32_t ___cultureID_4;
	int32_t ___parent_lcid_5;
	int32_t ___datetime_index_6;
	int32_t ___number_index_7;
	int32_t ___default_calendar_type_8;
	int32_t ___m_useUserOverride_9;
	NumberFormatInfo_t8E26808B202927FEBF9064FCFEEA4D6E076E6472* ___numInfo_10;
	DateTimeFormatInfo_t0457520F9FA7B5C8EAAEB3AD50413B6AEEB7458A* ___dateTimeInfo_11;
	TextInfo_tD3BAFCFD77418851E7D5CB8D2588F47019E414B4* ___textInfo_12;
	Il2CppChar* ___m_name_13;
	Il2CppChar* ___englishname_14;
	Il2CppChar* ___nativename_15;
	Il2CppChar* ___iso3lang_16;
	Il2CppChar* ___iso2lang_17;
	Il2CppChar* ___win3lang_18;
	Il2CppChar* ___territory_19;
	Il2CppChar** ___native_calendar_names_20;
	CompareInfo_t1B1A6AC3486B570C76ABA52149C9BD4CD82F9E57* ___compareInfo_21;
	void* ___textinfo_data_22;
	int32_t ___m_dataItem_23;
	Calendar_t0A117CC7532A54C17188C2EFEA1F79DB20DF3A3B* ___calendar_24;
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_marshaled_com* ___parent_culture_25;
	int32_t ___constructed_26;
	Il2CppSafeArray/*NONE*/* ___cached_serialized_form_27;
	CultureData_tEEFDCF4ECA1BBF6C0C8C94EB3541657245598F9D_marshaled_com* ___m_cultureData_28;
	int32_t ___m_isInherited_29;
};

// Defective.JSON.JSONObject
struct JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC  : public RuntimeObject
{
	// Defective.JSON.JSONObject/Type Defective.JSON.JSONObject::type
	int32_t ___type_2;
	// System.Collections.Generic.List`1<Defective.JSON.JSONObject> Defective.JSON.JSONObject::list
	List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* ___list_3;
	// System.Collections.Generic.List`1<System.String> Defective.JSON.JSONObject::keys
	List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* ___keys_4;
	// System.String Defective.JSON.JSONObject::stringValue
	String_t* ___stringValue_5;
	// System.Boolean Defective.JSON.JSONObject::isInteger
	bool ___isInteger_6;
	// System.Int64 Defective.JSON.JSONObject::longValue
	int64_t ___longValue_7;
	// System.Boolean Defective.JSON.JSONObject::boolValue
	bool ___boolValue_8;
	// System.Double Defective.JSON.JSONObject::doubleValue
	double ___doubleValue_9;
};

struct JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_StaticFields
{
	// System.Diagnostics.Stopwatch Defective.JSON.JSONObject::PrintWatch
	Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043* ___PrintWatch_0;
	// System.Char[] Defective.JSON.JSONObject::Whitespace
	CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* ___Whitespace_1;
};

// Defective.JSON.JSONObjectEnumerator
struct JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5  : public RuntimeObject
{
	// Defective.JSON.JSONObject Defective.JSON.JSONObjectEnumerator::target
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___target_0;
	// System.Int32 Defective.JSON.JSONObjectEnumerator::position
	int32_t ___position_1;
};

// System.Diagnostics.Stopwatch
struct Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043  : public RuntimeObject
{
	// System.Int64 System.Diagnostics.Stopwatch::elapsed
	int64_t ___elapsed_2;
	// System.Int64 System.Diagnostics.Stopwatch::started
	int64_t ___started_3;
	// System.Boolean System.Diagnostics.Stopwatch::is_running
	bool ___is_running_4;
};

struct Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043_StaticFields
{
	// System.Int64 System.Diagnostics.Stopwatch::Frequency
	int64_t ___Frequency_0;
	// System.Boolean System.Diagnostics.Stopwatch::IsHighResolution
	bool ___IsHighResolution_1;
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

// System.Text.StringBuilder
struct StringBuilder_t  : public RuntimeObject
{
	// System.Char[] System.Text.StringBuilder::m_ChunkChars
	CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* ___m_ChunkChars_0;
	// System.Text.StringBuilder System.Text.StringBuilder::m_ChunkPrevious
	StringBuilder_t* ___m_ChunkPrevious_1;
	// System.Int32 System.Text.StringBuilder::m_ChunkLength
	int32_t ___m_ChunkLength_2;
	// System.Int32 System.Text.StringBuilder::m_ChunkOffset
	int32_t ___m_ChunkOffset_3;
	// System.Int32 System.Text.StringBuilder::m_MaxCapacity
	int32_t ___m_MaxCapacity_4;
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

// System.Collections.Generic.List`1/Enumerator<Defective.JSON.JSONObject>
struct Enumerator_t67AE52CF7FD6EE3C251143D6B7534AF4A04048A1 
{
	// System.Collections.Generic.List`1<T> System.Collections.Generic.List`1/Enumerator::_list
	List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* ____list_0;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::_index
	int32_t ____index_1;
	// System.Int32 System.Collections.Generic.List`1/Enumerator::_version
	int32_t ____version_2;
	// T System.Collections.Generic.List`1/Enumerator::_current
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ____current_3;
};

// System.Collections.Generic.List`1/Enumerator<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>
typedef Il2CppFullySharedGenericStruct Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF;

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

// System.Double
struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	// System.Double System.Double::m_value
	double ___m_value_0;
};

// System.Int32
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;
};

// System.Int64
struct Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3 
{
	// System.Int64 System.Int64::m_value
	int64_t ___m_value_0;
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

// UnityEngine.Quaternion
struct Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 
{
	// System.Single UnityEngine.Quaternion::x
	float ___x_0;
	// System.Single UnityEngine.Quaternion::y
	float ___y_1;
	// System.Single UnityEngine.Quaternion::z
	float ___z_2;
	// System.Single UnityEngine.Quaternion::w
	float ___w_3;
};

struct Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_StaticFields
{
	// UnityEngine.Quaternion UnityEngine.Quaternion::identityQuaternion
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___identityQuaternion_4;
};

// System.Single
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	// System.Single System.Single::m_value
	float ___m_value_0;
};

// UnityEngine.Vector2
struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 
{
	// System.Single UnityEngine.Vector2::x
	float ___x_0;
	// System.Single UnityEngine.Vector2::y
	float ___y_1;
};

struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_StaticFields
{
	// UnityEngine.Vector2 UnityEngine.Vector2::zeroVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___zeroVector_2;
	// UnityEngine.Vector2 UnityEngine.Vector2::oneVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___oneVector_3;
	// UnityEngine.Vector2 UnityEngine.Vector2::upVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___upVector_4;
	// UnityEngine.Vector2 UnityEngine.Vector2::downVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___downVector_5;
	// UnityEngine.Vector2 UnityEngine.Vector2::leftVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___leftVector_6;
	// UnityEngine.Vector2 UnityEngine.Vector2::rightVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___rightVector_7;
	// UnityEngine.Vector2 UnityEngine.Vector2::positiveInfinityVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___positiveInfinityVector_8;
	// UnityEngine.Vector2 UnityEngine.Vector2::negativeInfinityVector
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___negativeInfinityVector_9;
};

// UnityEngine.Vector3
struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 
{
	// System.Single UnityEngine.Vector3::x
	float ___x_2;
	// System.Single UnityEngine.Vector3::y
	float ___y_3;
	// System.Single UnityEngine.Vector3::z
	float ___z_4;
};

struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields
{
	// UnityEngine.Vector3 UnityEngine.Vector3::zeroVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___zeroVector_5;
	// UnityEngine.Vector3 UnityEngine.Vector3::oneVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___oneVector_6;
	// UnityEngine.Vector3 UnityEngine.Vector3::upVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___upVector_7;
	// UnityEngine.Vector3 UnityEngine.Vector3::downVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___downVector_8;
	// UnityEngine.Vector3 UnityEngine.Vector3::leftVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___leftVector_9;
	// UnityEngine.Vector3 UnityEngine.Vector3::rightVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rightVector_10;
	// UnityEngine.Vector3 UnityEngine.Vector3::forwardVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___forwardVector_11;
	// UnityEngine.Vector3 UnityEngine.Vector3::backVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___backVector_12;
	// UnityEngine.Vector3 UnityEngine.Vector3::positiveInfinityVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positiveInfinityVector_13;
	// UnityEngine.Vector3 UnityEngine.Vector3::negativeInfinityVector
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___negativeInfinityVector_14;
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

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=12
struct __StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F__padding[12];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=24
struct __StaticArrayInitTypeSizeU3D24_t3464DA68B6CCAB9A0A43F94B3DB9AA7E7FDDB19A 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D24_t3464DA68B6CCAB9A0A43F94B3DB9AA7E7FDDB19A__padding[24];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=48
struct __StaticArrayInitTypeSizeU3D48_tB184AFC7E0116F4B6DAFA18B66C9B248A3A9F2FE 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D48_tB184AFC7E0116F4B6DAFA18B66C9B248A3A9F2FE__padding[48];
	};
};

// <PrivateImplementationDetails>
struct U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA  : public RuntimeObject
{
};

struct U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA_StaticFields
{
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=12 <PrivateImplementationDetails>::13BA99FB374DE24EB2656ACE253C54E2DA7EBAEDA4DD3DAB04852553EAF91EF6
	__StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F ___13BA99FB374DE24EB2656ACE253C54E2DA7EBAEDA4DD3DAB04852553EAF91EF6_0;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=24 <PrivateImplementationDetails>::4F3A974D03B4939FC26A965844D8E5F89E151FF80F59BB8AF511CC703F5DA157
	__StaticArrayInitTypeSizeU3D24_t3464DA68B6CCAB9A0A43F94B3DB9AA7E7FDDB19A ___4F3A974D03B4939FC26A965844D8E5F89E151FF80F59BB8AF511CC703F5DA157_1;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=24 <PrivateImplementationDetails>::6E6A276CCCD4455AE240A4C37DD0783E9BCC737B1CCCC3EA145A08E2364FC998
	__StaticArrayInitTypeSizeU3D24_t3464DA68B6CCAB9A0A43F94B3DB9AA7E7FDDB19A ___6E6A276CCCD4455AE240A4C37DD0783E9BCC737B1CCCC3EA145A08E2364FC998_2;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=48 <PrivateImplementationDetails>::BA75250079507D98AC2F48E9A2457F6C7346902BC6C52203B97DCACED687EE8F
	__StaticArrayInitTypeSizeU3D48_tB184AFC7E0116F4B6DAFA18B66C9B248A3A9F2FE ___BA75250079507D98AC2F48E9A2457F6C7346902BC6C52203B97DCACED687EE8F_3;
};

// UnityEngine.Bounds
struct Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 
{
	// UnityEngine.Vector3 UnityEngine.Bounds::m_Center
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Center_0;
	// UnityEngine.Vector3 UnityEngine.Bounds::m_Extents
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Extents_1;
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

// System.Exception
struct Exception_t  : public RuntimeObject
{
	// System.String System.Exception::_className
	String_t* ____className_1;
	// System.String System.Exception::_message
	String_t* ____message_2;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_3;
	// System.Exception System.Exception::_innerException
	Exception_t* ____innerException_4;
	// System.String System.Exception::_helpURL
	String_t* ____helpURL_5;
	// System.Object System.Exception::_stackTrace
	RuntimeObject* ____stackTrace_6;
	// System.String System.Exception::_stackTraceString
	String_t* ____stackTraceString_7;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_8;
	// System.Int32 System.Exception::_remoteStackIndex
	int32_t ____remoteStackIndex_9;
	// System.Object System.Exception::_dynamicMethods
	RuntimeObject* ____dynamicMethods_10;
	// System.Int32 System.Exception::_HResult
	int32_t ____HResult_11;
	// System.String System.Exception::_source
	String_t* ____source_12;
	// System.Runtime.Serialization.SafeSerializationManager System.Exception::_safeSerializationManager
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	// System.Diagnostics.StackTrace[] System.Exception::captured_traces
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	// System.IntPtr[] System.Exception::native_trace_ips
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips_15;
	// System.Int32 System.Exception::caught_in_unmanaged
	int32_t ___caught_in_unmanaged_16;
};

struct Exception_t_StaticFields
{
	// System.Object System.Exception::s_EDILock
	RuntimeObject* ___s_EDILock_0;
};
// Native definition for P/Invoke marshalling of System.Exception
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};
// Native definition for COM marshalling of System.Exception
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
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

// System.RuntimeFieldHandle
struct RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 
{
	// System.IntPtr System.RuntimeFieldHandle::value
	intptr_t ___value_0;
};

// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.Material
struct Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.Mesh
struct Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
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

// System.SystemException
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};

// PathCreation.VertexPath
struct VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5  : public RuntimeObject
{
	// PathCreation.PathSpace PathCreation.VertexPath::space
	int32_t ___space_0;
	// System.Boolean PathCreation.VertexPath::isClosedLoop
	bool ___isClosedLoop_1;
	// UnityEngine.Vector3[] PathCreation.VertexPath::localPoints
	Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* ___localPoints_2;
	// UnityEngine.Vector3[] PathCreation.VertexPath::localTangents
	Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* ___localTangents_3;
	// UnityEngine.Vector3[] PathCreation.VertexPath::localNormals
	Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* ___localNormals_4;
	// System.Single[] PathCreation.VertexPath::times
	SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___times_5;
	// System.Single PathCreation.VertexPath::length
	float ___length_6;
	// System.Single[] PathCreation.VertexPath::cumulativeLengthAtEachVertex
	SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___cumulativeLengthAtEachVertex_7;
	// UnityEngine.Bounds PathCreation.VertexPath::bounds
	Bounds_t367E830C64BBF235ED8C3B2F8CF6254FDCAD39C3 ___bounds_8;
	// UnityEngine.Vector3 PathCreation.VertexPath::up
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___up_9;
	// UnityEngine.Transform PathCreation.VertexPath::transform
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___transform_12;
};

// System.Action
struct Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07  : public MulticastDelegate_t
{
};

// System.ArgumentException
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
	// System.String System.ArgumentException::_paramName
	String_t* ____paramName_18;
};

// System.ArithmeticException
struct ArithmeticException_t07E77822D0007642BC8959A671E70D1F33C84FEA  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// UnityEngine.Behaviour
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// System.FormatException
struct FormatException_tCD210E92627903FFEDAAA706C08FB6222B4D012B  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// System.InvalidOperationException
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// UnityEngine.MeshFilter
struct MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// UnityEngine.Renderer
struct Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// UnityEngine.Transform
struct Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// System.ArgumentNullException
struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129  : public ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263
{
};

// UnityEngine.MeshRenderer
struct MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE  : public Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF
{
};

// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
};

// System.OverflowException
struct OverflowException_t6F6AD8CACE20C37F701C05B373A215C4802FAB0C  : public ArithmeticException_t07E77822D0007642BC8959A671E70D1F33C84FEA
{
};

// PathCreation.PathCreator
struct PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// System.Action PathCreation.PathCreator::pathUpdated
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___pathUpdated_4;
	// PathCreation.PathCreatorData PathCreation.PathCreator::editorData
	PathCreatorData_tF6A229D948EA8F716EEE4748FE122754CFFF5D52* ___editorData_5;
	// System.Boolean PathCreation.PathCreator::initialized
	bool ___initialized_6;
	// PathCreation.GlobalDisplaySettings PathCreation.PathCreator::globalEditorDisplaySettings
	GlobalDisplaySettings_t16BF530513ABA3A70B008EA750EAAF4CFB02E33D* ___globalEditorDisplaySettings_7;
};

// PathCreation.Examples.PathFollower
struct PathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// PathCreation.PathCreator PathCreation.Examples.PathFollower::pathCreator
	PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* ___pathCreator_4;
	// PathCreation.EndOfPathInstruction PathCreation.Examples.PathFollower::endOfPathInstruction
	int32_t ___endOfPathInstruction_5;
	// System.Single PathCreation.Examples.PathFollower::speed
	float ___speed_6;
	// System.Single PathCreation.Examples.PathFollower::distanceTravelled
	float ___distanceTravelled_7;
};

// PathCreation.Examples.PathSceneTool
struct PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// System.Action PathCreation.Examples.PathSceneTool::onDestroyed
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___onDestroyed_4;
	// PathCreation.PathCreator PathCreation.Examples.PathSceneTool::pathCreator
	PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* ___pathCreator_5;
	// System.Boolean PathCreation.Examples.PathSceneTool::autoUpdate
	bool ___autoUpdate_6;
};

// PathCreation.Examples.PathSpawner
struct PathSpawner_tD3271976E287B5EB44C0EAB8C074C147A9DBE86B  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// PathCreation.PathCreator PathCreation.Examples.PathSpawner::pathPrefab
	PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* ___pathPrefab_4;
	// PathCreation.Examples.PathFollower PathCreation.Examples.PathSpawner::followerPrefab
	PathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E* ___followerPrefab_5;
	// UnityEngine.Transform[] PathCreation.Examples.PathSpawner::spawnPoints
	TransformU5BU5D_tBB9C5F5686CAE82E3D97D43DF0F3D68ABF75EC24* ___spawnPoints_6;
};

// PathCreation.Examples.RoadMeshCreator
struct RoadMeshCreator_t765ECF7A91520B0A606D722BB015194B9BFC0AF9  : public PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4
{
	// System.Single PathCreation.Examples.RoadMeshCreator::roadWidth
	float ___roadWidth_7;
	// System.Single PathCreation.Examples.RoadMeshCreator::thickness
	float ___thickness_8;
	// System.Boolean PathCreation.Examples.RoadMeshCreator::flattenSurface
	bool ___flattenSurface_9;
	// UnityEngine.Material PathCreation.Examples.RoadMeshCreator::roadMaterial
	Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___roadMaterial_10;
	// UnityEngine.Material PathCreation.Examples.RoadMeshCreator::undersideMaterial
	Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___undersideMaterial_11;
	// System.Single PathCreation.Examples.RoadMeshCreator::textureTiling
	float ___textureTiling_12;
	// UnityEngine.GameObject PathCreation.Examples.RoadMeshCreator::meshHolder
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___meshHolder_13;
	// UnityEngine.MeshFilter PathCreation.Examples.RoadMeshCreator::meshFilter
	MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5* ___meshFilter_14;
	// UnityEngine.MeshRenderer PathCreation.Examples.RoadMeshCreator::meshRenderer
	MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE* ___meshRenderer_15;
	// UnityEngine.Mesh PathCreation.Examples.RoadMeshCreator::mesh
	Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* ___mesh_16;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
// UnityEngine.Transform[]
struct TransformU5BU5D_tBB9C5F5686CAE82E3D97D43DF0F3D68ABF75EC24  : public RuntimeArray
{
	ALIGN_FIELD (8) Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* m_Items[1];

	inline Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// UnityEngine.Vector3[]
struct Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C  : public RuntimeArray
{
	ALIGN_FIELD (8) Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 m_Items[1];

	inline Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 value)
	{
		m_Items[index] = value;
	}
};
// UnityEngine.Vector2[]
struct Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA  : public RuntimeArray
{
	ALIGN_FIELD (8) Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 m_Items[1];

	inline Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 value)
	{
		m_Items[index] = value;
	}
};
// System.Int32[]
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C  : public RuntimeArray
{
	ALIGN_FIELD (8) int32_t m_Items[1];

	inline int32_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline int32_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, int32_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline int32_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline int32_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, int32_t value)
	{
		m_Items[index] = value;
	}
};
// System.Single[]
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C  : public RuntimeArray
{
	ALIGN_FIELD (8) float m_Items[1];

	inline float GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline float* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, float value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline float GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline float* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, float value)
	{
		m_Items[index] = value;
	}
};
// UnityEngine.Material[]
struct MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D  : public RuntimeArray
{
	ALIGN_FIELD (8) Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* m_Items[1];

	inline Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.Char[]
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB  : public RuntimeArray
{
	ALIGN_FIELD (8) Il2CppChar m_Items[1];

	inline Il2CppChar GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Il2CppChar* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Il2CppChar value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline Il2CppChar GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Il2CppChar* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Il2CppChar value)
	{
		m_Items[index] = value;
	}
};
// Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType[]
struct __Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC  : public RuntimeArray
{
	ALIGN_FIELD (8) uint8_t m_Items[1];

	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + il2cpp_array_calc_byte_offset(this, index);
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + il2cpp_array_calc_byte_offset(this, index);
	}
};


// T UnityEngine.Object::Instantiate<System.Object>(T,UnityEngine.Vector3,UnityEngine.Quaternion)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Object_Instantiate_TisRuntimeObject_m249A6BA4F2F19C2D3CE217D4D31847DF0EF03EFE_gshared (RuntimeObject* ___original0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position1, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rotation2, const RuntimeMethod* method) ;
// T UnityEngine.Object::Instantiate<System.Object>(T)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Object_Instantiate_TisRuntimeObject_m90A1E6C4C2B445D2E848DB75C772D1B95AAC046A_gshared (RuntimeObject* ___original0, const RuntimeMethod* method) ;
// T UnityEngine.GameObject::GetComponent<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GameObject_GetComponent_TisIl2CppFullySharedGenericAny_m1122128E432233EB251AECF734E2B72A42A2C194_gshared (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, Il2CppFullySharedGenericAny* il2cppRetVal, const RuntimeMethod* method) ;
// T UnityEngine.GameObject::AddComponent<System.Object>()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* GameObject_AddComponent_TisRuntimeObject_m69B93700FACCF372F5753371C6E8FB780800B824_gshared (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method) ;
// System.Int32 System.Collections.Generic.List`1<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>::get_Count()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_mD2ED26ACAF3BAF386FFEA83893BA51DB9FD8BA30_gshared_inline (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A* __this, const RuntimeMethod* method) ;
// System.Int32 System.Array::IndexOf<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>(T[],T)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Array_IndexOf_TisIl2CppFullySharedGenericAny_m7E4FCA28B813E61E3F552DAEB59FD0586B67077A_gshared (__Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC* ___array0, /*Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType*/Il2CppFullySharedGenericAny ___value1, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m0AFBAEA7EC427E32CC9CA267B1930DC5DF67A374_gshared (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>::Add(T)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Add_mD4F3498FBD3BDD3F03CBCFB38041CBAC9C28CAFC_gshared_inline (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A* __this, /*Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType*/Il2CppFullySharedGenericAny ___item0, const RuntimeMethod* method) ;
// T System.Collections.Generic.List`1<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>::get_Item(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_get_Item_m6E4BA37C1FB558E4A62AE4324212E45D09C5C937_gshared (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A* __this, int32_t ___index0, Il2CppFullySharedGenericAny* il2cppRetVal, const RuntimeMethod* method) ;
// System.Collections.Generic.List`1/Enumerator<T> System.Collections.Generic.List`1<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>::GetEnumerator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1_GetEnumerator_m8B2A92ACD4FBA5FBDC3F6F4F5C23A0DDF491DA61_gshared (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A* __this, Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF* il2cppRetVal, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1/Enumerator<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Enumerator_Dispose_mFE1EBE6F6425283FEAEAE7C79D02CDE4F9D367E8_gshared (Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF* __this, const RuntimeMethod* method) ;
// T System.Collections.Generic.List`1/Enumerator<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>::get_Current()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Enumerator_get_Current_m8B42D4B2DE853B9D11B997120CD0228D4780E394_gshared_inline (Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF* __this, Il2CppFullySharedGenericAny* il2cppRetVal, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.List`1/Enumerator<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Enumerator_MoveNext_m8D8E5E878AF0A88A535AB1AB5BA4F23E151A678A_gshared (Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF* __this, const RuntimeMethod* method) ;

// System.Delegate System.Delegate::Combine(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t* Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00 (Delegate_t* ___a0, Delegate_t* ___b1, const RuntimeMethod* method) ;
// System.Delegate System.Delegate::Remove(System.Delegate,System.Delegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Delegate_t* Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3 (Delegate_t* ___source0, Delegate_t* ___value1, const RuntimeMethod* method) ;
// PathCreation.VertexPath PathCreation.PathCreator::get_path()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* PathCreator_get_path_mCDB8EFAE116EA5C84233B664D7FC5ABB3815C763 (PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* __this, const RuntimeMethod* method) ;
// System.Void System.Action::Invoke()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.MonoBehaviour::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E (MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71* __this, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Transform::get_position()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, const RuntimeMethod* method) ;
// UnityEngine.Quaternion UnityEngine.Transform::get_rotation()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Transform_get_rotation_m32AF40CA0D50C797DA639A696F8EAEC7524C179C (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, const RuntimeMethod* method) ;
// T UnityEngine.Object::Instantiate<PathCreation.PathCreator>(T,UnityEngine.Vector3,UnityEngine.Quaternion)
inline PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* Object_Instantiate_TisPathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE_m31FEE817E86702ADD34DC6FFC0C98979B42D491C (PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* ___original0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___position1, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___rotation2, const RuntimeMethod* method)
{
	return ((  PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* (*) (PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE*, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974, const RuntimeMethod*))Object_Instantiate_TisRuntimeObject_m249A6BA4F2F19C2D3CE217D4D31847DF0EF03EFE_gshared)(___original0, ___position1, ___rotation2, method);
}
// T UnityEngine.Object::Instantiate<PathCreation.Examples.PathFollower>(T)
inline PathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E* Object_Instantiate_TisPathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E_m1F52C8D2E3D958BB9F53D6C4745BC997DF361190 (PathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E* ___original0, const RuntimeMethod* method)
{
	return ((  PathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E* (*) (PathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E*, const RuntimeMethod*))Object_Instantiate_TisRuntimeObject_m90A1E6C4C2B445D2E848DB75C772D1B95AAC046A_gshared)(___original0, method);
}
// UnityEngine.Transform UnityEngine.Component::get_transform()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371 (Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Transform::set_parent(UnityEngine.Transform)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transform_set_parent_m9BD5E563B539DD5BEC342736B03F97B38A243234 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* ___value0, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Object::op_Inequality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___x0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___y1, const RuntimeMethod* method) ;
// System.Void PathCreation.Examples.RoadMeshCreator::AssignMeshComponents()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RoadMeshCreator_AssignMeshComponents_mE381F5921D60869630DFE5B9665EF6759CC0282E (RoadMeshCreator_t765ECF7A91520B0A606D722BB015194B9BFC0AF9* __this, const RuntimeMethod* method) ;
// System.Void PathCreation.Examples.RoadMeshCreator::AssignMaterials()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RoadMeshCreator_AssignMaterials_m1BDA3C67291D5D7CE67AEEF06F6619CF24753DDC (RoadMeshCreator_t765ECF7A91520B0A606D722BB015194B9BFC0AF9* __this, const RuntimeMethod* method) ;
// System.Void PathCreation.Examples.RoadMeshCreator::CreateRoadMesh()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RoadMeshCreator_CreateRoadMesh_m542B2454BA8D0F2AC09ECB9913058DFBCB8B8D7A (RoadMeshCreator_t765ECF7A91520B0A606D722BB015194B9BFC0AF9* __this, const RuntimeMethod* method) ;
// PathCreation.VertexPath PathCreation.Examples.PathSceneTool::get_path()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF (PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4* __this, const RuntimeMethod* method) ;
// System.Int32 PathCreation.VertexPath::get_NumPoints()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t VertexPath_get_NumPoints_m4B85DE0156B233F8B6715FB5DB2462F6653180D7 (VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* __this, const RuntimeMethod* method) ;
// System.Void System.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(System.Array,System.RuntimeFieldHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B (RuntimeArray* ___array0, RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 ___fldHandle1, const RuntimeMethod* method) ;
// UnityEngine.Vector3 PathCreation.VertexPath::GetTangent(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 VertexPath_GetTangent_m350CCC9836B08797381A07BD5E3E8AE37F7D2B24 (VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* __this, int32_t ___index0, const RuntimeMethod* method) ;
// UnityEngine.Vector3 PathCreation.VertexPath::GetNormal(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 VertexPath_GetNormal_mCAC8A99FA4253F008171417FD0AB0DE82EEDBA98 (VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* __this, int32_t ___index0, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Vector3::Cross(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_Cross_mF93A280558BCE756D13B6CC5DCD7DE8A43148987_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lhs0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rhs1, const RuntimeMethod* method) ;
// UnityEngine.Vector3 PathCreation.VertexPath::GetPoint(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 VertexPath_GetPoint_m574B2DE3B258F5957AD9CDA434F2FFEB591CB0CF (VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* __this, int32_t ___index0, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Vector3::op_Multiply(UnityEngine.Vector3,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Multiply_m87BA7C578F96C8E49BB07088DAAC4649F83B0353_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, float ___d1, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Vector3::op_Subtraction(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Subtraction_mE42023FF80067CB44A1D4A27EB7CF2B24CABB828_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Vector3::op_Addition(UnityEngine.Vector3,UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Addition_m78C0EC70CB66E8DCAC225743D82B268DAEE92067_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Vector2::.ctor(System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* __this, float ___x0, float ___y1, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Vector3::op_UnaryNegation(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_UnaryNegation_m5450829F333BD2A88AF9A592C4EE331661225915_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Mesh::Clear()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_Clear_m0F95397EA143D31AD0B4D332E8C6FA25A7957BC0 (Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Mesh::set_vertices(UnityEngine.Vector3[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_set_vertices_m5BB814D89E9ACA00DBF19F7D8E22CB73AC73FE5C (Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* __this, Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Mesh::set_uv(UnityEngine.Vector2[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_set_uv_m6ED9C50E0DA8166DD48AC40FD6C828B9AD2E9617 (Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* __this, Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA* ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Mesh::set_normals(UnityEngine.Vector3[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_set_normals_m85D73193C49211BE9FA135FF72D5749B16A4760B (Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* __this, Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Mesh::set_subMeshCount(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_set_subMeshCount_m8E4DB392DB0621F7DFF8543FF3943A13072B8A28 (Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Mesh::SetTriangles(System.Int32[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_SetTriangles_mD97664344427EB85BB6DC2EF91479E03B9114258 (Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* __this, Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___triangles0, int32_t ___submesh1, const RuntimeMethod* method) ;
// System.Void UnityEngine.Mesh::RecalculateBounds()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh_RecalculateBounds_mA9B293F57C6CD298AE2D2DB19061FC23B05AB90B (Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Object::op_Equality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___x0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___y1, const RuntimeMethod* method) ;
// System.Void UnityEngine.GameObject::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GameObject__ctor_m37D512B05D292F954792225E6C6EEE95293A9B88 (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, String_t* ___name0, const RuntimeMethod* method) ;
// UnityEngine.Transform UnityEngine.GameObject::get_transform()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* GameObject_get_transform_m0BC10ADFA1632166AE5544BDF9038A2650C2AE56 (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method) ;
// UnityEngine.Quaternion UnityEngine.Quaternion::get_identity()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_get_identity_m7E701AE095ED10FD5EA0B50ABCFDE2EEFF2173A5_inline (const RuntimeMethod* method) ;
// System.Void UnityEngine.Transform::set_rotation(UnityEngine.Quaternion)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transform_set_rotation_m61340DE74726CF0F9946743A727C4D444397331D (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 ___value0, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Vector3::get_zero()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_zero_m0C1249C3F25B1C70EAD3CC8B31259975A457AE39_inline (const RuntimeMethod* method) ;
// System.Void UnityEngine.Transform::set_position(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transform_set_position_mA1A817124BB41B685043DED2A9BA48CDF37C4156 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) ;
// UnityEngine.Vector3 UnityEngine.Vector3::get_one()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_one_mC9B289F1E15C42C597180C9FE6FB492495B51D02_inline (const RuntimeMethod* method) ;
// System.Void UnityEngine.Transform::set_localScale(UnityEngine.Vector3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Transform_set_localScale_mBA79E811BAF6C47B80FF76414C12B47B3CD03633 (Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* __this, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___value0, const RuntimeMethod* method) ;
// UnityEngine.GameObject UnityEngine.GameObject::get_gameObject()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* GameObject_get_gameObject_m0878015B8CF7F5D432B583C187725810D27B57DC (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method) ;
// T UnityEngine.GameObject::GetComponent<UnityEngine.MeshFilter>()
inline MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5* GameObject_GetComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mDF6525BCE37B444313BE0AA2305BDF4EB8B92FE8 (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method)
{
	MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5* il2cppRetVal;
	((  void (*) (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, Il2CppFullySharedGenericAny*, const RuntimeMethod*))GameObject_GetComponent_TisIl2CppFullySharedGenericAny_m1122128E432233EB251AECF734E2B72A42A2C194_gshared)((GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*)__this, (Il2CppFullySharedGenericAny*)&il2cppRetVal, method);
	return il2cppRetVal;
}
// System.Boolean UnityEngine.Object::op_Implicit(UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___exists0, const RuntimeMethod* method) ;
// T UnityEngine.GameObject::AddComponent<UnityEngine.MeshFilter>()
inline MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5* GameObject_AddComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mEAB8177A64DF1A50BB7996ACEEEADCD65358AC94 (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method)
{
	return ((  MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5* (*) (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, const RuntimeMethod*))GameObject_AddComponent_TisRuntimeObject_m69B93700FACCF372F5753371C6E8FB780800B824_gshared)(__this, method);
}
// T UnityEngine.GameObject::GetComponent<UnityEngine.MeshRenderer>()
inline MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE* GameObject_GetComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_m7FF948365C38BC39333D82B235A7C4EAD219960D (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method)
{
	MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE* il2cppRetVal;
	((  void (*) (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, Il2CppFullySharedGenericAny*, const RuntimeMethod*))GameObject_GetComponent_TisIl2CppFullySharedGenericAny_m1122128E432233EB251AECF734E2B72A42A2C194_gshared)((GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*)__this, (Il2CppFullySharedGenericAny*)&il2cppRetVal, method);
	return il2cppRetVal;
}
// T UnityEngine.GameObject::AddComponent<UnityEngine.MeshRenderer>()
inline MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE* GameObject_AddComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_mCDD3E77673305199F52C772AE8C7952F3864740D (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, const RuntimeMethod* method)
{
	return ((  MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE* (*) (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*, const RuntimeMethod*))GameObject_AddComponent_TisRuntimeObject_m69B93700FACCF372F5753371C6E8FB780800B824_gshared)(__this, method);
}
// System.Void UnityEngine.Mesh::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Mesh__ctor_m5A9AECEDDAFFD84811ED8928012BDE97A9CEBD00 (Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.MeshFilter::set_sharedMesh(UnityEngine.Mesh)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MeshFilter_set_sharedMesh_m946F7E3F583761982642BDA4753784AF1DF6E16F (MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5* __this, Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Renderer::set_sharedMaterials(UnityEngine.Material[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Renderer_set_sharedMaterials_m665ADE4190214CC2AC52490B4A7373D7EE75DEB2 (Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF* __this, MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D* ___value0, const RuntimeMethod* method) ;
// UnityEngine.Material[] UnityEngine.Renderer::get_sharedMaterials()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D* Renderer_get_sharedMaterials_m0B61AFD8EDA35A70C796FFB2F28BB62380051ABF (Renderer_t320575F223BCB177A982E5DDB5DB19FAA89E7FBF* __this, const RuntimeMethod* method) ;
// System.Void UnityEngine.Vector3::.ctor(System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m5F87930F9B0828E5652E2D9D01ED907C01122C86_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___x0, float ___y1, const RuntimeMethod* method) ;
// UnityEngine.Vector2 UnityEngine.Vector2::op_Implicit(UnityEngine.Vector3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Implicit_mE8EBEE9291F11BB02F062D6E000F4798968CBD96_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Material::set_mainTextureScale(UnityEngine.Vector2)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Material_set_mainTextureScale_mABC2B4327CCDC6BB0E0EA72C6F29817400F56EF1 (Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* __this, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___value0, const RuntimeMethod* method) ;
// System.Void PathCreation.Examples.PathSceneTool::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PathSceneTool__ctor_mD5CF440FBD01E98E3C41BE3C4E3FAE05180C9602 (PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4* __this, const RuntimeMethod* method) ;
// System.Int32 System.Collections.Generic.List`1<Defective.JSON.JSONObject>::get_Count()
inline int32_t List_1_get_Count_m919AA1B61CF20232484BC458BCED3FFAA510E11C_inline (List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*, const RuntimeMethod*))List_1_get_Count_mD2ED26ACAF3BAF386FFEA83893BA51DB9FD8BA30_gshared_inline)((List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*)__this, method);
}
// Defective.JSON.JSONObject Defective.JSON.JSONObject::Create(Defective.JSON.JSONObject/Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_Create_mA98A7D0FA92912A9AF75DE79D74B5CB043F5C2C7 (int32_t ___type0, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject__ctor_mF2B460AF8159D2789DCD76E03D7A97F547CF81FF (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, const RuntimeMethod* method) ;
// Defective.JSON.JSONObject Defective.JSON.JSONObject::Create()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_Create_m43209E76E53E1DBE231EB3D763841EADD511D4A3 (const RuntimeMethod* method) ;
// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::Parse(System.String,System.Int32&,System.Int32,Defective.JSON.JSONObject,System.Int32,System.Boolean,System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_Parse_m8CC10FCB272F6AC7AB77A56A8CC45CA6B6B3EE76 (String_t* ___inputString0, int32_t* ___offset1, int32_t ___endOffset2, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container3, int32_t ___maxDepth4, bool ___storeExcessLevels5, int32_t ___depth6, bool ___isRoot7, const RuntimeMethod* method) ;
// System.Void System.ArgumentNullException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* __this, String_t* ___paramName0, const RuntimeMethod* method) ;
// System.Int32 System.String::get_Length()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) ;
// System.Boolean System.String::IsNullOrEmpty(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478 (String_t* ___value0, const RuntimeMethod* method) ;
// System.Void System.ArgumentException::.ctor(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentException__ctor_m8F9D40CE19D19B698A70F9A258640EB52DB39B62 (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* __this, String_t* ___message0, String_t* ___paramName1, const RuntimeMethod* method) ;
// System.Boolean Defective.JSON.JSONObject::BeginParse(System.String,System.Int32,System.Int32&,Defective.JSON.JSONObject,System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_BeginParse_m5DC3434F026462D2385421261304923E197E6C27 (String_t* ___inputString0, int32_t ___offset1, int32_t* ___endOffset2, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container3, int32_t ___maxDepth4, bool ___storeExcessLevels5, const RuntimeMethod* method) ;
// System.Char System.String::get_Chars(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3 (String_t* __this, int32_t ___index0, const RuntimeMethod* method) ;
// System.Int32 System.Array::IndexOf<System.Char>(T[],T)
inline int32_t Array_IndexOf_TisChar_t521A6F19B456D956AF452D926C32709DC03D6B17_m6E2BDAD7B5A1E51CA8029C65DCA4E847D543DDF9 (CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* ___array0, Il2CppChar ___value1, const RuntimeMethod* method)
{
	return ((  int32_t (*) (__Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC*, /*Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType*/Il2CppFullySharedGenericAny, const RuntimeMethod*))Array_IndexOf_TisIl2CppFullySharedGenericAny_m7E4FCA28B813E61E3F552DAEB59FD0586B67077A_gshared)((__Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC*)___array0, (Il2CppFullySharedGenericAny)&___value1, method);
}
// System.Void Defective.JSON.JSONObject::SafeAddChild(Defective.JSON.JSONObject,Defective.JSON.JSONObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_SafeAddChild_mF8B89C42E3021F550FF4D7030F361B3A9578A588 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container0, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___child1, const RuntimeMethod* method) ;
// System.Boolean Defective.JSON.JSONObject::ParseObjectEnd(System.String,System.Int32,System.Boolean,Defective.JSON.JSONObject,System.Int32,System.Int32,System.Int32,System.Boolean,System.Int32,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_ParseObjectEnd_m409EF6F2E8E663FF9D81D154E14B7FB54114CB2D (String_t* ___inputString0, int32_t ___offset1, bool ___openQuote2, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container3, int32_t ___startOffset4, int32_t ___lastValidOffset5, int32_t ___maxDepth6, bool ___storeExcessLevels7, int32_t ___depth8, int32_t* ___bakeDepth9, const RuntimeMethod* method) ;
// System.Boolean Defective.JSON.JSONObject::ParseArrayEnd(System.String,System.Int32,System.Boolean,Defective.JSON.JSONObject,System.Int32,System.Int32,System.Int32,System.Boolean,System.Int32,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_ParseArrayEnd_mCD9D6A7C7F47DAA478304ED96B06ED332521C54C (String_t* ___inputString0, int32_t ___offset1, bool ___openQuote2, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container3, int32_t ___startOffset4, int32_t ___lastValidOffset5, int32_t ___maxDepth6, bool ___storeExcessLevels7, int32_t ___depth8, int32_t* ___bakeDepth9, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::ParseQuote(System.Boolean&,System.Int32,System.Int32&,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_ParseQuote_mFBA405A5993329CD10F3255B7EA5FA0B512D9B9D (bool* ___openQuote0, int32_t ___offset1, int32_t* ___quoteStart2, int32_t* ___quoteEnd3, const RuntimeMethod* method) ;
// System.Boolean Defective.JSON.JSONObject::ParseColon(System.String,System.Boolean,Defective.JSON.JSONObject,System.Int32&,System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_ParseColon_m917F7EC0729BB7E9A86C447034DA9C00310778E7 (String_t* ___inputString0, bool ___openQuote1, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container2, int32_t* ___startOffset3, int32_t ___offset4, int32_t ___quoteStart5, int32_t ___quoteEnd6, int32_t ___bakeDepth7, const RuntimeMethod* method) ;
// System.Boolean Defective.JSON.JSONObject::ParseComma(System.String,System.Boolean,Defective.JSON.JSONObject,System.Int32&,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_ParseComma_mE24033BD9D67738BC3DDC81E2F9B821C25E2E5E4 (String_t* ___inputString0, bool ___openQuote1, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container2, int32_t* ___startOffset3, int32_t ___offset4, int32_t ___lastValidOffset5, int32_t ___bakeDepth6, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1<Defective.JSON.JSONObject>::.ctor()
inline void List_1__ctor_m512620C35691CD7C02708077DD0A844BD071283D (List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*, const RuntimeMethod*))List_1__ctor_m0AFBAEA7EC427E32CC9CA267B1930DC5DF67A374_gshared)((List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*)__this, method);
}
// System.Void System.Collections.Generic.List`1<Defective.JSON.JSONObject>::Add(T)
inline void List_1_Add_m67DC8AAA1F867623E0668663DD6FECC08D3CB03C_inline (List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* __this, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*, /*Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType*/Il2CppFullySharedGenericAny, const RuntimeMethod*))List_1_Add_mD4F3498FBD3BDD3F03CBCFB38041CBAC9C28CAFC_gshared_inline)((List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*)__this, (Il2CppFullySharedGenericAny)___item0, method);
}
// System.String System.String::Substring(System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Substring_mB1D94F47935D22E130FF2C01DBB6A4135FBB76CE (String_t* __this, int32_t ___startIndex0, int32_t ___length1, const RuntimeMethod* method) ;
// System.String Defective.JSON.JSONObject::UnEscapeString(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JSONObject_UnEscapeString_m2CBA283857DD92DF360CCE6997374980C3EED39A (String_t* ___input0, const RuntimeMethod* method) ;
// System.Boolean System.String::Contains(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_Contains_m6D77B121FADA7CA5F397C0FABB65DA62DF03B6C3 (String_t* __this, String_t* ___value0, const RuntimeMethod* method) ;
// System.Globalization.CultureInfo System.Globalization.CultureInfo::get_InvariantCulture()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* CultureInfo_get_InvariantCulture_mD1E96DC845E34B10F78CB744B0CB5D7D63CEB1E6 (const RuntimeMethod* method) ;
// System.Double System.Convert::ToDouble(System.String,System.IFormatProvider)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double Convert_ToDouble_mAA66A3AA3A6E53529E4F632BC69582B4B70D32B7 (String_t* ___value0, RuntimeObject* ___provider1, const RuntimeMethod* method) ;
// System.Int64 System.Convert::ToInt64(System.String,System.IFormatProvider)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t Convert_ToInt64_m849AF82E6C86C69E45DDDD095A39679D036239B7 (String_t* ___value0, RuntimeObject* ___provider1, const RuntimeMethod* method) ;
// System.Boolean System.String::StartsWith(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_StartsWith_mF75DBA1EB709811E711B44E26FF919C88A8E65C0 (String_t* __this, String_t* ___value0, const RuntimeMethod* method) ;
// System.String System.String::Format(System.String,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Format_mA8DBB4C2516B9723C5A41E6CB1E2FAF4BBE96DD8 (String_t* ___format0, RuntimeObject* ___arg01, const RuntimeMethod* method) ;
// System.Void UnityEngine.Debug::LogWarning(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogWarning_m33EF1B897E0C7C6FF538989610BFAFFEF4628CA9 (RuntimeObject* ___message0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Debug::LogError(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogError_mB00B2B4468EF3CAF041B038D840820FB84C924B2 (RuntimeObject* ___message0, const RuntimeMethod* method) ;
// Defective.JSON.JSONObject Defective.JSON.JSONObject::get_nullObject()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_get_nullObject_m1F5C12DDD7E80EAE0F2DB6F9D0DC722F0BC76D51 (const RuntimeMethod* method) ;
// Defective.JSON.JSONObject Defective.JSON.JSONObject::CreateBakedObject(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_CreateBakedObject_m2039F450D1C8D6B09DD2929411721737706B0730 (String_t* ___value0, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::ParseFinalObjectIfNeeded(System.String,Defective.JSON.JSONObject,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_ParseFinalObjectIfNeeded_mC5BBD01E9B35A0B100D806B8A50C52F95FE6B636 (String_t* ___inputString0, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container1, int32_t ___startOffset2, int32_t ___lastValidOffset3, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1<System.String>::.ctor()
inline void List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*, const RuntimeMethod*))List_1__ctor_m0AFBAEA7EC427E32CC9CA267B1930DC5DF67A374_gshared)((List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*)__this, method);
}
// System.Void System.Collections.Generic.List`1<System.String>::Add(T)
inline void List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, String_t* ___item0, const RuntimeMethod* method)
{
	((  void (*) (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*, /*Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType*/Il2CppFullySharedGenericAny, const RuntimeMethod*))List_1_Add_mD4F3498FBD3BDD3F03CBCFB38041CBAC9C28CAFC_gshared_inline)((List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*)__this, (Il2CppFullySharedGenericAny)___item0, method);
}
// System.Boolean Defective.JSON.JSONObject::IsClosingCharacter(System.Char)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_IsClosingCharacter_m9E9726C119837264FB5CE6DAADA3ACD873C198C2 (Il2CppChar ___character0, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::ParseValue(System.String,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_ParseValue_mCCFFA4657D41ADB772EB6906B5AE76297AF0FEC3 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, String_t* ___inputString0, int32_t ___startOffset1, int32_t ___lastValidOffset2, const RuntimeMethod* method) ;
// T System.Collections.Generic.List`1<System.String>::get_Item(System.Int32)
inline String_t* List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8 (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, int32_t ___index0, const RuntimeMethod* method)
{
	String_t* il2cppRetVal;
	((  void (*) (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*, int32_t, Il2CppFullySharedGenericAny*, const RuntimeMethod*))List_1_get_Item_m6E4BA37C1FB558E4A62AE4324212E45D09C5C937_gshared)((List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*)__this, ___index0, (Il2CppFullySharedGenericAny*)&il2cppRetVal, method);
	return il2cppRetVal;
}
// System.Boolean System.String::op_Equality(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_op_Equality_m030E1B219352228970A076136E455C4E568C02C1 (String_t* ___a0, String_t* ___b1, const RuntimeMethod* method) ;
// T System.Collections.Generic.List`1<Defective.JSON.JSONObject>::get_Item(System.Int32)
inline JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* List_1_get_Item_m72F3DB0603A408B7B91C4591FADFC8E855D81490 (List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* __this, int32_t ___index0, const RuntimeMethod* method)
{
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* il2cppRetVal;
	((  void (*) (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*, int32_t, Il2CppFullySharedGenericAny*, const RuntimeMethod*))List_1_get_Item_m6E4BA37C1FB558E4A62AE4324212E45D09C5C937_gshared)((List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*)__this, ___index0, (Il2CppFullySharedGenericAny*)&il2cppRetVal, method);
	return il2cppRetVal;
}
// System.Int32 System.Collections.Generic.List`1<System.String>::get_Count()
inline int32_t List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_inline (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*, const RuntimeMethod*))List_1_get_Count_mD2ED26ACAF3BAF386FFEA83893BA51DB9FD8BA30_gshared_inline)((List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*)__this, method);
}
// System.Void System.Text.StringBuilder::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void StringBuilder__ctor_m1D99713357DE05DAFA296633639DB55F8C30587D (StringBuilder_t* __this, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::Print(System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_Print_mE75F1673BBF3CFCFF9F934E87068BFCD143AD1E8 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::Stringify(System.Int32,System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_Stringify_m1B4AB8F7C1726AA4FA744CDA2C0261771D7737CE (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, int32_t ___depth0, StringBuilder_t* ___builder1, bool ___pretty2, const RuntimeMethod* method) ;
// System.String System.String::Replace(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166 (String_t* __this, String_t* ___oldValue0, String_t* ___newValue1, const RuntimeMethod* method) ;
// System.Text.StringBuilder System.Text.StringBuilder::Append(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D (StringBuilder_t* __this, String_t* ___value0, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::StringifyString(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyString_m6C60B157ADB60C0A400CE42AD83B78BF95531578 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::StringifyNumber(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyNumber_m59CDF5A6C31D5A0B994FB91C54C70A4B52CAC63E (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, const RuntimeMethod* method) ;
// System.Int32 Defective.JSON.JSONObject::get_count()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t JSONObject_get_count_m3013D1542E66CD45405528D5A5A7DCBE4F85421F (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::StringifyEmptyObject(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyEmptyObject_mF0208881D165951D3B98AC8D67B4E9CCF450C9D4 (StringBuilder_t* ___builder0, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::BeginStringifyObjectContainer(System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_BeginStringifyObjectContainer_m5DDF0C38F6519E8291886BA780B4116C70A33B4C (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::BeginStringifyObjectField(System.Text.StringBuilder,System.Boolean,System.Int32,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_BeginStringifyObjectField_m7FD31C38CCAB181AF2499C2971B6A0FEE8D0298B (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, int32_t ___depth2, String_t* ___key3, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::EndStringifyObjectField(System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_EndStringifyObjectField_mE69FE33F5E034275318A7C3D9AE2C5A802945090 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::EndStringifyObjectContainer(System.Text.StringBuilder,System.Boolean,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_EndStringifyObjectContainer_mD874A086B26BFD0B1543B4747D14CF073639F05B (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, int32_t ___depth2, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::StringifyEmptyArray(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyEmptyArray_mC78592CCEB915F47CCB8F3F3EF3F0CEECE0CD624 (StringBuilder_t* ___builder0, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::BeginStringifyArrayContainer(System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_BeginStringifyArrayContainer_m59F4D18EDB10B3243DD1AD8CF673F92EA912AE57 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, const RuntimeMethod* method) ;
// System.Collections.Generic.List`1/Enumerator<T> System.Collections.Generic.List`1<Defective.JSON.JSONObject>::GetEnumerator()
inline Enumerator_t67AE52CF7FD6EE3C251143D6B7534AF4A04048A1 List_1_GetEnumerator_m2EA9CF993A1757CD6FA450F8FB76CE5C4797CA95 (List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* __this, const RuntimeMethod* method)
{
	Enumerator_t67AE52CF7FD6EE3C251143D6B7534AF4A04048A1 il2cppRetVal;
	((  void (*) (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*, Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF*, const RuntimeMethod*))List_1_GetEnumerator_m8B2A92ACD4FBA5FBDC3F6F4F5C23A0DDF491DA61_gshared)((List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A*)__this, (Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF*)&il2cppRetVal, method);
	return il2cppRetVal;
}
// System.Void System.Collections.Generic.List`1/Enumerator<Defective.JSON.JSONObject>::Dispose()
inline void Enumerator_Dispose_m9AB7547595606304114C14F0450F15FD30F51468 (Enumerator_t67AE52CF7FD6EE3C251143D6B7534AF4A04048A1* __this, const RuntimeMethod* method)
{
	((  void (*) (Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF*, const RuntimeMethod*))Enumerator_Dispose_mFE1EBE6F6425283FEAEAE7C79D02CDE4F9D367E8_gshared)((Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF*)__this, method);
}
// T System.Collections.Generic.List`1/Enumerator<Defective.JSON.JSONObject>::get_Current()
inline JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* Enumerator_get_Current_m1499EAC836D33EE4BDFBC30928D75545E8F29523_inline (Enumerator_t67AE52CF7FD6EE3C251143D6B7534AF4A04048A1* __this, const RuntimeMethod* method)
{
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* il2cppRetVal;
	((  void (*) (Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF*, Il2CppFullySharedGenericAny*, const RuntimeMethod*))Enumerator_get_Current_m8B42D4B2DE853B9D11B997120CD0228D4780E394_gshared_inline)((Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF*)__this, (Il2CppFullySharedGenericAny*)&il2cppRetVal, method);
	return il2cppRetVal;
}
// System.Void Defective.JSON.JSONObject::BeginStringifyArrayElement(System.Text.StringBuilder,System.Boolean,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_BeginStringifyArrayElement_m401B397C85AA21E3E8707178CD43782B533141B3 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, int32_t ___depth2, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::EndStringifyArrayElement(System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_EndStringifyArrayElement_mD9266EAC7BC72C2ED1586C924DC8EA395E34E7F9 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.List`1/Enumerator<Defective.JSON.JSONObject>::MoveNext()
inline bool Enumerator_MoveNext_mB602A35E50D2614F8EB42D0EAB33B023FB737E4B (Enumerator_t67AE52CF7FD6EE3C251143D6B7534AF4A04048A1* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF*, const RuntimeMethod*))Enumerator_MoveNext_m8D8E5E878AF0A88A535AB1AB5BA4F23E151A678A_gshared)((Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF*)__this, method);
}
// System.Void Defective.JSON.JSONObject::EndStringifyArrayContainer(System.Text.StringBuilder,System.Boolean,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_EndStringifyArrayContainer_m4A176DF24C519585CF36618B389483DB439C88EB (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, int32_t ___depth2, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::StringifyBool(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyBool_m898A6B762DB8BFF8031306FCDE98DD54113853C4 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObject::StringifyNull(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyNull_m07BEE11BF14EE6CE788602C34450790A33411004 (StringBuilder_t* ___builder0, const RuntimeMethod* method) ;
// System.String Defective.JSON.JSONObject::EscapeString(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JSONObject_EscapeString_m9D82BC2F43D518B2C71EF91E9EB70EBDA338357C (String_t* ___input0, const RuntimeMethod* method) ;
// System.Text.StringBuilder System.Text.StringBuilder::AppendFormat(System.String,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* StringBuilder_AppendFormat_mFA88863E4018C2912D1A783E0EA6DAE4F594124F (StringBuilder_t* __this, String_t* ___format0, RuntimeObject* ___arg01, const RuntimeMethod* method) ;
// System.Int32 System.Text.StringBuilder::get_Length()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t StringBuilder_get_Length_mDEA041E7357C68CC3B5885276BB403676DAAE0D8 (StringBuilder_t* __this, const RuntimeMethod* method) ;
// System.Void System.Text.StringBuilder::set_Length(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void StringBuilder_set_Length_mE2427BDAEF91C4E4A6C80F3BDF1F6E01DBCC2414 (StringBuilder_t* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.String System.Int64::ToString(System.IFormatProvider)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Int64_ToString_m5250B67D3E89B8EB829FB26136E744F1F141B7FD (int64_t* __this, RuntimeObject* ___provider0, const RuntimeMethod* method) ;
// System.Boolean System.Double::IsNegativeInfinity(System.Double)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Double_IsNegativeInfinity_m13015C1072581C43BA6AAED02596E631C18942F6_inline (double ___d0, const RuntimeMethod* method) ;
// System.Boolean System.Double::IsInfinity(System.Double)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Double_IsInfinity_mF1F2BB1A8094AF95520E754AE9888993EA948B34_inline (double ___d0, const RuntimeMethod* method) ;
// System.Boolean System.Double::IsNaN(System.Double)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Double_IsNaN_mF2BC6D1FD4813179B2CAE58D29770E42830D0883_inline (double ___d0, const RuntimeMethod* method) ;
// System.String System.Double::ToString(System.String,System.IFormatProvider)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Double_ToString_m7E3930DDFB35B1919FE538A246A59C3FC62AF789 (double* __this, String_t* ___format0, RuntimeObject* ___provider1, const RuntimeMethod* method) ;
// Defective.JSON.JSONObject Defective.JSON.JSONObject::GetField(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_GetField_m2B0D3470E8784CF807ECAE34BBE45CB39EACCC53 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, String_t* ___name0, const RuntimeMethod* method) ;
// System.String Defective.JSON.JSONObject::Print(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JSONObject_Print_m3AC68522204B19733E330B8DA1F8919099E6C284 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, bool ___pretty0, const RuntimeMethod* method) ;
// Defective.JSON.JSONObjectEnumerator Defective.JSON.JSONObject::GetEnumerator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5* JSONObject_GetEnumerator_mB47C5B15F96CECE98FD0D8B8A64AB98CC78178BF (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, const RuntimeMethod* method) ;
// System.Void Defective.JSON.JSONObjectEnumerator::.ctor(Defective.JSON.JSONObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObjectEnumerator__ctor_m24FA52671B6CD2C9492B8273FD881FA9B0499383 (JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5* __this, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___jsonObject0, const RuntimeMethod* method) ;
// System.Void System.Diagnostics.Stopwatch::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Stopwatch__ctor_mAFE6B2F45CF1C3469EF6D5307972BC098B473D0A (Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043* __this, const RuntimeMethod* method) ;
// System.Boolean Defective.JSON.JSONObject::get_isContainer()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_get_isContainer_m00F12A4F458FD3741B5B84FF00361E8B60E015CA (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, const RuntimeMethod* method) ;
// System.Void System.InvalidOperationException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162 (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* __this, String_t* ___message0, const RuntimeMethod* method) ;
// Defective.JSON.JSONObject Defective.JSON.JSONObjectEnumerator::get_Current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObjectEnumerator_get_Current_m10B9A8901D2BB6CB9D84B23AEF44B25271762D8F (JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5* __this, const RuntimeMethod* method) ;
// Defective.JSON.JSONObject Defective.JSON.JSONObject::get_Item(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_get_Item_mFDB9D6D8206F6899009E5D35EF69E5085735AB1C (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, int32_t ___index0, const RuntimeMethod* method) ;
// System.Void UnityEngine.Vector3::.ctor(System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___x0, float ___y1, float ___z2, const RuntimeMethod* method) ;
// System.Int64 System.BitConverter::DoubleToInt64Bits(System.Double)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int64_t BitConverter_DoubleToInt64Bits_m4F42741818550F9956B5FBAF88C051F4DE5B0AE6_inline (double ___value0, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void PathCreation.Examples.PathSceneTool::add_onDestroyed(System.Action)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PathSceneTool_add_onDestroyed_mED76D915A299EF9E3B12D514D42D6167E84A9226 (PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4* __this, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_0 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_1 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_2 = NULL;
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = __this->___onDestroyed_4;
		V_0 = L_0;
	}

IL_0007:
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = V_0;
		V_1 = L_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_2 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Combine_m1F725AEF318BE6F0426863490691A6F4606E7D00(L_2, L_3, NULL);
		V_2 = ((Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)CastclassSealed((RuntimeObject*)L_4, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var));
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07** L_5 = (&__this->___onDestroyed_4);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_6 = V_2;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_7 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*>(L_5, L_6, L_7);
		V_0 = L_8;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_9 = V_0;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_9) == ((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// System.Void PathCreation.Examples.PathSceneTool::remove_onDestroyed(System.Action)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PathSceneTool_remove_onDestroyed_m61C0E8412396B932ECC9D5FF8DB9B9686D2A9E10 (PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4* __this, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_0 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_1 = NULL;
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* V_2 = NULL;
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = __this->___onDestroyed_4;
		V_0 = L_0;
	}

IL_0007:
	{
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = V_0;
		V_1 = L_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_2 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_3 = ___value0;
		Delegate_t* L_4;
		L_4 = Delegate_Remove_m8B7DD5661308FA972E23CA1CC3FC9CEB355504E3(L_2, L_3, NULL);
		V_2 = ((Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)CastclassSealed((RuntimeObject*)L_4, Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07_il2cpp_TypeInfo_var));
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07** L_5 = (&__this->___onDestroyed_4);
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_6 = V_2;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_7 = V_1;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_8;
		L_8 = InterlockedCompareExchangeImpl<Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*>(L_5, L_6, L_7);
		V_0 = L_8;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_9 = V_0;
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_10 = V_1;
		if ((!(((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_9) == ((RuntimeObject*)(Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07*)L_10))))
		{
			goto IL_0007;
		}
	}
	{
		return;
	}
}
// PathCreation.VertexPath PathCreation.Examples.PathSceneTool::get_path()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF (PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4* __this, const RuntimeMethod* method) 
{
	{
		// return pathCreator.path;
		PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* L_0 = __this->___pathCreator_5;
		NullCheck(L_0);
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_1;
		L_1 = PathCreator_get_path_mCDB8EFAE116EA5C84233B664D7FC5ABB3815C763(L_0, NULL);
		return L_1;
	}
}
// System.Void PathCreation.Examples.PathSceneTool::TriggerUpdate()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PathSceneTool_TriggerUpdate_m407BF9C2AD2199B431FEF16B38518A736A9271A9 (PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4* __this, const RuntimeMethod* method) 
{
	{
		// PathUpdated();
		VirtualActionInvoker0::Invoke(5 /* System.Void PathCreation.Examples.PathSceneTool::PathUpdated() */, __this);
		// }
		return;
	}
}
// System.Void PathCreation.Examples.PathSceneTool::OnDestroy()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PathSceneTool_OnDestroy_mE28803C69ECDD2B4C20F031BAFF54A68C95751B8 (PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4* __this, const RuntimeMethod* method) 
{
	{
		// if (onDestroyed != null) {
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_0 = __this->___onDestroyed_4;
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		// onDestroyed();
		Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* L_1 = __this->___onDestroyed_4;
		NullCheck(L_1);
		Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline(L_1, NULL);
	}

IL_0013:
	{
		// }
		return;
	}
}
// System.Void PathCreation.Examples.PathSceneTool::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PathSceneTool__ctor_mD5CF440FBD01E98E3C41BE3C4E3FAE05180C9602 (PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4* __this, const RuntimeMethod* method) 
{
	{
		// public bool autoUpdate = true;
		__this->___autoUpdate_6 = (bool)1;
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
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
// System.Void PathCreation.Examples.PathSpawner::Start()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PathSpawner_Start_m32C23C4E55AE475A539E6DA7E74C0DE4ACD5905D (PathSpawner_tD3271976E287B5EB44C0EAB8C074C147A9DBE86B* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_Instantiate_TisPathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE_m31FEE817E86702ADD34DC6FFC0C98979B42D491C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_Instantiate_TisPathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E_m1F52C8D2E3D958BB9F53D6C4745BC997DF361190_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	TransformU5BU5D_tBB9C5F5686CAE82E3D97D43DF0F3D68ABF75EC24* V_0 = NULL;
	int32_t V_1 = 0;
	Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* V_2 = NULL;
	PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* V_3 = NULL;
	{
		// foreach (Transform t in spawnPoints) {
		TransformU5BU5D_tBB9C5F5686CAE82E3D97D43DF0F3D68ABF75EC24* L_0 = __this->___spawnPoints_6;
		V_0 = L_0;
		V_1 = 0;
		goto IL_0048;
	}

IL_000b:
	{
		// foreach (Transform t in spawnPoints) {
		TransformU5BU5D_tBB9C5F5686CAE82E3D97D43DF0F3D68ABF75EC24* L_1 = V_0;
		int32_t L_2 = V_1;
		NullCheck(L_1);
		int32_t L_3 = L_2;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_4 = (L_1)->GetAt(static_cast<il2cpp_array_size_t>(L_3));
		V_2 = L_4;
		// var path = Instantiate (pathPrefab, t.position, t.rotation);
		PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* L_5 = __this->___pathPrefab_4;
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_6 = V_2;
		NullCheck(L_6);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7;
		L_7 = Transform_get_position_m69CD5FA214FDAE7BB701552943674846C220FDE1(L_6, NULL);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_8 = V_2;
		NullCheck(L_8);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_9;
		L_9 = Transform_get_rotation_m32AF40CA0D50C797DA639A696F8EAEC7524C179C(L_8, NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* L_10;
		L_10 = Object_Instantiate_TisPathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE_m31FEE817E86702ADD34DC6FFC0C98979B42D491C(L_5, L_7, L_9, Object_Instantiate_TisPathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE_m31FEE817E86702ADD34DC6FFC0C98979B42D491C_RuntimeMethod_var);
		V_3 = L_10;
		// var follower = Instantiate (followerPrefab);
		PathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E* L_11 = __this->___followerPrefab_5;
		PathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E* L_12;
		L_12 = Object_Instantiate_TisPathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E_m1F52C8D2E3D958BB9F53D6C4745BC997DF361190(L_11, Object_Instantiate_TisPathFollower_t42536D293ABCEB5AC1D91CCF201153D9BE38657E_m1F52C8D2E3D958BB9F53D6C4745BC997DF361190_RuntimeMethod_var);
		// follower.pathCreator = path;
		PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* L_13 = V_3;
		NullCheck(L_12);
		L_12->___pathCreator_4 = L_13;
		Il2CppCodeGenWriteBarrier((void**)(&L_12->___pathCreator_4), (void*)L_13);
		// path.transform.parent = t;
		PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* L_14 = V_3;
		NullCheck(L_14);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_15;
		L_15 = Component_get_transform_m2919A1D81931E6932C7F06D4C2F0AB8DDA9A5371(L_14, NULL);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_16 = V_2;
		NullCheck(L_15);
		Transform_set_parent_m9BD5E563B539DD5BEC342736B03F97B38A243234(L_15, L_16, NULL);
		int32_t L_17 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_17, 1));
	}

IL_0048:
	{
		// foreach (Transform t in spawnPoints) {
		int32_t L_18 = V_1;
		TransformU5BU5D_tBB9C5F5686CAE82E3D97D43DF0F3D68ABF75EC24* L_19 = V_0;
		NullCheck(L_19);
		if ((((int32_t)L_18) < ((int32_t)((int32_t)(((RuntimeArray*)L_19)->max_length)))))
		{
			goto IL_000b;
		}
	}
	{
		// }
		return;
	}
}
// System.Void PathCreation.Examples.PathSpawner::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PathSpawner__ctor_m809B671B8A86A88E3C1AF3D858468BBF2BF7B1F3 (PathSpawner_tD3271976E287B5EB44C0EAB8C074C147A9DBE86B* __this, const RuntimeMethod* method) 
{
	{
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
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
// System.Void PathCreation.Examples.RoadMeshCreator::PathUpdated()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RoadMeshCreator_PathUpdated_mCA67E079DCB3573FD352814A9683122AFDEF2BA6 (RoadMeshCreator_t765ECF7A91520B0A606D722BB015194B9BFC0AF9* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (pathCreator != null) {
		PathCreator_t3410C82F79126B5BBB41C825469ED64F36F0A4FE* L_0 = ((PathSceneTool_tC375C6897036E4568F77269FE31DB6F8E1FECCC4*)__this)->___pathCreator_5;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_1)
		{
			goto IL_0020;
		}
	}
	{
		// AssignMeshComponents ();
		RoadMeshCreator_AssignMeshComponents_mE381F5921D60869630DFE5B9665EF6759CC0282E(__this, NULL);
		// AssignMaterials ();
		RoadMeshCreator_AssignMaterials_m1BDA3C67291D5D7CE67AEEF06F6619CF24753DDC(__this, NULL);
		// CreateRoadMesh ();
		RoadMeshCreator_CreateRoadMesh_m542B2454BA8D0F2AC09ECB9913058DFBCB8B8D7A(__this, NULL);
	}

IL_0020:
	{
		// }
		return;
	}
}
// System.Void PathCreation.Examples.RoadMeshCreator::CreateRoadMesh()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RoadMeshCreator_CreateRoadMesh_m542B2454BA8D0F2AC09ECB9913058DFBCB8B8D7A (RoadMeshCreator_t765ECF7A91520B0A606D722BB015194B9BFC0AF9* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____6E6A276CCCD4455AE240A4C37DD0783E9BCC737B1CCCC3EA145A08E2364FC998_2_FieldInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____BA75250079507D98AC2F48E9A2457F6C7346902BC6C52203B97DCACED687EE8F_3_FieldInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* V_0 = NULL;
	Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA* V_1 = NULL;
	Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* V_2 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_3 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_4 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_5 = NULL;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_8 = NULL;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_9 = NULL;
	bool V_10 = false;
	int32_t V_11 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_12;
	memset((&V_12), 0, sizeof(V_12));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_13;
	memset((&V_13), 0, sizeof(V_13));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_14;
	memset((&V_14), 0, sizeof(V_14));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_15;
	memset((&V_15), 0, sizeof(V_15));
	int32_t V_16 = 0;
	int32_t V_17 = 0;
	int32_t G_B2_0 = 0;
	int32_t G_B1_0 = 0;
	int32_t G_B3_0 = 0;
	int32_t G_B3_1 = 0;
	int32_t G_B6_0 = 0;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B10_0;
	memset((&G_B10_0), 0, sizeof(G_B10_0));
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 G_B13_0;
	memset((&G_B13_0), 0, sizeof(G_B13_0));
	{
		// Vector3[] verts = new Vector3[path.NumPoints * 8];
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_0;
		L_0 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		NullCheck(L_0);
		int32_t L_1;
		L_1 = VertexPath_get_NumPoints_m4B85DE0156B233F8B6715FB5DB2462F6653180D7(L_0, NULL);
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_2 = (Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C*)(Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C*)SZArrayNew(Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C_il2cpp_TypeInfo_var, (uint32_t)((int32_t)il2cpp_codegen_multiply(L_1, 8)));
		V_0 = L_2;
		// Vector2[] uvs = new Vector2[verts.Length];
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_3 = V_0;
		NullCheck(L_3);
		Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA* L_4 = (Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA*)(Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA*)SZArrayNew(Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA_il2cpp_TypeInfo_var, (uint32_t)((int32_t)(((RuntimeArray*)L_3)->max_length)));
		V_1 = L_4;
		// Vector3[] normals = new Vector3[verts.Length];
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_5 = V_0;
		NullCheck(L_5);
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_6 = (Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C*)(Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C*)SZArrayNew(Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C_il2cpp_TypeInfo_var, (uint32_t)((int32_t)(((RuntimeArray*)L_5)->max_length)));
		V_2 = L_6;
		// int numTris = 2 * (path.NumPoints - 1) + ((path.isClosedLoop) ? 2 : 0);
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_7;
		L_7 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		NullCheck(L_7);
		int32_t L_8;
		L_8 = VertexPath_get_NumPoints_m4B85DE0156B233F8B6715FB5DB2462F6653180D7(L_7, NULL);
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_9;
		L_9 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		NullCheck(L_9);
		bool L_10 = L_9->___isClosedLoop_1;
		G_B1_0 = ((int32_t)il2cpp_codegen_multiply(2, ((int32_t)il2cpp_codegen_subtract(L_8, 1))));
		if (L_10)
		{
			G_B2_0 = ((int32_t)il2cpp_codegen_multiply(2, ((int32_t)il2cpp_codegen_subtract(L_8, 1))));
			goto IL_0044;
		}
	}
	{
		G_B3_0 = 0;
		G_B3_1 = G_B1_0;
		goto IL_0045;
	}

IL_0044:
	{
		G_B3_0 = 2;
		G_B3_1 = G_B2_0;
	}

IL_0045:
	{
		// int[] roadTriangles = new int[numTris * 3];
		int32_t L_11 = ((int32_t)il2cpp_codegen_add(G_B3_1, G_B3_0));
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_12 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)((int32_t)il2cpp_codegen_multiply(L_11, 3)));
		V_3 = L_12;
		// int[] underRoadTriangles = new int[numTris * 3];
		int32_t L_13 = L_11;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_14 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)((int32_t)il2cpp_codegen_multiply(L_13, 3)));
		V_4 = L_14;
		// int[] sideOfRoadTriangles = new int[numTris * 2 * 3];
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_15 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)((int32_t)il2cpp_codegen_multiply(((int32_t)il2cpp_codegen_multiply(L_13, 2)), 3)));
		V_5 = L_15;
		// int vertIndex = 0;
		V_6 = 0;
		// int triIndex = 0;
		V_7 = 0;
		// int[] triangleMap = { 0, 8, 1, 1, 8, 9 };
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_16 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)6);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_17 = L_16;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_18 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____6E6A276CCCD4455AE240A4C37DD0783E9BCC737B1CCCC3EA145A08E2364FC998_2_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_17, L_18, NULL);
		V_8 = L_17;
		// int[] sidesTriangleMap = { 4, 6, 14, 12, 4, 14, 5, 15, 7, 13, 15, 5 };
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_19 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)((int32_t)12));
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_20 = L_19;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_21 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____BA75250079507D98AC2F48E9A2457F6C7346902BC6C52203B97DCACED687EE8F_3_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_20, L_21, NULL);
		V_9 = L_20;
		// bool usePathNormals = !(path.space == PathSpace.xyz && flattenSurface);
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_22;
		L_22 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		NullCheck(L_22);
		int32_t L_23 = L_22->___space_0;
		if (L_23)
		{
			goto IL_00a9;
		}
	}
	{
		bool L_24 = __this->___flattenSurface_9;
		G_B6_0 = ((((int32_t)L_24) == ((int32_t)0))? 1 : 0);
		goto IL_00aa;
	}

IL_00a9:
	{
		G_B6_0 = 1;
	}

IL_00aa:
	{
		V_10 = (bool)G_B6_0;
		// for (int i = 0; i < path.NumPoints; i++) {
		V_11 = 0;
		goto IL_034b;
	}

IL_00b4:
	{
		// Vector3 localUp = (usePathNormals) ? Vector3.Cross (path.GetTangent (i), path.GetNormal (i)) : path.up;
		bool L_25 = V_10;
		if (L_25)
		{
			goto IL_00c5;
		}
	}
	{
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_26;
		L_26 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		NullCheck(L_26);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_27 = L_26->___up_9;
		G_B10_0 = L_27;
		goto IL_00e4;
	}

IL_00c5:
	{
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_28;
		L_28 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		int32_t L_29 = V_11;
		NullCheck(L_28);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_30;
		L_30 = VertexPath_GetTangent_m350CCC9836B08797381A07BD5E3E8AE37F7D2B24(L_28, L_29, NULL);
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_31;
		L_31 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		int32_t L_32 = V_11;
		NullCheck(L_31);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_33;
		L_33 = VertexPath_GetNormal_mCAC8A99FA4253F008171417FD0AB0DE82EEDBA98(L_31, L_32, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_34;
		L_34 = Vector3_Cross_mF93A280558BCE756D13B6CC5DCD7DE8A43148987_inline(L_30, L_33, NULL);
		G_B10_0 = L_34;
	}

IL_00e4:
	{
		V_12 = G_B10_0;
		// Vector3 localRight = (usePathNormals) ? path.GetNormal (i) : Vector3.Cross (localUp, path.GetTangent (i));
		bool L_35 = V_10;
		if (L_35)
		{
			goto IL_0100;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_36 = V_12;
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_37;
		L_37 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		int32_t L_38 = V_11;
		NullCheck(L_37);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_39;
		L_39 = VertexPath_GetTangent_m350CCC9836B08797381A07BD5E3E8AE37F7D2B24(L_37, L_38, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_40;
		L_40 = Vector3_Cross_mF93A280558BCE756D13B6CC5DCD7DE8A43148987_inline(L_36, L_39, NULL);
		G_B13_0 = L_40;
		goto IL_010d;
	}

IL_0100:
	{
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_41;
		L_41 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		int32_t L_42 = V_11;
		NullCheck(L_41);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_43;
		L_43 = VertexPath_GetNormal_mCAC8A99FA4253F008171417FD0AB0DE82EEDBA98(L_41, L_42, NULL);
		G_B13_0 = L_43;
	}

IL_010d:
	{
		V_13 = G_B13_0;
		// Vector3 vertSideA = path.GetPoint (i) - localRight * Mathf.Abs (roadWidth);
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_44;
		L_44 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		int32_t L_45 = V_11;
		NullCheck(L_44);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_46;
		L_46 = VertexPath_GetPoint_m574B2DE3B258F5957AD9CDA434F2FFEB591CB0CF(L_44, L_45, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_47 = V_13;
		float L_48 = __this->___roadWidth_7;
		float L_49;
		L_49 = fabsf(L_48);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_50;
		L_50 = Vector3_op_Multiply_m87BA7C578F96C8E49BB07088DAAC4649F83B0353_inline(L_47, L_49, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_51;
		L_51 = Vector3_op_Subtraction_mE42023FF80067CB44A1D4A27EB7CF2B24CABB828_inline(L_46, L_50, NULL);
		V_14 = L_51;
		// Vector3 vertSideB = path.GetPoint (i) + localRight * Mathf.Abs (roadWidth);
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_52;
		L_52 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		int32_t L_53 = V_11;
		NullCheck(L_52);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_54;
		L_54 = VertexPath_GetPoint_m574B2DE3B258F5957AD9CDA434F2FFEB591CB0CF(L_52, L_53, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_55 = V_13;
		float L_56 = __this->___roadWidth_7;
		float L_57;
		L_57 = fabsf(L_56);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_58;
		L_58 = Vector3_op_Multiply_m87BA7C578F96C8E49BB07088DAAC4649F83B0353_inline(L_55, L_57, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_59;
		L_59 = Vector3_op_Addition_m78C0EC70CB66E8DCAC225743D82B268DAEE92067_inline(L_54, L_58, NULL);
		V_15 = L_59;
		// verts[vertIndex + 0] = vertSideA;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_60 = V_0;
		int32_t L_61 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_62 = V_14;
		NullCheck(L_60);
		(L_60)->SetAt(static_cast<il2cpp_array_size_t>(L_61), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_62);
		// verts[vertIndex + 1] = vertSideB;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_63 = V_0;
		int32_t L_64 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_65 = V_15;
		NullCheck(L_63);
		(L_63)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_64, 1))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_65);
		// verts[vertIndex + 2] = vertSideA - localUp * thickness;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_66 = V_0;
		int32_t L_67 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_68 = V_14;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_69 = V_12;
		float L_70 = __this->___thickness_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_71;
		L_71 = Vector3_op_Multiply_m87BA7C578F96C8E49BB07088DAAC4649F83B0353_inline(L_69, L_70, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_72;
		L_72 = Vector3_op_Subtraction_mE42023FF80067CB44A1D4A27EB7CF2B24CABB828_inline(L_68, L_71, NULL);
		NullCheck(L_66);
		(L_66)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_67, 2))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_72);
		// verts[vertIndex + 3] = vertSideB - localUp * thickness;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_73 = V_0;
		int32_t L_74 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_75 = V_15;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_76 = V_12;
		float L_77 = __this->___thickness_8;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_78;
		L_78 = Vector3_op_Multiply_m87BA7C578F96C8E49BB07088DAAC4649F83B0353_inline(L_76, L_77, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_79;
		L_79 = Vector3_op_Subtraction_mE42023FF80067CB44A1D4A27EB7CF2B24CABB828_inline(L_75, L_78, NULL);
		NullCheck(L_73);
		(L_73)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_74, 3))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_79);
		// verts[vertIndex + 4] = verts[vertIndex + 0];
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_80 = V_0;
		int32_t L_81 = V_6;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_82 = V_0;
		int32_t L_83 = V_6;
		NullCheck(L_82);
		int32_t L_84 = L_83;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_85 = (L_82)->GetAt(static_cast<il2cpp_array_size_t>(L_84));
		NullCheck(L_80);
		(L_80)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_81, 4))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_85);
		// verts[vertIndex + 5] = verts[vertIndex + 1];
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_86 = V_0;
		int32_t L_87 = V_6;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_88 = V_0;
		int32_t L_89 = V_6;
		NullCheck(L_88);
		int32_t L_90 = ((int32_t)il2cpp_codegen_add(L_89, 1));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_91 = (L_88)->GetAt(static_cast<il2cpp_array_size_t>(L_90));
		NullCheck(L_86);
		(L_86)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_87, 5))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_91);
		// verts[vertIndex + 6] = verts[vertIndex + 2];
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_92 = V_0;
		int32_t L_93 = V_6;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_94 = V_0;
		int32_t L_95 = V_6;
		NullCheck(L_94);
		int32_t L_96 = ((int32_t)il2cpp_codegen_add(L_95, 2));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_97 = (L_94)->GetAt(static_cast<il2cpp_array_size_t>(L_96));
		NullCheck(L_92);
		(L_92)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_93, 6))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_97);
		// verts[vertIndex + 7] = verts[vertIndex + 3];
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_98 = V_0;
		int32_t L_99 = V_6;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_100 = V_0;
		int32_t L_101 = V_6;
		NullCheck(L_100);
		int32_t L_102 = ((int32_t)il2cpp_codegen_add(L_101, 3));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_103 = (L_100)->GetAt(static_cast<il2cpp_array_size_t>(L_102));
		NullCheck(L_98);
		(L_98)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_99, 7))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_103);
		// uvs[vertIndex + 0] = new Vector2 (0, path.times[i]);
		Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA* L_104 = V_1;
		int32_t L_105 = V_6;
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_106;
		L_106 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		NullCheck(L_106);
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_107 = L_106->___times_5;
		int32_t L_108 = V_11;
		NullCheck(L_107);
		int32_t L_109 = L_108;
		float L_110 = (L_107)->GetAt(static_cast<il2cpp_array_size_t>(L_109));
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_111;
		memset((&L_111), 0, sizeof(L_111));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_111), (0.0f), L_110, /*hidden argument*/NULL);
		NullCheck(L_104);
		(L_104)->SetAt(static_cast<il2cpp_array_size_t>(L_105), (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7)L_111);
		// uvs[vertIndex + 1] = new Vector2 (1, path.times[i]);
		Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA* L_112 = V_1;
		int32_t L_113 = V_6;
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_114;
		L_114 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		NullCheck(L_114);
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_115 = L_114->___times_5;
		int32_t L_116 = V_11;
		NullCheck(L_115);
		int32_t L_117 = L_116;
		float L_118 = (L_115)->GetAt(static_cast<il2cpp_array_size_t>(L_117));
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_119;
		memset((&L_119), 0, sizeof(L_119));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_119), (1.0f), L_118, /*hidden argument*/NULL);
		NullCheck(L_112);
		(L_112)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_113, 1))), (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7)L_119);
		// normals[vertIndex + 0] = localUp;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_120 = V_2;
		int32_t L_121 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_122 = V_12;
		NullCheck(L_120);
		(L_120)->SetAt(static_cast<il2cpp_array_size_t>(L_121), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_122);
		// normals[vertIndex + 1] = localUp;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_123 = V_2;
		int32_t L_124 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_125 = V_12;
		NullCheck(L_123);
		(L_123)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_124, 1))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_125);
		// normals[vertIndex + 2] = -localUp;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_126 = V_2;
		int32_t L_127 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_128 = V_12;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_129;
		L_129 = Vector3_op_UnaryNegation_m5450829F333BD2A88AF9A592C4EE331661225915_inline(L_128, NULL);
		NullCheck(L_126);
		(L_126)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_127, 2))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_129);
		// normals[vertIndex + 3] = -localUp;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_130 = V_2;
		int32_t L_131 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_132 = V_12;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_133;
		L_133 = Vector3_op_UnaryNegation_m5450829F333BD2A88AF9A592C4EE331661225915_inline(L_132, NULL);
		NullCheck(L_130);
		(L_130)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_131, 3))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_133);
		// normals[vertIndex + 4] = -localRight;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_134 = V_2;
		int32_t L_135 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_136 = V_13;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_137;
		L_137 = Vector3_op_UnaryNegation_m5450829F333BD2A88AF9A592C4EE331661225915_inline(L_136, NULL);
		NullCheck(L_134);
		(L_134)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_135, 4))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_137);
		// normals[vertIndex + 5] = localRight;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_138 = V_2;
		int32_t L_139 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_140 = V_13;
		NullCheck(L_138);
		(L_138)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_139, 5))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_140);
		// normals[vertIndex + 6] = -localRight;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_141 = V_2;
		int32_t L_142 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_143 = V_13;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_144;
		L_144 = Vector3_op_UnaryNegation_m5450829F333BD2A88AF9A592C4EE331661225915_inline(L_143, NULL);
		NullCheck(L_141);
		(L_141)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_142, 6))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_144);
		// normals[vertIndex + 7] = localRight;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_145 = V_2;
		int32_t L_146 = V_6;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_147 = V_13;
		NullCheck(L_145);
		(L_145)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_146, 7))), (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2)L_147);
		// if (i < path.NumPoints - 1 || path.isClosedLoop) {
		int32_t L_148 = V_11;
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_149;
		L_149 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		NullCheck(L_149);
		int32_t L_150;
		L_150 = VertexPath_get_NumPoints_m4B85DE0156B233F8B6715FB5DB2462F6653180D7(L_149, NULL);
		if ((((int32_t)L_148) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_150, 1)))))
		{
			goto IL_02cd;
		}
	}
	{
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_151;
		L_151 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		NullCheck(L_151);
		bool L_152 = L_151->___isClosedLoop_1;
		if (!L_152)
		{
			goto IL_0339;
		}
	}

IL_02cd:
	{
		// for (int j = 0; j < triangleMap.Length; j++) {
		V_16 = 0;
		goto IL_0308;
	}

IL_02d2:
	{
		// roadTriangles[triIndex + j] = (vertIndex + triangleMap[j]) % verts.Length;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_153 = V_3;
		int32_t L_154 = V_7;
		int32_t L_155 = V_16;
		int32_t L_156 = V_6;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_157 = V_8;
		int32_t L_158 = V_16;
		NullCheck(L_157);
		int32_t L_159 = L_158;
		int32_t L_160 = (L_157)->GetAt(static_cast<il2cpp_array_size_t>(L_159));
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_161 = V_0;
		NullCheck(L_161);
		NullCheck(L_153);
		(L_153)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_154, L_155))), (int32_t)((int32_t)(((int32_t)il2cpp_codegen_add(L_156, L_160))%((int32_t)(((RuntimeArray*)L_161)->max_length)))));
		// underRoadTriangles[triIndex + j] = (vertIndex + triangleMap[triangleMap.Length - 1 - j] + 2) % verts.Length;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_162 = V_4;
		int32_t L_163 = V_7;
		int32_t L_164 = V_16;
		int32_t L_165 = V_6;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_166 = V_8;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_167 = V_8;
		NullCheck(L_167);
		int32_t L_168 = V_16;
		NullCheck(L_166);
		int32_t L_169 = ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_subtract(((int32_t)(((RuntimeArray*)L_167)->max_length)), 1)), L_168));
		int32_t L_170 = (L_166)->GetAt(static_cast<il2cpp_array_size_t>(L_169));
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_171 = V_0;
		NullCheck(L_171);
		NullCheck(L_162);
		(L_162)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_163, L_164))), (int32_t)((int32_t)(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_165, L_170)), 2))%((int32_t)(((RuntimeArray*)L_171)->max_length)))));
		// for (int j = 0; j < triangleMap.Length; j++) {
		int32_t L_172 = V_16;
		V_16 = ((int32_t)il2cpp_codegen_add(L_172, 1));
	}

IL_0308:
	{
		// for (int j = 0; j < triangleMap.Length; j++) {
		int32_t L_173 = V_16;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_174 = V_8;
		NullCheck(L_174);
		if ((((int32_t)L_173) < ((int32_t)((int32_t)(((RuntimeArray*)L_174)->max_length)))))
		{
			goto IL_02d2;
		}
	}
	{
		// for (int j = 0; j < sidesTriangleMap.Length; j++) {
		V_17 = 0;
		goto IL_0331;
	}

IL_0315:
	{
		// sideOfRoadTriangles[triIndex * 2 + j] = (vertIndex + sidesTriangleMap[j]) % verts.Length;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_175 = V_5;
		int32_t L_176 = V_7;
		int32_t L_177 = V_17;
		int32_t L_178 = V_6;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_179 = V_9;
		int32_t L_180 = V_17;
		NullCheck(L_179);
		int32_t L_181 = L_180;
		int32_t L_182 = (L_179)->GetAt(static_cast<il2cpp_array_size_t>(L_181));
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_183 = V_0;
		NullCheck(L_183);
		NullCheck(L_175);
		(L_175)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_multiply(L_176, 2)), L_177))), (int32_t)((int32_t)(((int32_t)il2cpp_codegen_add(L_178, L_182))%((int32_t)(((RuntimeArray*)L_183)->max_length)))));
		// for (int j = 0; j < sidesTriangleMap.Length; j++) {
		int32_t L_184 = V_17;
		V_17 = ((int32_t)il2cpp_codegen_add(L_184, 1));
	}

IL_0331:
	{
		// for (int j = 0; j < sidesTriangleMap.Length; j++) {
		int32_t L_185 = V_17;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_186 = V_9;
		NullCheck(L_186);
		if ((((int32_t)L_185) < ((int32_t)((int32_t)(((RuntimeArray*)L_186)->max_length)))))
		{
			goto IL_0315;
		}
	}

IL_0339:
	{
		// vertIndex += 8;
		int32_t L_187 = V_6;
		V_6 = ((int32_t)il2cpp_codegen_add(L_187, 8));
		// triIndex += 6;
		int32_t L_188 = V_7;
		V_7 = ((int32_t)il2cpp_codegen_add(L_188, 6));
		// for (int i = 0; i < path.NumPoints; i++) {
		int32_t L_189 = V_11;
		V_11 = ((int32_t)il2cpp_codegen_add(L_189, 1));
	}

IL_034b:
	{
		// for (int i = 0; i < path.NumPoints; i++) {
		int32_t L_190 = V_11;
		VertexPath_t4B1ABFDB26236D2545B5E7D077C8AF22EE17F5A5* L_191;
		L_191 = PathSceneTool_get_path_m72F68E384DBC035855743F4B2FCB5415DBFF14EF(__this, NULL);
		NullCheck(L_191);
		int32_t L_192;
		L_192 = VertexPath_get_NumPoints_m4B85DE0156B233F8B6715FB5DB2462F6653180D7(L_191, NULL);
		if ((((int32_t)L_190) < ((int32_t)L_192)))
		{
			goto IL_00b4;
		}
	}
	{
		// mesh.Clear ();
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_193 = __this->___mesh_16;
		NullCheck(L_193);
		Mesh_Clear_m0F95397EA143D31AD0B4D332E8C6FA25A7957BC0(L_193, NULL);
		// mesh.vertices = verts;
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_194 = __this->___mesh_16;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_195 = V_0;
		NullCheck(L_194);
		Mesh_set_vertices_m5BB814D89E9ACA00DBF19F7D8E22CB73AC73FE5C(L_194, L_195, NULL);
		// mesh.uv = uvs;
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_196 = __this->___mesh_16;
		Vector2U5BU5D_tFEBBC94BCC6C9C88277BA04047D2B3FDB6ED7FDA* L_197 = V_1;
		NullCheck(L_196);
		Mesh_set_uv_m6ED9C50E0DA8166DD48AC40FD6C828B9AD2E9617(L_196, L_197, NULL);
		// mesh.normals = normals;
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_198 = __this->___mesh_16;
		Vector3U5BU5D_tFF1859CCE176131B909E2044F76443064254679C* L_199 = V_2;
		NullCheck(L_198);
		Mesh_set_normals_m85D73193C49211BE9FA135FF72D5749B16A4760B(L_198, L_199, NULL);
		// mesh.subMeshCount = 3;
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_200 = __this->___mesh_16;
		NullCheck(L_200);
		Mesh_set_subMeshCount_m8E4DB392DB0621F7DFF8543FF3943A13072B8A28(L_200, 3, NULL);
		// mesh.SetTriangles (roadTriangles, 0);
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_201 = __this->___mesh_16;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_202 = V_3;
		NullCheck(L_201);
		Mesh_SetTriangles_mD97664344427EB85BB6DC2EF91479E03B9114258(L_201, L_202, 0, NULL);
		// mesh.SetTriangles (underRoadTriangles, 1);
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_203 = __this->___mesh_16;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_204 = V_4;
		NullCheck(L_203);
		Mesh_SetTriangles_mD97664344427EB85BB6DC2EF91479E03B9114258(L_203, L_204, 1, NULL);
		// mesh.SetTriangles (sideOfRoadTriangles, 2);
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_205 = __this->___mesh_16;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_206 = V_5;
		NullCheck(L_205);
		Mesh_SetTriangles_mD97664344427EB85BB6DC2EF91479E03B9114258(L_205, L_206, 2, NULL);
		// mesh.RecalculateBounds ();
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_207 = __this->___mesh_16;
		NullCheck(L_207);
		Mesh_RecalculateBounds_mA9B293F57C6CD298AE2D2DB19061FC23B05AB90B(L_207, NULL);
		// }
		return;
	}
}
// System.Void PathCreation.Examples.RoadMeshCreator::AssignMeshComponents()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RoadMeshCreator_AssignMeshComponents_mE381F5921D60869630DFE5B9665EF6759CC0282E (RoadMeshCreator_t765ECF7A91520B0A606D722BB015194B9BFC0AF9* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_AddComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mEAB8177A64DF1A50BB7996ACEEEADCD65358AC94_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_AddComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_mCDD3E77673305199F52C772AE8C7952F3864740D_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mDF6525BCE37B444313BE0AA2305BDF4EB8B92FE8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_GetComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_m7FF948365C38BC39333D82B235A7C4EAD219960D_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&GameObject_t76FEDD663AB33C991A9C9A23129337651094216F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral7E9AAA262720DD1434B6C5339B3252FC1055AD36);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (meshHolder == null) {
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_0 = __this->___meshHolder_13;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_1)
		{
			goto IL_001e;
		}
	}
	{
		// meshHolder = new GameObject ("Road Mesh Holder");
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_2 = (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F*)il2cpp_codegen_object_new(GameObject_t76FEDD663AB33C991A9C9A23129337651094216F_il2cpp_TypeInfo_var);
		NullCheck(L_2);
		GameObject__ctor_m37D512B05D292F954792225E6C6EEE95293A9B88(L_2, _stringLiteral7E9AAA262720DD1434B6C5339B3252FC1055AD36, NULL);
		__this->___meshHolder_13 = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___meshHolder_13), (void*)L_2);
	}

IL_001e:
	{
		// meshHolder.transform.rotation = Quaternion.identity;
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_3 = __this->___meshHolder_13;
		NullCheck(L_3);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_4;
		L_4 = GameObject_get_transform_m0BC10ADFA1632166AE5544BDF9038A2650C2AE56(L_3, NULL);
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_5;
		L_5 = Quaternion_get_identity_m7E701AE095ED10FD5EA0B50ABCFDE2EEFF2173A5_inline(NULL);
		NullCheck(L_4);
		Transform_set_rotation_m61340DE74726CF0F9946743A727C4D444397331D(L_4, L_5, NULL);
		// meshHolder.transform.position = Vector3.zero;
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_6 = __this->___meshHolder_13;
		NullCheck(L_6);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_7;
		L_7 = GameObject_get_transform_m0BC10ADFA1632166AE5544BDF9038A2650C2AE56(L_6, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8;
		L_8 = Vector3_get_zero_m0C1249C3F25B1C70EAD3CC8B31259975A457AE39_inline(NULL);
		NullCheck(L_7);
		Transform_set_position_mA1A817124BB41B685043DED2A9BA48CDF37C4156(L_7, L_8, NULL);
		// meshHolder.transform.localScale = Vector3.one;
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_9 = __this->___meshHolder_13;
		NullCheck(L_9);
		Transform_tB27202C6F4E36D225EE28A13E4D662BF99785DB1* L_10;
		L_10 = GameObject_get_transform_m0BC10ADFA1632166AE5544BDF9038A2650C2AE56(L_9, NULL);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_11;
		L_11 = Vector3_get_one_mC9B289F1E15C42C597180C9FE6FB492495B51D02_inline(NULL);
		NullCheck(L_10);
		Transform_set_localScale_mBA79E811BAF6C47B80FF76414C12B47B3CD03633(L_10, L_11, NULL);
		// if (!meshHolder.gameObject.GetComponent<MeshFilter> ()) {
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_12 = __this->___meshHolder_13;
		NullCheck(L_12);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_13;
		L_13 = GameObject_get_gameObject_m0878015B8CF7F5D432B583C187725810D27B57DC(L_12, NULL);
		NullCheck(L_13);
		MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5* L_14;
		L_14 = GameObject_GetComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mDF6525BCE37B444313BE0AA2305BDF4EB8B92FE8(L_13, GameObject_GetComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mDF6525BCE37B444313BE0AA2305BDF4EB8B92FE8_RuntimeMethod_var);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_15;
		L_15 = Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A(L_14, NULL);
		if (L_15)
		{
			goto IL_0085;
		}
	}
	{
		// meshHolder.gameObject.AddComponent<MeshFilter> ();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_16 = __this->___meshHolder_13;
		NullCheck(L_16);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_17;
		L_17 = GameObject_get_gameObject_m0878015B8CF7F5D432B583C187725810D27B57DC(L_16, NULL);
		NullCheck(L_17);
		MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5* L_18;
		L_18 = GameObject_AddComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mEAB8177A64DF1A50BB7996ACEEEADCD65358AC94(L_17, GameObject_AddComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mEAB8177A64DF1A50BB7996ACEEEADCD65358AC94_RuntimeMethod_var);
	}

IL_0085:
	{
		// if (!meshHolder.GetComponent<MeshRenderer> ()) {
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_19 = __this->___meshHolder_13;
		NullCheck(L_19);
		MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE* L_20;
		L_20 = GameObject_GetComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_m7FF948365C38BC39333D82B235A7C4EAD219960D(L_19, GameObject_GetComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_m7FF948365C38BC39333D82B235A7C4EAD219960D_RuntimeMethod_var);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_21;
		L_21 = Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A(L_20, NULL);
		if (L_21)
		{
			goto IL_00a8;
		}
	}
	{
		// meshHolder.gameObject.AddComponent<MeshRenderer> ();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_22 = __this->___meshHolder_13;
		NullCheck(L_22);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_23;
		L_23 = GameObject_get_gameObject_m0878015B8CF7F5D432B583C187725810D27B57DC(L_22, NULL);
		NullCheck(L_23);
		MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE* L_24;
		L_24 = GameObject_AddComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_mCDD3E77673305199F52C772AE8C7952F3864740D(L_23, GameObject_AddComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_mCDD3E77673305199F52C772AE8C7952F3864740D_RuntimeMethod_var);
	}

IL_00a8:
	{
		// meshRenderer = meshHolder.GetComponent<MeshRenderer> ();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_25 = __this->___meshHolder_13;
		NullCheck(L_25);
		MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE* L_26;
		L_26 = GameObject_GetComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_m7FF948365C38BC39333D82B235A7C4EAD219960D(L_25, GameObject_GetComponent_TisMeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE_m7FF948365C38BC39333D82B235A7C4EAD219960D_RuntimeMethod_var);
		__this->___meshRenderer_15 = L_26;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___meshRenderer_15), (void*)L_26);
		// meshFilter = meshHolder.GetComponent<MeshFilter> ();
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_27 = __this->___meshHolder_13;
		NullCheck(L_27);
		MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5* L_28;
		L_28 = GameObject_GetComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mDF6525BCE37B444313BE0AA2305BDF4EB8B92FE8(L_27, GameObject_GetComponent_TisMeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5_mDF6525BCE37B444313BE0AA2305BDF4EB8B92FE8_RuntimeMethod_var);
		__this->___meshFilter_14 = L_28;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___meshFilter_14), (void*)L_28);
		// if (mesh == null) {
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_29 = __this->___mesh_16;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_30;
		L_30 = Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605(L_29, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_30)
		{
			goto IL_00e3;
		}
	}
	{
		// mesh = new Mesh ();
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_31 = (Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4*)il2cpp_codegen_object_new(Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4_il2cpp_TypeInfo_var);
		NullCheck(L_31);
		Mesh__ctor_m5A9AECEDDAFFD84811ED8928012BDE97A9CEBD00(L_31, NULL);
		__this->___mesh_16 = L_31;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___mesh_16), (void*)L_31);
	}

IL_00e3:
	{
		// meshFilter.sharedMesh = mesh;
		MeshFilter_t6D1CE2473A1E45AC73013400585A1163BF66B2F5* L_32 = __this->___meshFilter_14;
		Mesh_t6D9C539763A09BC2B12AEAEF36F6DFFC98AE63D4* L_33 = __this->___mesh_16;
		NullCheck(L_32);
		MeshFilter_set_sharedMesh_m946F7E3F583761982642BDA4753784AF1DF6E16F(L_32, L_33, NULL);
		// }
		return;
	}
}
// System.Void PathCreation.Examples.RoadMeshCreator::AssignMaterials()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RoadMeshCreator_AssignMaterials_m1BDA3C67291D5D7CE67AEEF06F6619CF24753DDC (RoadMeshCreator_t765ECF7A91520B0A606D722BB015194B9BFC0AF9* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (roadMaterial != null && undersideMaterial != null) {
		Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* L_0 = __this->___roadMaterial_10;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_1)
		{
			goto IL_006f;
		}
	}
	{
		Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* L_2 = __this->___undersideMaterial_11;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = Object_op_Inequality_mD0BE578448EAA61948F25C32F8DD55AB1F778602(L_2, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_3)
		{
			goto IL_006f;
		}
	}
	{
		// meshRenderer.sharedMaterials = new Material[] { roadMaterial, undersideMaterial, undersideMaterial };
		MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE* L_4 = __this->___meshRenderer_15;
		MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D* L_5 = (MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D*)(MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D*)SZArrayNew(MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D_il2cpp_TypeInfo_var, (uint32_t)3);
		MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D* L_6 = L_5;
		Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* L_7 = __this->___roadMaterial_10;
		NullCheck(L_6);
		ArrayElementTypeCheck (L_6, L_7);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(0), (Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3*)L_7);
		MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D* L_8 = L_6;
		Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* L_9 = __this->___undersideMaterial_11;
		NullCheck(L_8);
		ArrayElementTypeCheck (L_8, L_9);
		(L_8)->SetAt(static_cast<il2cpp_array_size_t>(1), (Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3*)L_9);
		MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D* L_10 = L_8;
		Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* L_11 = __this->___undersideMaterial_11;
		NullCheck(L_10);
		ArrayElementTypeCheck (L_10, L_11);
		(L_10)->SetAt(static_cast<il2cpp_array_size_t>(2), (Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3*)L_11);
		NullCheck(L_4);
		Renderer_set_sharedMaterials_m665ADE4190214CC2AC52490B4A7373D7EE75DEB2(L_4, L_10, NULL);
		// meshRenderer.sharedMaterials[0].mainTextureScale = new Vector3 (1, textureTiling);
		MeshRenderer_t4B7747212F0B88244BB7790C61AE124BFC15BAAE* L_12 = __this->___meshRenderer_15;
		NullCheck(L_12);
		MaterialU5BU5D_t2B1D11C42DB07A4400C0535F92DBB87A2E346D3D* L_13;
		L_13 = Renderer_get_sharedMaterials_m0B61AFD8EDA35A70C796FFB2F28BB62380051ABF(L_12, NULL);
		NullCheck(L_13);
		int32_t L_14 = 0;
		Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* L_15 = (L_13)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
		float L_16 = __this->___textureTiling_12;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_17;
		memset((&L_17), 0, sizeof(L_17));
		Vector3__ctor_m5F87930F9B0828E5652E2D9D01ED907C01122C86_inline((&L_17), (1.0f), L_16, /*hidden argument*/NULL);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_18;
		L_18 = Vector2_op_Implicit_mE8EBEE9291F11BB02F062D6E000F4798968CBD96_inline(L_17, NULL);
		NullCheck(L_15);
		Material_set_mainTextureScale_mABC2B4327CCDC6BB0E0EA72C6F29817400F56EF1(L_15, L_18, NULL);
	}

IL_006f:
	{
		// }
		return;
	}
}
// System.Void PathCreation.Examples.RoadMeshCreator::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RoadMeshCreator__ctor_mC9E751781592C035A35CB786BA0EF703201E4C93 (RoadMeshCreator_t765ECF7A91520B0A606D722BB015194B9BFC0AF9* __this, const RuntimeMethod* method) 
{
	{
		// public float roadWidth = .4f;
		__this->___roadWidth_7 = (0.400000006f);
		// public float thickness = .15f;
		__this->___thickness_8 = (0.150000006f);
		// public float textureTiling = 1;
		__this->___textureTiling_12 = (1.0f);
		PathSceneTool__ctor_mD5CF440FBD01E98E3C41BE3C4E3FAE05180C9602(__this, NULL);
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
// System.Boolean Defective.JSON.JSONObject::get_isContainer()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_get_isContainer_m00F12A4F458FD3741B5B84FF00361E8B60E015CA (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, const RuntimeMethod* method) 
{
	{
		// get { return type == Type.Array || type == Type.Object; }
		int32_t L_0 = __this->___type_2;
		if ((((int32_t)L_0) == ((int32_t)4)))
		{
			goto IL_0013;
		}
	}
	{
		int32_t L_1 = __this->___type_2;
		return (bool)((((int32_t)L_1) == ((int32_t)3))? 1 : 0);
	}

IL_0013:
	{
		return (bool)1;
	}
}
// System.Int32 Defective.JSON.JSONObject::get_count()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t JSONObject_get_count_m3013D1542E66CD45405528D5A5A7DCBE4F85421F (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_m919AA1B61CF20232484BC458BCED3FFAA510E11C_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return list == null ? 0 : list.Count;
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_0 = __this->___list_3;
		if (!L_0)
		{
			goto IL_0014;
		}
	}
	{
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_1 = __this->___list_3;
		NullCheck(L_1);
		int32_t L_2;
		L_2 = List_1_get_Count_m919AA1B61CF20232484BC458BCED3FFAA510E11C_inline(L_1, List_1_get_Count_m919AA1B61CF20232484BC458BCED3FFAA510E11C_RuntimeMethod_var);
		return L_2;
	}

IL_0014:
	{
		return 0;
	}
}
// Defective.JSON.JSONObject Defective.JSON.JSONObject::get_nullObject()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_get_nullObject_m1F5C12DDD7E80EAE0F2DB6F9D0DC722F0BC76D51 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// get { return Create(Type.Null); }
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_0;
		L_0 = JSONObject_Create_mA98A7D0FA92912A9AF75DE79D74B5CB043F5C2C7(0, NULL);
		return L_0;
	}
}
// Defective.JSON.JSONObject Defective.JSON.JSONObject::Create()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_Create_m43209E76E53E1DBE231EB3D763841EADD511D4A3 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return new JSONObject();
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_0 = (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC*)il2cpp_codegen_object_new(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		JSONObject__ctor_mF2B460AF8159D2789DCD76E03D7A97F547CF81FF(L_0, NULL);
		return L_0;
	}
}
// Defective.JSON.JSONObject Defective.JSON.JSONObject::Create(Defective.JSON.JSONObject/Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_Create_mA98A7D0FA92912A9AF75DE79D74B5CB043F5C2C7 (int32_t ___type0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// var jsonObject = Create();
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_0;
		L_0 = JSONObject_Create_m43209E76E53E1DBE231EB3D763841EADD511D4A3(NULL);
		// jsonObject.type = type;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_1 = L_0;
		int32_t L_2 = ___type0;
		NullCheck(L_1);
		L_1->___type_2 = L_2;
		// return jsonObject;
		return L_1;
	}
}
// Defective.JSON.JSONObject Defective.JSON.JSONObject::CreateBakedObject(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_CreateBakedObject_m2039F450D1C8D6B09DD2929411721737706B0730 (String_t* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// var bakedObject = Create();
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_0;
		L_0 = JSONObject_Create_m43209E76E53E1DBE231EB3D763841EADD511D4A3(NULL);
		// bakedObject.type = Type.Baked;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_1 = L_0;
		NullCheck(L_1);
		L_1->___type_2 = 6;
		// bakedObject.stringValue = value;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_2 = L_1;
		String_t* L_3 = ___value0;
		NullCheck(L_2);
		L_2->___stringValue_5 = L_3;
		Il2CppCodeGenWriteBarrier((void**)(&L_2->___stringValue_5), (void*)L_3);
		// return bakedObject;
		return L_2;
	}
}
// System.Void Defective.JSON.JSONObject::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject__ctor_mF2B460AF8159D2789DCD76E03D7A97F547CF81FF (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, const RuntimeMethod* method) 
{
	{
		// public JSONObject() { }
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// public JSONObject() { }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::.ctor(System.String,System.Int32,System.Int32,System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject__ctor_mFE2486DED26CD17E22720E73F1E624E532EAFF8A (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, String_t* ___jsonString0, int32_t ___offset1, int32_t ___endOffset2, int32_t ___maxDepth3, bool ___storeExcessLevels4, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public JSONObject(string jsonString, int offset = 0, int endOffset = -1, int maxDepth = -1, bool storeExcessLevels = false) {
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// Parse(jsonString, ref offset, endOffset, this, maxDepth, storeExcessLevels);
		String_t* L_0 = ___jsonString0;
		int32_t L_1 = ___endOffset2;
		int32_t L_2 = ___maxDepth3;
		bool L_3 = ___storeExcessLevels4;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_Parse_m8CC10FCB272F6AC7AB77A56A8CC45CA6B6B3EE76(L_0, (&___offset1), L_1, __this, L_2, L_3, 0, (bool)1, NULL);
		// }
		return;
	}
}
// System.Boolean Defective.JSON.JSONObject::BeginParse(System.String,System.Int32,System.Int32&,Defective.JSON.JSONObject,System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_BeginParse_m5DC3434F026462D2385421261304923E197E6C27 (String_t* ___inputString0, int32_t ___offset1, int32_t* ___endOffset2, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container3, int32_t ___maxDepth4, bool ___storeExcessLevels5, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		// if (container == null)
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_0 = ___container3;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		// throw new ArgumentNullException("container");
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_1 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		NullCheck(L_1);
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral0074C49CE7D7ED9232C28459AA9DB19B1D06C223)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&JSONObject_BeginParse_m5DC3434F026462D2385421261304923E197E6C27_RuntimeMethod_var)));
	}

IL_000e:
	{
		// if (maxDepth == 0) {
		int32_t L_2 = ___maxDepth4;
		if (L_2)
		{
			goto IL_002f;
		}
	}
	{
		// if (storeExcessLevels) {
		bool L_3 = ___storeExcessLevels5;
		if (!L_3)
		{
			goto IL_0026;
		}
	}
	{
		// container.stringValue = inputString;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_4 = ___container3;
		String_t* L_5 = ___inputString0;
		NullCheck(L_4);
		L_4->___stringValue_5 = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&L_4->___stringValue_5), (void*)L_5);
		// container.type = Type.Baked;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_6 = ___container3;
		NullCheck(L_6);
		L_6->___type_2 = 6;
		goto IL_002d;
	}

IL_0026:
	{
		// container.type = Type.Null;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_7 = ___container3;
		NullCheck(L_7);
		L_7->___type_2 = 0;
	}

IL_002d:
	{
		// return false;
		return (bool)0;
	}

IL_002f:
	{
		// var stringLength = inputString.Length;
		String_t* L_8 = ___inputString0;
		NullCheck(L_8);
		int32_t L_9;
		L_9 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_8, NULL);
		V_0 = L_9;
		// if (endOffset == -1)
		int32_t* L_10 = ___endOffset2;
		int32_t L_11 = *((int32_t*)L_10);
		if ((!(((uint32_t)L_11) == ((uint32_t)(-1)))))
		{
			goto IL_0040;
		}
	}
	{
		// endOffset = stringLength - 1;
		int32_t* L_12 = ___endOffset2;
		int32_t L_13 = V_0;
		*((int32_t*)L_12) = (int32_t)((int32_t)il2cpp_codegen_subtract(L_13, 1));
	}

IL_0040:
	{
		// if (string.IsNullOrEmpty(inputString)) {
		String_t* L_14 = ___inputString0;
		bool L_15;
		L_15 = String_IsNullOrEmpty_mEA9E3FB005AC28FE02E69FCF95A7B8456192B478(L_14, NULL);
		if (!L_15)
		{
			goto IL_004a;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_004a:
	{
		// if (endOffset >= stringLength)
		int32_t* L_16 = ___endOffset2;
		int32_t L_17 = *((int32_t*)L_16);
		int32_t L_18 = V_0;
		if ((((int32_t)L_17) < ((int32_t)L_18)))
		{
			goto IL_005f;
		}
	}
	{
		// throw new ArgumentException("Cannot parse if end offset is greater than or equal to string length", "endOffset");
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_19 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_19);
		ArgumentException__ctor_m8F9D40CE19D19B698A70F9A258640EB52DB39B62(L_19, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralF269C8AA670766E94BF5B0AB838989B114D6C9D8)), ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralB18401C35133C78B1809EA9659B10913E2F430A7)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_19, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&JSONObject_BeginParse_m5DC3434F026462D2385421261304923E197E6C27_RuntimeMethod_var)));
	}

IL_005f:
	{
		// if (offset >= endOffset)
		int32_t L_20 = ___offset1;
		int32_t* L_21 = ___endOffset2;
		int32_t L_22 = *((int32_t*)L_21);
		if ((((int32_t)L_20) < ((int32_t)L_22)))
		{
			goto IL_0074;
		}
	}
	{
		// throw new ArgumentException("Cannot parse if offset is greater than or equal to end offset", "offset");
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_23 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_23);
		ArgumentException__ctor_m8F9D40CE19D19B698A70F9A258640EB52DB39B62(L_23, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralA5A52E47B1F94FFB41929E7E93154B6B04402E29)), ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral544DC80A2A82A08B6321F56F8987CB7E5DEED1C4)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_23, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&JSONObject_BeginParse_m5DC3434F026462D2385421261304923E197E6C27_RuntimeMethod_var)));
	}

IL_0074:
	{
		// return true;
		return (bool)1;
	}
}
// System.Void Defective.JSON.JSONObject::Parse(System.String,System.Int32&,System.Int32,Defective.JSON.JSONObject,System.Int32,System.Boolean,System.Int32,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_Parse_m8CC10FCB272F6AC7AB77A56A8CC45CA6B6B3EE76 (String_t* ___inputString0, int32_t* ___offset1, int32_t ___endOffset2, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container3, int32_t ___maxDepth4, bool ___storeExcessLevels5, int32_t ___depth6, bool ___isRoot7, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Array_IndexOf_TisChar_t521A6F19B456D956AF452D926C32709DC03D6B17_m6E2BDAD7B5A1E51CA8029C65DCA4E847D543DDF9_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	int32_t V_5 = 0;
	Il2CppChar V_6 = 0x0;
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* V_7 = NULL;
	int32_t V_8 = 0;
	{
		// if (!BeginParse(inputString, offset, ref endOffset, container, maxDepth, storeExcessLevels))
		String_t* L_0 = ___inputString0;
		int32_t* L_1 = ___offset1;
		int32_t L_2 = *((int32_t*)L_1);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_3 = ___container3;
		int32_t L_4 = ___maxDepth4;
		bool L_5 = ___storeExcessLevels5;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		bool L_6;
		L_6 = JSONObject_BeginParse_m5DC3434F026462D2385421261304923E197E6C27(L_0, L_2, (&___endOffset2), L_3, L_4, L_5, NULL);
		if (L_6)
		{
			goto IL_0012;
		}
	}
	{
		// return;
		return;
	}

IL_0012:
	{
		// var startOffset = offset;
		int32_t* L_7 = ___offset1;
		int32_t L_8 = *((int32_t*)L_7);
		V_0 = L_8;
		// var quoteStart = 0;
		V_1 = 0;
		// var quoteEnd = 0;
		V_2 = 0;
		// var lastValidOffset = offset;
		int32_t* L_9 = ___offset1;
		int32_t L_10 = *((int32_t*)L_9);
		V_3 = L_10;
		// var openQuote = false;
		V_4 = (bool)0;
		// var bakeDepth = 0;
		V_5 = 0;
		goto IL_01b6;
	}

IL_0027:
	{
		// var currentCharacter = inputString[offset++];
		String_t* L_11 = ___inputString0;
		int32_t* L_12 = ___offset1;
		int32_t* L_13 = ___offset1;
		int32_t L_14 = *((int32_t*)L_13);
		V_8 = L_14;
		int32_t L_15 = V_8;
		*((int32_t*)L_12) = (int32_t)((int32_t)il2cpp_codegen_add(L_15, 1));
		int32_t L_16 = V_8;
		NullCheck(L_11);
		Il2CppChar L_17;
		L_17 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_11, L_16, NULL);
		V_6 = L_17;
		// if (Array.IndexOf(Whitespace, currentCharacter) > -1)
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* L_18 = ((JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_StaticFields*)il2cpp_codegen_static_fields_for(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var))->___Whitespace_1;
		Il2CppChar L_19 = V_6;
		int32_t L_20;
		L_20 = Array_IndexOf_TisChar_t521A6F19B456D956AF452D926C32709DC03D6B17_m6E2BDAD7B5A1E51CA8029C65DCA4E847D543DDF9(L_18, L_19, Array_IndexOf_TisChar_t521A6F19B456D956AF452D926C32709DC03D6B17_m6E2BDAD7B5A1E51CA8029C65DCA4E847D543DDF9_RuntimeMethod_var);
		if ((((int32_t)L_20) > ((int32_t)(-1))))
		{
			goto IL_01b6;
		}
	}
	{
		Il2CppChar L_21 = V_6;
		if ((!(((uint32_t)L_21) <= ((uint32_t)((int32_t)58)))))
		{
			goto IL_0073;
		}
	}
	{
		Il2CppChar L_22 = V_6;
		if ((((int32_t)L_22) == ((int32_t)((int32_t)34))))
		{
			goto IL_017b;
		}
	}
	{
		Il2CppChar L_23 = V_6;
		if ((((int32_t)L_23) == ((int32_t)((int32_t)44))))
		{
			goto IL_019e;
		}
	}
	{
		Il2CppChar L_24 = V_6;
		if ((((int32_t)L_24) == ((int32_t)((int32_t)58))))
		{
			goto IL_018a;
		}
	}
	{
		goto IL_01b1;
	}

IL_0073:
	{
		Il2CppChar L_25 = V_6;
		switch (((int32_t)il2cpp_codegen_subtract((int32_t)L_25, ((int32_t)91))))
		{
			case 0:
			{
				goto IL_00fb;
			}
			case 1:
			{
				goto IL_009d;
			}
			case 2:
			{
				goto IL_0163;
			}
		}
	}
	{
		Il2CppChar L_26 = V_6;
		if ((((int32_t)L_26) == ((int32_t)((int32_t)123))))
		{
			goto IL_00a8;
		}
	}
	{
		Il2CppChar L_27 = V_6;
		if ((((int32_t)L_27) == ((int32_t)((int32_t)125))))
		{
			goto IL_014b;
		}
	}
	{
		goto IL_01b1;
	}

IL_009d:
	{
		// offset++;
		int32_t* L_28 = ___offset1;
		int32_t* L_29 = ___offset1;
		int32_t L_30 = *((int32_t*)L_29);
		*((int32_t*)L_28) = (int32_t)((int32_t)il2cpp_codegen_add(L_30, 1));
		// break;
		goto IL_01b1;
	}

IL_00a8:
	{
		// if (openQuote)
		bool L_31 = V_4;
		if (L_31)
		{
			goto IL_01b1;
		}
	}
	{
		// if (maxDepth >= 0 && depth >= maxDepth) {
		int32_t L_32 = ___maxDepth4;
		if ((((int32_t)L_32) < ((int32_t)0)))
		{
			goto IL_00c5;
		}
	}
	{
		int32_t L_33 = ___depth6;
		int32_t L_34 = ___maxDepth4;
		if ((((int32_t)L_33) < ((int32_t)L_34)))
		{
			goto IL_00c5;
		}
	}
	{
		// bakeDepth++;
		int32_t L_35 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_35, 1));
		// break;
		goto IL_01b1;
	}

IL_00c5:
	{
		// newContainer = container;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_36 = ___container3;
		V_7 = L_36;
		// if (!isRoot) {
		bool L_37 = ___isRoot7;
		if (L_37)
		{
			goto IL_00db;
		}
	}
	{
		// newContainer = Create();
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_38;
		L_38 = JSONObject_Create_m43209E76E53E1DBE231EB3D763841EADD511D4A3(NULL);
		V_7 = L_38;
		// SafeAddChild(container, newContainer);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_39 = ___container3;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_40 = V_7;
		JSONObject_SafeAddChild_mF8B89C42E3021F550FF4D7030F361B3A9578A588(L_39, L_40, NULL);
	}

IL_00db:
	{
		// newContainer.type = Type.Object;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_41 = V_7;
		NullCheck(L_41);
		L_41->___type_2 = 3;
		// Parse(inputString, ref offset, endOffset, newContainer, maxDepth, storeExcessLevels, depth + 1, false);
		String_t* L_42 = ___inputString0;
		int32_t* L_43 = ___offset1;
		int32_t L_44 = ___endOffset2;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_45 = V_7;
		int32_t L_46 = ___maxDepth4;
		bool L_47 = ___storeExcessLevels5;
		int32_t L_48 = ___depth6;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_Parse_m8CC10FCB272F6AC7AB77A56A8CC45CA6B6B3EE76(L_42, L_43, L_44, L_45, L_46, L_47, ((int32_t)il2cpp_codegen_add(L_48, 1)), (bool)0, NULL);
		// break;
		goto IL_01b1;
	}

IL_00fb:
	{
		// if (openQuote)
		bool L_49 = V_4;
		if (L_49)
		{
			goto IL_01b1;
		}
	}
	{
		// if (maxDepth >= 0 && depth >= maxDepth) {
		int32_t L_50 = ___maxDepth4;
		if ((((int32_t)L_50) < ((int32_t)0)))
		{
			goto IL_0118;
		}
	}
	{
		int32_t L_51 = ___depth6;
		int32_t L_52 = ___maxDepth4;
		if ((((int32_t)L_51) < ((int32_t)L_52)))
		{
			goto IL_0118;
		}
	}
	{
		// bakeDepth++;
		int32_t L_53 = V_5;
		V_5 = ((int32_t)il2cpp_codegen_add(L_53, 1));
		// break;
		goto IL_01b1;
	}

IL_0118:
	{
		// newContainer = container;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_54 = ___container3;
		V_7 = L_54;
		// if (!isRoot) {
		bool L_55 = ___isRoot7;
		if (L_55)
		{
			goto IL_012e;
		}
	}
	{
		// newContainer = Create();
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_56;
		L_56 = JSONObject_Create_m43209E76E53E1DBE231EB3D763841EADD511D4A3(NULL);
		V_7 = L_56;
		// SafeAddChild(container, newContainer);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_57 = ___container3;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_58 = V_7;
		JSONObject_SafeAddChild_mF8B89C42E3021F550FF4D7030F361B3A9578A588(L_57, L_58, NULL);
	}

IL_012e:
	{
		// newContainer.type = Type.Array;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_59 = V_7;
		NullCheck(L_59);
		L_59->___type_2 = 4;
		// Parse(inputString, ref offset, endOffset, newContainer, maxDepth, storeExcessLevels, depth + 1, false);
		String_t* L_60 = ___inputString0;
		int32_t* L_61 = ___offset1;
		int32_t L_62 = ___endOffset2;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_63 = V_7;
		int32_t L_64 = ___maxDepth4;
		bool L_65 = ___storeExcessLevels5;
		int32_t L_66 = ___depth6;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_Parse_m8CC10FCB272F6AC7AB77A56A8CC45CA6B6B3EE76(L_60, L_61, L_62, L_63, L_64, L_65, ((int32_t)il2cpp_codegen_add(L_66, 1)), (bool)0, NULL);
		// break;
		goto IL_01b1;
	}

IL_014b:
	{
		// if (!ParseObjectEnd(inputString, offset, openQuote, container, startOffset, lastValidOffset, maxDepth, storeExcessLevels, depth, ref bakeDepth))
		String_t* L_67 = ___inputString0;
		int32_t* L_68 = ___offset1;
		int32_t L_69 = *((int32_t*)L_68);
		bool L_70 = V_4;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_71 = ___container3;
		int32_t L_72 = V_0;
		int32_t L_73 = V_3;
		int32_t L_74 = ___maxDepth4;
		bool L_75 = ___storeExcessLevels5;
		int32_t L_76 = ___depth6;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		bool L_77;
		L_77 = JSONObject_ParseObjectEnd_m409EF6F2E8E663FF9D81D154E14B7FB54114CB2D(L_67, L_69, L_70, L_71, L_72, L_73, L_74, L_75, L_76, (&V_5), NULL);
		if (L_77)
		{
			goto IL_01b1;
		}
	}
	{
		// return;
		return;
	}

IL_0163:
	{
		// if (!ParseArrayEnd(inputString, offset, openQuote, container, startOffset, lastValidOffset, maxDepth, storeExcessLevels, depth, ref bakeDepth))
		String_t* L_78 = ___inputString0;
		int32_t* L_79 = ___offset1;
		int32_t L_80 = *((int32_t*)L_79);
		bool L_81 = V_4;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_82 = ___container3;
		int32_t L_83 = V_0;
		int32_t L_84 = V_3;
		int32_t L_85 = ___maxDepth4;
		bool L_86 = ___storeExcessLevels5;
		int32_t L_87 = ___depth6;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		bool L_88;
		L_88 = JSONObject_ParseArrayEnd_mCD9D6A7C7F47DAA478304ED96B06ED332521C54C(L_78, L_80, L_81, L_82, L_83, L_84, L_85, L_86, L_87, (&V_5), NULL);
		if (L_88)
		{
			goto IL_01b1;
		}
	}
	{
		// return;
		return;
	}

IL_017b:
	{
		// ParseQuote(ref openQuote, offset, ref quoteStart, ref quoteEnd);
		int32_t* L_89 = ___offset1;
		int32_t L_90 = *((int32_t*)L_89);
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_ParseQuote_mFBA405A5993329CD10F3255B7EA5FA0B512D9B9D((&V_4), L_90, (&V_1), (&V_2), NULL);
		// break;
		goto IL_01b1;
	}

IL_018a:
	{
		// if (!ParseColon(inputString, openQuote, container, ref startOffset, offset, quoteStart, quoteEnd, bakeDepth))
		String_t* L_91 = ___inputString0;
		bool L_92 = V_4;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_93 = ___container3;
		int32_t* L_94 = ___offset1;
		int32_t L_95 = *((int32_t*)L_94);
		int32_t L_96 = V_1;
		int32_t L_97 = V_2;
		int32_t L_98 = V_5;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		bool L_99;
		L_99 = JSONObject_ParseColon_m917F7EC0729BB7E9A86C447034DA9C00310778E7(L_91, L_92, L_93, (&V_0), L_95, L_96, L_97, L_98, NULL);
		if (L_99)
		{
			goto IL_01b1;
		}
	}
	{
		// return;
		return;
	}

IL_019e:
	{
		// if (!ParseComma(inputString, openQuote, container, ref startOffset, offset, lastValidOffset, bakeDepth))
		String_t* L_100 = ___inputString0;
		bool L_101 = V_4;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_102 = ___container3;
		int32_t* L_103 = ___offset1;
		int32_t L_104 = *((int32_t*)L_103);
		int32_t L_105 = V_3;
		int32_t L_106 = V_5;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		bool L_107;
		L_107 = JSONObject_ParseComma_mE24033BD9D67738BC3DDC81E2F9B821C25E2E5E4(L_100, L_101, L_102, (&V_0), L_104, L_105, L_106, NULL);
		if (L_107)
		{
			goto IL_01b1;
		}
	}
	{
		// return;
		return;
	}

IL_01b1:
	{
		// lastValidOffset = offset - 1;
		int32_t* L_108 = ___offset1;
		int32_t L_109 = *((int32_t*)L_108);
		V_3 = ((int32_t)il2cpp_codegen_subtract(L_109, 1));
	}

IL_01b6:
	{
		// while (offset <= endOffset) {
		int32_t* L_110 = ___offset1;
		int32_t L_111 = *((int32_t*)L_110);
		int32_t L_112 = ___endOffset2;
		if ((((int32_t)L_111) <= ((int32_t)L_112)))
		{
			goto IL_0027;
		}
	}
	{
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::SafeAddChild(Defective.JSON.JSONObject,Defective.JSON.JSONObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_SafeAddChild_mF8B89C42E3021F550FF4D7030F361B3A9578A588 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container0, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___child1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_m67DC8AAA1F867623E0668663DD6FECC08D3CB03C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m512620C35691CD7C02708077DD0A844BD071283D_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* V_0 = NULL;
	{
		// var list = container.list;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_0 = ___container0;
		NullCheck(L_0);
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_1 = L_0->___list_3;
		V_0 = L_1;
		// if (list == null) {
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_2 = V_0;
		if (L_2)
		{
			goto IL_0017;
		}
	}
	{
		// list = new List<JSONObject>();
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_3 = (List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E*)il2cpp_codegen_object_new(List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E_il2cpp_TypeInfo_var);
		NullCheck(L_3);
		List_1__ctor_m512620C35691CD7C02708077DD0A844BD071283D(L_3, List_1__ctor_m512620C35691CD7C02708077DD0A844BD071283D_RuntimeMethod_var);
		V_0 = L_3;
		// container.list = list;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_4 = ___container0;
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_5 = V_0;
		NullCheck(L_4);
		L_4->___list_3 = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&L_4->___list_3), (void*)L_5);
	}

IL_0017:
	{
		// list.Add(child);
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_6 = V_0;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_7 = ___child1;
		NullCheck(L_6);
		List_1_Add_m67DC8AAA1F867623E0668663DD6FECC08D3CB03C_inline(L_6, L_7, List_1_Add_m67DC8AAA1F867623E0668663DD6FECC08D3CB03C_RuntimeMethod_var);
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::ParseValue(System.String,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_ParseValue_mCCFFA4657D41ADB772EB6906B5AE76297AF0FEC3 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, String_t* ___inputString0, int32_t ___startOffset1, int32_t ___lastValidOffset2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Array_IndexOf_TisChar_t521A6F19B456D956AF452D926C32709DC03D6B17_m6E2BDAD7B5A1E51CA8029C65DCA4E847D543DDF9_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Convert_t7097FF336D592F7C06D88A98349A44646F91EFFC_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralF3E84B722399601AD7E281754E917478AA9AD48D);
		s_Il2CppMethodInitialized = true;
	}
	Il2CppChar V_0 = 0x0;
	String_t* V_1 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* G_B30_0 = NULL;
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* G_B29_0 = NULL;
	double G_B31_0 = 0.0;
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* G_B31_1 = NULL;
	{
		// var firstCharacter = inputString[startOffset];
		String_t* L_0 = ___inputString0;
		int32_t L_1 = ___startOffset1;
		NullCheck(L_0);
		Il2CppChar L_2;
		L_2 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_0, L_1, NULL);
		V_0 = L_2;
	}

IL_0008:
	{
		// if (Array.IndexOf(Whitespace, firstCharacter) > -1) {
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* L_3 = ((JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_StaticFields*)il2cpp_codegen_static_fields_for(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var))->___Whitespace_1;
		Il2CppChar L_4 = V_0;
		int32_t L_5;
		L_5 = Array_IndexOf_TisChar_t521A6F19B456D956AF452D926C32709DC03D6B17_m6E2BDAD7B5A1E51CA8029C65DCA4E847D543DDF9(L_3, L_4, Array_IndexOf_TisChar_t521A6F19B456D956AF452D926C32709DC03D6B17_m6E2BDAD7B5A1E51CA8029C65DCA4E847D543DDF9_RuntimeMethod_var);
		if ((((int32_t)L_5) <= ((int32_t)(-1))))
		{
			goto IL_0025;
		}
	}
	{
		// firstCharacter = inputString[++startOffset];
		String_t* L_6 = ___inputString0;
		int32_t L_7 = ___startOffset1;
		int32_t L_8 = ((int32_t)il2cpp_codegen_add(L_7, 1));
		___startOffset1 = L_8;
		NullCheck(L_6);
		Il2CppChar L_9;
		L_9 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_6, L_8, NULL);
		V_0 = L_9;
		// continue;
		goto IL_0008;
	}

IL_0025:
	{
		Il2CppChar L_10 = V_0;
		if ((!(((uint32_t)L_10) <= ((uint32_t)((int32_t)73)))))
		{
			goto IL_0041;
		}
	}
	{
		Il2CppChar L_11 = V_0;
		if ((((int32_t)L_11) == ((int32_t)((int32_t)34))))
		{
			goto IL_0064;
		}
	}
	{
		Il2CppChar L_12 = V_0;
		if ((((int32_t)L_12) == ((int32_t)((int32_t)45))))
		{
			goto IL_00d9;
		}
	}
	{
		Il2CppChar L_13 = V_0;
		if ((((int32_t)L_13) == ((int32_t)((int32_t)73))))
		{
			goto IL_00ab;
		}
	}
	{
		goto IL_00fd;
	}

IL_0041:
	{
		Il2CppChar L_14 = V_0;
		if ((!(((uint32_t)L_14) <= ((uint32_t)((int32_t)102)))))
		{
			goto IL_0055;
		}
	}
	{
		Il2CppChar L_15 = V_0;
		if ((((int32_t)L_15) == ((int32_t)((int32_t)78))))
		{
			goto IL_00c2;
		}
	}
	{
		Il2CppChar L_16 = V_0;
		if ((((int32_t)L_16) == ((int32_t)((int32_t)102))))
		{
			goto IL_0094;
		}
	}
	{
		goto IL_00fd;
	}

IL_0055:
	{
		Il2CppChar L_17 = V_0;
		if ((((int32_t)L_17) == ((int32_t)((int32_t)110))))
		{
			goto IL_00a3;
		}
	}
	{
		Il2CppChar L_18 = V_0;
		if ((((int32_t)L_18) == ((int32_t)((int32_t)116))))
		{
			goto IL_0085;
		}
	}
	{
		goto IL_00fd;
	}

IL_0064:
	{
		// type = Type.String;
		__this->___type_2 = 1;
		// stringValue = UnEscapeString(inputString.Substring(startOffset + 1, lastValidOffset - startOffset - 1));
		String_t* L_19 = ___inputString0;
		int32_t L_20 = ___startOffset1;
		int32_t L_21 = ___lastValidOffset2;
		int32_t L_22 = ___startOffset1;
		NullCheck(L_19);
		String_t* L_23;
		L_23 = String_Substring_mB1D94F47935D22E130FF2C01DBB6A4135FBB76CE(L_19, ((int32_t)il2cpp_codegen_add(L_20, 1)), ((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_subtract(L_21, L_22)), 1)), NULL);
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		String_t* L_24;
		L_24 = JSONObject_UnEscapeString_m2CBA283857DD92DF360CCE6997374980C3EED39A(L_23, NULL);
		__this->___stringValue_5 = L_24;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___stringValue_5), (void*)L_24);
		// return;
		return;
	}

IL_0085:
	{
		// type = Type.Bool;
		__this->___type_2 = 5;
		// boolValue = true;
		__this->___boolValue_8 = (bool)1;
		// return;
		return;
	}

IL_0094:
	{
		// type = Type.Bool;
		__this->___type_2 = 5;
		// boolValue = false;
		__this->___boolValue_8 = (bool)0;
		// return;
		return;
	}

IL_00a3:
	{
		// type = Type.Null;
		__this->___type_2 = 0;
		// return;
		return;
	}

IL_00ab:
	{
		// type = Type.Number;
		__this->___type_2 = 2;
		// doubleValue = double.PositiveInfinity;
		__this->___doubleValue_9 = (std::numeric_limits<double>::infinity());
		// return;
		return;
	}

IL_00c2:
	{
		// type = Type.Number;
		__this->___type_2 = 2;
		// doubleValue = double.NaN;
		__this->___doubleValue_9 = (std::numeric_limits<double>::quiet_NaN());
		// return;
		return;
	}

IL_00d9:
	{
		// if (inputString[startOffset + 1] == 'I') {
		String_t* L_25 = ___inputString0;
		int32_t L_26 = ___startOffset1;
		NullCheck(L_25);
		Il2CppChar L_27;
		L_27 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_25, ((int32_t)il2cpp_codegen_add(L_26, 1)), NULL);
		if ((!(((uint32_t)L_27) == ((uint32_t)((int32_t)73)))))
		{
			goto IL_00fd;
		}
	}
	{
		// type = Type.Number;
		__this->___type_2 = 2;
		// doubleValue = double.NegativeInfinity;
		__this->___doubleValue_9 = (-std::numeric_limits<double>::infinity());
		// return;
		return;
	}

IL_00fd:
	{
		// var numericString = inputString.Substring(startOffset, lastValidOffset - startOffset + 1);
		String_t* L_28 = ___inputString0;
		int32_t L_29 = ___startOffset1;
		int32_t L_30 = ___lastValidOffset2;
		int32_t L_31 = ___startOffset1;
		NullCheck(L_28);
		String_t* L_32;
		L_32 = String_Substring_mB1D94F47935D22E130FF2C01DBB6A4135FBB76CE(L_28, L_29, ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_30, L_31)), 1)), NULL);
		V_1 = L_32;
	}
	try
	{// begin try (depth: 1)
		{
			// if (numericString.Contains(".")) {
			String_t* L_33 = V_1;
			NullCheck(L_33);
			bool L_34;
			L_34 = String_Contains_m6D77B121FADA7CA5F397C0FABB65DA62DF03B6C3(L_33, _stringLiteralF3E84B722399601AD7E281754E917478AA9AD48D, NULL);
			if (!L_34)
			{
				goto IL_012a_1;
			}
		}
		{
			// doubleValue = Convert.ToDouble(numericString, CultureInfo.InvariantCulture);
			String_t* L_35 = V_1;
			il2cpp_codegen_runtime_class_init_inline(CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var);
			CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* L_36;
			L_36 = CultureInfo_get_InvariantCulture_mD1E96DC845E34B10F78CB744B0CB5D7D63CEB1E6(NULL);
			il2cpp_codegen_runtime_class_init_inline(Convert_t7097FF336D592F7C06D88A98349A44646F91EFFC_il2cpp_TypeInfo_var);
			double L_37;
			L_37 = Convert_ToDouble_mAA66A3AA3A6E53529E4F632BC69582B4B70D32B7(L_35, L_36, NULL);
			__this->___doubleValue_9 = L_37;
			goto IL_014f_1;
		}

IL_012a_1:
		{
			// longValue = Convert.ToInt64(numericString, CultureInfo.InvariantCulture);
			String_t* L_38 = V_1;
			il2cpp_codegen_runtime_class_init_inline(CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var);
			CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* L_39;
			L_39 = CultureInfo_get_InvariantCulture_mD1E96DC845E34B10F78CB744B0CB5D7D63CEB1E6(NULL);
			il2cpp_codegen_runtime_class_init_inline(Convert_t7097FF336D592F7C06D88A98349A44646F91EFFC_il2cpp_TypeInfo_var);
			int64_t L_40;
			L_40 = Convert_ToInt64_m849AF82E6C86C69E45DDDD095A39679D036239B7(L_38, L_39, NULL);
			__this->___longValue_7 = L_40;
			// isInteger = true;
			__this->___isInteger_6 = (bool)1;
			// doubleValue = longValue;
			int64_t L_41 = __this->___longValue_7;
			__this->___doubleValue_9 = ((double)L_41);
		}

IL_014f_1:
		{
			// type = Type.Number;
			__this->___type_2 = 2;
			// } catch (OverflowException) {
			goto IL_01a3;
		}
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&OverflowException_t6F6AD8CACE20C37F701C05B373A215C4802FAB0C_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0158;
		}
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&FormatException_tCD210E92627903FFEDAAA706C08FB6222B4D012B_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0189;
		}
		throw e;
	}

CATCH_0158:
	{// begin catch(System.OverflowException)
		{
			// } catch (OverflowException) {
			// type = Type.Number;
			__this->___type_2 = 2;
			// doubleValue = numericString.StartsWith("-") ? double.NegativeInfinity : double.PositiveInfinity;
			String_t* L_42 = V_1;
			NullCheck(L_42);
			bool L_43;
			L_43 = String_StartsWith_mF75DBA1EB709811E711B44E26FF919C88A8E65C0(L_42, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral3B2C1C62D4D1C2A0C8A9AC42DB00D33C654F9AD0)), NULL);
			G_B29_0 = __this;
			if (L_43)
			{
				G_B30_0 = __this;
				goto IL_0179;
			}
		}
		{
			G_B31_0 = (std::numeric_limits<double>::infinity());
			G_B31_1 = G_B29_0;
			goto IL_0182;
		}

IL_0179:
		{
			G_B31_0 = (-std::numeric_limits<double>::infinity());
			G_B31_1 = G_B30_0;
		}

IL_0182:
		{
			NullCheck(G_B31_1);
			G_B31_1->___doubleValue_9 = G_B31_0;
			// } catch (FormatException) {
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_01a3;
		}
	}// end catch (depth: 1)

CATCH_0189:
	{// begin catch(System.FormatException)
		// } catch (FormatException) {
		// type = Type.Null;
		__this->___type_2 = 0;
		//                 Debug.LogWarning
		// #else
		//                 Debug.WriteLine
		// #endif
		//                     (string.Format("Improper JSON formatting:{0}", numericString));
		String_t* L_44 = V_1;
		String_t* L_45;
		L_45 = String_Format_mA8DBB4C2516B9723C5A41E6CB1E2FAF4BBE96DD8(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralFA9F4ADBA883DCCA70B2BFF2E103994E8AA5A599)), L_44, NULL);
		il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var)));
		Debug_LogWarning_m33EF1B897E0C7C6FF538989610BFAFFEF4628CA9(L_45, NULL);
		// }
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_01a3;
	}// end catch (depth: 1)

IL_01a3:
	{
		// }
		return;
	}
}
// System.Boolean Defective.JSON.JSONObject::ParseObjectEnd(System.String,System.Int32,System.Boolean,Defective.JSON.JSONObject,System.Int32,System.Int32,System.Int32,System.Boolean,System.Int32,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_ParseObjectEnd_m409EF6F2E8E663FF9D81D154E14B7FB54114CB2D (String_t* ___inputString0, int32_t ___offset1, bool ___openQuote2, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container3, int32_t ___startOffset4, int32_t ___lastValidOffset5, int32_t ___maxDepth6, bool ___storeExcessLevels7, int32_t ___depth8, int32_t* ___bakeDepth9, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral06B4A96E9E13BC375962BF44CF7B409D3020362D);
		s_Il2CppMethodInitialized = true;
	}
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* G_B9_0 = NULL;
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* G_B8_0 = NULL;
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* G_B10_0 = NULL;
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* G_B10_1 = NULL;
	{
		// if (openQuote)
		bool L_0 = ___openQuote2;
		if (!L_0)
		{
			goto IL_0005;
		}
	}
	{
		// return true;
		return (bool)1;
	}

IL_0005:
	{
		// if (container == null) {
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_1 = ___container3;
		if (L_1)
		{
			goto IL_0014;
		}
	}
	{
		// Debug.LogError("Parsing error: encountered `}` with no container object");
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_LogError_mB00B2B4468EF3CAF041B038D840820FB84C924B2(_stringLiteral06B4A96E9E13BC375962BF44CF7B409D3020362D, NULL);
		// return false;
		return (bool)0;
	}

IL_0014:
	{
		// if (maxDepth >= 0 && depth >= maxDepth) {
		int32_t L_2 = ___maxDepth6;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_0056;
		}
	}
	{
		int32_t L_3 = ___depth8;
		int32_t L_4 = ___maxDepth6;
		if ((((int32_t)L_3) < ((int32_t)L_4)))
		{
			goto IL_0056;
		}
	}
	{
		// bakeDepth--;
		int32_t* L_5 = ___bakeDepth9;
		int32_t* L_6 = ___bakeDepth9;
		int32_t L_7 = *((int32_t*)L_6);
		*((int32_t*)L_5) = (int32_t)((int32_t)il2cpp_codegen_subtract(L_7, 1));
		// if (bakeDepth == 0) {
		int32_t* L_8 = ___bakeDepth9;
		int32_t L_9 = *((int32_t*)L_8);
		if (L_9)
		{
			goto IL_004e;
		}
	}
	{
		// SafeAddChild(container,
		//     storeExcessLevels
		//         ? CreateBakedObject(inputString.Substring(startOffset, offset - startOffset))
		//         : nullObject);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_10 = ___container3;
		bool L_11 = ___storeExcessLevels7;
		G_B8_0 = L_10;
		if (L_11)
		{
			G_B9_0 = L_10;
			goto IL_0038;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_12;
		L_12 = JSONObject_get_nullObject_m1F5C12DDD7E80EAE0F2DB6F9D0DC722F0BC76D51(NULL);
		G_B10_0 = L_12;
		G_B10_1 = G_B8_0;
		goto IL_0049;
	}

IL_0038:
	{
		String_t* L_13 = ___inputString0;
		int32_t L_14 = ___startOffset4;
		int32_t L_15 = ___offset1;
		int32_t L_16 = ___startOffset4;
		NullCheck(L_13);
		String_t* L_17;
		L_17 = String_Substring_mB1D94F47935D22E130FF2C01DBB6A4135FBB76CE(L_13, L_14, ((int32_t)il2cpp_codegen_subtract(L_15, L_16)), NULL);
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_18;
		L_18 = JSONObject_CreateBakedObject_m2039F450D1C8D6B09DD2929411721737706B0730(L_17, NULL);
		G_B10_0 = L_18;
		G_B10_1 = G_B9_0;
	}

IL_0049:
	{
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_SafeAddChild_mF8B89C42E3021F550FF4D7030F361B3A9578A588(G_B10_1, G_B10_0, NULL);
	}

IL_004e:
	{
		// if (bakeDepth >= 0)
		int32_t* L_19 = ___bakeDepth9;
		int32_t L_20 = *((int32_t*)L_19);
		if ((((int32_t)L_20) < ((int32_t)0)))
		{
			goto IL_0056;
		}
	}
	{
		// return true;
		return (bool)1;
	}

IL_0056:
	{
		// ParseFinalObjectIfNeeded(inputString, container, startOffset, lastValidOffset);
		String_t* L_21 = ___inputString0;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_22 = ___container3;
		int32_t L_23 = ___startOffset4;
		int32_t L_24 = ___lastValidOffset5;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_ParseFinalObjectIfNeeded_mC5BBD01E9B35A0B100D806B8A50C52F95FE6B636(L_21, L_22, L_23, L_24, NULL);
		// return false;
		return (bool)0;
	}
}
// System.Boolean Defective.JSON.JSONObject::ParseArrayEnd(System.String,System.Int32,System.Boolean,Defective.JSON.JSONObject,System.Int32,System.Int32,System.Int32,System.Boolean,System.Int32,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_ParseArrayEnd_mCD9D6A7C7F47DAA478304ED96B06ED332521C54C (String_t* ___inputString0, int32_t ___offset1, bool ___openQuote2, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container3, int32_t ___startOffset4, int32_t ___lastValidOffset5, int32_t ___maxDepth6, bool ___storeExcessLevels7, int32_t ___depth8, int32_t* ___bakeDepth9, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral54154E1F5FCB5154DF6748F2558087DBA8903D65);
		s_Il2CppMethodInitialized = true;
	}
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* G_B9_0 = NULL;
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* G_B8_0 = NULL;
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* G_B10_0 = NULL;
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* G_B10_1 = NULL;
	{
		// if (openQuote)
		bool L_0 = ___openQuote2;
		if (!L_0)
		{
			goto IL_0005;
		}
	}
	{
		// return true;
		return (bool)1;
	}

IL_0005:
	{
		// if (container == null) {
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_1 = ___container3;
		if (L_1)
		{
			goto IL_0014;
		}
	}
	{
		// Debug.LogError("Parsing error: encountered `]` with no container object");
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_LogError_mB00B2B4468EF3CAF041B038D840820FB84C924B2(_stringLiteral54154E1F5FCB5154DF6748F2558087DBA8903D65, NULL);
		// return false;
		return (bool)0;
	}

IL_0014:
	{
		// if (maxDepth >= 0 && depth >= maxDepth) {
		int32_t L_2 = ___maxDepth6;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_0056;
		}
	}
	{
		int32_t L_3 = ___depth8;
		int32_t L_4 = ___maxDepth6;
		if ((((int32_t)L_3) < ((int32_t)L_4)))
		{
			goto IL_0056;
		}
	}
	{
		// bakeDepth--;
		int32_t* L_5 = ___bakeDepth9;
		int32_t* L_6 = ___bakeDepth9;
		int32_t L_7 = *((int32_t*)L_6);
		*((int32_t*)L_5) = (int32_t)((int32_t)il2cpp_codegen_subtract(L_7, 1));
		// if (bakeDepth == 0) {
		int32_t* L_8 = ___bakeDepth9;
		int32_t L_9 = *((int32_t*)L_8);
		if (L_9)
		{
			goto IL_004e;
		}
	}
	{
		// SafeAddChild(container,
		//     storeExcessLevels
		//         ? CreateBakedObject(inputString.Substring(startOffset, offset - startOffset))
		//         : nullObject);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_10 = ___container3;
		bool L_11 = ___storeExcessLevels7;
		G_B8_0 = L_10;
		if (L_11)
		{
			G_B9_0 = L_10;
			goto IL_0038;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_12;
		L_12 = JSONObject_get_nullObject_m1F5C12DDD7E80EAE0F2DB6F9D0DC722F0BC76D51(NULL);
		G_B10_0 = L_12;
		G_B10_1 = G_B8_0;
		goto IL_0049;
	}

IL_0038:
	{
		String_t* L_13 = ___inputString0;
		int32_t L_14 = ___startOffset4;
		int32_t L_15 = ___offset1;
		int32_t L_16 = ___startOffset4;
		NullCheck(L_13);
		String_t* L_17;
		L_17 = String_Substring_mB1D94F47935D22E130FF2C01DBB6A4135FBB76CE(L_13, L_14, ((int32_t)il2cpp_codegen_subtract(L_15, L_16)), NULL);
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_18;
		L_18 = JSONObject_CreateBakedObject_m2039F450D1C8D6B09DD2929411721737706B0730(L_17, NULL);
		G_B10_0 = L_18;
		G_B10_1 = G_B9_0;
	}

IL_0049:
	{
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_SafeAddChild_mF8B89C42E3021F550FF4D7030F361B3A9578A588(G_B10_1, G_B10_0, NULL);
	}

IL_004e:
	{
		// if (bakeDepth >= 0)
		int32_t* L_19 = ___bakeDepth9;
		int32_t L_20 = *((int32_t*)L_19);
		if ((((int32_t)L_20) < ((int32_t)0)))
		{
			goto IL_0056;
		}
	}
	{
		// return true;
		return (bool)1;
	}

IL_0056:
	{
		// ParseFinalObjectIfNeeded(inputString, container, startOffset, lastValidOffset);
		String_t* L_21 = ___inputString0;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_22 = ___container3;
		int32_t L_23 = ___startOffset4;
		int32_t L_24 = ___lastValidOffset5;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_ParseFinalObjectIfNeeded_mC5BBD01E9B35A0B100D806B8A50C52F95FE6B636(L_21, L_22, L_23, L_24, NULL);
		// return false;
		return (bool)0;
	}
}
// System.Void Defective.JSON.JSONObject::ParseQuote(System.Boolean&,System.Int32,System.Int32&,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_ParseQuote_mFBA405A5993329CD10F3255B7EA5FA0B512D9B9D (bool* ___openQuote0, int32_t ___offset1, int32_t* ___quoteStart2, int32_t* ___quoteEnd3, const RuntimeMethod* method) 
{
	{
		// if (openQuote) {
		bool* L_0 = ___openQuote0;
		int32_t L_1 = *((uint8_t*)L_0);
		if (!L_1)
		{
			goto IL_000d;
		}
	}
	{
		// quoteEnd = offset - 1;
		int32_t* L_2 = ___quoteEnd3;
		int32_t L_3 = ___offset1;
		*((int32_t*)L_2) = (int32_t)((int32_t)il2cpp_codegen_subtract(L_3, 1));
		// openQuote = false;
		bool* L_4 = ___openQuote0;
		*((int8_t*)L_4) = (int8_t)0;
		return;
	}

IL_000d:
	{
		// quoteStart = offset;
		int32_t* L_5 = ___quoteStart2;
		int32_t L_6 = ___offset1;
		*((int32_t*)L_5) = (int32_t)L_6;
		// openQuote = true;
		bool* L_7 = ___openQuote0;
		*((int8_t*)L_7) = (int8_t)1;
		// }
		return;
	}
}
// System.Boolean Defective.JSON.JSONObject::ParseColon(System.String,System.Boolean,Defective.JSON.JSONObject,System.Int32&,System.Int32,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_ParseColon_m917F7EC0729BB7E9A86C447034DA9C00310778E7 (String_t* ___inputString0, bool ___openQuote1, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container2, int32_t* ___startOffset3, int32_t ___offset4, int32_t ___quoteStart5, int32_t ___quoteEnd6, int32_t ___bakeDepth7, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral19967C1E48314D711A74F7072B6A080EC2E7DCF0);
		s_Il2CppMethodInitialized = true;
	}
	List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* V_0 = NULL;
	{
		// if (openQuote || bakeDepth > 0)
		bool L_0 = ___openQuote1;
		if (L_0)
		{
			goto IL_0008;
		}
	}
	{
		int32_t L_1 = ___bakeDepth7;
		if ((((int32_t)L_1) <= ((int32_t)0)))
		{
			goto IL_000a;
		}
	}

IL_0008:
	{
		// return true;
		return (bool)1;
	}

IL_000a:
	{
		// if (container == null) {
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_2 = ___container2;
		if (L_2)
		{
			goto IL_0019;
		}
	}
	{
		// Debug.LogError("Parsing error: encountered `:` with no container object");
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_LogError_mB00B2B4468EF3CAF041B038D840820FB84C924B2(_stringLiteral19967C1E48314D711A74F7072B6A080EC2E7DCF0, NULL);
		// return false;
		return (bool)0;
	}

IL_0019:
	{
		// var keys = container.keys;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_3 = ___container2;
		NullCheck(L_3);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_4 = L_3->___keys_4;
		V_0 = L_4;
		// if (keys == null) {
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_5 = V_0;
		if (L_5)
		{
			goto IL_0030;
		}
	}
	{
		// keys = new List<string>();
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_6 = (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*)il2cpp_codegen_object_new(List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var);
		NullCheck(L_6);
		List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E(L_6, List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var);
		V_0 = L_6;
		// container.keys = keys;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_7 = ___container2;
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_8 = V_0;
		NullCheck(L_7);
		L_7->___keys_4 = L_8;
		Il2CppCodeGenWriteBarrier((void**)(&L_7->___keys_4), (void*)L_8);
	}

IL_0030:
	{
		// container.keys.Add(inputString.Substring(quoteStart, quoteEnd - quoteStart));
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_9 = ___container2;
		NullCheck(L_9);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_10 = L_9->___keys_4;
		String_t* L_11 = ___inputString0;
		int32_t L_12 = ___quoteStart5;
		int32_t L_13 = ___quoteEnd6;
		int32_t L_14 = ___quoteStart5;
		NullCheck(L_11);
		String_t* L_15;
		L_15 = String_Substring_mB1D94F47935D22E130FF2C01DBB6A4135FBB76CE(L_11, L_12, ((int32_t)il2cpp_codegen_subtract(L_13, L_14)), NULL);
		NullCheck(L_10);
		List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_inline(L_10, L_15, List_1_Add_mF10DB1D3CBB0B14215F0E4F8AB4934A1955E5351_RuntimeMethod_var);
		// startOffset = offset;
		int32_t* L_16 = ___startOffset3;
		int32_t L_17 = ___offset4;
		*((int32_t*)L_16) = (int32_t)L_17;
		// return true;
		return (bool)1;
	}
}
// System.Boolean Defective.JSON.JSONObject::ParseComma(System.String,System.Boolean,Defective.JSON.JSONObject,System.Int32&,System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_ParseComma_mE24033BD9D67738BC3DDC81E2F9B821C25E2E5E4 (String_t* ___inputString0, bool ___openQuote1, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container2, int32_t* ___startOffset3, int32_t ___offset4, int32_t ___lastValidOffset5, int32_t ___bakeDepth6, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral6BDD6023A35877E4881FA93114DF2689C56BC822);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (openQuote || bakeDepth > 0)
		bool L_0 = ___openQuote1;
		if (L_0)
		{
			goto IL_0008;
		}
	}
	{
		int32_t L_1 = ___bakeDepth6;
		if ((((int32_t)L_1) <= ((int32_t)0)))
		{
			goto IL_000a;
		}
	}

IL_0008:
	{
		// return true;
		return (bool)1;
	}

IL_000a:
	{
		// if (container == null) {
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_2 = ___container2;
		if (L_2)
		{
			goto IL_0019;
		}
	}
	{
		// Debug.LogError("Parsing error: encountered `,` with no container object");
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_LogError_mB00B2B4468EF3CAF041B038D840820FB84C924B2(_stringLiteral6BDD6023A35877E4881FA93114DF2689C56BC822, NULL);
		// return false;
		return (bool)0;
	}

IL_0019:
	{
		// ParseFinalObjectIfNeeded(inputString, container, startOffset, lastValidOffset);
		String_t* L_3 = ___inputString0;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_4 = ___container2;
		int32_t* L_5 = ___startOffset3;
		int32_t L_6 = *((int32_t*)L_5);
		int32_t L_7 = ___lastValidOffset5;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_ParseFinalObjectIfNeeded_mC5BBD01E9B35A0B100D806B8A50C52F95FE6B636(L_3, L_4, L_6, L_7, NULL);
		// startOffset = offset;
		int32_t* L_8 = ___startOffset3;
		int32_t L_9 = ___offset4;
		*((int32_t*)L_8) = (int32_t)L_9;
		// return true;
		return (bool)1;
	}
}
// System.Void Defective.JSON.JSONObject::ParseFinalObjectIfNeeded(System.String,Defective.JSON.JSONObject,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_ParseFinalObjectIfNeeded_mC5BBD01E9B35A0B100D806B8A50C52F95FE6B636 (String_t* ___inputString0, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___container1, int32_t ___startOffset2, int32_t ___lastValidOffset3, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* V_0 = NULL;
	{
		// if (IsClosingCharacter(inputString[lastValidOffset]))
		String_t* L_0 = ___inputString0;
		int32_t L_1 = ___lastValidOffset3;
		NullCheck(L_0);
		Il2CppChar L_2;
		L_2 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_0, L_1, NULL);
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		bool L_3;
		L_3 = JSONObject_IsClosingCharacter_m9E9726C119837264FB5CE6DAADA3ACD873C198C2(L_2, NULL);
		if (!L_3)
		{
			goto IL_000f;
		}
	}
	{
		// return;
		return;
	}

IL_000f:
	{
		// var child = Create();
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_4;
		L_4 = JSONObject_Create_m43209E76E53E1DBE231EB3D763841EADD511D4A3(NULL);
		V_0 = L_4;
		// child.ParseValue(inputString, startOffset, lastValidOffset);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_5 = V_0;
		String_t* L_6 = ___inputString0;
		int32_t L_7 = ___startOffset2;
		int32_t L_8 = ___lastValidOffset3;
		NullCheck(L_5);
		JSONObject_ParseValue_mCCFFA4657D41ADB772EB6906B5AE76297AF0FEC3(L_5, L_6, L_7, L_8, NULL);
		// SafeAddChild(container, child);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_9 = ___container1;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_10 = V_0;
		JSONObject_SafeAddChild_mF8B89C42E3021F550FF4D7030F361B3A9578A588(L_9, L_10, NULL);
		// }
		return;
	}
}
// System.Boolean Defective.JSON.JSONObject::IsClosingCharacter(System.Char)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObject_IsClosingCharacter_m9E9726C119837264FB5CE6DAADA3ACD873C198C2 (Il2CppChar ___character0, const RuntimeMethod* method) 
{
	{
		Il2CppChar L_0 = ___character0;
		if ((((int32_t)L_0) == ((int32_t)((int32_t)93))))
		{
			goto IL_000a;
		}
	}
	{
		Il2CppChar L_1 = ___character0;
		if ((!(((uint32_t)L_1) == ((uint32_t)((int32_t)125)))))
		{
			goto IL_000c;
		}
	}

IL_000a:
	{
		// return true;
		return (bool)1;
	}

IL_000c:
	{
		// return false;
		return (bool)0;
	}
}
// Defective.JSON.JSONObject Defective.JSON.JSONObject::GetField(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_GetField_m2B0D3470E8784CF807ECAE34BBE45CB39EACCC53 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, String_t* ___name0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m72F3DB0603A408B7B91C4591FADFC8E855D81490_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// if (type == Type.Object && keys != null && list != null) {
		int32_t L_0 = __this->___type_2;
		if ((!(((uint32_t)L_0) == ((uint32_t)3))))
		{
			goto IL_0050;
		}
	}
	{
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_1 = __this->___keys_4;
		if (!L_1)
		{
			goto IL_0050;
		}
	}
	{
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_2 = __this->___list_3;
		if (!L_2)
		{
			goto IL_0050;
		}
	}
	{
		// for (var index = 0; index < keys.Count; index++)
		V_0 = 0;
		goto IL_0042;
	}

IL_001d:
	{
		// if (keys[index] == name)
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_3 = __this->___keys_4;
		int32_t L_4 = V_0;
		NullCheck(L_3);
		String_t* L_5;
		L_5 = List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8(L_3, L_4, List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8_RuntimeMethod_var);
		String_t* L_6 = ___name0;
		bool L_7;
		L_7 = String_op_Equality_m030E1B219352228970A076136E455C4E568C02C1(L_5, L_6, NULL);
		if (!L_7)
		{
			goto IL_003e;
		}
	}
	{
		// return list[index];
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_8 = __this->___list_3;
		int32_t L_9 = V_0;
		NullCheck(L_8);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_10;
		L_10 = List_1_get_Item_m72F3DB0603A408B7B91C4591FADFC8E855D81490(L_8, L_9, List_1_get_Item_m72F3DB0603A408B7B91C4591FADFC8E855D81490_RuntimeMethod_var);
		return L_10;
	}

IL_003e:
	{
		// for (var index = 0; index < keys.Count; index++)
		int32_t L_11 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_11, 1));
	}

IL_0042:
	{
		// for (var index = 0; index < keys.Count; index++)
		int32_t L_12 = V_0;
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_13 = __this->___keys_4;
		NullCheck(L_13);
		int32_t L_14;
		L_14 = List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_inline(L_13, List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_RuntimeMethod_var);
		if ((((int32_t)L_12) < ((int32_t)L_14)))
		{
			goto IL_001d;
		}
	}

IL_0050:
	{
		// return null;
		return (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC*)NULL;
	}
}
// System.String Defective.JSON.JSONObject::Print(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JSONObject_Print_m3AC68522204B19733E330B8DA1F8919099E6C284 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, bool ___pretty0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringBuilder_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t* V_0 = NULL;
	{
		// var builder = new StringBuilder();
		StringBuilder_t* L_0 = (StringBuilder_t*)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		StringBuilder__ctor_m1D99713357DE05DAFA296633639DB55F8C30587D(L_0, NULL);
		V_0 = L_0;
		// Print(builder, pretty);
		StringBuilder_t* L_1 = V_0;
		bool L_2 = ___pretty0;
		JSONObject_Print_mE75F1673BBF3CFCFF9F934E87068BFCD143AD1E8(__this, L_1, L_2, NULL);
		// return builder.ToString();
		StringBuilder_t* L_3 = V_0;
		NullCheck(L_3);
		String_t* L_4;
		L_4 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_3);
		return L_4;
	}
}
// System.Void Defective.JSON.JSONObject::Print(System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_Print_mE75F1673BBF3CFCFF9F934E87068BFCD143AD1E8 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, const RuntimeMethod* method) 
{
	{
		// Stringify(0, builder, pretty);
		StringBuilder_t* L_0 = ___builder0;
		bool L_1 = ___pretty1;
		JSONObject_Stringify_m1B4AB8F7C1726AA4FA744CDA2C0261771D7737CE(__this, 0, L_0, L_1, NULL);
		// }
		return;
	}
}
// System.String Defective.JSON.JSONObject::EscapeString(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JSONObject_EscapeString_m9D82BC2F43D518B2C71EF91E9EB70EBDA338357C (String_t* ___input0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral00B28FF06B788B9B67C6B259800F404F9F3761FD);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral053D8D6CEEBA9453C97D0EE5374DB863E6F77AD4);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral5962E944D7340CE47999BF097B4AFD70C1501FB9);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral785F17F45C331C415D0A7458E6AAC36966399C51);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral7F3238CD8C342B06FB9AB185C610175C84625462);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral848E5ED630B3142F565DD995C6E8D30187ED33CD);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralA7C3FCA8C63E127B542B38A5CA5E3FEEDDD1B122);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralB78F235D4291950A7D101307609C259F3E1F033F);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDB5B55A9B215F744DB82517864984D073F2E8F8C);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDE28F98354F48E7C0878BBA93033C6BDC68B27E2);
		s_Il2CppMethodInitialized = true;
	}
	{
		// var escaped = input.Replace("\b", "\\b");
		String_t* L_0 = ___input0;
		NullCheck(L_0);
		String_t* L_1;
		L_1 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_0, _stringLiteral053D8D6CEEBA9453C97D0EE5374DB863E6F77AD4, _stringLiteral5962E944D7340CE47999BF097B4AFD70C1501FB9, NULL);
		// escaped = escaped.Replace("\f", "\\f");
		NullCheck(L_1);
		String_t* L_2;
		L_2 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_1, _stringLiteralDE28F98354F48E7C0878BBA93033C6BDC68B27E2, _stringLiteralA7C3FCA8C63E127B542B38A5CA5E3FEEDDD1B122, NULL);
		// escaped = escaped.Replace("\n", "\\n");
		NullCheck(L_2);
		String_t* L_3;
		L_3 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_2, _stringLiteral00B28FF06B788B9B67C6B259800F404F9F3761FD, _stringLiteral785F17F45C331C415D0A7458E6AAC36966399C51, NULL);
		// escaped = escaped.Replace("\r", "\\r");
		NullCheck(L_3);
		String_t* L_4;
		L_4 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_3, _stringLiteralDB5B55A9B215F744DB82517864984D073F2E8F8C, _stringLiteralB78F235D4291950A7D101307609C259F3E1F033F, NULL);
		// escaped = escaped.Replace("\t", "\\t");
		NullCheck(L_4);
		String_t* L_5;
		L_5 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_4, _stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3, _stringLiteral7F3238CD8C342B06FB9AB185C610175C84625462, NULL);
		// escaped = escaped.Replace("\"", "\\\"");
		NullCheck(L_5);
		String_t* L_6;
		L_6 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_5, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, _stringLiteral848E5ED630B3142F565DD995C6E8D30187ED33CD, NULL);
		// return escaped;
		return L_6;
	}
}
// System.String Defective.JSON.JSONObject::UnEscapeString(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JSONObject_UnEscapeString_m2CBA283857DD92DF360CCE6997374980C3EED39A (String_t* ___input0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral00B28FF06B788B9B67C6B259800F404F9F3761FD);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral053D8D6CEEBA9453C97D0EE5374DB863E6F77AD4);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral5962E944D7340CE47999BF097B4AFD70C1501FB9);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral785F17F45C331C415D0A7458E6AAC36966399C51);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral7F3238CD8C342B06FB9AB185C610175C84625462);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral848E5ED630B3142F565DD995C6E8D30187ED33CD);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralA7C3FCA8C63E127B542B38A5CA5E3FEEDDD1B122);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralB78F235D4291950A7D101307609C259F3E1F033F);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDB5B55A9B215F744DB82517864984D073F2E8F8C);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDE28F98354F48E7C0878BBA93033C6BDC68B27E2);
		s_Il2CppMethodInitialized = true;
	}
	{
		// var unescaped = input.Replace("\\\"", "\"");
		String_t* L_0 = ___input0;
		NullCheck(L_0);
		String_t* L_1;
		L_1 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_0, _stringLiteral848E5ED630B3142F565DD995C6E8D30187ED33CD, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		// unescaped = unescaped.Replace("\\b", "\b");
		NullCheck(L_1);
		String_t* L_2;
		L_2 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_1, _stringLiteral5962E944D7340CE47999BF097B4AFD70C1501FB9, _stringLiteral053D8D6CEEBA9453C97D0EE5374DB863E6F77AD4, NULL);
		// unescaped = unescaped.Replace("\\f", "\f");
		NullCheck(L_2);
		String_t* L_3;
		L_3 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_2, _stringLiteralA7C3FCA8C63E127B542B38A5CA5E3FEEDDD1B122, _stringLiteralDE28F98354F48E7C0878BBA93033C6BDC68B27E2, NULL);
		// unescaped = unescaped.Replace("\\n", "\n");
		NullCheck(L_3);
		String_t* L_4;
		L_4 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_3, _stringLiteral785F17F45C331C415D0A7458E6AAC36966399C51, _stringLiteral00B28FF06B788B9B67C6B259800F404F9F3761FD, NULL);
		// unescaped = unescaped.Replace("\\r", "\r");
		NullCheck(L_4);
		String_t* L_5;
		L_5 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_4, _stringLiteralB78F235D4291950A7D101307609C259F3E1F033F, _stringLiteralDB5B55A9B215F744DB82517864984D073F2E8F8C, NULL);
		// unescaped = unescaped.Replace("\\t", "\t");
		NullCheck(L_5);
		String_t* L_6;
		L_6 = String_Replace_mABDB7003A1D0AEDCAE9FF85E3DFFFBA752D2A166(L_5, _stringLiteral7F3238CD8C342B06FB9AB185C610175C84625462, _stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3, NULL);
		// return unescaped;
		return L_6;
	}
}
// System.Void Defective.JSON.JSONObject::Stringify(System.Int32,System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_Stringify_m1B4AB8F7C1726AA4FA744CDA2C0261771D7737CE (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, int32_t ___depth0, StringBuilder_t* ___builder1, bool ___pretty2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_Dispose_m9AB7547595606304114C14F0450F15FD30F51468_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_MoveNext_mB602A35E50D2614F8EB42D0EAB33B023FB737E4B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Enumerator_get_Current_m1499EAC836D33EE4BDFBC30928D75545E8F29523_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_GetEnumerator_m2EA9CF993A1757CD6FA450F8FB76CE5C4797CA95_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m72F3DB0603A408B7B91C4591FADFC8E855D81490_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* V_3 = NULL;
	String_t* V_4 = NULL;
	Enumerator_t67AE52CF7FD6EE3C251143D6B7534AF4A04048A1 V_5;
	memset((&V_5), 0, sizeof(V_5));
	JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* V_6 = NULL;
	{
		// depth++;
		int32_t L_0 = ___depth0;
		___depth0 = ((int32_t)il2cpp_codegen_add(L_0, 1));
		// switch (type) {
		int32_t L_1 = __this->___type_2;
		V_1 = L_1;
		int32_t L_2 = V_1;
		switch (L_2)
		{
			case 0:
			{
				goto IL_0147;
			}
			case 1:
			{
				goto IL_003d;
			}
			case 2:
			{
				goto IL_0045;
			}
			case 3:
			{
				goto IL_004d;
			}
			case 4:
			{
				goto IL_00cd;
			}
			case 5:
			{
				goto IL_013f;
			}
			case 6:
			{
				goto IL_002f;
			}
		}
	}
	{
		return;
	}

IL_002f:
	{
		// builder.Append(stringValue);
		StringBuilder_t* L_3 = ___builder1;
		String_t* L_4 = __this->___stringValue_5;
		NullCheck(L_3);
		StringBuilder_t* L_5;
		L_5 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_3, L_4, NULL);
		// break;
		return;
	}

IL_003d:
	{
		// StringifyString(builder);
		StringBuilder_t* L_6 = ___builder1;
		JSONObject_StringifyString_m6C60B157ADB60C0A400CE42AD83B78BF95531578(__this, L_6, NULL);
		// break;
		return;
	}

IL_0045:
	{
		// StringifyNumber(builder);
		StringBuilder_t* L_7 = ___builder1;
		JSONObject_StringifyNumber_m59CDF5A6C31D5A0B994FB91C54C70A4B52CAC63E(__this, L_7, NULL);
		// break;
		return;
	}

IL_004d:
	{
		// var fieldCount = count;
		int32_t L_8;
		L_8 = JSONObject_get_count_m3013D1542E66CD45405528D5A5A7DCBE4F85421F(__this, NULL);
		V_0 = L_8;
		// if (fieldCount <= 0) {
		int32_t L_9 = V_0;
		if ((((int32_t)L_9) > ((int32_t)0)))
		{
			goto IL_005f;
		}
	}
	{
		// StringifyEmptyObject(builder);
		StringBuilder_t* L_10 = ___builder1;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_StringifyEmptyObject_mF0208881D165951D3B98AC8D67B4E9CCF450C9D4(L_10, NULL);
		// break;
		return;
	}

IL_005f:
	{
		// BeginStringifyObjectContainer(builder, pretty);
		StringBuilder_t* L_11 = ___builder1;
		bool L_12 = ___pretty2;
		JSONObject_BeginStringifyObjectContainer_m5DDF0C38F6519E8291886BA780B4116C70A33B4C(__this, L_11, L_12, NULL);
		// for (var index = 0; index < fieldCount; index++) {
		V_2 = 0;
		goto IL_00bf;
	}

IL_006b:
	{
		// var jsonObject = list[index];
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_13 = __this->___list_3;
		int32_t L_14 = V_2;
		NullCheck(L_13);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_15;
		L_15 = List_1_get_Item_m72F3DB0603A408B7B91C4591FADFC8E855D81490(L_13, L_14, List_1_get_Item_m72F3DB0603A408B7B91C4591FADFC8E855D81490_RuntimeMethod_var);
		V_3 = L_15;
		// if (jsonObject == null)
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_16 = V_3;
		if (!L_16)
		{
			goto IL_00bb;
		}
	}
	{
		// if (keys == null || index >= keys.Count)
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_17 = __this->___keys_4;
		if (!L_17)
		{
			goto IL_00c3;
		}
	}
	{
		int32_t L_18 = V_2;
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_19 = __this->___keys_4;
		NullCheck(L_19);
		int32_t L_20;
		L_20 = List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_inline(L_19, List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_RuntimeMethod_var);
		if ((((int32_t)L_18) >= ((int32_t)L_20)))
		{
			goto IL_00c3;
		}
	}
	{
		// var key = keys[index];
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_21 = __this->___keys_4;
		int32_t L_22 = V_2;
		NullCheck(L_21);
		String_t* L_23;
		L_23 = List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8(L_21, L_22, List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8_RuntimeMethod_var);
		V_4 = L_23;
		// BeginStringifyObjectField(builder, pretty, depth, key);
		StringBuilder_t* L_24 = ___builder1;
		bool L_25 = ___pretty2;
		int32_t L_26 = ___depth0;
		String_t* L_27 = V_4;
		JSONObject_BeginStringifyObjectField_m7FD31C38CCAB181AF2499C2971B6A0FEE8D0298B(__this, L_24, L_25, L_26, L_27, NULL);
		// jsonObject.Stringify(depth, builder, pretty);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_28 = V_3;
		int32_t L_29 = ___depth0;
		StringBuilder_t* L_30 = ___builder1;
		bool L_31 = ___pretty2;
		NullCheck(L_28);
		JSONObject_Stringify_m1B4AB8F7C1726AA4FA744CDA2C0261771D7737CE(L_28, L_29, L_30, L_31, NULL);
		// EndStringifyObjectField(builder, pretty);
		StringBuilder_t* L_32 = ___builder1;
		bool L_33 = ___pretty2;
		JSONObject_EndStringifyObjectField_mE69FE33F5E034275318A7C3D9AE2C5A802945090(__this, L_32, L_33, NULL);
	}

IL_00bb:
	{
		// for (var index = 0; index < fieldCount; index++) {
		int32_t L_34 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_34, 1));
	}

IL_00bf:
	{
		// for (var index = 0; index < fieldCount; index++) {
		int32_t L_35 = V_2;
		int32_t L_36 = V_0;
		if ((((int32_t)L_35) < ((int32_t)L_36)))
		{
			goto IL_006b;
		}
	}

IL_00c3:
	{
		// EndStringifyObjectContainer(builder, pretty, depth);
		StringBuilder_t* L_37 = ___builder1;
		bool L_38 = ___pretty2;
		int32_t L_39 = ___depth0;
		JSONObject_EndStringifyObjectContainer_mD874A086B26BFD0B1543B4747D14CF073639F05B(__this, L_37, L_38, L_39, NULL);
		// break;
		return;
	}

IL_00cd:
	{
		// if (count <= 0) {
		int32_t L_40;
		L_40 = JSONObject_get_count_m3013D1542E66CD45405528D5A5A7DCBE4F85421F(__this, NULL);
		if ((((int32_t)L_40) > ((int32_t)0)))
		{
			goto IL_00dd;
		}
	}
	{
		// StringifyEmptyArray(builder);
		StringBuilder_t* L_41 = ___builder1;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_StringifyEmptyArray_mC78592CCEB915F47CCB8F3F3EF3F0CEECE0CD624(L_41, NULL);
		// break;
		return;
	}

IL_00dd:
	{
		// BeginStringifyArrayContainer(builder, pretty);
		StringBuilder_t* L_42 = ___builder1;
		bool L_43 = ___pretty2;
		JSONObject_BeginStringifyArrayContainer_m59F4D18EDB10B3243DD1AD8CF673F92EA912AE57(__this, L_42, L_43, NULL);
		// foreach (var jsonObject in list) {
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_44 = __this->___list_3;
		NullCheck(L_44);
		Enumerator_t67AE52CF7FD6EE3C251143D6B7534AF4A04048A1 L_45;
		L_45 = List_1_GetEnumerator_m2EA9CF993A1757CD6FA450F8FB76CE5C4797CA95(L_44, List_1_GetEnumerator_m2EA9CF993A1757CD6FA450F8FB76CE5C4797CA95_RuntimeMethod_var);
		V_5 = L_45;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_0127:
			{// begin finally (depth: 1)
				Enumerator_Dispose_m9AB7547595606304114C14F0450F15FD30F51468((&V_5), Enumerator_Dispose_m9AB7547595606304114C14F0450F15FD30F51468_RuntimeMethod_var);
				return;
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			{
				goto IL_011c_1;
			}

IL_00f4_1:
			{
				// foreach (var jsonObject in list) {
				JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_46;
				L_46 = Enumerator_get_Current_m1499EAC836D33EE4BDFBC30928D75545E8F29523_inline((&V_5), Enumerator_get_Current_m1499EAC836D33EE4BDFBC30928D75545E8F29523_RuntimeMethod_var);
				V_6 = L_46;
				// if (jsonObject == null)
				JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_47 = V_6;
				if (!L_47)
				{
					goto IL_011c_1;
				}
			}
			{
				// BeginStringifyArrayElement(builder, pretty, depth);
				StringBuilder_t* L_48 = ___builder1;
				bool L_49 = ___pretty2;
				int32_t L_50 = ___depth0;
				JSONObject_BeginStringifyArrayElement_m401B397C85AA21E3E8707178CD43782B533141B3(__this, L_48, L_49, L_50, NULL);
				// jsonObject.Stringify(depth, builder, pretty);
				JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_51 = V_6;
				int32_t L_52 = ___depth0;
				StringBuilder_t* L_53 = ___builder1;
				bool L_54 = ___pretty2;
				NullCheck(L_51);
				JSONObject_Stringify_m1B4AB8F7C1726AA4FA744CDA2C0261771D7737CE(L_51, L_52, L_53, L_54, NULL);
				// EndStringifyArrayElement(builder, pretty);
				StringBuilder_t* L_55 = ___builder1;
				bool L_56 = ___pretty2;
				JSONObject_EndStringifyArrayElement_mD9266EAC7BC72C2ED1586C924DC8EA395E34E7F9(__this, L_55, L_56, NULL);
			}

IL_011c_1:
			{
				// foreach (var jsonObject in list) {
				bool L_57;
				L_57 = Enumerator_MoveNext_mB602A35E50D2614F8EB42D0EAB33B023FB737E4B((&V_5), Enumerator_MoveNext_mB602A35E50D2614F8EB42D0EAB33B023FB737E4B_RuntimeMethod_var);
				if (L_57)
				{
					goto IL_00f4_1;
				}
			}
			{
				goto IL_0135;
			}
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_0135:
	{
		// EndStringifyArrayContainer(builder, pretty, depth);
		StringBuilder_t* L_58 = ___builder1;
		bool L_59 = ___pretty2;
		int32_t L_60 = ___depth0;
		JSONObject_EndStringifyArrayContainer_m4A176DF24C519585CF36618B389483DB439C88EB(__this, L_58, L_59, L_60, NULL);
		// break;
		return;
	}

IL_013f:
	{
		// StringifyBool(builder);
		StringBuilder_t* L_61 = ___builder1;
		JSONObject_StringifyBool_m898A6B762DB8BFF8031306FCDE98DD54113853C4(__this, L_61, NULL);
		// break;
		return;
	}

IL_0147:
	{
		// StringifyNull(builder);
		StringBuilder_t* L_62 = ___builder1;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		JSONObject_StringifyNull_m07BEE11BF14EE6CE788602C34450790A33411004(L_62, NULL);
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::StringifyString(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyString_m6C60B157ADB60C0A400CE42AD83B78BF95531578 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral49A5AAB83859C60FC692064F7CA72853E8B6B189);
		s_Il2CppMethodInitialized = true;
	}
	{
		// builder.AppendFormat("\"{0}\"", EscapeString(stringValue));
		StringBuilder_t* L_0 = ___builder0;
		String_t* L_1 = __this->___stringValue_5;
		il2cpp_codegen_runtime_class_init_inline(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		String_t* L_2;
		L_2 = JSONObject_EscapeString_m9D82BC2F43D518B2C71EF91E9EB70EBDA338357C(L_1, NULL);
		NullCheck(L_0);
		StringBuilder_t* L_3;
		L_3 = StringBuilder_AppendFormat_mFA88863E4018C2912D1A783E0EA6DAE4F594124F(L_0, _stringLiteral49A5AAB83859C60FC692064F7CA72853E8B6B189, L_2, NULL);
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::BeginStringifyObjectContainer(System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_BeginStringifyObjectContainer_m5DDF0C38F6519E8291886BA780B4116C70A33B4C (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0C3C6829C3CCF8020C6AC45B87963ADC095CD44A);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5);
		s_Il2CppMethodInitialized = true;
	}
	{
		// builder.Append("{");
		StringBuilder_t* L_0 = ___builder0;
		NullCheck(L_0);
		StringBuilder_t* L_1;
		L_1 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_0, _stringLiteral0C3C6829C3CCF8020C6AC45B87963ADC095CD44A, NULL);
		// if (pretty)
		bool L_2 = ___pretty1;
		if (!L_2)
		{
			goto IL_001b;
		}
	}
	{
		// builder.Append(Newline);
		StringBuilder_t* L_3 = ___builder0;
		NullCheck(L_3);
		StringBuilder_t* L_4;
		L_4 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_3, _stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5, NULL);
	}

IL_001b:
	{
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::StringifyEmptyObject(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyEmptyObject_mF0208881D165951D3B98AC8D67B4E9CCF450C9D4 (StringBuilder_t* ___builder0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9ED931619E39F59A8520C1E3B03FEA2E9A56FB60);
		s_Il2CppMethodInitialized = true;
	}
	{
		// builder.Append("{}");
		StringBuilder_t* L_0 = ___builder0;
		NullCheck(L_0);
		StringBuilder_t* L_1;
		L_1 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_0, _stringLiteral9ED931619E39F59A8520C1E3B03FEA2E9A56FB60, NULL);
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::BeginStringifyObjectField(System.Text.StringBuilder,System.Boolean,System.Int32,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_BeginStringifyObjectField_m7FD31C38CCAB181AF2499C2971B6A0FEE8D0298B (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, int32_t ___depth2, String_t* ___key3, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral763076C684EFEFA1B5A84D92C472EA6FF54AB95D);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// if (pretty)
		bool L_0 = ___pretty1;
		if (!L_0)
		{
			goto IL_001b;
		}
	}
	{
		// for (var j = 0; j < depth; j++)
		V_0 = 0;
		goto IL_0017;
	}

IL_0007:
	{
		// builder.Append(Tab); //for a bit more readability
		StringBuilder_t* L_1 = ___builder0;
		NullCheck(L_1);
		StringBuilder_t* L_2;
		L_2 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_1, _stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3, NULL);
		// for (var j = 0; j < depth; j++)
		int32_t L_3 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_3, 1));
	}

IL_0017:
	{
		// for (var j = 0; j < depth; j++)
		int32_t L_4 = V_0;
		int32_t L_5 = ___depth2;
		if ((((int32_t)L_4) < ((int32_t)L_5)))
		{
			goto IL_0007;
		}
	}

IL_001b:
	{
		// builder.AppendFormat("\"{0}\":", key);
		StringBuilder_t* L_6 = ___builder0;
		String_t* L_7 = ___key3;
		NullCheck(L_6);
		StringBuilder_t* L_8;
		L_8 = StringBuilder_AppendFormat_mFA88863E4018C2912D1A783E0EA6DAE4F594124F(L_6, _stringLiteral763076C684EFEFA1B5A84D92C472EA6FF54AB95D, L_7, NULL);
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::EndStringifyObjectField(System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_EndStringifyObjectField_mE69FE33F5E034275318A7C3D9AE2C5A802945090 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB);
		s_Il2CppMethodInitialized = true;
	}
	{
		// builder.Append(",");
		StringBuilder_t* L_0 = ___builder0;
		NullCheck(L_0);
		StringBuilder_t* L_1;
		L_1 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_0, _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB, NULL);
		// if (pretty)
		bool L_2 = ___pretty1;
		if (!L_2)
		{
			goto IL_001b;
		}
	}
	{
		// builder.Append(Newline);
		StringBuilder_t* L_3 = ___builder0;
		NullCheck(L_3);
		StringBuilder_t* L_4;
		L_4 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_3, _stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5, NULL);
	}

IL_001b:
	{
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::EndStringifyObjectContainer(System.Text.StringBuilder,System.Boolean,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_EndStringifyObjectContainer_mD874A086B26BFD0B1543B4747D14CF073639F05B (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, int32_t ___depth2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4D8D9C94AC5DA5FCED2EC8A64E10E714A2515C30);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		// if (pretty)
		bool L_0 = ___pretty1;
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		// builder.Length -= 3;
		StringBuilder_t* L_1 = ___builder0;
		StringBuilder_t* L_2 = L_1;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = StringBuilder_get_Length_mDEA041E7357C68CC3B5885276BB403676DAAE0D8(L_2, NULL);
		NullCheck(L_2);
		StringBuilder_set_Length_mE2427BDAEF91C4E4A6C80F3BDF1F6E01DBCC2414(L_2, ((int32_t)il2cpp_codegen_subtract(L_3, 3)), NULL);
		goto IL_0023;
	}

IL_0013:
	{
		// builder.Length--;
		StringBuilder_t* L_4 = ___builder0;
		StringBuilder_t* L_5 = L_4;
		NullCheck(L_5);
		int32_t L_6;
		L_6 = StringBuilder_get_Length_mDEA041E7357C68CC3B5885276BB403676DAAE0D8(L_5, NULL);
		V_0 = L_6;
		int32_t L_7 = V_0;
		NullCheck(L_5);
		StringBuilder_set_Length_mE2427BDAEF91C4E4A6C80F3BDF1F6E01DBCC2414(L_5, ((int32_t)il2cpp_codegen_subtract(L_7, 1)), NULL);
	}

IL_0023:
	{
		// if (pretty && count > 0) {
		bool L_8 = ___pretty1;
		if (!L_8)
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_9;
		L_9 = JSONObject_get_count_m3013D1542E66CD45405528D5A5A7DCBE4F85421F(__this, NULL);
		if ((((int32_t)L_9) <= ((int32_t)0)))
		{
			goto IL_0055;
		}
	}
	{
		// builder.Append(Newline);
		StringBuilder_t* L_10 = ___builder0;
		NullCheck(L_10);
		StringBuilder_t* L_11;
		L_11 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_10, _stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5, NULL);
		// for (var j = 0; j < depth - 1; j++)
		V_1 = 0;
		goto IL_004f;
	}

IL_003f:
	{
		// builder.Append(Tab);
		StringBuilder_t* L_12 = ___builder0;
		NullCheck(L_12);
		StringBuilder_t* L_13;
		L_13 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_12, _stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3, NULL);
		// for (var j = 0; j < depth - 1; j++)
		int32_t L_14 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_14, 1));
	}

IL_004f:
	{
		// for (var j = 0; j < depth - 1; j++)
		int32_t L_15 = V_1;
		int32_t L_16 = ___depth2;
		if ((((int32_t)L_15) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_16, 1)))))
		{
			goto IL_003f;
		}
	}

IL_0055:
	{
		// builder.Append("}");
		StringBuilder_t* L_17 = ___builder0;
		NullCheck(L_17);
		StringBuilder_t* L_18;
		L_18 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_17, _stringLiteral4D8D9C94AC5DA5FCED2EC8A64E10E714A2515C30, NULL);
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::StringifyEmptyArray(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyEmptyArray_mC78592CCEB915F47CCB8F3F3EF3F0CEECE0CD624 (StringBuilder_t* ___builder0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral5B4F028A4070094FCA4E7762E2C376A65E2D59C6);
		s_Il2CppMethodInitialized = true;
	}
	{
		// builder.Append("[]");
		StringBuilder_t* L_0 = ___builder0;
		NullCheck(L_0);
		StringBuilder_t* L_1;
		L_1 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_0, _stringLiteral5B4F028A4070094FCA4E7762E2C376A65E2D59C6, NULL);
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::BeginStringifyArrayContainer(System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_BeginStringifyArrayContainer_m59F4D18EDB10B3243DD1AD8CF673F92EA912AE57 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralD9691C4FD8A1F6B09DB1147CA32B442772FB46A1);
		s_Il2CppMethodInitialized = true;
	}
	{
		// builder.Append("[");
		StringBuilder_t* L_0 = ___builder0;
		NullCheck(L_0);
		StringBuilder_t* L_1;
		L_1 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_0, _stringLiteralD9691C4FD8A1F6B09DB1147CA32B442772FB46A1, NULL);
		// if (pretty)
		bool L_2 = ___pretty1;
		if (!L_2)
		{
			goto IL_001b;
		}
	}
	{
		// builder.Append(Newline);
		StringBuilder_t* L_3 = ___builder0;
		NullCheck(L_3);
		StringBuilder_t* L_4;
		L_4 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_3, _stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5, NULL);
	}

IL_001b:
	{
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::BeginStringifyArrayElement(System.Text.StringBuilder,System.Boolean,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_BeginStringifyArrayElement_m401B397C85AA21E3E8707178CD43782B533141B3 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, int32_t ___depth2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// if (pretty)
		bool L_0 = ___pretty1;
		if (!L_0)
		{
			goto IL_001b;
		}
	}
	{
		// for (var j = 0; j < depth; j++)
		V_0 = 0;
		goto IL_0017;
	}

IL_0007:
	{
		// builder.Append(Tab); //for a bit more readability
		StringBuilder_t* L_1 = ___builder0;
		NullCheck(L_1);
		StringBuilder_t* L_2;
		L_2 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_1, _stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3, NULL);
		// for (var j = 0; j < depth; j++)
		int32_t L_3 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_3, 1));
	}

IL_0017:
	{
		// for (var j = 0; j < depth; j++)
		int32_t L_4 = V_0;
		int32_t L_5 = ___depth2;
		if ((((int32_t)L_4) < ((int32_t)L_5)))
		{
			goto IL_0007;
		}
	}

IL_001b:
	{
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::EndStringifyArrayElement(System.Text.StringBuilder,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_EndStringifyArrayElement_mD9266EAC7BC72C2ED1586C924DC8EA395E34E7F9 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB);
		s_Il2CppMethodInitialized = true;
	}
	{
		// builder.Append(",");
		StringBuilder_t* L_0 = ___builder0;
		NullCheck(L_0);
		StringBuilder_t* L_1;
		L_1 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_0, _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB, NULL);
		// if (pretty)
		bool L_2 = ___pretty1;
		if (!L_2)
		{
			goto IL_001b;
		}
	}
	{
		// builder.Append(Newline);
		StringBuilder_t* L_3 = ___builder0;
		NullCheck(L_3);
		StringBuilder_t* L_4;
		L_4 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_3, _stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5, NULL);
	}

IL_001b:
	{
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::EndStringifyArrayContainer(System.Text.StringBuilder,System.Boolean,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_EndStringifyArrayContainer_m4A176DF24C519585CF36618B389483DB439C88EB (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, bool ___pretty1, int32_t ___depth2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralE166C9564FBDE461738077E3B1B506525EB6ACCC);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		// if (pretty)
		bool L_0 = ___pretty1;
		if (!L_0)
		{
			goto IL_0013;
		}
	}
	{
		// builder.Length -= 3;
		StringBuilder_t* L_1 = ___builder0;
		StringBuilder_t* L_2 = L_1;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = StringBuilder_get_Length_mDEA041E7357C68CC3B5885276BB403676DAAE0D8(L_2, NULL);
		NullCheck(L_2);
		StringBuilder_set_Length_mE2427BDAEF91C4E4A6C80F3BDF1F6E01DBCC2414(L_2, ((int32_t)il2cpp_codegen_subtract(L_3, 3)), NULL);
		goto IL_0023;
	}

IL_0013:
	{
		// builder.Length--;
		StringBuilder_t* L_4 = ___builder0;
		StringBuilder_t* L_5 = L_4;
		NullCheck(L_5);
		int32_t L_6;
		L_6 = StringBuilder_get_Length_mDEA041E7357C68CC3B5885276BB403676DAAE0D8(L_5, NULL);
		V_0 = L_6;
		int32_t L_7 = V_0;
		NullCheck(L_5);
		StringBuilder_set_Length_mE2427BDAEF91C4E4A6C80F3BDF1F6E01DBCC2414(L_5, ((int32_t)il2cpp_codegen_subtract(L_7, 1)), NULL);
	}

IL_0023:
	{
		// if (pretty && count > 0) {
		bool L_8 = ___pretty1;
		if (!L_8)
		{
			goto IL_0055;
		}
	}
	{
		int32_t L_9;
		L_9 = JSONObject_get_count_m3013D1542E66CD45405528D5A5A7DCBE4F85421F(__this, NULL);
		if ((((int32_t)L_9) <= ((int32_t)0)))
		{
			goto IL_0055;
		}
	}
	{
		// builder.Append(Newline);
		StringBuilder_t* L_10 = ___builder0;
		NullCheck(L_10);
		StringBuilder_t* L_11;
		L_11 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_10, _stringLiteral4133EC0E83E4C69B6C0094B47BFD1408F0C8D4C5, NULL);
		// for (var j = 0; j < depth - 1; j++)
		V_1 = 0;
		goto IL_004f;
	}

IL_003f:
	{
		// builder.Append(Tab);
		StringBuilder_t* L_12 = ___builder0;
		NullCheck(L_12);
		StringBuilder_t* L_13;
		L_13 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_12, _stringLiteral24313380B89749FA23D81C8CFE7ECADF5F282DF3, NULL);
		// for (var j = 0; j < depth - 1; j++)
		int32_t L_14 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_14, 1));
	}

IL_004f:
	{
		// for (var j = 0; j < depth - 1; j++)
		int32_t L_15 = V_1;
		int32_t L_16 = ___depth2;
		if ((((int32_t)L_15) < ((int32_t)((int32_t)il2cpp_codegen_subtract(L_16, 1)))))
		{
			goto IL_003f;
		}
	}

IL_0055:
	{
		// builder.Append("]");
		StringBuilder_t* L_17 = ___builder0;
		NullCheck(L_17);
		StringBuilder_t* L_18;
		L_18 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_17, _stringLiteralE166C9564FBDE461738077E3B1B506525EB6ACCC, NULL);
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::StringifyNumber(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyNumber_m59CDF5A6C31D5A0B994FB91C54C70A4B52CAC63E (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral2C3D4826D5236B3C9A914C5CE2E3D8CEA48AC7CE);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral5B22DE498A248A5D137E9D01CFAA089B3CA784EA);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral70EEFAA66DA29FAC9E1A81759A5984878FB67ED3);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9CA8C44D8001E19877B2F2B86EC61A60048AF615);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (isInteger) {
		bool L_0 = __this->___isInteger_6;
		if (!L_0)
		{
			goto IL_0020;
		}
	}
	{
		// builder.Append(longValue.ToString(CultureInfo.InvariantCulture));
		StringBuilder_t* L_1 = ___builder0;
		int64_t* L_2 = (&__this->___longValue_7);
		il2cpp_codegen_runtime_class_init_inline(CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var);
		CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* L_3;
		L_3 = CultureInfo_get_InvariantCulture_mD1E96DC845E34B10F78CB744B0CB5D7D63CEB1E6(NULL);
		String_t* L_4;
		L_4 = Int64_ToString_m5250B67D3E89B8EB829FB26136E744F1F141B7FD(L_2, L_3, NULL);
		NullCheck(L_1);
		StringBuilder_t* L_5;
		L_5 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_1, L_4, NULL);
		return;
	}

IL_0020:
	{
		// if (double.IsNegativeInfinity(doubleValue))
		double L_6 = __this->___doubleValue_9;
		bool L_7;
		L_7 = Double_IsNegativeInfinity_m13015C1072581C43BA6AAED02596E631C18942F6_inline(L_6, NULL);
		if (!L_7)
		{
			goto IL_003a;
		}
	}
	{
		// builder.Append(NegativeInfinity);
		StringBuilder_t* L_8 = ___builder0;
		NullCheck(L_8);
		StringBuilder_t* L_9;
		L_9 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_8, _stringLiteral70EEFAA66DA29FAC9E1A81759A5984878FB67ED3, NULL);
		return;
	}

IL_003a:
	{
		// else if (double.IsInfinity(doubleValue))
		double L_10 = __this->___doubleValue_9;
		bool L_11;
		L_11 = Double_IsInfinity_mF1F2BB1A8094AF95520E754AE9888993EA948B34_inline(L_10, NULL);
		if (!L_11)
		{
			goto IL_0054;
		}
	}
	{
		// builder.Append(Infinity);
		StringBuilder_t* L_12 = ___builder0;
		NullCheck(L_12);
		StringBuilder_t* L_13;
		L_13 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_12, _stringLiteral5B22DE498A248A5D137E9D01CFAA089B3CA784EA, NULL);
		return;
	}

IL_0054:
	{
		// else if (double.IsNaN(doubleValue))
		double L_14 = __this->___doubleValue_9;
		bool L_15;
		L_15 = Double_IsNaN_mF2BC6D1FD4813179B2CAE58D29770E42830D0883_inline(L_14, NULL);
		if (!L_15)
		{
			goto IL_006e;
		}
	}
	{
		// builder.Append(NaN);
		StringBuilder_t* L_16 = ___builder0;
		NullCheck(L_16);
		StringBuilder_t* L_17;
		L_17 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_16, _stringLiteral9CA8C44D8001E19877B2F2B86EC61A60048AF615, NULL);
		return;
	}

IL_006e:
	{
		// builder.Append(doubleValue.ToString("R", CultureInfo.InvariantCulture));
		StringBuilder_t* L_18 = ___builder0;
		double* L_19 = (&__this->___doubleValue_9);
		il2cpp_codegen_runtime_class_init_inline(CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0_il2cpp_TypeInfo_var);
		CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* L_20;
		L_20 = CultureInfo_get_InvariantCulture_mD1E96DC845E34B10F78CB744B0CB5D7D63CEB1E6(NULL);
		String_t* L_21;
		L_21 = Double_ToString_m7E3930DDFB35B1919FE538A246A59C3FC62AF789(L_19, _stringLiteral2C3D4826D5236B3C9A914C5CE2E3D8CEA48AC7CE, L_20, NULL);
		NullCheck(L_18);
		StringBuilder_t* L_22;
		L_22 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_18, L_21, NULL);
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::StringifyBool(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyBool_m898A6B762DB8BFF8031306FCDE98DD54113853C4 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, StringBuilder_t* ___builder0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral77D38C0623F92B292B925F6E72CF5CF99A20D4EB);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralB7C45DD316C68ABF3429C20058C2981C652192F2);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t* G_B2_0 = NULL;
	StringBuilder_t* G_B1_0 = NULL;
	String_t* G_B3_0 = NULL;
	StringBuilder_t* G_B3_1 = NULL;
	{
		// builder.Append(boolValue ? True : False);
		StringBuilder_t* L_0 = ___builder0;
		bool L_1 = __this->___boolValue_8;
		G_B1_0 = L_0;
		if (L_1)
		{
			G_B2_0 = L_0;
			goto IL_0010;
		}
	}
	{
		G_B3_0 = _stringLiteral77D38C0623F92B292B925F6E72CF5CF99A20D4EB;
		G_B3_1 = G_B1_0;
		goto IL_0015;
	}

IL_0010:
	{
		G_B3_0 = _stringLiteralB7C45DD316C68ABF3429C20058C2981C652192F2;
		G_B3_1 = G_B2_0;
	}

IL_0015:
	{
		NullCheck(G_B3_1);
		StringBuilder_t* L_2;
		L_2 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(G_B3_1, G_B3_0, NULL);
		// }
		return;
	}
}
// System.Void Defective.JSON.JSONObject::StringifyNull(System.Text.StringBuilder)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject_StringifyNull_m07BEE11BF14EE6CE788602C34450790A33411004 (StringBuilder_t* ___builder0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral5BEFD8CC60A79699B5BB00E37BAC5B62D371E174);
		s_Il2CppMethodInitialized = true;
	}
	{
		// builder.Append(Null);
		StringBuilder_t* L_0 = ___builder0;
		NullCheck(L_0);
		StringBuilder_t* L_1;
		L_1 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_0, _stringLiteral5BEFD8CC60A79699B5BB00E37BAC5B62D371E174, NULL);
		// }
		return;
	}
}
// Defective.JSON.JSONObject Defective.JSON.JSONObject::get_Item(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_get_Item_mFDB9D6D8206F6899009E5D35EF69E5085735AB1C (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, int32_t ___index0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m72F3DB0603A408B7B91C4591FADFC8E855D81490_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return count > index ? list[index] : null;
		int32_t L_0;
		L_0 = JSONObject_get_count_m3013D1542E66CD45405528D5A5A7DCBE4F85421F(__this, NULL);
		int32_t L_1 = ___index0;
		if ((((int32_t)L_0) > ((int32_t)L_1)))
		{
			goto IL_000b;
		}
	}
	{
		return (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC*)NULL;
	}

IL_000b:
	{
		List_1_tAF8C7FE7745E3AF175E6652DEE3CB8C82B65E63E* L_2 = __this->___list_3;
		int32_t L_3 = ___index0;
		NullCheck(L_2);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_4;
		L_4 = List_1_get_Item_m72F3DB0603A408B7B91C4591FADFC8E855D81490(L_2, L_3, List_1_get_Item_m72F3DB0603A408B7B91C4591FADFC8E855D81490_RuntimeMethod_var);
		return L_4;
	}
}
// Defective.JSON.JSONObject Defective.JSON.JSONObject::get_Item(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObject_get_Item_m32CD450E44D55B639F7C13F48A4CC98AF4E4B6EA (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, String_t* ___index0, const RuntimeMethod* method) 
{
	{
		// get { return GetField(index); }
		String_t* L_0 = ___index0;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_1;
		L_1 = JSONObject_GetField_m2B0D3470E8784CF807ECAE34BBE45CB39EACCC53(__this, L_0, NULL);
		return L_1;
	}
}
// System.String Defective.JSON.JSONObject::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JSONObject_ToString_mC75F8ED6593F16613D74FE21534C7857F4D4D19D (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, const RuntimeMethod* method) 
{
	{
		// return Print();
		String_t* L_0;
		L_0 = JSONObject_Print_m3AC68522204B19733E330B8DA1F8919099E6C284(__this, (bool)0, NULL);
		return L_0;
	}
}
// System.Collections.IEnumerator Defective.JSON.JSONObject::System.Collections.IEnumerable.GetEnumerator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* JSONObject_System_Collections_IEnumerable_GetEnumerator_mD11F6ABC323D05CAD33E0968487A894D48F942B7 (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, const RuntimeMethod* method) 
{
	{
		// return GetEnumerator();
		JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5* L_0;
		L_0 = JSONObject_GetEnumerator_mB47C5B15F96CECE98FD0D8B8A64AB98CC78178BF(__this, NULL);
		return L_0;
	}
}
// Defective.JSON.JSONObjectEnumerator Defective.JSON.JSONObject::GetEnumerator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5* JSONObject_GetEnumerator_mB47C5B15F96CECE98FD0D8B8A64AB98CC78178BF (JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return new JSONObjectEnumerator(this);
		JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5* L_0 = (JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5*)il2cpp_codegen_object_new(JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		JSONObjectEnumerator__ctor_m24FA52671B6CD2C9492B8273FD881FA9B0499383(L_0, __this, NULL);
		return L_0;
	}
}
// System.Void Defective.JSON.JSONObject::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObject__cctor_m027D19D544CEABDFB5E9F84F76CAE9F1D395559D (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____13BA99FB374DE24EB2656ACE253C54E2DA7EBAEDA4DD3DAB04852553EAF91EF6_0_FieldInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// static readonly Stopwatch PrintWatch = new Stopwatch();
		Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043* L_0 = (Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043*)il2cpp_codegen_object_new(Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Stopwatch__ctor_mAFE6B2F45CF1C3469EF6D5307972BC098B473D0A(L_0, NULL);
		((JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_StaticFields*)il2cpp_codegen_static_fields_for(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var))->___PrintWatch_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_StaticFields*)il2cpp_codegen_static_fields_for(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var))->___PrintWatch_0), (void*)L_0);
		// public static readonly char[] Whitespace = { ' ', '\r', '\n', '\t', '\uFEFF', '\u0009' };
		CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* L_1 = (CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB*)(CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB*)SZArrayNew(CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB_il2cpp_TypeInfo_var, (uint32_t)6);
		CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* L_2 = L_1;
		RuntimeFieldHandle_t6E4C45B6D2EA12FC99185805A7E77527899B25C5 L_3 = { reinterpret_cast<intptr_t> (U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA____13BA99FB374DE24EB2656ACE253C54E2DA7EBAEDA4DD3DAB04852553EAF91EF6_0_FieldInfo_var) };
		RuntimeHelpers_InitializeArray_m751372AA3F24FBF6DA9B9D687CBFA2DE436CAB9B((RuntimeArray*)L_2, L_3, NULL);
		((JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_StaticFields*)il2cpp_codegen_static_fields_for(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var))->___Whitespace_1 = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&((JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_StaticFields*)il2cpp_codegen_static_fields_for(JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC_il2cpp_TypeInfo_var))->___Whitespace_1), (void*)L_2);
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
// System.Void Defective.JSON.JSONObjectEnumerator::.ctor(Defective.JSON.JSONObject)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObjectEnumerator__ctor_m24FA52671B6CD2C9492B8273FD881FA9B0499383 (JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5* __this, JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* ___jsonObject0, const RuntimeMethod* method) 
{
	{
		// int position = -1;
		__this->___position_1 = (-1);
		// public JSONObjectEnumerator(JSONObject jsonObject) {
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// if (!jsonObject.isContainer)
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_0 = ___jsonObject0;
		NullCheck(L_0);
		bool L_1;
		L_1 = JSONObject_get_isContainer_m00F12A4F458FD3741B5B84FF00361E8B60E015CA(L_0, NULL);
		if (L_1)
		{
			goto IL_0020;
		}
	}
	{
		// throw new InvalidOperationException("JSONObject must be an array or object to provide an iterator");
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_2 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_2);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_2, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral4A85F7924EB5D4EE9D1DD6344A4679BFEB95F45C)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&JSONObjectEnumerator__ctor_m24FA52671B6CD2C9492B8273FD881FA9B0499383_RuntimeMethod_var)));
	}

IL_0020:
	{
		// target = jsonObject;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_3 = ___jsonObject0;
		__this->___target_0 = L_3;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___target_0), (void*)L_3);
		// }
		return;
	}
}
// System.Boolean Defective.JSON.JSONObjectEnumerator::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool JSONObjectEnumerator_MoveNext_m2425B8A23491F18F8C0D41C9271BA35057422A64 (JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5* __this, const RuntimeMethod* method) 
{
	{
		// position++;
		int32_t L_0 = __this->___position_1;
		__this->___position_1 = ((int32_t)il2cpp_codegen_add(L_0, 1));
		// return position < target.count;
		int32_t L_1 = __this->___position_1;
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_2 = __this->___target_0;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = JSONObject_get_count_m3013D1542E66CD45405528D5A5A7DCBE4F85421F(L_2, NULL);
		return (bool)((((int32_t)L_1) < ((int32_t)L_3))? 1 : 0);
	}
}
// System.Void Defective.JSON.JSONObjectEnumerator::Reset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void JSONObjectEnumerator_Reset_mB699A9DE360AB13B85F0DB535DAEB0DECBE70EC3 (JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5* __this, const RuntimeMethod* method) 
{
	{
		// position = -1;
		__this->___position_1 = (-1);
		// }
		return;
	}
}
// System.Object Defective.JSON.JSONObjectEnumerator::System.Collections.IEnumerator.get_Current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* JSONObjectEnumerator_System_Collections_IEnumerator_get_Current_m40EE8D11793F1C74EFD9EC85C9BB17FC2455AC75 (JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5* __this, const RuntimeMethod* method) 
{
	{
		// get { return Current; }
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_0;
		L_0 = JSONObjectEnumerator_get_Current_m10B9A8901D2BB6CB9D84B23AEF44B25271762D8F(__this, NULL);
		return L_0;
	}
}
// Defective.JSON.JSONObject Defective.JSON.JSONObjectEnumerator::get_Current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* JSONObjectEnumerator_get_Current_m10B9A8901D2BB6CB9D84B23AEF44B25271762D8F (JSONObjectEnumerator_t943E3CCEC1B0A03D69F4FBD7A99C8355AEC408E5* __this, const RuntimeMethod* method) 
{
	{
		// return target[position];
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_0 = __this->___target_0;
		int32_t L_1 = __this->___position_1;
		NullCheck(L_0);
		JSONObject_t8EDF02FD857855C9DC72DE51C3FD37EEABC5EBCC* L_2;
		L_2 = JSONObject_get_Item_mFDB9D6D8206F6899009E5D35EF69E5085735AB1C(L_0, L_1, NULL);
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
#ifdef __clang__
#pragma clang diagnostic pop
#endif
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
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Action_Invoke_m7126A54DACA72B845424072887B5F3A51FC3808E_inline (Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* __this, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_Cross_mF93A280558BCE756D13B6CC5DCD7DE8A43148987_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___lhs0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rhs1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___lhs0;
		float L_1 = L_0.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___rhs1;
		float L_3 = L_2.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___lhs0;
		float L_5 = L_4.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___rhs1;
		float L_7 = L_6.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___lhs0;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___rhs1;
		float L_11 = L_10.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12 = ___lhs0;
		float L_13 = L_12.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_14 = ___rhs1;
		float L_15 = L_14.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_16 = ___lhs0;
		float L_17 = L_16.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_18 = ___rhs1;
		float L_19 = L_18.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_20 = ___lhs0;
		float L_21 = L_20.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_22 = ___rhs1;
		float L_23 = L_22.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_24;
		memset((&L_24), 0, sizeof(L_24));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_24), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_1, L_3)), ((float)il2cpp_codegen_multiply(L_5, L_7)))), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_9, L_11)), ((float)il2cpp_codegen_multiply(L_13, L_15)))), ((float)il2cpp_codegen_subtract(((float)il2cpp_codegen_multiply(L_17, L_19)), ((float)il2cpp_codegen_multiply(L_21, L_23)))), /*hidden argument*/NULL);
		V_0 = L_24;
		goto IL_005a;
	}

IL_005a:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_25 = V_0;
		return L_25;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Multiply_m87BA7C578F96C8E49BB07088DAAC4649F83B0353_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, float ___d1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		float L_2 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_3 = ___a0;
		float L_4 = L_3.___y_3;
		float L_5 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___a0;
		float L_7 = L_6.___z_4;
		float L_8 = ___d1;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_9;
		memset((&L_9), 0, sizeof(L_9));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_9), ((float)il2cpp_codegen_multiply(L_1, L_2)), ((float)il2cpp_codegen_multiply(L_4, L_5)), ((float)il2cpp_codegen_multiply(L_7, L_8)), /*hidden argument*/NULL);
		V_0 = L_9;
		goto IL_0021;
	}

IL_0021:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = V_0;
		return L_10;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Subtraction_mE42023FF80067CB44A1D4A27EB7CF2B24CABB828_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___b1;
		float L_3 = L_2.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___a0;
		float L_5 = L_4.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___b1;
		float L_7 = L_6.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___a0;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___b1;
		float L_11 = L_10.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_12), ((float)il2cpp_codegen_subtract(L_1, L_3)), ((float)il2cpp_codegen_subtract(L_5, L_7)), ((float)il2cpp_codegen_subtract(L_9, L_11)), /*hidden argument*/NULL);
		V_0 = L_12;
		goto IL_0030;
	}

IL_0030:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = V_0;
		return L_13;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_Addition_m78C0EC70CB66E8DCAC225743D82B268DAEE92067_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___b1, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___b1;
		float L_3 = L_2.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___a0;
		float L_5 = L_4.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6 = ___b1;
		float L_7 = L_6.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_8 = ___a0;
		float L_9 = L_8.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10 = ___b1;
		float L_11 = L_10.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_12;
		memset((&L_12), 0, sizeof(L_12));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_12), ((float)il2cpp_codegen_add(L_1, L_3)), ((float)il2cpp_codegen_add(L_5, L_7)), ((float)il2cpp_codegen_add(L_9, L_11)), /*hidden argument*/NULL);
		V_0 = L_12;
		goto IL_0030;
	}

IL_0030:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_13 = V_0;
		return L_13;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline (Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* __this, float ___x0, float ___y1, const RuntimeMethod* method) 
{
	{
		float L_0 = ___x0;
		__this->___x_0 = L_0;
		float L_1 = ___y1;
		__this->___y_1 = L_1;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_op_UnaryNegation_m5450829F333BD2A88AF9A592C4EE331661225915_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___a0, const RuntimeMethod* method) 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___a0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___a0;
		float L_3 = L_2.___y_3;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_4 = ___a0;
		float L_5 = L_4.___z_4;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_6;
		memset((&L_6), 0, sizeof(L_6));
		Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline((&L_6), ((-L_1)), ((-L_3)), ((-L_5)), /*hidden argument*/NULL);
		V_0 = L_6;
		goto IL_001e;
	}

IL_001e:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_7 = V_0;
		return L_7;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 Quaternion_get_identity_m7E701AE095ED10FD5EA0B50ABCFDE2EEFF2173A5_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_0 = ((Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_StaticFields*)il2cpp_codegen_static_fields_for(Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974_il2cpp_TypeInfo_var))->___identityQuaternion_4;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Quaternion_tDA59F214EF07D7700B26E40E562F267AF7306974 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_zero_m0C1249C3F25B1C70EAD3CC8B31259975A457AE39_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ((Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields*)il2cpp_codegen_static_fields_for(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var))->___zeroVector_5;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 Vector3_get_one_mC9B289F1E15C42C597180C9FE6FB492495B51D02_inline (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ((Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields*)il2cpp_codegen_static_fields_for(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_il2cpp_TypeInfo_var))->___oneVector_6;
		V_0 = L_0;
		goto IL_0009;
	}

IL_0009:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_1 = V_0;
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m5F87930F9B0828E5652E2D9D01ED907C01122C86_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___x0, float ___y1, const RuntimeMethod* method) 
{
	{
		float L_0 = ___x0;
		__this->___x_2 = L_0;
		float L_1 = ___y1;
		__this->___y_3 = L_1;
		__this->___z_4 = (0.0f);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 Vector2_op_Implicit_mE8EBEE9291F11BB02F062D6E000F4798968CBD96_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___v0, const RuntimeMethod* method) 
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_0 = ___v0;
		float L_1 = L_0.___x_2;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_2 = ___v0;
		float L_3 = L_2.___y_3;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_4;
		memset((&L_4), 0, sizeof(L_4));
		Vector2__ctor_m9525B79969AFFE3254B303A40997A56DEEB6F548_inline((&L_4), L_1, L_3, /*hidden argument*/NULL);
		V_0 = L_4;
		goto IL_0015;
	}

IL_0015:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_5 = V_0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____stringLength_4;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Double_IsNegativeInfinity_m13015C1072581C43BA6AAED02596E631C18942F6_inline (double ___d0, const RuntimeMethod* method) 
{
	{
		double L_0 = ___d0;
		return (bool)((((double)L_0) == ((double)(-std::numeric_limits<double>::infinity())))? 1 : 0);
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Double_IsInfinity_mF1F2BB1A8094AF95520E754AE9888993EA948B34_inline (double ___d0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		double L_0 = ___d0;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int64_t L_1;
		L_1 = BitConverter_DoubleToInt64Bits_m4F42741818550F9956B5FBAF88C051F4DE5B0AE6_inline(L_0, NULL);
		return (bool)((((int64_t)((int64_t)(L_1&((int64_t)(std::numeric_limits<int64_t>::max)())))) == ((int64_t)((int64_t)9218868437227405312LL)))? 1 : 0);
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Double_IsNaN_mF2BC6D1FD4813179B2CAE58D29770E42830D0883_inline (double ___d0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		double L_0 = ___d0;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int64_t L_1;
		L_1 = BitConverter_DoubleToInt64Bits_m4F42741818550F9956B5FBAF88C051F4DE5B0AE6_inline(L_0, NULL);
		return (bool)((((int64_t)((int64_t)(L_1&((int64_t)(std::numeric_limits<int64_t>::max)())))) > ((int64_t)((int64_t)9218868437227405312LL)))? 1 : 0);
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_mD2ED26ACAF3BAF386FFEA83893BA51DB9FD8BA30_gshared_inline (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = (int32_t)__this->____size_2;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Add_mD4F3498FBD3BDD3F03CBCFB38041CBAC9C28CAFC_gshared_inline (List_1_tDBA89B0E21BAC58CFBD3C1F76E4668E3B562761A* __this, /*Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType*/Il2CppFullySharedGenericAny ___item0, const RuntimeMethod* method) 
{
	// sizeof(T)
	const uint32_t SizeOf_T_t664E2061A913AF1FEE499655BC64F0FDE10D2A5E = il2cpp_codegen_sizeof(il2cpp_rgctx_data(method->klass->rgctx_data, 9));
	// T
	const Il2CppFullySharedGenericAny L_8 = alloca(SizeOf_T_t664E2061A913AF1FEE499655BC64F0FDE10D2A5E);
	const Il2CppFullySharedGenericAny L_9 = L_8;
	__Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC* V_0 = NULL;
	int32_t V_1 = 0;
	{
		int32_t L_0 = (int32_t)__this->____version_3;
		__this->____version_3 = ((int32_t)il2cpp_codegen_add(L_0, 1));
		__Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC* L_1 = (__Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC*)__this->____items_1;
		V_0 = L_1;
		int32_t L_2 = (int32_t)__this->____size_2;
		V_1 = L_2;
		int32_t L_3 = V_1;
		__Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC* L_4 = V_0;
		NullCheck(L_4);
		if ((!(((uint32_t)L_3) < ((uint32_t)((int32_t)(((RuntimeArray*)L_4)->max_length))))))
		{
			goto IL_0034;
		}
	}
	{
		int32_t L_5 = V_1;
		__this->____size_2 = ((int32_t)il2cpp_codegen_add(L_5, 1));
		__Il2CppFullySharedGenericTypeU5BU5D_tCAB6D060972DD49223A834B7EEFEB9FE2D003BEC* L_6 = V_0;
		int32_t L_7 = V_1;
		il2cpp_codegen_memcpy(L_8, (il2cpp_codegen_class_is_value_type(il2cpp_rgctx_data(method->klass->rgctx_data, 9)) ? ___item0 : &___item0), SizeOf_T_t664E2061A913AF1FEE499655BC64F0FDE10D2A5E);
		NullCheck(L_6);
		il2cpp_codegen_memcpy((L_6)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_7)), L_8, SizeOf_T_t664E2061A913AF1FEE499655BC64F0FDE10D2A5E);
		Il2CppCodeGenWriteBarrierForClass(il2cpp_rgctx_data(method->klass->rgctx_data, 9), (void**)(L_6)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_7)), (void*)L_8);
		return;
	}

IL_0034:
	{
		il2cpp_codegen_memcpy(L_9, (il2cpp_codegen_class_is_value_type(il2cpp_rgctx_data(method->klass->rgctx_data, 9)) ? ___item0 : &___item0), SizeOf_T_t664E2061A913AF1FEE499655BC64F0FDE10D2A5E);
		InvokerActionInvoker1< Il2CppFullySharedGenericAny >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->klass->rgctx_data, 14)), il2cpp_rgctx_method(method->klass->rgctx_data, 14), __this, (il2cpp_codegen_class_is_value_type(il2cpp_rgctx_data(method->klass->rgctx_data, 9)) ? L_9: *(void**)L_9));
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Enumerator_get_Current_m8B42D4B2DE853B9D11B997120CD0228D4780E394_gshared_inline (Enumerator_tF5AC6CD19D283FBD724440520CEE68FE2602F7AF* __this, Il2CppFullySharedGenericAny* il2cppRetVal, const RuntimeMethod* method) 
{
	// sizeof(T)
	const uint32_t SizeOf_T_t010616E3077234188F9BB4FAF369F8571BC5F2E1 = il2cpp_codegen_sizeof(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 2));
	// T
	const Il2CppFullySharedGenericAny L_0 = alloca(SizeOf_T_t010616E3077234188F9BB4FAF369F8571BC5F2E1);
	{
		il2cpp_codegen_memcpy(L_0, il2cpp_codegen_get_instance_field_data_pointer(__this, il2cpp_rgctx_field(il2cpp_rgctx_data(InitializedTypeInfo(method->klass)->rgctx_data, 1),3)), SizeOf_T_t010616E3077234188F9BB4FAF369F8571BC5F2E1);
		il2cpp_codegen_memcpy(il2cppRetVal, L_0, SizeOf_T_t010616E3077234188F9BB4FAF369F8571BC5F2E1);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void Vector3__ctor_m376936E6B999EF1ECBE57D990A386303E2283DE0_inline (Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* __this, float ___x0, float ___y1, float ___z2, const RuntimeMethod* method) 
{
	{
		float L_0 = ___x0;
		__this->___x_2 = L_0;
		float L_1 = ___y1;
		__this->___y_3 = L_1;
		float L_2 = ___z2;
		__this->___z_4 = L_2;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int64_t BitConverter_DoubleToInt64Bits_m4F42741818550F9956B5FBAF88C051F4DE5B0AE6_inline (double ___value0, const RuntimeMethod* method) 
{
	{
		int64_t L_0 = *((int64_t*)((uintptr_t)(&___value0)));
		return L_0;
	}
}
