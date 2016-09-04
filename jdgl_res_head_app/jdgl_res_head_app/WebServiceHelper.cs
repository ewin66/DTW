using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Net;
using System.IO;
using System.Web.Services.Description;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using Maticsoft.Common;

namespace jdgl_res_head_app
{
    /// <summary>
    /// ��̬����WebService ����ط���
    /// </summary>
    public sealed class DynamicWebServiceCall
    {
        /// <summary>
        /// ��̬����WebService �ķ���
        /// </summary>
        /// <param name="pcUrl">WebService �ķ���·�� http://localhost:8080/WebServiceTest.asmx </param>
        /// <param name="pcClassName">Ҫ���õ�����</param>
        /// <param name="pcMethodName">������</param>
        /// <param name="args">��������</param>
        /// <returns></returns>
        public static object InvokeWebService(string pcUrl, string pcMethodName, object[] args)
        {
           

            return InvokeWebService(pcUrl, "", pcMethodName, args);

        }
        /// <summary>
        /// ��̬����WebService �ķ���
        /// </summary>
        /// <param name="pcUrl">WebService �ķ���·�� http://localhost:8080/  �� http://localhost:8080/WebServiceTest.asmx </param>
        /// <param name="pcClassName">Ҫ���õ���������Url���Ѿ�������������ʱ����������Ϊ����</param>
        /// <param name="pcMethodName">������</param>
        /// <param name="args">��������</param>
        /// <returns></returns>
        /// 




        public static object InvokeWebService(string pcUrl, string pcClassName, string pcMethodName, object[] args)
        {
            object loRetVal = null;

            try
            {
                if (!string.IsNullOrEmpty(pcClassName))
                {
                    pcUrl += pcClassName;
                }
                else
                {
                    pcClassName = GetWsClassName(pcUrl);
                }

                Assembly loAssemble = CreateDynWebServiceAssemble(pcUrl);
                if (loAssemble != null)
                {
                    string lcNameSpace = "Sonic.Web.WebService.DynamicWebService";
                    Type t = loAssemble.GetType(lcNameSpace + "." + pcClassName, true, true);
                    object obj = Activator.CreateInstance(t);
                    MethodInfo loMethodInfo = t.GetMethod(pcMethodName);
            
                    if (loMethodInfo != null)
                        loRetVal = loMethodInfo.Invoke(obj, args);
                }
            }
            catch (Exception e)
            {
               
                common_file.Common.WriteLog(e.Message.ToString(),"webservice���ص���ʱ����");

                loRetVal = null;
             }
            return loRetVal;
        }

        /// <summary>
        /// ��̬����WebService��Assembly
        /// </summary>
        /// <param name="pcUrl">WebService �ķ���·�� �� http://localhost:8080/WebServiceTest.asmx</param>
        /// <returns></returns>
        public static Assembly CreateDynWebServiceAssemble(string pcUrl)
        {
            Assembly loRetVal = null;
            string lcNameSpace = "Sonic.Web.WebService.DynamicWebService";
            try
            {
                //��ȡWSDL
                WebClient loWC = new WebClient();
                Stream stream = loWC.OpenRead(pcUrl + "?WSDL");

                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(lcNameSpace);

                //���ɿͻ��˴��������
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CSharpCodeProvider csc = new CSharpCodeProvider();
                ICodeCompiler icc =csc.CreateCompiler();

                //�趨�������
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");

                //���������
                CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }

                //���ɴ���ʵ���������÷���
                loRetVal = cr.CompiledAssembly;
            }
            catch (Exception e)
            {
                loRetVal = null;
                throw e;
            }

            return loRetVal;
        }

        private static string GetWsClassName(string wsUrl)
        {
            string[] parts = wsUrl.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');

            return pps[0];
        }
        //protected override WebRequest GetWebRequest(Uri uri)
        //{
        //    HttpWebRequest wr = (HttpWebRequest)base.GetWebRequest(uri);
        //    wr.Timeout = 300 * 1000;
        //    return wr;
        //}
    }
}
