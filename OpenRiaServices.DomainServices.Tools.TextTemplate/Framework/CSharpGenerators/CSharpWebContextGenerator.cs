﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 12.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace OpenRiaServices.DomainServices.Tools.TextTemplate.CSharpGenerators
{
    using OpenRiaServices.DomainServices;
    using OpenRiaServices.DomainServices.Server;
    using OpenRiaServices.DomainServices.Server.ApplicationServices;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class CSharpWebContextGenerator : OpenRiaServices.DomainServices.Tools.TextTemplate.WebContextGenerator
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n");
            this.Write("\r\n");
            this.Write("\r\n\r\n");
 this.Generate(); 
            this.Write("\r\n");
            return this.GenerationEnvironment.ToString();
        }
 
	private void GenerateNamespace()
	{
		string ns = this.ClientCodeGenerator.Options.ClientRootNamespace;

this.Write("namespace ");

this.Write(this.ToStringHelper.ToStringWithCulture(ns));

this.Write("\r\n");


	}
	
	/// <summary>
	/// Generates the class declaration for the WebContext class.
	/// </summary>
	protected virtual void GenerateClassDeclaration()
	{

this.Write("public sealed partial class WebContext : OpenRiaServices.DomainServices.Client.Ap" +
        "plicationServices.WebContextBase\r\n");


	}
	
	private void GenerateConstructor()
	{

this.Write("public WebContext()\r\n{\t\t\t\r\n\tthis.OnCreated();\r\n}\r\n");


	}
	
	/// <summary>
	/// Generates extensibility methods on the web context class.
	/// </summary>
	protected virtual void GenerateExtensibilityMethods()
	{

this.Write("partial void OnCreated();\r\n");


	}
	
	/// <summary>
	/// Generates the properties on the WebContext class.
	/// </summary>
	protected virtual void GenerateProperties()
	{

this.Write("public new static WebContext Current\r\n{\r\n    get\r\n    {\r\n        return ((WebCont" +
        "ext)(OpenRiaServices.DomainServices.Client.ApplicationServices.WebContextBase.Cu" +
        "rrent));\r\n    }\r\n}\r\n");


		
		DomainServiceDescription defaultAuthDescription = this.GetDefaultAuthDescription();
		if(defaultAuthDescription != null)
		{
			Type genericType = null;
            typeof(IAuthentication<>).DefinitionIsAssignableFrom(defaultAuthDescription.DomainServiceType, out genericType);
            if ((genericType != null) && (genericType.GetGenericArguments().Count() == 1))
            {
				string typeName = CodeGenUtilities.GetTypeName(genericType.GetGenericArguments()[0]);

this.Write("public new ");

this.Write(this.ToStringHelper.ToStringWithCulture(typeName));

this.Write(" User\r\n{\r\n\tget { return (");

this.Write(this.ToStringHelper.ToStringWithCulture(typeName));

this.Write(")base.User; }\r\n}\r\n");


			}
		}
	}



private void GenerateParameterDeclaration(IEnumerable<DomainOperationParameter> parameters, bool generateAttributes)
{
	DomainOperationParameter[] paramInfos = parameters.ToArray();
	for(int i = 0; i < paramInfos.Length; i++)
	{
		DomainOperationParameter paramInfo = paramInfos[i];
		if(generateAttributes)
		{
			IEnumerable<Attribute> paramAttributes = paramInfo.Attributes.Cast<Attribute>();
			this.GenerateAttributes(paramAttributes);
		}
		string paramTypeName = CodeGenUtilities.GetTypeName(CodeGenUtilities.TranslateType(paramInfo.ParameterType));
		string paramName = CodeGenUtilities.GetSafeName(paramInfo.Name);
		
this.Write(this.ToStringHelper.ToStringWithCulture(paramTypeName));

this.Write(" ");

this.Write(this.ToStringHelper.ToStringWithCulture(paramName));


		if(i + 1 < paramInfos.Length)
		{
			
this.Write(", ");


		}
	}
}

