using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle("GeniusControls")]

//
// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//   (*) If no key is specified, the assembly is not signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. KeyFile refers to a file which contains
//       a key.
//   (*) If the KeyFile and the KeyName values are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP, that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the KeyFile is installed into the CSP and used.
//   (*) In order to create a KeyFile, you can use the sn.exe (Strong Name) utility.
//       When specifying the KeyFile, the location of the KeyFile should be
//       relative to the project output directory which is
//       %Project Directory%\obj\<configuration>. For example, if your KeyFile is
//       located in the project directory, you would specify the AssemblyKeyFile 
//       attribute as [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//
[assembly: AssemblyDelaySign(false)]
[assembly: ComVisible(false)]
[assembly: Guid("231B4DCF-ADB8-4b86-8B71-BE7AC2F1EBFC")]
[assembly: NeutralResourcesLanguage("US-US")]
[assembly: CLSCompliant(false)]
[assembly: InternalsVisibleTo("Genius.Controls.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100510bb9be48d92b90f3b3adf43bd448f7c012ac7fdebf5327b99340186b59a4cc7b27fc2788b6139c8664e8702dac96e30e206c9d3ecd4f455441da8d72566bc05bffab8d11e7348cf716f5783337aa482d2e1e4513d3137f0e4290c66705e0f01534839914d2806e31660b6994d5ee6675b3882d39ae4388b953cb2fbbbc10b2")]