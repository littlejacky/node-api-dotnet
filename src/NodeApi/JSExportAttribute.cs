using System;

namespace Microsoft.JavaScript.NodeApi;

/// <summary>
/// Exports an item to JavaScript, optionally specifying the name of the export and whether
/// it is the default export of the module.
/// </summary>
/// <remarks>
/// A public static class tagged with <see cref="JSExportAttribute"/> is exported as a JavaScript
/// object, with public members of the static class automatically exported as properties on the
/// object.
/// <para/>
/// A public non-static class or struct tagged with <see cref="JSExportAttribute"/> is exported as
/// a JavaScript class, with public static members automatically exported as properties of the
/// class constructor object, and public instance members automatically exported as properties of
/// the class. .NET classes are passed by reference, such that a JavaScript instance of the class
/// is always backed by a .NET instance; structs are passed by value.
/// <para/>
/// A public static property tagged with <see cref="JSExportAttribute"/> is exported as a JavaScript
/// property on the module object.
/// <para/>
/// A public static method tagged with <see cref="JSExportAttribute"/> is exported as a JavaScript
/// function property on the module object.
/// <para/>
/// A public enum, interface, or delegate tagged with <see cref="JSExportAttribute"/> is exported
/// as part of the type definitions of the module but does not have any runtime representation in
/// the JavaScript exports.
/// <para/>
/// (This attribute may not be applied to non-static properties or methods, any fields, or any
/// non-public items.)
/// </remarks>
[AttributeUsage(
    AttributeTargets.Class |
    AttributeTargets.Struct |
    AttributeTargets.Property |
    AttributeTargets.Method |
    AttributeTargets.Enum |
    AttributeTargets.Interface |
    AttributeTargets.Delegate
)]
public class JSExportAttribute : Attribute
{
    /// <summary>
    /// Exports an item as a property of the module exports object, with the JavaScript property
    /// name auto-generated by camel-casing the .NET name.
    /// </summary>
    public JSExportAttribute()
    {
    }

    /// <summary>
    /// Exports an item as a property of the module exports object, with an explicit JavaScript
    /// property name.
    /// </summary>
    /// <param name="name">Name of the item as exported to JavaScript.</param>
    public JSExportAttribute(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
    }

    /// <summary>
    /// Gets the name of item as exported to JavaScript, or null if the JavaScript name is
    /// auto-generated by camel-casing the .NET name.
    /// </summary>
    /// <remarks>
    /// Names must be unique among a module's exports. Duplicates will result in a build error.
    /// <para/>
    /// Use the name "default" to create a default export.
    /// </remarks>
    public string? Name { get; }
}