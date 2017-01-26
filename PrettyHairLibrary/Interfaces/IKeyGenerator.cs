using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary {
	public interface IKeyGenerator {
		int NextKey {
			get;
		}

	}
}