private void GenerateOpeningBrace()
{

this.Write("{\r\n");


	PushIndent("\t");
}

private void GenerateClosingBrace()
{
	PopIndent();

this.Write("}\r\n");


}

private void GenerateNamespace(string ns)
{

this.Write("namespace ");

this.Write(this.ToStringHelper.ToStringWithCulture(ns));

this.Write("\r\n");


}



	/// <summary>
	/// Generates attribute declarations in C#.
	/// </summary>
	/// <param name="attributes">The list of attributes to be generated.</param>
	protected virtual void GenerateAttributes(IEnumerable<Attribute> attributes)
	{	
		this.GenerateAttributes(attributes, false);
	}
	
	/// <summary>
	/// Generates attribute declarations in C#.
	/// </summary>
	/// <param name="attributes">The attributes to be generated.</param>
	/// <param name="forcePropagation">Causes the attributes to be generated even if the attribute verification fails.</param>
	protected virtual void GenerateAttributes(IEnumerable<Attribute> attributes, bool forcePropagation)
	{
		foreach (Attribute attribute in attributes.OrderBy(a => a.GetType().Name))
        {
			AttributeDeclaration attributeDeclaration = AttributeGeneratorHelper.GetAttributeDeclaration(attribute, this.ClientCodeGenerator, forcePropagation);
            if (attributeDeclaration == null || attributeDeclaration.HasErrors)
			{
				continue;
			}
			
			string attributeTypeName = CodeGenUtilities.GetTypeName(attributeDeclaration.AttributeType);

this.Write("[");

this.Write(this.ToStringHelper.ToStringWithCulture(attributeTypeName));

this.Write("(");


			if (attributeDeclaration.ConstructorArguments.Count > 0)
            {
				for (int i = 0; i < attributeDeclaration.ConstructorArguments.Count; i++)
            	{
                	object value = attributeDeclaration.ConstructorArguments[i];
					string stringValue = AttributeGeneratorHelper.ConvertValueToCode(value, true);
					
this.Write(this.ToStringHelper.ToStringWithCulture(stringValue));


					if (i + 1 < attributeDeclaration.ConstructorArguments.Count)
					{
					
this.Write(", ");


					}
	            }
			}
			if (attributeDeclaration.NamedParameters.Count > 0)
            {
				if (attributeDeclaration.ConstructorArguments.Count > 0)
            	{
					
this.Write(", ");


				}
				
				for (int i = 0; i < attributeDeclaration.NamedParameters.Count; i++)
                {
                    KeyValuePair<string, object> pair = attributeDeclaration.NamedParameters.ElementAt(i);
                    string stringValue = AttributeGeneratorHelper.ConvertValueToCode(pair.Value, true);
					
this.Write(this.ToStringHelper.ToStringWithCulture(pair.Key));

this.Write("=");

this.Write(this.ToStringHelper.ToStringWithCulture(stringValue));


                    if (i + 1 < attributeDeclaration.NamedParameters.Count)
                    {
					
this.Write(",");


                    }
                }
			}

this.Write(")]\r\n");


		}
	}
	
	private void GenerateDataContractAttribute(Type sourceType)
	{
		string dataContractNamespace, dataContractName;
		AttributeGeneratorHelper.GetContractNameAndNamespace(sourceType, out dataContractNamespace, out dataContractName);

this.Write("[System.Runtime.Serialization.DataContract(Namespace = \"");

this.Write(this.ToStringHelper.ToStringWithCulture(dataContractNamespace));

this.Write("\"");

  
		if(!string.IsNullOrEmpty(dataContractName))
		{
		
this.Write(", Name = \" ");

this.Write(this.ToStringHelper.ToStringWithCulture(dataContractName));

this.Write("\"");


		}

this.Write(")]\r\n");


	}	

    }
}
