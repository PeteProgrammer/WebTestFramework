﻿namespace WebTestFramework
{
	/// <summary>
	/// Interface for creating a controls for various locator strategies
	/// </summary>
	public interface ICreateControl<out T>
	{
		/// <summary>
		/// Creates an instance of <typeparamref name="T"/> for representing a
		/// specific element with a specific ID on the web page.
		/// </summary>
		/// <param name="id">
		/// The ID of the element to control
		/// </param>		
		T FromID(string id);

		/// <summary>
		/// Creates an instance of <typeparamref name="T"/> for representing a
		/// specific element with a specific name attribute
		/// </summary>
		/// <param name="name">
		/// The name attribute of the element
		/// </param>
		T FromName(string name);

		/// <summary>
		/// Creates an instance of <typeparamref name="T"/> for representing a
		/// specific element with a specific xpath attribute
		/// </summary>
		/// <param name="xpath">
		/// The xpath to search for the specific element
		/// </param>
		T FromXPath(string xpath);
	}
}