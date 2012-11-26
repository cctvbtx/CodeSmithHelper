using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeSmith.Core.Extensions;
using CodeSmith.BaseTemplates;
using CodeSmith.Engine;

using SchemaExplorer;

namespace Dev.CSmith.Common
{
    public static class Template
    {

        public static void RunTableCollectionTemplate(CodeTemplate Parent, TableSchemaCollection Tables, string Path, string Template, string Output, bool debug)
        {
            // admin datamodel
            try
            {

                PreserveRegionsMergeStrategy strategy = new PreserveRegionsMergeStrategy("^[ \t]*(?i:Custom)", "C#");
                CodeTemplate template = null;
                if (!debug)
                {
                    template = Parent.GetCodeTemplateInstance(Parent.CodeTemplateInfo.DirectoryName + Path + "\\" + Template);
                }
                else
                {
                    template = CompileTemplate(Parent, Parent.CodeTemplateInfo.DirectoryName + Path + "\\" + Template);
                }

                if (template != null)
                {
                    template.SetProperty("MultiSourceTable", Tables);
                    template.RenderToFile(Parent.CodeTemplateInfo.DirectoryName + Path + "\\" + Output, strategy);
                    Parent.Response.WriteLine("File: " + Output + " Created Successfully");
                }
                else
                {
                    Parent.Response.WriteLine("Template is null: " + Parent.CodeTemplateInfo.DirectoryName + Path + "\\" + Template);
                }
            }
            catch (Exception ex)
            {
                Parent.Response.WriteLine("Template: " + Parent.CodeTemplateInfo.DirectoryName + Path + "\\" + Template);
                Parent.Response.WriteLine("Error: " + ex.Message);
                Parent.Response.WriteLine("StackTrace: " + ex.StackTrace);
            }
        }

        public static void RunTableTemplate(CodeTemplate Parent, TableSchema SourceTable, string Path, string Template, string Output, bool debug)
        {
            // admin datamodel
            try
            {

                PreserveRegionsMergeStrategy strategy = new PreserveRegionsMergeStrategy("^[ \t]*(?i:Custom)", "C#");
                CodeTemplate template = null;
                if (!debug)
                {
                    template = Parent.GetCodeTemplateInstance(Parent.CodeTemplateInfo.DirectoryName + Path + "\\" + Template);
                }
                else
                {
                    template = CompileTemplate(Parent, Parent.CodeTemplateInfo.DirectoryName + Path + "\\" + Template);
                }

                if (template != null)
                {
                    template.SetProperty("SourceTable", SourceTable);
                    template.RenderToFile(Parent.CodeTemplateInfo.DirectoryName + Path + "\\" + Output, strategy);
                    Parent.Response.WriteLine("File: " + Output + " Created Successfully");
                }
                else
                {
                    Parent.Response.WriteLine("Template is null: " + Parent.CodeTemplateInfo.DirectoryName + Path + "\\" + Template);
                }
            }
            catch (Exception ex)
            {
                Parent.Response.WriteLine("Template: " + Parent.CodeTemplateInfo.DirectoryName + Path + "\\" + Template);
                Parent.Response.WriteLine("Error: " + ex.Message);
                Parent.Response.WriteLine("StackTrace: " + ex.StackTrace);
            }
        }

        public static CodeTemplate CompileTemplate(CodeTemplate parent, string template)
        {
            CodeTemplateCompiler compiler = new CodeTemplateCompiler(template);
            compiler.Compile();

            if (compiler.Errors.Count == 0)
            {
                return compiler.CreateInstance();
            }
            else
            {
                for (int i = 0; i < compiler.Errors.Count; i++)
                {
                    parent.Response.WriteLine(compiler.Errors[i].ToString());
                }
                return null;
            }

        }

    }
}
