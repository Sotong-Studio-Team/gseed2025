using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.VContainer
{
    public class VContainerDIInstallerUtils
    {
        public static RegistrationBuilder RegisterComponent(IContainerBuilder builder, string objectScripting)
        {
            Type registerType = Type.GetType(objectScripting) ??
             throw new InvalidOperationException($"Registering Component failed. Cannot get Scripting Type : {objectScripting}");

            var regisBuilder = builder.Register(registerType, Lifetime.Singleton);

            if (registerType.GetCustomAttribute<RegisterAsAttribute>() is IRegisterAs regisAttb)
            {
                foreach (var regisType in regisAttb.RegisterTypes)
                {
                    regisBuilder.As(regisType);
                }
            }
            else
            {
                regisBuilder.AsSelf();
            }

            return regisBuilder;
        }
        public static IEnumerable<RegistrationBuilder> RegisterComponents(IContainerBuilder builder, IEnumerable<string> objectsScripting)
        {
            List<RegistrationBuilder> result = new();
            foreach (var target in objectsScripting)
            {
                var resigBuilder = RegisterComponent(builder, target);
                result.Add(resigBuilder);
            }

            return result;
        }

        public static IEnumerable<RegistrationBuilder> RegisterMonoBehaviourComponents(IContainerBuilder builder, IEnumerable<MonoBehaviour> monoObjects)
        {
            List<RegistrationBuilder> result = new();
            foreach (var target in monoObjects)
            {
                var type = target.GetType();
                var regisBuilder = builder.RegisterComponent(target);

                if (type.GetCustomAttribute<RegisterAsAttribute>() is IRegisterAs regisAttb)
                {
                    regisBuilder.As(regisAttb.RegisterTypes);
                }
                else
                {
                    regisBuilder.AsSelf();
                }
                result.Add(regisBuilder);
            }
            return result;
        }

#if UNITY_EDITOR
        public static void RevalidateScripts(IEnumerable<UnityEditor.MonoScript> scripts, ref List<string> stringScripts)
        {
            List<string> stringScriptsResult = new();
            foreach (var script in scripts)
            {
                if (script == null) continue;

                var scriptClass = script.GetClass();
                if (scriptClass == null) continue;

                var result = scriptClass.AssemblyQualifiedName;
                stringScriptsResult.Add(result);

                stringScripts = stringScriptsResult;
            }
        }

        public static void RevalidateScript(UnityEditor.MonoScript script, ref string stringScript)
        {
            var scriptClass = script.GetClass();
            if (scriptClass == null) return;
            stringScript = scriptClass.AssemblyQualifiedName;
        }
#endif

        public static object RegisterInstanceWithComponents(IContainerBuilder builder, string mainObjectScripting, params MonoBehaviour[] components)
        {
            Type registerType = Type.GetType(mainObjectScripting) ??
             throw new InvalidOperationException($"Registering Component failed. Cannot get Scripting Type : {mainObjectScripting}");

            var instance = Activator.CreateInstance(registerType, components);
            var regisBuilder = builder.RegisterComponent(instance);

            if (registerType.GetCustomAttribute<RegisterAsAttribute>() is IRegisterAs regisAttb)
            {
                regisBuilder.As(regisAttb.RegisterTypes);
            }
            else
            {
                regisBuilder.AsSelf();
            }

            return instance;
        }

        public static RegistrationBuilder RegisterScriptable(IContainerBuilder builder, ScriptableObject data)
        {
            var stringScript = data.GetType().AssemblyQualifiedName;
            Type registerType = Type.GetType(stringScript) ??
            throw new InvalidOperationException($"Registering Component failed. Cannot get Scripting Type : {stringScript}");

            var regisBuilder = builder.RegisterComponent(data);
            if (registerType.GetCustomAttribute<RegisterAsAttribute>() is IRegisterAs regisAttb)
            {
                regisBuilder.As(regisAttb.RegisterTypes);

            }

            return regisBuilder;
        }
    }
}

