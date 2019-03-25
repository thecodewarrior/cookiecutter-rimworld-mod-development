using System.Reflection;
using System.Linq;
using Verse;
using RimWorld;
using UnityEngine;
{%if(cookiecutter.harmony != 'n')%}using Harmony;
{%endif%}
namespace {{cookiecutter.mod_name.replace(' ', '_')}}
{
	public class Mod : Verse.Mod
	{
		public Mod(ModContentPack content) : base(content)
		{
{%if(cookiecutter.helloWorld != 'n')%}			Log.Message("Hello world from {{cookiecutter.mod_name}}");

{% endif %}{%if(cookiecutter.settings != 'n')%}			// initialize settings
			GetSettings<Settings>();

{%endif%}{%if(cookiecutter.harmony != 'n')%}#if DEBUG
			HarmonyInstance.DEBUG = true;
#endif

			HarmonyInstance harmony = HarmonyInstance.Create("{{cookiecutter.author}}.rimworld.{{cookiecutter.mod_name.replace(' ', '_')}}.main");
{%if(cookiecutter.defOfWarn != 'n')%}
			//Turn off DefOf warning since harmony patches trigger it.
			MethodInfo DefOfHelperInfo = AccessTools.Method(typeof(DefOfHelper), "EnsureInitializedInCtor");
			if (!harmony.GetPatchedMethods().Contains(DefOfHelperInfo))
				harmony.Patch(DefOfHelperInfo, new HarmonyMethod(typeof(Mod), "EnsureInitializedInCtorPrefix"), null);
{%endif%}			
			harmony.PatchAll();
{%endif%}		}
{%if(cookiecutter.defOfWarn != 'n')%}
		public static bool EnsureInitializedInCtorPrefix()
		{
			//No need to display this warning.
			return false;
		}
{%endif%}{%if(cookiecutter.settings != 'n')%}
		public override void DoSettingsWindowContents(Rect inRect)
		{
			base.DoSettingsWindowContents(inRect);
			GetSettings<Settings>().DoWindowContents(inRect);
		}

		public override string SettingsCategory()
		{
			return "{{cookiecutter.mod_name}}";
		}
{% endif %}	}
}