﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó mediante una herramienta.
//     Los cambios del archivo se perderán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TrieNode : ITrieNode
{
	private TrieNode* _parent
	{
		get;
		set;
	}

	private *TrieNode[] _children
	{
		get;
		set;
	}

	public virtual TrieNode TrieNode
	{
		get;
		set;
	}

	public virtual int asign(object char c, object TrieNode* node)
	{
		throw new System.NotImplementedException();
	}

	public virtual TrieNode* value(object char c)
	{
		throw new System.NotImplementedException();
	}

	public virtual int terminate()
	{
		throw new System.NotImplementedException();
	}

}

