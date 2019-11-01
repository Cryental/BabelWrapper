using System;
using System.Linq;
using Newtonsoft.Json;

namespace Babel.Obfuscator
{
    internal class Wrapper
    {
        private readonly Settings _settings;

        internal Wrapper(string jsonSettings)
        {
            _settings = JsonConvert.DeserializeObject<Settings>(jsonSettings);
        }

        internal Wrapper(Settings settings)
        {
            _settings = settings;
        }

        private static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        internal string JsonBuild()
        {
            return JsonConvert.SerializeObject(_settings, Formatting.Indented);
        }

        internal string CommandArgsBuild()
        {
            var config = new CommandArgsBuilder();

            config.AddCommandLine(_settings.InputPath);

            foreach (var f in _settings.EmbedFiles)
            {
                var command = "--embed";

                switch (f.Action)
                {
                    case InputAction.Embed:
                        command = "--embed";
                        break;
                    case InputAction.Merge:
                        command = "";
                        break;
                }

                if (f.Action == InputAction.Embed)
                    config.AddCommandLine(command + " " + f.Path);
                else
                    config.AddCommandLine(f.Path);
            }

            config.AddCommandLine("--output " + _settings.OutputPath);

            if (_settings.Renaming.Types) config.AddCommandLine("--types");
            if (_settings.Renaming.Methods) config.AddCommandLine("--methods");
            if (_settings.Renaming.Overloaded) config.AddCommandLine("--overloaded");
            if (_settings.Renaming.Virtual) config.AddCommandLine("--virtual");
            if (_settings.Renaming.Properties) config.AddCommandLine("--properties");
            if (_settings.Renaming.Fields) config.AddCommandLine("--fields");
            if (_settings.Renaming.XAML) config.AddCommandLine("--xaml");
            if (_settings.Renaming.FlattenNamespaces)
            {
                if (string.IsNullOrEmpty(_settings.Renaming.FlattenNamespacesValue))
                    config.AddCommandLine("--flatns " + RandomString(15));
                else
                    config.AddCommandLine("--flatns " + _settings.Renaming.FlattenNamespacesValue);
            }

            if (_settings.Renaming.Events) config.AddCommandLine("--events");

            if (_settings.Renaming.NameLength != 0)
                config.AddCommandLine("--namelength " + _settings.Renaming.NameLength);

            if (_settings.ControlFlow.ObfuscateControlFlow)
            {
                if (_settings.ControlFlow.Algorithm.Goto) config.AddCommandLine("--controlflow goto=on");
                if (_settings.ControlFlow.Algorithm.Switch) config.AddCommandLine("--controlflow switch=on");
                if (_settings.ControlFlow.Algorithm.Case) config.AddCommandLine("--controlflow case=on");
                if (_settings.ControlFlow.Algorithm.If) config.AddCommandLine("--controlflow if=on");
                if (_settings.ControlFlow.Algorithm.Call) config.AddCommandLine("--controlflow call=on");
                if (_settings.ControlFlow.Algorithm.Value) config.AddCommandLine("--controlflow value=on");
                if (_settings.ControlFlow.Algorithm.Token) config.AddCommandLine("--controlflow token=on");
                if (_settings.ControlFlow.Algorithm.Underflow) config.AddCommandLine("--controlflow underflow=on");

                config.AddCommandLine("--iliterations " + _settings.ControlFlow.Iterations);
            }

            if (_settings.ControlFlow.EmitInvalidOpcodes) config.AddCommandLine("--invalidopcodes enhanced");

            if (_settings.Encryption.EncryptStrings)
                switch (_settings.Encryption.StringAlgorithm)
                {
                    case StringAlgorithm.Xor:
                        config.AddCommandLine("--stringencryption xor");
                        break;
                    case StringAlgorithm.Hash:
                        config.AddCommandLine("--stringencryption hash");
                        break;
                    default:
                        config.AddCommandLine("--stringencryption hash");
                        break;
                }

            if (_settings.Encryption.EncryptValues)
            {
                if (_settings.Encryption.ValuesAlgorithm.Int32) config.AddCommandLine("--valueencryption int32=on");
                if (_settings.Encryption.ValuesAlgorithm.Int64) config.AddCommandLine("--valueencryption int64=on");
                if (_settings.Encryption.ValuesAlgorithm.Single) config.AddCommandLine("--valueencryption single=on");
                if (_settings.Encryption.ValuesAlgorithm.Double) config.AddCommandLine("--valueencryption double=on");
                if (_settings.Encryption.ValuesAlgorithm.Array) config.AddCommandLine("--valueencryption array=on");
            }

            if (_settings.Encryption.EncryptResources)
            {
                config.AddCommandLine("--resourceencryption");
                config.AddCommandLine("--resource compress=on");
                config.AddCommandLine("--resource encrypt=on");
            }

            if (_settings.Protection.PreventILdasmDisassembly) config.AddCommandLine("--ildasm");

            if (_settings.Protection.AntiReflection) config.AddCommandLine("--reflection");

            if (_settings.Protection.GenerateDynamicProxy)
                switch (_settings.Protection.DynamicProxyTypes)
                {
                    case DynamicProxyTypes.All:
                        config.AddCommandLine("--proxy all");
                        break;
                    case DynamicProxyTypes.External:
                        config.AddCommandLine("--proxy external");
                        break;
                    case DynamicProxyTypes.Internal:
                        config.AddCommandLine("--proxy internal");
                        break;
                }

            if (_settings.Protection.AntiDebugging) config.AddCommandLine("--antidebugging");
            if (_settings.Protection.AntiTampering) config.AddCommandLine("--tamperingdetection");
            foreach (var f in _settings.CodeGeneration.ReferenceAssembly) config.AddCommandLine("--addreference " + f);
            if (_settings.CodeGeneration.Internalize) config.AddCommandLine("--internalize");
            if (_settings.CodeGeneration.CopyAttributes) config.AddCommandLine("--copyattrs");
            if (_settings.DeadCodeRemoval.RemoveDeadCode) config.AddCommandLine("--deadcode");
            if (_settings.Optimizations.SealClasses) config.AddCommandLine("--seal");
            if (_settings.Optimizations.RemoveEnumTypes) config.AddCommandLine("--enumremoval");
            if (_settings.Optimizations.CleanupAttributes) config.AddCommandLine("--cleanattrs \\[mscorlib\\]System.Runtime.CompilerServices.CompilerGeneratedAttribute --cleanattrs \\[mscorlib\\]System.Diagnostics.DebuggerDisplayAttribute --cleanattrs \\[mscorlib\\]System.Diagnostics.DebuggerBrowsableAttribute --cleanattrs \\[mscorlib\\]System.Diagnostics.DebuggerNonUserCodeAttribute --cleanattrs \\[mscorlib\\]System.Diagnostics.DebuggerHiddenAttribute --cleanattrs \\[mscorlib\\]System.Diagnostics.DebuggerStepThroughAttribute");
            if (_settings.Optimizations.DisgregatePropertiesEvents) config.AddCommandLine("--disgregateremoval");
            if (_settings.Optimizations.RemoveConstFields) config.AddCommandLine("--constremoval");
            if (_settings.Optimizations.InlineExpansion) config.AddCommandLine("--inlineexpansion");

            return config.Build();
        }
    }
}