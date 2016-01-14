using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Markup;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("WPFConverters")]
[assembly: AssemblyDescription("WPF Converters")]
[assembly: AssemblyCompany("Cameron MacFarland")]
[assembly: AssemblyProduct("WPFConverters")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("c3f74dac-8892-417c-9d19-7a169d5d8b72")]

// XAML Bits
[assembly: XmlnsDefinition("http://schemas.macfar.land/wpfconverters", nameof(WPFConverters))]
[assembly: XmlnsPrefix("http://schemas.macfar.land/wpfconverters", "con")]