using System.Collections.Generic;
using Newtonsoft.Json;

namespace KeyCipher.BabelWrapper.BabelObfuscator
{
    internal class Settings
    {
        [JsonProperty("input-path")]
        internal string InputPath { get; set; }

        [JsonProperty("embed-files")]
        internal List<InputSerialize> EmbedFiles { get; set; } = new List<InputSerialize>();

        [JsonProperty("output-path")]
        internal string OutputPath { get; set; }

        [JsonProperty("renaming")]
        internal Renaming Renaming { get; set; } = new Renaming();

        [JsonProperty("control-flow")]
        internal ControlFlow ControlFlow { get; set; } = new ControlFlow();

        [JsonProperty("encryption")]
        internal Encryption Encryption { get; set; } = new Encryption();

        [JsonProperty("protection")]
        internal Protection Protection { get; set; } = new Protection();

        [JsonProperty("code-generation")]
        internal CodeGeneration CodeGeneration { get; set; } = new CodeGeneration();

        [JsonProperty("deadcode-removal")]
        internal DeadCodeRemoval DeadCodeRemoval { get; set; } = new DeadCodeRemoval();

        [JsonProperty("optimizations")]
        internal Optimizations Optimizations { get; set; } = new Optimizations();
    }

    internal class Renaming
    {
        [JsonProperty("types")]
        internal bool Types { get; set; }

        [JsonProperty("methods")]
        internal bool Methods { get; set; }

        [JsonProperty("properties")]
        internal bool Properties { get; set; }

        [JsonProperty("fields")]
        internal bool Fields { get; set; }

        [JsonProperty("events")]
        internal bool Events { get; set; }

        [JsonProperty("virtual")]
        internal bool Virtual { get; set; }

        [JsonProperty("overloaded")]
        internal bool Overloaded { get; set; }

        [JsonProperty("xaml")]
        internal bool XAML { get; set; }

        [JsonProperty("namelength")]
        internal int NameLength { get; set; }

        [JsonProperty("flatten")]
        internal bool FlattenNamespaces { get; set; }

        [JsonProperty("flatten-value")]
        internal string FlattenNamespacesValue { get; set; }
    }

    internal class ControlFlow
    {
        [JsonProperty("obfuscate-control-flow")]
        internal bool ObfuscateControlFlow { get; set; }

        [JsonProperty("algorithm")]
        internal ControlFlowAlgorithm Algorithm { get; set; } = new ControlFlowAlgorithm();

        [JsonProperty("invalid-opcodes")]
        internal bool EmitInvalidOpcodes { get; set; } //32-bit only

        [JsonProperty("iterations")]
        internal int Iterations { get; set; }
    }

    internal class Encryption
    {
        [JsonProperty("encrypt-strings")]
        internal bool EncryptStrings { get; set; }

        [JsonProperty("string-algorithm")]
        internal StringAlgorithm StringAlgorithm { get; set; }

        [JsonProperty("encrypt-values")]
        internal bool EncryptValues { get; set; }

        [JsonProperty("values-algorithm")]
        internal ValuesAlgorithm ValuesAlgorithm { get; set; } = new ValuesAlgorithm();

        [JsonProperty("encrypt-resources")]
        internal bool EncryptResources { get; set; }
    }

    internal class Protection
    {
        [JsonProperty("ildasm")]
        internal bool PreventILdasmDisassembly { get; set; }

        [JsonProperty("anti-reflection")]
        internal bool AntiReflection { get; set; }

        [JsonProperty("dynamic-proxy")]
        internal bool GenerateDynamicProxy { get; set; }

        [JsonProperty("dynamic-proxy-types")]
        internal DynamicProxyTypes DynamicProxyTypes { get; set; }

        [JsonProperty("anti-debugging")]
        internal bool AntiDebugging { get; set; }

        [JsonProperty("anti-tampering")]
        internal bool AntiTampering { get; set; }
    }

    internal class CodeGeneration
    {
        [JsonProperty("ref-assembly")]
        internal List<string> ReferenceAssembly { get; set; } = new List<string>();

        [JsonProperty("internalize")]
        internal bool Internalize { get; set; }

        [JsonProperty("copy-attributes")]
        internal bool CopyAttributes { get; set; }
    }

    internal class DeadCodeRemoval
    {
        [JsonProperty("remove-dead-code")]
        internal bool RemoveDeadCode { get; set; }
    }

    internal class Optimizations
    {
        [JsonProperty("seal")]
        internal bool SealClasses { get; set; }

        [JsonProperty("remove-enum")]
        internal bool RemoveEnumTypes { get; set; }

        [JsonProperty("cleanattrs")]
        internal bool CleanupAttributes { get; set; }

        [JsonProperty("disgregate-properties-events")]
        internal bool DisgregatePropertiesEvents { get; set; }

        [JsonProperty("remove-const")]
        internal bool RemoveConstFields { get; set; }

        [JsonProperty("inline")]
        internal bool InlineExpansion { get; set; }
    }

    internal enum StringAlgorithm
    {
        Xor,
        Hash
    }

    internal enum DynamicProxyTypes
    {
        External,
        Internal,
        All
    }

    internal class ValuesAlgorithm
    {
        [JsonProperty("int32")]
        internal bool Int32 { get; set; }

        [JsonProperty("int64")]
        internal bool Int64 { get; set; }

        [JsonProperty("single")]
        internal bool Single { get; set; }

        [JsonProperty("double")]
        internal bool Double { get; set; }

        [JsonProperty("array")]
        internal bool Array { get; set; }
    }

    internal class ControlFlowAlgorithm
    {
        [JsonProperty("goto")]
        internal bool Goto { get; set; }

        [JsonProperty("switch")]
        internal bool Switch { get; set; }

        [JsonProperty("case")]
        internal bool Case { get; set; }

        [JsonProperty("if")]
        internal bool If { get; set; }

        [JsonProperty("call")]
        internal bool Call { get; set; }

        [JsonProperty("value")]
        internal bool Value { get; set; }

        [JsonProperty("token")]
        internal bool Token { get; set; }

        [JsonProperty("underflow")]
        internal bool Underflow { get; set; }
    }

    internal class InputSerialize
    {
        [JsonProperty("path")]
        internal string Path { get; set; }

        [JsonProperty("action")]
        internal InputAction Action { get; set; }
    }

    internal enum InputAction
    {
        Merge,
        Embed
    }
}