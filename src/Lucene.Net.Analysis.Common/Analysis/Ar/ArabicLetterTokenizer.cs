﻿using System;

namespace org.apache.lucene.analysis.ar
{
	/*
	 * Licensed to the Apache Software Foundation (ASF) under one or more
	 * contributor license agreements.  See the NOTICE file distributed with
	 * this work for additional information regarding copyright ownership.
	 * The ASF licenses this file to You under the Apache License, Version 2.0
	 * (the "License"); you may not use this file except in compliance with
	 * the License.  You may obtain a copy of the License at
	 *
	 *     http://www.apache.org/licenses/LICENSE-2.0
	 *
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 */

	using LetterTokenizer = org.apache.lucene.analysis.core.LetterTokenizer;
	using CharTokenizer = org.apache.lucene.analysis.util.CharTokenizer;
	using StandardTokenizer = org.apache.lucene.analysis.standard.StandardTokenizer; // javadoc @link
	using Version = org.apache.lucene.util.Version;

	/// <summary>
	/// Tokenizer that breaks text into runs of letters and diacritics.
	/// <para>
	/// The problem with the standard Letter tokenizer is that it fails on diacritics.
	/// Handling similar to this is necessary for Indic Scripts, Hebrew, Thaana, etc.
	/// </para>
	/// <para>
	/// <a name="version"/>
	/// You must specify the required <seealso cref="Version"/> compatibility when creating
	/// <seealso cref="ArabicLetterTokenizer"/>:
	/// <ul>
	/// <li>As of 3.1, <seealso cref="CharTokenizer"/> uses an int based API to normalize and
	/// detect token characters. See <seealso cref="#isTokenChar(int)"/> and
	/// <seealso cref="#normalize(int)"/> for details.</li>
	/// </ul>
	/// </para>
	/// </summary>
	/// @deprecated (3.1) Use <seealso cref="StandardTokenizer"/> instead. 
	[Obsolete("(3.1) Use <seealso cref="StandardTokenizer"/> instead.")]
	public class ArabicLetterTokenizer : LetterTokenizer
	{
	  /// <summary>
	  /// Construct a new ArabicLetterTokenizer. </summary>
	  /// <param name="matchVersion"> Lucene version
	  /// to match See <seealso cref="<a href="#version">above</a>"/>
	  /// </param>
	  /// <param name="in">
	  ///          the input to split up into tokens </param>
	  public ArabicLetterTokenizer(Version matchVersion, Reader @in) : base(matchVersion, @in)
	  {
	  }

	  /// <summary>
	  /// Construct a new ArabicLetterTokenizer using a given
	  /// <seealso cref="org.apache.lucene.util.AttributeSource.AttributeFactory"/>. * @param
	  /// matchVersion Lucene version to match See
	  /// <seealso cref="<a href="#version">above</a>"/>
	  /// </summary>
	  /// <param name="factory">
	  ///          the attribute factory to use for this Tokenizer </param>
	  /// <param name="in">
	  ///          the input to split up into tokens </param>
	  public ArabicLetterTokenizer(Version matchVersion, AttributeFactory factory, Reader @in) : base(matchVersion, factory, @in)
	  {
	  }

	  /// <summary>
	  /// Allows for Letter category or NonspacingMark category </summary>
	  /// <seealso cref= org.apache.lucene.analysis.core.LetterTokenizer#isTokenChar(int) </seealso>
	  protected internal override bool isTokenChar(int c)
	  {
		return base.isTokenChar(c) || char.getType(c) == char.NON_SPACING_MARK;
	  }

	}

}