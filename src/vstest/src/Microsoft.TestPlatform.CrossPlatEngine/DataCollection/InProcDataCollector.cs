﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.DataCollection
{
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
    using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.DataCollection.Interfaces;
    using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

#if !NET46
    using System.Runtime.Loader;
#endif

    /// <summary>
    /// Class representing an InProcDataCollector loaded by InProcDataCollectionExtensionManager
    /// </summary>
    internal class InProcDataCollector : IInProcDataCollector
    {
        /// <summary>
        /// DataCollector Class Type
        /// </summary>
        private Type dataCollectorType;

        /// <summary>
        /// Instance of the 
        /// </summary>
        private object dataCollectorObject;

        /// <summary>
        /// Config XML from the runsettings for current datacollector
        /// </summary>
        private string configXml;

        public InProcDataCollector(string codeBase, string assemblyQualifiedName, TypeInfo interfaceTypeInfo, string configXml)
        {
            this.configXml = configXml;

            var assembly = this.LoadInProcDataCollectorExtension(codeBase);
            this.dataCollectorType =
                assembly?.GetTypes()
                    .FirstOrDefault(x => (x.AssemblyQualifiedName.Equals(assemblyQualifiedName) && interfaceTypeInfo.IsAssignableFrom(x)));

            this.AssemblyQualifiedName = (dataCollectorType?.AssemblyQualifiedName);
        }

        /// <summary>
        /// AssemblyQualifiedName of the datacollector type
        /// </summary>
        public string AssemblyQualifiedName { get; private set; }

        /// <summary>
        /// Loads the DataCollector type 
        /// </summary>
        /// <param name="inProcDataCollectionSink">Sink object to send data</param>
        public void LoadDataCollector(IDataCollectionSink inProcDataCollectionSink)
        {
            this.dataCollectorObject = CreateObjectFromType(dataCollectorType);
            InitializeDataCollector(dataCollectorObject, inProcDataCollectionSink);
        }

        /// <summary>
        /// Triggers InProcDataCollection Methods
        /// </summary>
        /// <param name="methodName">Name of the method to trigger</param>
        /// <param name="methodArg">Arguments for the method</param>
        public void TriggerInProcDataCollectionMethod(string methodName, InProcDataCollectionArgs methodArg)
        {
            var methodInfo = GetMethodInfoFromType(this.dataCollectorObject.GetType(), methodName, new[] { methodArg.GetType() });

            if (methodName.Equals(Constants.TestSessionStartMethodName))
            {
                var testSessionStartArgs = (TestSessionStartArgs)methodArg;
                testSessionStartArgs.Configuration = configXml;
                methodInfo?.Invoke(this.dataCollectorObject, new object[] { testSessionStartArgs });
            }
            else
            {
                methodInfo?.Invoke(this.dataCollectorObject, new object[] { methodArg });
            }
        }

        #region Private Methods

        private void InitializeDataCollector(object obj, IDataCollectionSink inProcDataCollectionSink)
        {
            var initializeMethodInfo = GetMethodInfoFromType(obj.GetType(), "Initialize", new Type[] { typeof(IDataCollectionSink) });
            initializeMethodInfo.Invoke(obj, new object[] { inProcDataCollectionSink });
        }

        private static MethodInfo GetMethodInfoFromType(Type type, string funcName, Type[] argumentTypes)
        {
            MethodInfo methodInfo = null;

            var typeInfo = type.GetTypeInfo();
            methodInfo = typeInfo?.GetMethod(funcName, argumentTypes);
            return methodInfo;
        }

        private static object CreateObjectFromType(Type type)
        {
            object obj = null;

            var typeInfo = type.GetTypeInfo();
            var constructorInfo = typeInfo?.GetConstructor(Type.EmptyTypes);
            obj = constructorInfo?.Invoke(new object[] { });

            return obj;
        }

        /// <summary>
        /// Loads the assembly into the default context based on the codebase path
        /// </summary>
        /// <param name="codeBase"></param>
        /// <returns></returns>
        private Assembly LoadInProcDataCollectorExtension(string codeBase)
        {
            Assembly assembly = null;
            try
            {
#if NET46
                assembly = Assembly.LoadFrom(codeBase);
#else
                assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(codeBase);
#endif

            }
            catch (Exception ex)
            {
                EqtTrace.Error(
                    "InProcDataCollectionExtensionManager: Error occured while loading the InProcDataCollector : {0} , Exception Details : {1}", codeBase, ex);
            }

            return assembly;
        }

        #endregion
    }
}
