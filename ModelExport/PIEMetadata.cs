using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelExport
{
	/// <summary>
	/// Metadata for a PIE file
	/// Assumptions:
	/// - save and retrieve functions to suit runtime environment. JSON or SQL? another scotch? is this thing on?
	/// 
	/// Common disclaimer: This is train-of-thought nonsense, don't use this as a guide.
	/// When I understand the requirements I might start to understand the solution.
	/// </summary>
	public class PIEMetadata
	{
		public string Notes { get; set; }
		public string[] Tags { get; set; }
	}
}
