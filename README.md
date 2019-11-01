# BabelWrapper
Babel Obfuscator's Command Line Helper for Enterprise and Company Plan Users

Required: Newtonsoft.Json

### Usages:

```
var settings = new Settings();
settings.InputPath = "Your File Path";
settings.OutputPath = "Final File's Output Path";
settings.EmbedFiles.Add(new InputSerialize()
{
    Path = "Your Assembly",
    Action = InputAction.Embed
});

settings.Renaming.Types = true;
settings.Renaming.Methods = true;
settings.Renaming.Properties = true;
settings.Renaming.Fields = true;
settings.Renaming.Events = true;
settings.Renaming.Virtual = true;
settings.Renaming.Overloaded = true;
settings.Renaming.NameLength = 8;
settings.Renaming.FlattenNamespaces = true;
settings.ControlFlow.ObfuscateControlFlow = true;
settings.ControlFlow.Algorithm.Goto = true;
settings.ControlFlow.Algorithm.Switch = true;
settings.ControlFlow.Algorithm.Case = true;
settings.ControlFlow.Algorithm.If = true;
settings.ControlFlow.Algorithm.Call = true;
settings.ControlFlow.Algorithm.Value = true;
settings.ControlFlow.Algorithm.Token = true;
settings.ControlFlow.Algorithm.Underflow = true;
settings.ControlFlow.Iterations = 5;
settings.Encryption.EncryptStrings = true;
settings.Encryption.StringAlgorithm = StringAlgorithm.Hash;
settings.Encryption.EncryptValues = true;
settings.Encryption.ValuesAlgorithm.Int32 = true;
settings.Encryption.ValuesAlgorithm.Int64 = true;
settings.Encryption.ValuesAlgorithm.Single = true;
settings.Encryption.ValuesAlgorithm.Double = true;
settings.Encryption.ValuesAlgorithm.Array = true;
settings.Encryption.EncryptResources = true;
settings.Protection.PreventILdasmDisassembly = true;
settings.Protection.AntiReflection = true;
settings.Protection.GenerateDynamicProxy = true;
settings.Protection.DynamicProxyTypes = DynamicProxyTypes.All;
settings.Protection.AntiDebugging = true;
settings.Protection.AntiTampering = true;
settings.CodeGeneration.Internalize = true;
settings.CodeGeneration.CopyAttributes = true;
settings.DeadCodeRemoval.RemoveDeadCode = true;
settings.Optimizations.SealClasses = true;
settings.Optimizations.RemoveEnumTypes = true;
settings.Optimizations.CleanupAttributes = true;
settings.Optimizations.DisgregatePropertiesEvents = true;
settings.Optimizations.RemoveConstFields = true;
settings.Optimizations.InlineExpansion = true;
var wrapper = new Wrapper(settings);
            
wrapper.CommandArgsBuild(); // Command Args String
wrapper.JsonBuild(); // JSON Saveable String
```
