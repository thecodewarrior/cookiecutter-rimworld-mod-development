using Verse;
{%if(cookiecutter.harmony != 'n')%}using HarmonyLib;
{%endif%}{%if(cookiecutter.settings != 'n')%}using UnityEngine;
{%endif%}
namespace {{cookiecutter.mod_name.replace(' ', '_')}}
{
    public class Mod : Verse.Mod
    {
        public Mod(ModContentPack content) : base(content)
        {{"{"}}{%if(cookiecutter.settings != 'n')%}
            // initialize settings
            GetSettings<Settings>();
{%endif%}{%if(cookiecutter.harmony != 'n')%}
            new Harmony("{{cookiecutter.author}}.rimworld.{{cookiecutter.mod_name.replace(' ', '_')}}.main").PatchAll();
{%endif%}        }
{%if(cookiecutter.settings != 'n')%}
        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            GetSettings<Settings>().DoWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "{{cookiecutter.mod_name}}";
        }
{% endif %}    }
}
