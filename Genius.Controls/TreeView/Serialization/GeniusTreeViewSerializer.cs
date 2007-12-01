using System;
using System.CodeDom;
using System.ComponentModel.Design.Serialization;

namespace Genius.Controls.TreeView.Serialization
{
	/// <summary>
	/// Summary description for GeniusTreeViewSerializer.
	/// </summary>
	public class GeniusTreeViewSerializer : CodeDomSerializer
	{
        /// <summary>
        /// constructeur par défaut
        /// </summary>
		public GeniusTreeViewSerializer()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
		{
			// This is how we associate the component with the serializer.
			CodeDomSerializer baseClassSerializer = (CodeDomSerializer)manager.
				GetSerializer(typeof(GeniusTreeView).BaseType, typeof(CodeDomSerializer));

			/* This is the simplest case, in which the class just calls the base class
				to do the work. */
			return baseClassSerializer.Deserialize(manager, codeObject);			
		}

		public override object Serialize(IDesignerSerializationManager manager, object value)
		{
			/* Associate the component with the serializer in the same manner as with
				Deserialize */
			CodeDomSerializer baseClassSerializer = (CodeDomSerializer)manager.
				GetSerializer(typeof(GeniusTreeView).BaseType, typeof(CodeDomSerializer));
 
			object codeObject = baseClassSerializer.Serialize(manager, value);
 
			if (codeObject is CodeStatementCollection) 
			{
				CodeStatementCollection statements = (CodeStatementCollection)codeObject;
 
				// The code statement collection is valid, so add a comment.
				string commentText = "GeniusTreeView By Pierrick Gourlain";
				CodeCommentStatement comment = new CodeCommentStatement(commentText);
				statements.Insert(0, comment);
			}
			return codeObject;			
		}
	}
}
