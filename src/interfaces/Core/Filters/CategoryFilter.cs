// ***********************************************************************
// Copyright (c) 2007 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using System.Text;
using System.Collections;

namespace NUnit.Core.Filters
{
	/// <summary>
	/// CategoryFilter is able to select or exclude tests
	/// based on their categories.
	/// </summary>
	/// 
	[Serializable]
	public class CategoryFilter : TestFilter
	{
		ArrayList categories;

		/// <summary>
		/// Construct an empty CategoryFilter
		/// </summary>
		public CategoryFilter()
		{
			categories = new ArrayList();
		}

		/// <summary>
		/// Construct a CategoryFilter using a single category name
		/// </summary>
		/// <param name="name">A category name</param>
		public CategoryFilter( string name )
		{
			categories = new ArrayList();
			if ( name != null && name != string.Empty )
				categories.Add( name );
		}

		/// <summary>
		/// Construct a CategoryFilter using an array of category names
		/// </summary>
		/// <param name="names">An array of category names</param>
		public CategoryFilter( string[] names )
		{
			categories = new ArrayList();
			if ( names != null )
				categories.AddRange( names );
		}

		/// <summary>
		/// Add a category name to the filter
		/// </summary>
		/// <param name="name">A category name</param>
		public void AddCategory(string name) 
		{
			categories.Add( name );
		}

		/// <summary>
		/// Check whether the filter matches a test
		/// </summary>
		/// <param name="test">The test to be matched</param>
		/// <returns></returns>
        public override bool Match(ITest test)
        {
			if ( test.Categories == null )
				return false;

			foreach( string cat in categories )
				if ( test.Categories.Contains( cat ) )
					return true;

			return false;
        }
		
		/// <summary>
		/// Return the string representation of a category filter
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for( int i = 0; i < categories.Count; i++ )
			{
				if ( i > 0 ) sb.Append( ',' );
				sb.Append( categories[i] );
			}
			return sb.ToString();
		}

		/// <summary>
		/// Gets the list of categories from this filter
		/// </summary>
		public IList Categories
		{
			get { return categories; }
		}
	}
}
