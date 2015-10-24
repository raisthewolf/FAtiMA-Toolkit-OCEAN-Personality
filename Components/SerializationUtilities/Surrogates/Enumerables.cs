﻿using GAIPS.Serialization.SerializationGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAIPS.Serialization.Surrogates
{
	public sealed class EnumerableSerializationSurrogate : ISerializationSurrogate
	{
		public void GetObjectData(object obj, ObjectGraphNode holder, Graph graph)
		{
			IEnumerable e = obj as IEnumerable;
			Type elemType = typeof(object);
			Type objType = e.GetType();

			if (objType.IsGenericType)
				elemType = objType.GetGenericArguments()[0];

			SequenceGraphNode array = new SequenceGraphNode();
			holder["elements"] = array;
			IEnumerator it = e.GetEnumerator();
			while (it.MoveNext())
			{
				GraphNode node = SerializationServices.BuildNode(it.Current, elemType, holder, graph);
				array.Add(node);
			}
		}

		public void SetObjectData(ref object obj, ObjectGraphNode node, Graph graph)
		{
			throw new NotImplementedException();
		}
	}
}
