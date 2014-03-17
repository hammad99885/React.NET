﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace React
{
	/// <summary>
	/// Site-wide configuration for React.NET
	/// </summary>
	public class ReactSiteConfiguration : IReactSiteConfiguration
	{
		private readonly Func<string, string> _pathResolverFunc;

		/// <summary>
		/// Initializes a new instance of the <see cref="ReactSiteConfiguration"/> class.
		/// </summary>
		/// <param name="pathResolverFunc">
		/// Function used to convert site relative paths to system absolute
		/// </param>
		public ReactSiteConfiguration(Func<string, string> pathResolverFunc)
		{
			_pathResolverFunc = pathResolverFunc;
		}

		/// <summary>
		/// All the scripts that have been added to this configuration
		/// </summary>
		private readonly IList<string> _scriptFiles = new List<string>();

		/// <summary>
		/// Adds a script to the list of scripts that are executed. This should be called for all
		/// React components and their dependencies.
		/// </summary>
		/// <param name="filename">
		/// Name of the file to execute. Should be a server relative path starting with ~ (eg. 
		/// <c>~/Scripts/Awesome.js</c>)
		/// </param>
		/// <returns>This configuration, for chaining</returns>
		public IReactSiteConfiguration AddScript(string filename)
		{
			_scriptFiles.Add(_pathResolverFunc(filename));
			return this;
		}

		/// <summary>
		/// Gets a list of all the scripts that have been added to this configuration.
		/// </summary>
		public IList<string> Scripts
		{
			get { return new ReadOnlyCollection<string>(_scriptFiles); }
		} 
	}
}
